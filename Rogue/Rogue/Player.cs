using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	class Player : Tile
	{
		public override char Character { get; set; } = 'P';

		public override bool Walkable { get; } = false;

		public int HealthValue { get; set; } = 15;


		public void PlayerInput()
		{ 
			
		}

	}
}
