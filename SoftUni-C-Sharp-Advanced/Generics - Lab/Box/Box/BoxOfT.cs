using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOfT
{
    public class BoxOfT<T>
    {
        private List<T> data;
        private int count;
        public BoxOfT()
        {
            this.Data = new List<T>();
            count = this.Data.Count;
        }
        public List<T> Data
        {
            get { return data; }
            set { data = value; }
        }

        public void Add(T item)
        {
            Data.Add(item);
        }

        public int Count()
        {
            var count = this.Data.Count;
            return count;
        }

        public T Remove()
        {
            var lastItem = this.Data[this.Data.Count - 1];
            data.RemoveAt(this.Data.Count - 1);
            return lastItem;
        }
    }
}
