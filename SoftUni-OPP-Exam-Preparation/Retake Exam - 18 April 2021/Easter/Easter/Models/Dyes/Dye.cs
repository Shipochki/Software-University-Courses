using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Dyes
{
	public class Dye : IDye
	{
		public Dye(int power)
		{
			this.power = power;
		}

		private int power;

		public int Power
		{
			get 
			{ 
				if(this.power < 0)
				{
					this.power = 0;
				}
				return power; 
			}
		}

		public bool IsFinished()
		{
			if(this.power == 0)
			{
				return true;
			}

			return false;
		}

		public void Use()
		{
			if(this.power - 10 <= 0)
			{
				this.power = 0;
			}
			else
			{
				this.power -= 10;
			}
		}
	}
}
