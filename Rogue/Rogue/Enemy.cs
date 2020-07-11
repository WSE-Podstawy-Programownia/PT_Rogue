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


		public void Move(int moveToY, int moveToX)
		{

		}

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
				//implement movement towards player
				}

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
