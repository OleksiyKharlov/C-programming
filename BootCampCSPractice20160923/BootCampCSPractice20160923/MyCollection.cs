using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BootCampCSPractice20160923

{
    class MyCollection<T>: IList<T>, ICollection<T> where T: IComparable, ICloneable
    {
        T[] Arr = new T[0];
  

        public int Length
        {
            get;
            protected set;
        }

        protected int Capacity
        {
            get { return Arr.Length; }
        }

        public T this[int index]
        {
            get
            {
                return Arr[index];
            }

            set
            {
                Arr[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return Length;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return Arr.IsReadOnly;
            }
        }

        public void Add(T item)
        {
            if (Capacity == 0)
            {
                T[] newArr = new T[16];
                newArr[Length++] = item;
                Arr = newArr;
            }
            else if (Length + 1 >= Capacity)
            {
                T[] newArr = new T[Capacity * 2];
                Array.Copy(Arr, newArr, Capacity);
                newArr[Length++] = item;
                GC.Collect();
            }
            else
            {
                Arr[Length++] = item;
            }
        }

        public void Clear()
        {
            Arr = new T[Arr.Length];
            GC.Collect();
        }

        public bool Contains(T item)
        {
            return (Arr.Contains(item));
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(Arr, 0, array, arrayIndex, Length);
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i].Equals(item))
                    return i;
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index >= Arr.Length)
                throw new ArgumentOutOfRangeException("Index out of range");
            if (Capacity - 1 == Length)
            {
                T[] newArr = new T[Capacity * 2];
                for (int i = 0; i < newArr.Length; i++)
                {
                    if (i < index)
                        newArr[i] = Arr[i];
                    else if (i == index)
                        newArr[i] = item;
                    else
                        newArr[i] = Arr[i - 1];
                }
                Arr = newArr;
                GC.Collect();
            }
            else
            {
                for (int i = Length; i > index; i--)
                {
                    Arr[i] = Arr[i - 1];
                }
                Arr[index] = item;
            }
            Length++;
        }

        public bool Remove(T item)
        {
            int indexOfItem = IndexOf(item);
            if (indexOfItem >= 0)
            {
                RemoveAt(indexOfItem);
                return true;
            }
            else return false;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < Length; i++)
                Arr[i] = Arr[i + 1];
            Length--;
            if (Length * 2 < Capacity)
            {
                T[] newArr = new T[Capacity / 2];
                Array.Copy(Arr, newArr, newArr.Length);
                Arr = newArr;
                GC.Collect();
            }
        }

       

        public void SelSort()
        {
            int curMin;
            for (int i = 0; i < Length - 1; i++)
            {
                curMin = i;
                for (int j = i + 1; j < Length; j++)
                {
                    if (Arr[j].CompareTo(Arr[curMin]) < 0)
                    {
                        curMin = j;
                    }
                }
                T tmp = Arr[curMin];
                Arr[curMin] = Arr[i];
                Arr[i] = tmp;
            }
        }

        public T[] LambdaLinqSort()
        {
            return (Arr.OrderBy(e => e)).ToArray();
        }

        public T[] LambdaLinqDecsSort()
        {
            return (Arr.OrderByDescending(e => e)).ToArray();
        }
        public void Sort()

        {
            Array.Sort(Arr, 0, Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return this[i];
            }
        }

        public List<T> ToList()
        {
            var newlist = new List<T>();
            for (int i = 0; i < Length; i++)
                newlist.Add(Arr[i]);
            return newlist;
        }
    }
}
