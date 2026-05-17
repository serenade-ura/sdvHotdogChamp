using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Buffs;
using Color = Microsoft.Xna.Framework.Color;
using healList; // Contains the Edibles class. I don't know if this is the "right" way to do it but its the only way that would work... But I think I just fucked up the first time.


namespace sdvHotdogChamp
{
	 /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {      
			
		// objects apparently?
		public static Texture2D hungyMeter;
		public static Texture2D hungyMeterFiller;
		public static Texture2D thorstMeter;
		public static Texture2D thorstMeterFiller;
		public Edibles healValues = new Edibles(); // Make an object of the class here so we can use it later.
		public hungySave readingRainbow { get; set; }
		
		public static string ToolUsedName;
		public static char ToolCategory;
		public static string QualifiedTool;
		public static bool AlreadyUsingTool;
		public static bool AlreadyEating;
		public static bool hungerPenaltyFlag = false;
		public static bool thirstPenaltyFlag = false;
		public static bool starvingFlag = false;
		public static bool parchedFlag = false;
		public static bool stuffedFlag = false;
		public static bool moistenedFlag = false;
		public static int fishTicked = 0;
		
		
		// Variables used in the Bars code.
		// Theoretically this should be all it ever needs?
		public static float currentThirst = 100; // Initializing the hunger and thirst values as 100 because drawing the bar will be a lot easier if I'm dividing by 100 rather than dividing by 0.
		public static float currentHunger = 100; // So rather than "hunger" and "thirst" its more like fullness and uh... quenched I guess.
		public static float maxHunger = 100; // Maximum reachable thirst and hunger. If current == these, you're maxed out.
		public static float maxThirst = 100; // Since the maximum is 100, maybe I would never be trying to divide by 0 but idgaf
		public static float minHunger = 0;
		public static float minThirst = 0;
		public static Color hungerColor = new Color(1, .7f, 0); // Honestly no clue what these colors are but its what survivalistic used.
        public static Color thirstColor = new Color(0,.7f, 1);
        public Buff thorsty;
        public Buff hungy;
        public Buff parched;
        public Buff starved;
        public Buff moistened;
        public Buff stuffed;
        
        
        public override void Entry(IModHelper helper)
        {
                       
			//hungyMeterFiller = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);   
			//thorstMeterFiller = new Texture2D(Game1.graphics.GraphicsDevice, 1, 1);     
			hungyMeterFiller = helper.ModContent.Load<Texture2D>("assets/hungyFiller.png");
			thorstMeterFiller = helper.ModContent.Load<Texture2D>("assets/thorstFiller.png");
			hungyMeter = helper.ModContent.Load<Texture2D>("assets/hungy.png");
			hungyMeter.Name = "hungyMeter";
			thorstMeter = helper.ModContent.Load<Texture2D>("assets/thorst.png");
			thorstMeter.Name = "thorstMeter";
			
			
			
			// Handle save functions
			
			helper.Events.GameLoop.SaveLoaded += this.CheckSave;
			helper.Events.GameLoop.Saving += this.WriteSave;
			
			// Event Handler for the Rednered Event, calling "DrawBars" function.			
			helper.Events.Display.RenderingHud += this.DrawBars;
			helper.Events.GameLoop.TimeChanged += this.ProcessHunger;
			helper.Events.GameLoop.TimeChanged += this.FishingFucker;
			helper.Events.GameLoop.TimeChanged += this.StuffedBuff;
			helper.Events.GameLoop.DayEnding += this.TheNightBugs;
			helper.Events.GameLoop.UpdateTicked += this.CheckToolUse;
			helper.Events.GameLoop.UpdateTicked += this.CheckEatedGoods;
			helper.Events.GameLoop.UpdateTicked += this.HungerPenalty;
			helper.Events.GameLoop.UpdateTicked += this.ThirstPenalty;
			helper.Events.GameLoop.UpdateTicked += this.HungerThirstZeroer;
			
			thorsty = new Buff(
			id: "sdvHotdogChamp_thirsty",
			displayName: "Thorsty",
			iconTexture: this.Helper.ModContent.Load<Texture2D>("assets/thirstyDebuff.png"),
			iconSheetIndex: 0,
			duration: Buff.ENDLESS
	
			);
			parched = new Buff(
			id: "anything",
			displayName: "Parched",
			iconTexture: this.Helper.ModContent.Load<Texture2D>("assets/parchedDebuff.png"),
			iconSheetIndex: 0,
			duration: Buff.ENDLESS

			);
			hungy = new Buff(
			id: "sdvHotdogChamp_hungy",
			displayName: "Hungy",
			iconTexture: this.Helper.ModContent.Load<Texture2D>("assets/hungyDebuff.png"),
			iconSheetIndex: 0,
			duration: Buff.ENDLESS
			);
			starved = new Buff(
			id: "sdvHotdogChamp_starved",
			displayName: "Starved",
			iconTexture: this.Helper.ModContent.Load<Texture2D>("assets/starvedDebuff.png"),
			iconSheetIndex: 0,
			duration: Buff.ENDLESS
			);
			stuffed = new Buff(
			id: "sdvHotdogChamp_stuffed",
			displayName: "Stuffed",
			iconTexture: this.Helper.ModContent.Load<Texture2D>("assets/starvedDebuff.png"),
			iconSheetIndex: 0,
			duration: Buff.ENDLESS
			);
			moistened = new Buff(
			id: "sdvHotdogChamp_moistened",
			displayName: "Moistened",
			iconTexture: this.Helper.ModContent.Load<Texture2D>("assets/starvedDebuff.png"),
			iconSheetIndex: 0,
			duration: Buff.ENDLESS,
			effects: new BuffEffects()
			{
				Speed = { 1 }
			}
			
			);
          
		}
        
		
		// Functions can be called via event handlers
		// The params are always "object? sender," and then "xEventArgs e" where x=The Event name... At least, it seems that way. Just coming up with a name doesn't work.
		#nullable enable
		public void DrawBars(object? sender, RenderingHudEventArgs e)
		{
			if (!Context.IsWorldReady || Game1.eventUp) // Let's not do this until the world is ready or else this draws on the title screen.
			return;
			
			// Get the current size of the UI
			Vector2 UIsize = new Vector2(Game1.uiViewport.Width, Game1.uiViewport.Height);
			
			
			// Set up a vector for the hunger bar position.
			// -171 and -240 come from survivalistic. I have no idea how he got these numbers unless it was just guess and check.
			// Using the Y value of the UI size draws these to the left of the toolbar.
			// We'll do this conditionally, depending on if the player is somewhere that the health bar renders.
			
			int offset;
			bool inDanger;
			string area = Game1.player.currentLocation.Name;
			// According to some rendering rules in Survivalistic, these three areas are dangerous. I only know about the mine. Fuck do you mean "skull cavern"? I heard there's goblin village...
			if (area.Contains("UndergroundMine") || (area.Contains("VolcanoDungeon") && area != ("VolcanoDungeon0")) || area.Contains("SkullCavern"))
			{
				inDanger = true;
			}
			else
			{
				inDanger = false;
			}
			// boy I love if and else, it would be a shame if some other conditional existed that is somewhat more memory efficient for large groups of items and I never used it
			if(inDanger)
			{  
				offset = 230;
			}
			else
			{
				offset = 171;
			}
			Vector2 hungerBarPosition = new Vector2((int)(UIsize.X-offset), (int)(UIsize.Y-240));
			// Set up a vector for the thirst bar position as well. This draws it right next to the hunger bar.
			Vector2 thirstBarPosition = new Vector2(hungerBarPosition.X+(4*hungyMeter.Width)+ 8, hungerBarPosition.Y);
			

			// This actually draws the hunger bar or whatever other sprite you want to draw. 
			// The format is (sprite asset, vector position, source rectangle (whatever that means), the color (whatever that does), the rotation of the sprite (if any), the scale (1 is the original sprite size), Sprite effects (whatever that is...), and finally the layer depth... Whatever that is.)
			// The scale is 4, if you want it to match the inbuilt UI scale... I guess? It works.
			Game1.spriteBatch.Draw(hungyMeter, hungerBarPosition, null, Color.White, 0, Vector2.Zero, 4, SpriteEffects.None, 1);
			Game1.spriteBatch.Draw(thorstMeter, thirstBarPosition, null,	Color.White, 0, Vector2.Zero, 4, SpriteEffects.None, 1);
			
			// Here we calculate a percentage to draw the dynamic part of the bars.
			// ... it might be horrendous to do these calculations here in the render step. I didn't make the game so I don't actually know.
			float hungyPercentage = hungyPercent(currentHunger, maxHunger);
			float thorstPercentage = thorstPercent(currentThirst, maxThirst);
			// They become part of the rectangle.
			// Some of this is probably scumbag code but I was just holding it for a friend, I swear.
			
			Game1.spriteBatch.Draw(thorstMeterFiller, new Vector2(thirstBarPosition.X + 36, thirstBarPosition.Y + (thorstMeter.Height * 4) - 8), new Microsoft.Xna.Framework.Rectangle(0, 0, thorstMeterFiller.Width * Game1.pixelZoom, (int)thorstPercentage), thirstColor, 3.138997f, new Vector2(0.5f, 0.5f), 1f, SpriteEffects.None, 1f);
			Game1.spriteBatch.Draw(hungyMeterFiller, new Vector2(hungerBarPosition.X + 36, hungerBarPosition.Y + (hungyMeter.Height * 4) - 8), new Microsoft.Xna.Framework.Rectangle(0, 0, hungyMeterFiller.Width * Game1.pixelZoom, (int)hungyPercentage), hungerColor, 3.138997f, new Vector2(0.5f, 0.5f), 1f, SpriteEffects.None, 1f);

			
			// Do the tooltip show when you hover the mouse
			hungerThirstHover(hungerBarPosition, hungyMeter);
			hungerThirstHover(thirstBarPosition, thorstMeter);
			
			
			
		}
		#nullable disable
		// There might not be a reason to make these have a return value, but I'm doing it anyway. Feels more trackable.
		public float hungyPercent(float currentHungy, float maxHungy)
		{
			float hungyAmt = (currentHungy / maxHungy) * 168; // I have no idea why this guy used 168 here, maybe it'll make sense to me if I think about it harder.
			return hungyAmt;
		}
		public float thorstPercent(float currentThorsty, float maxThorsty)
		{
			float thorstAmt = (currentThorsty / maxThorsty) * 168; // Ok I thought about it harder, this is approximately the size of the internal bar area (where the bar will fill) times 4.
			return thorstAmt; // So at full, these bars render as 1*168 = 168 pixels high. As the division becomes more lopsided, that height shrinks.
		}
		
		// Essentially lifted from Survivalistic, once more.
		// Well, not copied and pasted since that never pays off. The logic is stolen but the code is mine.
		// Honestly most of the logic is mine too because Survivalistic Rebooted seems to have been coded by the type of guy who thinks needless complexity is how you're supposed to program
		// That's exactly what they teach you in college!
		public void hungerThirstHover(Vector2 barPosition, Texture2D sprite)
		{
			Vector2 mousePosition = new Vector2(Game1.getMousePosition(true).X, Game1.getMousePosition(true).Y); // Why does the get mouse position function take a bool? I'm sure there's a good reason but its just kind of odd.
			
			if (mousePosition.X >= barPosition.X && mousePosition.X <= (barPosition.X + sprite.Width * 4) && mousePosition.Y-240 >= (barPosition.Y - 240) && mousePosition.Y-240 <= ((barPosition.Y - 240) + sprite.Height * 4))
			{
				// Doing some really experimental shit here. Name is apparently not populated by default (hence why I populated it way at the top) and presumably it sticks.
				if (sprite.Name == "hungyMeter")
				{
					showBarTooltip("hunger", barPosition, sprite);
				}
				if (sprite.Name == "thorstMeter")
				{
					showBarTooltip("thirst", barPosition, sprite);
				}
			}
		}
		
		// Continuing down the functions to display numbers pipeline.
		// I keep having to send bar position and sprite through these functions and its making me almost slightly sort of maybe consider how classes would help here but I'm just set in my ways.
		#nullable enable
		public void showBarTooltip(string type, Vector2 barPosition, Texture2D sprite)
		{
			string Info = " ";
			if (type == "hunger")
			{
				Info = $"{(int)currentHunger}/{(int)maxHunger}";
				
			}
			if (type == "thirst")
			{
				float curThirst = (float)Math.Round(currentThirst, 0);
				Info = $"{(int)curThirst}/{(int)maxThirst}";
			}
			Vector2 textSizeInfo = Game1.dialogueFont.MeasureString(Info);
			Vector2 textPositionInfo = new Vector2 (-12, textSizeInfo.X);
			
			Game1.spriteBatch.DrawString(Game1.dialogueFont, Info, new Vector2 (barPosition.X + textPositionInfo.X, barPosition.Y + 49 + sprite.Height * 4 / (4 + 8)), Color.White, 0f, new Vector2(textPositionInfo.Y, 0), 1, SpriteEffects.None, 0f);
			
		}
		
		// CheckToolUse does what it says on the tin - per tick, check if the player used a tool. 
		public void CheckToolUse(object? sender, UpdateTickedEventArgs e)
		{	
			if (!Context.IsWorldReady)
			{
				return;
			}
					
			if (Game1.player.UsingTool)
			{
				ToolUsedName = Game1.player.CurrentTool.BaseName; // Gets the base name of the tool, ie "Axe" or "Watering Can"
				QualifiedTool = Game1.player.CurrentTool.QualifiedItemId; // This gets the full item ID of the used tool, including its category (W) for weapon, etc.
				ToolCategory = QualifiedTool[1]; // QualifiedTool is a string, but we only want the one character. We're setting it here.
				AlreadyUsingTool = true;
			}
			else
			{
				if (AlreadyUsingTool)
				{
					AlreadyUsingTool = false; // Presumably this is because the update ticked goes too fast.
					ProcessThirst(ToolUsedName);
					
					if (ToolCategory == 'W')
					{// Let's say that you're swinging a weapon, you don't want to die of thirst.
					}
					else
					{
						if (thirstPenaltyFlag)
						{
							Game1.player.stamina -= 1;
						}
						if (hungerPenaltyFlag)
						{
							Game1.player.stamina -= 1;
						}
						if (hungerPenaltyFlag && thirstPenaltyFlag)
						{
							Game1.player.stamina -= 1;
						}
						if (starvingFlag)
						{
							Game1.player.stamina -= 1;
						}
						if (parchedFlag)
						{
							Game1.player.stamina -= 1;
						}
					}
				}
			}
		}
		
		// CheckEatedGoods is a funny way of saying "see if the player ate something". 
		public void CheckEatedGoods(object? sender, UpdateTickedEventArgs e)
		{	
			if (!Context.IsWorldReady)
			{
				return;
			}
			
			var eatenObject = (Game1.player.itemToEat);	// itemToEat is an object - we'll be passing it to our recovery function.
			if (Game1.player.isEating)
			{
				AlreadyEating = true;
			}
			else
			{
				if (AlreadyEating)
				{
					AlreadyEating = false; // Presumably this is because the update ticked goes too fast.
					recoverHungerAndThirst(eatenObject);
				}
			}
		}
		
		
		// Every time the game clock updates (every 10 in-game minutes), ProcessHunger processes hunger. 
		public void ProcessHunger(object? sender, TimeChangedEventArgs e)
		{
			if (!Context.IsWorldReady || Game1.eventUp) // Let's not do this until the world is ready or else this draws on the title screen.
			return;
			// Hunger gradually depletes over the course of the day, rather than by activity. Stardew protag does not seem to be Goku so hunger should not be a second stamina or health bar.
			currentHunger -= 1;
			// We lose one hunger per 10 in game minutes. God damn tragedy. So it'll take 1000 minutes to be running on empty. If there's 60 minutes per hour, that's definitely over 10 hours. 
			// Almost 20, in fact! It isn't an even number, unfortunately. 
			
		}
		public void StuffedBuff(object? sender, TimeChangedEventArgs e)
		{
			if (stuffedFlag)
			{
				Game1.player.stamina += 1;
			}
			if (moistenedFlag)
			{
				currentThirst -= 1;
			}
		}
		#nullable disable
		
		// ProcessThirst is dependent on player action - you do not get thirstier as time goes on... Unless we change it.
		public void ProcessThirst(string ToolName)
		{
			// Drain thirst when we use a tool.
			// I AM FINALLY USING A SWITCH TAKE THAT YANDEV
			
			// Thirst drain is very small to make sure it does not outrun stamina at the beginning of the game and to be sure that it ends up being a pain in the ass as you get stamina-er.
			if (currentThirst == 0)
			{//don't
			}
			else
			{
				switch(ToolName)
				{
					case string toolType when toolType.Contains("Axe"):
						currentThirst -= .5f;
					break;
					case string toolType when toolType.Contains("Watering Can"):
						currentThirst -= .5f;
					break;
					case string toolType when toolType.Contains("Hoe"):
						currentThirst -= .5f;
					break;
					case string toolType when toolType.Contains("Pickaxe"):
						currentThirst -= .5f;
					break;
					case string toolType when toolType.Contains("Scythe"):
						currentThirst -= .2f;
					break;
					case string toolType when toolType.Contains("Rod"):
						currentThirst -= (1f * (float)fishTicked);
						fishTicked = 0;
					break;
					case string toolType when toolType.Contains("Pole"):
						currentThirst -= (1f * (float)fishTicked);
						fishTicked = 0;
					break;
					case string toolType when toolType.Contains("Pail"):
						currentThirst -= .5f;
					break;
					case string toolType when toolType.Contains("Pan"):
						currentThirst -= .5f;
					break;
					case string toolType when toolType.Contains("Shears"):
						currentThirst -= .5f;
					break;
				}
			}
			Console.WriteLine(ToolName);
			
		}
		
		
		// recoverHunderAndThirst has got to be the longest named function here, right? It takes an object of StardewValley.Item. Maybe you recognize that...
		public void recoverHungerAndThirst(StardewValley.Item eatedItem)
		{
			string foodID = eatedItem.ItemId; // The ItemId method returns a string that equates to the item's numerical ID, except in cases where the item doesn't have a numerical ID, in which case it returns its name.
			Console.WriteLine(foodID);
			int[] hungyAndThirst = healValues.ediblesListAndValues(foodID); // healValues is the other class here, in the healList namespace. It probably didn't have to be a separate namespace, but uhhhhhh
			Console.WriteLine(hungyAndThirst[0].ToString());
			Console.WriteLine(hungyAndThirst[1].ToString());
			// Anyway, hungyAndThirst is an array passed back from the ediblesListAndValues method in that class. It contains [0]: hunger and [1]: thirst.
			// You can edit that document and recompile to customize this mod.
			
			// Now that we have that array, we'll update currentHunger and currentThirst, plus checking to be sure we don't overdo the max.
			currentHunger += (float)hungyAndThirst[0];
			if (currentHunger > maxHunger)
			{
				currentHunger = maxHunger;
			}
			currentThirst += (float)hungyAndThirst[1]; // Add the values from the edibles function.
			if (currentThirst > maxThirst)
			{
				// Make sure hunger and thirst don't exceed the maximum.
				currentThirst = maxThirst;
			}
		}
		
		// Hunger and thirst penalties live here. They'll be checked every step (frame?) to be sure they apply and unapply as expected.
		// For ease of searching, I'll make sure I mention their function names: HungerPenalty
		#nullable enable
		public void HungerPenalty(object? sender, UpdateTickedEventArgs e)
		{
			// Placeholder for when we remember what having low hunger does to you.
			if (currentHunger > 0)
			{
				starvingFlag = false;
				Game1.player.buffs.Remove("sdvHotdogChamp_starved");
			}
			if (currentHunger <= 20)
			{
				hungerPenaltyFlag = true;
				Game1.player.applyBuff(hungy);
				if (currentHunger == 0)
				{
					starvingFlag = true;
					Game1.player.applyBuff(starved);
				}
			}
			if (currentHunger >= 50)
			{
				hungerPenaltyFlag = false;
				Game1.player.buffs.Remove("sdvHotdogChamp_hungy");
			}
			if (currentHunger == maxHunger)
			{
				stuffedFlag = true;
				Game1.player.applyBuff(stuffed);
				Game1.player.applyBuff("6");
			}
			if (currentHunger < 80 && stuffedFlag == true)
			{
				stuffedFlag = false;
				Game1.player.buffs.Remove("sdvHotdogChamp_stuffed");
				Game1.player.buffs.Remove("6");
			}
			
		}
		// And ThirstPenalty
		public void ThirstPenalty(object? sender, UpdateTickedEventArgs e)
		{
			// Also placeholder
			if (currentThirst > 0)
			{
				parchedFlag = false;
				Game1.player.buffs.Remove("anything");
			}
			if (currentThirst <= 20)
			{
				thirstPenaltyFlag = true;
				Game1.player.applyBuff(thorsty);
				if (currentThirst == 0)
				{
					parchedFlag = true;
					Game1.player.applyBuff(parched);
				}
			}
			if (currentThirst >= 50)
			{
				thirstPenaltyFlag = false;
				Game1.player.buffs.Remove("sdvHotdogChamp_thirsty");
			}
			if (currentThirst == maxThirst)
			{
				moistenedFlag = true;
				Game1.player.applyBuff(moistened);
				Game1.player.applyBuff("7");
			}
			if (currentThirst < 90 && moistenedFlag == true)
			{
				moistenedFlag = false;
				Game1.player.buffs.Remove("sdvHotdogChamp_moistened");
				Game1.player.buffs.Remove("7");
			}
		}
		
		public void HungerThirstZeroer(object? sender, UpdateTickedEventArgs e)
		{
			// during all game ticks, if hunger or thirst is under 0, we want to be sure they don't stay under 0.
			if (currentHunger < minHunger)
			{
				currentHunger = minHunger;
			}
			if (currentThirst < minThirst)
			{
				currentThirst = minThirst;
			}
		}
		
		public void CheckSave(object? sender, SaveLoadedEventArgs e)
		{
			// Check that the save data actually exists. If it doesn't, this line creates it.
			var readingRainbow = this.Helper.Data.ReadSaveData<hungySave>("hotdogwater") ?? new hungySave();
			// Set the current hunger and thirst values to the ones from the save data. When you start a new file, this will be whatever the constructor values are in hungySave
			currentHunger = readingRainbow.savedHunger;
			currentThirst = readingRainbow.savedThirst;
		}
		public void WriteSave(object? sender, SavingEventArgs e)
		{
			// load the save to be sure we actually have one. Surely we have one, if we're here at all.
			var readingRainbow = this.Helper.Data.ReadSaveData<hungySave>("hotdogwater") ?? new hungySave(); // what the fuck am I casting
			
			// Before we actually save, we need to update the hungySave values to reflect our current hunger and thirst values in game.
			// If you have brain damage and do this in reverse, well... skull emoji
			readingRainbow.savedHunger = currentHunger;
			readingRainbow.savedThirst = currentThirst;
			// actually save the fucking game. gg you are now starving.
			this.Helper.Data.WriteSaveData("hotdogwater", readingRainbow);
		}
		public void FishingFucker(object? sender, TimeChangedEventArgs e)
		{
			// I live in a house of people who despise fishing and I think this is honestly too far
			// sorry fisherman.
			if (Game1.player.UsingTool)
			{
				string toolChecker = Game1.player.CurrentTool.BaseName; // Gets the base name of the tool, ie "Axe" or "Watering Can"
				bool checkRod = toolChecker.Contains("Rod"); // rod inspection day
				bool checkPole = toolChecker.Contains("Pole"); // pole inspection day too
				if (checkRod || checkPole)
				{
					fishTicked += 1;
				}
			}
		}
		
		public void TheNightBugs(object? sender, DayEndingEventArgs e)
		{
			// WHAT ARE THOOOOOOSE
			// Everyone wakes up hungry, having to piss, and ultimately thirsty.
			// farmer does too.
			
			// This happens before save, so these will be written by WriteSave.
			currentHunger -= 15f;
			currentThirst -= 15f;
		}

		#nullable disable
    }	
}
