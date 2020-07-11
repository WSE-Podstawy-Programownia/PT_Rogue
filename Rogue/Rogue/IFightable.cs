using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rogue
{
	interface IFightable
	{
		int HitPoints { get; set; }

		void Attack(IFightable target);

		void EvaluateDeath();

	}
}
