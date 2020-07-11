using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	 class Player : Tile, IMovable, IFightable
	{

		#region fields
		public override char Character { get; set; } = 'P';

		public override bool Walkable { get; } = false;

		public int HitPoints { get; set; } = 15;

		public override int PositionX { get; set; } = 2;
		public override int PositionY { get; set; } = 2;

		public Tile StoodOnTile { get; set; }
		#endregion


		public Player()
		{
			StoodOnTile = new Floor(PositionX, PositionY);
		}

		//Player input handles the arrow key inputs and moves or attacks
		public void HandlePlayerInput()
		{
			ConsoleKeyInfo input = Console.ReadKey(true);

			int desiredPositionY = PositionY;
			int desiredPositionX = PositionX;

			if (input.Key == ConsoleKey.LeftArrow)
			{
				desiredPositionX--;
			}
			else if (input.Key == ConsoleKey.RightArrow)
			{
				desiredPositionX++;
			}
			else if (input.Key == ConsoleKey.DownArrow)
			{
				desiredPositionY++;
			}
			else if (input.Key == ConsoleKey.UpArrow)
			{
				desiredPositionY--;
			} 
			else
			{

			}

			//If the desired spot is walkable move there if not then await next input
			if (Game.map.Room[desiredPositionY, desiredPositionX] is IFightable)
			{
				Attack((IFightable) Game.map.Room[desiredPositionY, desiredPositionX]);
			}
			else if (Game.map.Room[desiredPositionY, desiredPositionX].Walkable == true)
			{
				Move(desiredPositionY, desiredPositionX);
			}
			else
			{
				HandlePlayerInput();
			}


		}


		//Move the player to a given position, replaces old spot on the map with the StoodOnTile
		public void Move(int moveToY, int moveToX)
		{
			//replace pre-move position Tile on the map
			Game.map.Room[PositionY, PositionX] = StoodOnTile;

			//Change position to new values and change the Tile on the Map to player
			PositionY = moveToY;
			PositionX = moveToX;

			StoodOnTile = Game.map.Room[PositionY, PositionX];
			Game.map.Room[PositionY, PositionX] = this;
		}

		public void Attack(IFightable target)
		{
			target.HitPoints -= 3;
			target.EvaluateDeath();
		}

		public void EvaluateDeath()
		{
			if (HitPoints <= 0)
			{
				Game.GameOver = true;
			}
		}
	}
}
