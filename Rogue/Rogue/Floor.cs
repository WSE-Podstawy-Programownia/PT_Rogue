using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	class Floor : Tile
	{
		public override char Character { get; set; } = '-';

		public override bool Walkable { get; } = true;

	}
}
