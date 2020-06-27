using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	 class Player : Tile, IMovable
	{

		public override char Character { get; set; } = 'P';

		public override bool Walkable { get; } = false;

		public int HealthValue { get; set; } = 15;

		public override int PositionX { get; set; } = 2;
		public override int PositionY { get; set; } = 2;

		public Tile StoodOnTile { get; set; }

		public Player()
		{
			StoodOnTile = new Floor(PositionX, PositionY);
		}

		public void HandlePlayerInput()
		{
			ConsoleKeyInfo input = Console.ReadKey(true);

			if (input.Key == ConsoleKey.LeftArrow)
			{
				PositionX -= 1;
			}
			else if (input.Key == ConsoleKey.RightArrow)
			{
				PositionX += 1;
			}
			else if (input.Key == ConsoleKey.DownArrow)
			{
				PositionY += 1;
			}
			else if (input.Key == ConsoleKey.UpArrow)
			{
				PositionY -= 1;
			} else
			{

			}

		}

		public void Move()
		{

			Game.map.Room[PositionY, PositionX] = StoodOnTile;

			int OldPositionY = PositionY;
			int OldPositionX = PositionX;

			HandlePlayerInput();

			if (Game.map.Room[PositionY, PositionX].Walkable == false)
			{
				PositionY = OldPositionY;
				PositionX = OldPositionX;

				Game.map.Room[PositionY, PositionX] = this;
			}
			else
			{
				StoodOnTile = Game.map.Room[PositionY, PositionX];
				Game.map.Room[PositionY, PositionX] = this;
			}

			Game.map.DrawMap(Game.map.Room);

		}
	}
}
