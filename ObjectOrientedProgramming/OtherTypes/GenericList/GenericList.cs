using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericListProject
{
    [VersionAttribute(1, 2)]
    internal class GenericList<T> : IList<T> where T : IComparable<T> 
    {
        public const int DEFAULT_CAPACITY = 16;

        private T[] listElements;
        private int elementsCount = 0;

        public GenericList(int capacity = DEFAULT_CAPACITY)
        {
            this.listElements = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.listElements.Length)
                {
                    throw new ArgumentOutOfRangeException("Given index is outside the list!");
                }
                return this.listElements[index];
            }
            set
            {
                throw new InvalidOperationException("Cannot set through indexer!");
            }
        }

        public int Count
        {
            get { return this.elementsCount; }
            private set
            {
                if (value > this.listElements.Length)
                {
                    IncreaseListCapacity();
                }

                this.elementsCount = value;
            }
        }

        public int Capacity
        {
            get { return this.listElements.Length; }
        }

        public void Add(T element)
        {
            this.Count++;

            this.listElements[this.elementsCount - 1] = element;
        }

        public void Clear()
        {
            this.Count = 0;
            this.listElements = new T[DEFAULT_CAPACITY];
        }

        public bool Contains(T value)
        {
            return this.listElements.Contains(value);
        }

        public override string ToString()
        {
            return String.Join(", ", this.listElements.Take(this.Count));
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Equals(item)) return i;
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Given index is outside the list!");
            }
            this.Count++;
            T[] newList = new T[this.listElements.Length];
            for (int i = 0, j = 0; j < this.Count; i++)
            {
                if (i == index)
                {
                    newList[i] = item;
                }
                else
                {
                    newList[i] = this.listElements[j++];
                }
            }
            this.listElements = newList;
        }

        public void RemoveAt(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }
            if (index < 0 || index >= this.listElements.Length)
            {
                throw new ArgumentOutOfRangeException("Given index is outside the list!");
            }

            T[] newList = new T[this.listElements.Length];
            for (int i = 0, j = 0; i < this.listElements.Length; i++)
            {
                if (i != index)
                {
                    newList[j++] = this.listElements[i];
                }
            }
            this.listElements = newList;
            this.Count--;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            bool hasRemovedElements = false;
            int elementIndex = this.IndexOf(item);
            while (elementIndex >= 0)
            {
                this.RemoveAt(elementIndex);
                elementIndex = this.IndexOf(item);
                hasRemovedElements = true;
            }
            return hasRemovedElements;
        }

        public T Min()
        {
            return this.listElements.Min();
        }

        public T Max()
        {
            return this.listElements.Max();
        }

        public string GetVersion()
        {
            var attr =
            (VersionAttribute)Attribute.GetCustomAttribute(typeof(GenericList<T>), typeof(VersionAttribute));
            return String.Format("{0}.{1}", attr.Major, attr.Minor);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.listElements)
            {
                yield return item;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void IncreaseListCapacity()
        {
            T[] newList = new T[this.elementsCount * 2];
            for (int i = 0; i < this.listElements.Length; i++)
            {
                newList[i] = this.listElements[i];
            }

            this.listElements = newList;
        }
    }
}
