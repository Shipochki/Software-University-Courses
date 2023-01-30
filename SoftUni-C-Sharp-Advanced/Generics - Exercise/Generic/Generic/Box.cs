using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    internal class Box<T>
    {
        private T data;
        public Box(T data)
        {
            Data = data;
        }
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public string ToString()
        {
            var result = this.Data.ToString();
            return result;
        }
    }
}
