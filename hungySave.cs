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

namespace sdvHotdogChamp
{
	public class hungySave
	{
		public float savedHunger { get; set; }
		public float savedThirst { get; set; }
		
		public hungySave()
		{
			// Default constructor values for your brand new save.
			savedHunger = 70f;
			savedThirst = 70f;
		}
		
	}
	
	
	

}
