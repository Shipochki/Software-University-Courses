using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCount
{
    internal class Box<T>
    {
        private T item;

        public Box(T item)
        {
            Item = item;
        }

        public T Item
        {
            get { return item; }
            set { item = value; }
        }
    }
}
