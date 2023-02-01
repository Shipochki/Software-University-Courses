using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class LibraryIterator
    {
        private readonly List<Book> books;
        public IEnumerable<Book> GetEnumerator()
        {
            for (int i = 0; i < this.books.Count; i++)
                yield return this.books[i];
        }
    }

}
