using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    internal class ListBoxes<T>
    {
        private List<Box<T>> boxes;

        public ListBoxes()
        {
            Boxes = new List<Box<T>>();
        }
        public List<Box<T>> Boxes
        {
            get { return boxes; }
            set { boxes = value; }
        }

        public void Add(Box<T> item)
        {
            this.boxes.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var currentBoxes = this.boxes;

            var firstItem = currentBoxes[firstIndex];
            var secondItem = currentBoxes[secondIndex];
            currentBoxes.RemoveAt(secondIndex);
            currentBoxes.RemoveAt(firstIndex);
            currentBoxes.Insert(firstIndex, secondItem);
            currentBoxes.Insert(secondIndex, firstItem);
        }
    }
}
