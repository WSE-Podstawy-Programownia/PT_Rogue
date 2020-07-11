using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	class Enemy : Tile, IMovable, IFightable
	{

		public Enemy(int y, int x)
		{
			PositionY = y;
			PositionX = x;
			StoodOnTile = new Floor(PositionY, PositionX);
			Game.Enemies.Add(this);
		}

		public int HitPoints { get; set; } = 5;
		public Tile StoodOnTile { get; set; }

		Random random = new Random();
		public override char Character { get; set; } = 'E';

		public override bool Walkable { get; } = false;

		public override int PositionY { get; set; }

		public override int PositionX { get; set; }



		public virtual void AIBehaviour()
		{
			//If player is adjescent in straight line then attack
			if
			(Game.map.Room[PositionY + 1, PositionX] == Game.player
			|| Game.map.Room[PositionY - 1, PositionX] == Game.player
			|| Game.map.Room[PositionY, PositionX + 1] == Game.player
			|| Game.map.Room[PositionY, PositionX - 1] == Game.player)
				{
				Attack(Game.player);
				} 
			else
				{
				int desiredY = PositionY;
				int desiredX = PositionX;
				//Determine direction
				int roll = random.Next(0, 4);
				switch (roll)
				{
					case 0:
						desiredY++;
						break;
					case 1:
						desiredY--;
						break;
					case 2:
						desiredX++;
						break;
					case 3:
						desiredX--;
						break;
				}

				if (Game.map.Room[desiredY, desiredX].Walkable == true)
				{
					Move(desiredY, desiredX);
				}
			}

		}

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

		public virtual void Attack(IFightable target)
		{
			target.HitPoints--;
			target.EvaluateDeath();
		}

		public void EvaluateDeath()
		{
			if (HitPoints <= 0)
			{
				Game.map.Room[PositionY, PositionX] = StoodOnTile;
				Game.Enemies.Remove(this);
			}
		}

	}
}
