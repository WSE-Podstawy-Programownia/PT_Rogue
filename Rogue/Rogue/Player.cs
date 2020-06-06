using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	 class Player : Tile
	{
		public override char Character { get; set; } = 'P';

		public override bool Walkable { get; } = false;

		public int HealthValue { get; set; } = 15;

		public int[] Position { get; set; } = { 2, 2 };



		public void HandlePlayerInput()
		{
			ConsoleKeyInfo input = Console.ReadKey(true);

			if (input.Key == ConsoleKey.LeftArrow)
			{
				Position[1] -= 1;
			}
			else if (input.Key == ConsoleKey.RightArrow)
			{
				Position[1] += 1;
			}
			else if (input.Key == ConsoleKey.DownArrow)
			{
				Position[0] += 1;
			}
			else if (input.Key == ConsoleKey.UpArrow)
			{
				Position[0] -= 1;
			} else
			{

			}

		}

	}
}
