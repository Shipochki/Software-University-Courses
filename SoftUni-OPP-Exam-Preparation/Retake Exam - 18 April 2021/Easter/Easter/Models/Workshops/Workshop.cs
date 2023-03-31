using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
	public class Workshop : IWorkshop
	{
		public void Color(IEgg egg, IBunny bunny)
		{
			if (bunny.Energy > 0 && bunny.Dyes.Any(d => !d.IsFinished()))
			{
				foreach (var dye in bunny.Dyes)
				{
					while (!dye.IsFinished())
					{
						if (bunny.Energy <= 0)
						{
							return;
						}

						bunny.Work();
						dye.Use();
						egg.GetColored();
					}
				}
			}
		}
	}
}
