namespace _03.GenericList
{
    using System;
    using System.Text;

    [Version(0, 1)]
    public class GenericList<T>
    {
        public const int DefaultListCapacity = 16;
        private T[] array;
        private int count = 0;

        public GenericList(int initialCapacity = DefaultListCapacity)
        {
            this.array = new T[initialCapacity];
        }

        /// <summary>
        /// Holds the number of elements that have been added to the GenericList.
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        /// <summary>
        /// Holds the current capacity of the GenericList. If the number of elements exceeds the capacity, the capacity is doubled.
        /// </summary>
        public int Capacity
        {
            get
            {
                return this.array.Length;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || this.Count <= index)
                {
                    throw new IndexOutOfRangeException("Index is outside the boundaries of the GenericList.");
                }

                return this.array[index];
            }
        }

        public static T Min<T>(GenericList<T> list)
            where T : IComparable
        {
            T min = default(T);
            for (int index = 0; index < list.Count; index++)
            {
                if (min.CompareTo(default(T)) == 0 || min.CompareTo(list[index]) == 1)
                {
                    min = list[index];
                }
            }

            return min;
        }

        public static T Max<T>(GenericList<T> list)
            where T : IComparable
        {
            T max = default(T);
            for (int index = 0; index < list.Count; index++)
            {
                if (max.CompareTo(default(T)) == 0 || max.CompareTo(list[index]) == -1)
                {
                    max = list[index];
                }
            }

            return max;
        }

        /// <summary>
        /// Adds the specified element at the end of the list.
        /// </summary>
        /// <param name="elementToAdd">The element to be added.</param>
        public void Add(T elementToAdd)
        {
            if (this.Count + 1 >= this.array.Length)
            {
                this.ResizeList();
            }

            this.array[this.Count] = elementToAdd;

            this.Count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || this.Count <= index)
            {
                throw new IndexOutOfRangeException("Index is outside the boundaries of the GenericList.");
            }

            T[] newArray = new T[this.array.Length];
            Array.Copy(this.array, 0, newArray, 0, index);
            Array.Copy(this.array, index + 1, newArray, index, this.Count - index - 1);

            this.Count--;
            this.array = newArray;
        }

        /// <summary>
        /// Inserts the new element at the specified index. 
        /// If there are empty positions between the index and the current last element, these positions are filled with default values depending on the type of the list.  
        /// </summary>
        /// <param name="index">The index where the new element will be inserted.</param>
        /// <param name="newElement">The element which will be added to the list.</param>
        public void InsertAt(int index, T newElement)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException("Index is outside the boundaries of the GenericList.");
            }

            int size = this.Capacity;

            while (index  + 1 >= size)
            {
                size *= 2;
            }

            T[] newArray = new T[size];
            Array.Copy(this.array, 0, newArray, 0, index);
            newArray[index] = newElement;

            if (index > this.Count)
            {
                this.Count = index + 1;
            }
            else
            {
                this.Count++;
                Array.Copy(this.array, index, newArray, index + 1, this.Count - index - 1);
            }

            this.array = newArray;
        }

        public void Clear()
        {
            this.array = new T[this.array.Length];
        }

        /// <summary>
        /// Searches for the first occurrence of the specified element in the list and returns its index if found, -1 otherwise.
        /// Compares value types by value and reference types by reference.
        /// </summary>
        /// <param name="elementToFind">The element to search for.</param>
        /// <returns>The zero-based index of the element or -1 if the element isn't found in the list.</returns>
        public int IndexOf(T elementToFind)
        {
            for (int index = 0; index < this.Count; index++)
            {
                if (object.ReferenceEquals(this.array[index], elementToFind))
                {
                    return index;
                }
                
                if (typeof(T).IsValueType && this.array[index].Equals(elementToFind))
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// Searches for the last occurrence of the specified element in the list and returns its index if found, -1 otherwise.
        /// Compares value types by value and reference types by reference.
        /// </summary>
        /// <param name="elementToFind">The element to search for.</param>
        /// <returns>The zero-based index of the element or -1 if the element isn't found in the list.</returns>
        public int LastIndexOf(T elementToFind)
        {
            for (int index = this.Count - 1; index >= 0; index--)
            {
                if (object.ReferenceEquals(this.array[index], elementToFind))
                {
                    return index;
                }
            }

            return -1;
        }

        public bool Exists(T elementToCheck)
        {
            bool exists = this.IndexOf(elementToCheck) != -1;
            return exists;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("{");

            for (int i = 0; i < this.Count; i++)
            {
                result.Append(this[i]);

                if (i != this.Count - 1)
                {
                    result.Append(", ");
                }
            }

            result.Append("}");

            return result.ToString();
        }

        private void ResizeList()
        {
            int newArraySize = this.array.Length * 2;
            T[] newArray = new T[newArraySize];

            Array.Copy(this.array, newArray, this.array.Length);
            this.array = newArray;
        }
    }
}
