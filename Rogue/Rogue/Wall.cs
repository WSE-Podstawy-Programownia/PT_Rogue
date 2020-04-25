using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	class Wall : Tile
	{
		public override char Character { get; set; } = '=';

		public override bool Walkable { get; } = false;


	}
}
