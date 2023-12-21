namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;

        public List()
            : this(DEFAULT_CAPACITY) {
        }

        public List(int capacity)
        {
            if(capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];
        }

        public T this[int index] 
        {
            get 
            {
                ValidateIndex(index);
                return this.items[index];
            }
            set 
            {
                ValidateIndex(index);
                this.items[index] = value;
			}
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if(this.Count == this.items.Length)
            {
				this.Grow();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

		public bool Contains(T item)
        {
            if(Count == 0)
            {
                return false;
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.items[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            if(this.Count == this.items.Length)
            {
                Grow();
            }

            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }

            this.items[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if(index == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(index);
                return true;
            }
        }

        public void RemoveAt(int index)
        {
            ValidateIndex(index);
            this.items[index] = default(T);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            } 

            this.Count--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Grow()
		{
            T[] newItems = new T[this.Count * 2];

            Array.Copy(this.items, newItems, this.items.Length);

            this.items = newItems;
        }

        private void ValidateIndex(int index)
        {
			if (index < 0 || index >= this.items.Length)
			{
				throw new IndexOutOfRangeException(nameof(index));
			}
		}
    }
}