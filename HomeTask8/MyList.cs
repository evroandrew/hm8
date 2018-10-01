using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask8
{
    /// <summary>
    /// My ArrayList for type <T>
    /// </summary>
    class MyArrayList<T> : ICollection<T>, IList<T>, IEnumerator<T>
    {
        #region filds
        private T[] arr;
        int count = 0;
        #endregion

        #region .ctors

        /// <summary>
        /// Constructor MyArrayList
        /// </summary>
        /// <param name="capacity">Initial capecity of arrayList</param>
        public MyArrayList(int capacity = 10)
        {
            arr = new T[capacity];
        }
        #endregion

        #region Properties and Indexator
        /// <summary>
        /// counter of elements in List
        /// </summary>
        public int Count
        {
            get => count;
        }
        /// <summary>
        /// Check for the possibility of changing
        /// </summary>
        public bool IsReadOnly => false;
        /// <summary>
        /// Get element with index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add element with value
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (count == arr.Length)
            {
                size_inc();
            }
            arr[count++] = value;
        }

        /// <summary>
        /// Increasethe size of array
        /// </summary>
        private void size_inc()
        {
            T[] tmp = new T[arr.Length + arr.Length / 2 + 1];
            for (int i = 0; i < arr.Length; ++i)
            {
                tmp[i] = arr[i];
            }
            arr = tmp;
        }

        /// <summary>
        /// Clear count
        /// </summary>
        public void Clear()
        {
            count = 0;
        }

        /// <summary>
        /// Check whether the element is in an array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            for (int i = 0; i < count; ++i)
                if (arr[i].Equals(value)) return true;
            return false;
        }

        /// <summary>
        /// Copy List to array
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < count; ++i)
                array[arrayIndex++] = arr[i];
        }

        /// <summary>
        /// Find index of Element
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public int IndexOf(T val)
        {
            for (int i = 0; i < count; ++i)
            {
                if (arr[i].Equals(val)) return i;
            }
            return -1;
        }

        /// <summary>
        /// Remove object with val from List
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Remove(T val)
        {
            int i = IndexOf(val);
            if (i < 0) return false;
            RemoveAt(i);
            return true;
        }

        /// <summary>
        /// Remove object with index from List
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            for (++index; index < count; ++index)
            {
                arr[index - 1] = arr[index];
            }
            --count;
        }

        /// <summary>
        /// Insert elemnet in List with index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        public void Insert(int index, T item)
        {
            if (count == arr.Length)
            {
                size_inc();
            }
            for (int i = count - 1; i > index; i--)
            {
                arr[i + 1] = arr[i];
            }
            arr[index] = item;
            count++;
        }
        #endregion
        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region IEnumerator 
        public T Current
        {
            get => arr[currentIndex];
        }

        object IEnumerator.Current => Current;

        T IList<T>.this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }

        private int currentIndex = -1;

        public bool MoveNext()
        {
            ++currentIndex;
            return currentIndex <= count;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
        public void Dispose()
        {
            Reset();
        }

        #endregion
    }

}