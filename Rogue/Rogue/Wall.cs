using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	class Wall : Tile
	{
		//CONSTRUCTOR
		public Wall(int y, int x)
		{
			PositionY = y;
			PositionX = x;
		}

		//implementation of Tile class fields
		public override char Character { get; set; } = '=';

		public override bool Walkable { get; } = false;

		public override int PositionY { get; set; }
		public override int PositionX { get; set; }

	}
}
