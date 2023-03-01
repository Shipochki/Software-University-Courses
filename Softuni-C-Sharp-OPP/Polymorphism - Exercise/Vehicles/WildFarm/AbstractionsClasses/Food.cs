using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Food
    {
        protected int quantity;

        public Food(int quantity)
        {
            this.quantity = quantity;
        }
    }
}
