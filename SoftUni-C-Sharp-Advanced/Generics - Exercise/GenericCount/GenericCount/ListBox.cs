using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCount
{
    internal class ListBox<T> where T : Box<T>
    {
        private List<Box<T>> list;

        public ListBox()
        {
            List = new List<Box<T>>();
        }

        public List<Box<T>> List
        {
            get { return list; }
            set { list = value; }
        }
    }
}
