using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NinjaWorld;

namespace ConsoleInstantationTester
{
    public class Bag<T> : IEnumerable<T>
        where T : IItem
    {
        IList<T> bagItems = null;

        public Bag()
        {
            bagItems = new List<T>();  
        }

        public void Add(T item)
        {
            bagItems.Add(item);
            
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in bagItems)
            {
                if (t == null)
                {
                    break;
                }

                yield return t;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
               
        public void Insert(int index, T item)
        {
            bagItems.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            bagItems.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return bagItems[index];
            }
            set
            {
                bagItems[index] = value;
            }
        }


    }
}
