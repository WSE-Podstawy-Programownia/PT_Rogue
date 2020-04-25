using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	abstract class Tile
	{
		public abstract char Character
		{
			get;
			set;
		}

		public abstract bool Walkable
		{
			get;
		}

	}
}
