using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	interface IMovable
	{
		Tile StoodOnTile { get; set; }

		void Move();
	}
}
