using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	class Floor : Tile
	{
		public Floor(int y, int x)
		{
			PositionY = y;
			PositionX = x;
		}

		public override char Character { get; set; } = '-';

		public override bool Walkable { get; } = true;

		public override int PositionY { get; set; }
		public override int PositionX { get; set; }

	}
}
