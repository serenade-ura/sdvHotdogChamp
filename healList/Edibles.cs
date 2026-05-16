using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using Color = Microsoft.Xna.Framework.Color;

namespace healList
{
	public class Edibles
	{
		int[] healValues = new int[2];
		// healValues[0] is hunger, [1] is thirst.
		public int[] ediblesListAndValues(string itemId)
		{
			// A list of the item ids and how much they heal hunger and thirst.
			// Add this shit to the labors of hercules, there absolutely should have been a better way to do this.
			// There probably WAS a better way to do this and that's the worst part.
			switch(itemId)
			{
				case "16": //Wild Horseradish
				{
					healValues[0] = 100 ;
					healValues[1] = 1 ;
					break;
				}
				case "18": // Daffodil
				{
					healValues[0] = 0 ;
					healValues[1] = 100 ;
					break;
				}
				case "20": // Leek
				{
					healValues[0] = 100 ;
					healValues[1] = 100 ;
					break;
				}
				case "22": // Dandelion
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "24": // Parsnip
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "78": // Cave Carrot
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "88": // Coconut
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "90": // Cactus Fruit
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "91": // Banana
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "92": // Sap
				{
					healValues[0] = -150 ;
					healValues[1] = -100 ;
					break;
				}
				case "128": // Pufferfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "129": // Anchovy
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "130": // Tuna
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "131": // Sardine
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "132": // Bream
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "136": // Largemouth Bass 
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "137": // Smallmouth Bass
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "138": // Rainbow Trout 
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "139": // Salmon
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "140": // Walleye
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "141": // Perch
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "142": // Carp
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "143": // Catfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "144": // Pike
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "145": // Sunfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "146": // Red Mullet
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "147": // Herring
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "148": // Eel
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "149": // Octopus
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "150": // Red Snapper
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "151": // Squid
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "152": // Seaweed
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "153": // Green Algae
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "154": // Sea Cucumber
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "155": // Super Cucumber
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "156": // Ghostfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "157": // White Algae
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "158": // Stonefish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "159": // Crimsonfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "160": // Angler
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "161": // Ice Pip
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "162": // Lava Eel
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "163": // Legend
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "164": // Sandfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "165": // Scorpion Carp
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "167": // Joja Cola
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "174": // Large Egg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "176": // Egg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "180": // Egg TWO (brown)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "182": // Large Egg TWO (brown)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "184": // Milg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "186": // Large Milg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "188": // Green Bean
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "190": // Cauliflower
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "192": // Potato
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "194": // Fried Egg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "195": // Omelet
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "196": // Salad
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "197": // Cheese Cauliflower
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "198": // Baked Fish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "199": // Parsnip Soup
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "200": // Vegetable Medley
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "201": // Complete Breakfast
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "202": // Fried Calamari
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "203": // Strange Bun
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "204": // Lucky Lunch
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "205": // Fried Mushroom
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "206": // Pizza
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "207": // Bean Hotpot
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "208": // Glazed Yams
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "209": // Carp Surprise
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "210": // Hashbrowns
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "211": // Pancakes
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "212": // Salmon Dinner
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "213": // Fish Taco
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "214": // Crispy Bass
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "215": // Pepper Poppers
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "216": // Bread
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "218": // Tom Kha Soup
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "219": // Trout Soup
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "220": // Chocolate Cake
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "221": // Pink Cake
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "222": // Rhubarb Pie
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "223": // Cookies
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "224": // Spaghet
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "225": // Fried Eel
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "226": // Spicy Eel
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "227": // Sashimi
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "228": // Maki Roll
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "229": // Tortilla
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "230": // Red Plate
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "231": // Eggplant Parm
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "232": // Arroz con leche
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "233": // Ice Cream
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "234": // Blueberry Tart
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "235": // Autumn's Bounty
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "236": // Pumpkin Soup
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "237": // Super Meal
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "238": // Cranberry Sauce
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "239": // Stuffing
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "240": // Farmer's Lunch
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "241": // Survival Burger
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "242": // Filet o'Fish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "243": // Miner's Treat
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "244": // Roots Platter
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "245": // Sugar
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "246": // Wheat Flour
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "247": // Oil
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "248": // Garlic
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "250": // Kale
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "251": // Triple Shot Espresso
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "254": // Melon
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "256": // Tomato
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "257": // Morel
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "258": // Blueberry
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "259": // Fiddlehead
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "260": // Hot Pepper
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "264": // Radish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "265": // Seafoam Pudding
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "266": // Red Cabbage
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "267": // Flounder (how the fuck are we back on fish)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "268": // Starfruit
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "269": // Midnight carp
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "270": // Corrin
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "271": // Unmilled Rice
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "272": // Eggplant
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "274": // Artichoke
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "276": // Pumpkin
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "278": // Bok Choy
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "279": // Rock Candy
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "280": // Yam
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "281": // Chanterelle (I thought it was just chantrell)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "282": // Cranberries
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "283": // Holly
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "284": // Beet
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "289": // Ostrich Egg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "296": // Salmonberry
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "300": // Amaranth (GIVE IT UP FOR ITEM THREE HUNDRED)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "303": // Pale Ale
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "304": // Hops (why)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "305": // Void Egg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "306": // Mayonnaise
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "307": // Duck Mayonnaise (why is there a difference)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "308": // Void Mayonnaise
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "340": // Honey
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "342": // Pickles
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "344": // Jelly
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "346": // today's secret ingredient is... BEEEEEEEEEEEEER
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "348": // Wine
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "349": // Energy Tonic
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "350": // Juice
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "351": // Muscle Remedy
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "373": // Golden Pumpkin
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "376": // Poppy
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "395": // Coffee
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "396": // Spice Berry
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "398": // Grape
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "399": // Spring Onion
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "400": // Strawberry (These items never end...)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "403": // Field Snack
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "404": // Common mushroom (not found)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "406": // Wild Plum
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "408": // Hazelnut
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "410": // blackberry
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "412": // Winter Root
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "414": // Crystal fruit
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "416": // Snow Yam
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "418": // Crocus
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "419": // Vinegar (if you eat this it should kill you instantly)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "420": // Red Mushroom (ayy)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "421": // Sunflower
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "422": // Purple Mushroom
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "423": // Rice
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "424": // Cheese
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "426": // Goat Cheese
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "430": // Truffle
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "432": // Truffle Oil
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "434": // Stardrop
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "436": // Goat Milk
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "438": // Large Goat Milk
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "442": // Duck Egg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "445": // Caviar
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "447": // Aged Roe
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "456": // Algae Soup
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "457": // Pale Broth
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "459": // Mead
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "591": // Tulip
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "593": // Summer Spangle
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "595": // Fairy Rose
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "597": // Blue Jazz
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "604": // Plum Pudding
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "605": // Artichoke Dip
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "606": // Stir Fry
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "607": // Roasted Hazelnuts
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "608": // Pumpkin Pie
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "609": // Radish Salad
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "610": // Fruit Salad
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "611": // Blackberry Cobbler 
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "612": // Cranberry Candy
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "613": // Apple
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "614": // Green Tea
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "618": // Bruschetta
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "634": // Apricot
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "635": // Orange
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "636": // Peach
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "637": // Pomegranate
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "638": // Cherry
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "648": // Coleslaw
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "649": // Fiddlehead Rice
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "651": // Poppyseed Muffin
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "682": // Mutant Carp
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "698": // Sturgeon (FISH IS BACK)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "699": // Tiger Trout
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "700": // Bullhead
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "701": // Tilapia
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "702": // Chub
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "704": // Dorado
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "705": // Albacore
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "706": // Shad
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "707": // Lingcod
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "708": // Halibut
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "724": // Maple Syrup
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "727": // Chowder
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "728": // Fish Stew
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "729": // Escargot
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "730": // Lobster Bisque
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "731": // Maple Bar
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "732": // Crab Cakes
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "733": // Shrimp Cocktail
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "734": // Woodskip
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "772": // Oil of Garlic
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "773": // Life Elixir
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "775": // Glacierfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "791": // Golden Coconut
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "795": // Void Salmon
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "796": // Slimejack
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "798": // midnight squid
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "799": // Spook Fish (you can't call him that)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "800": // Blobfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "812": // Roe
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "829": // Ginger
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "830": // Taro Root
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "832": // Pineapple
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "834": // Mango
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "836": // Stingray
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "837": // Lionfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "838": // Blue Discus
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "873": // Pina Colada (this is an inhumane amount of items)	
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "874": // Bug Steak
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "889": // Qi Fruit
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "890": // Qi Bean
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "898": // Son of Crimsonfish
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "899": // Ms. Angler
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "900": // Legend TWO
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "901": // Radioactive Carp (is this a fucking earthbound enemy)
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "902": // Glacierfish Jr.
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "903": // Gingerale
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "904": // Banana pudding
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "905": // Mango Sticky Rice
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "906": // Poi
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "907": // Tropical Curry
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "928": // Golden Egg
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "Raisins":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "DriedFruit":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "DriedMushrooms":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "Carrot":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "SummerSquash":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "Broccoli":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "Powdermelon":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "SmokedFish":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "SeaJelly":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "CaveJelly":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "RiverJelly":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "Goby":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				case "MossSoup":
				{
					healValues[0] = 0 ;
					healValues[1] = 0 ;
					break;
				}
				default:
				{
					// If somehow we missed something, or he added MORE shit
					// Basically, this just heals a decent amount. This should make it "work" with custom food mods...
					// but if you're adding more food to this game you can fuck yourself tbh because what the hell do you mean 300 consumable items wasn't enough
					healValues[0] = 5;
					healValues[1] = 5;
					break;
				}
			}	
			
			return healValues; 
		}
	}
}
