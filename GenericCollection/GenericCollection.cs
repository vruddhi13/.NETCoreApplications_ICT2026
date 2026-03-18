using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    internal class GenericCollection<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item) => items.Add(item);

        // String indexer: returns first match
        public T this[string search]
        {
            get
            {
                return items.FirstOrDefault(i => i.ToString().Contains(search));
            }
        }

        // Multivalued indexer: returns all matches
        public IEnumerable<T> this[Func<T, bool> predicate]
        {
            get
            {
                return items.Where(predicate);
            }
        }
    }
}
