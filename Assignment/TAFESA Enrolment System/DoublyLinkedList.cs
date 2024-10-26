using System;
using System.Collections;
using System.Collections.Generic;

namespace TAFESA_Enrolment_System
{
    /// <summary>
    /// Represents a doubly linked list that supports generic type T.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }

            public Node(T value)
            {
                Value = value;
                Next = null;
                Previous = null;
            }
        }

        public Node Head { get; set; }
        public Node Tail { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the list.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Adds an item at the start of the list.
        /// </summary>
        /// <param name="value">The value to add to the list.</param>
        public void AddFirst(T value)
        {
            var node = new Node(value)
            {
                Next = Head
            };

            if (Head != null)
            {
                Head.Previous = node;
            }
            Head = node;

            if (Count == 0)
            {
                Tail = Head;
            }

            Count++;
        }

        /// <summary>
        /// Adds an item at the end of the list.
        /// </summary>
        /// <param name="value">The value to add to the list.</param>
        public void AddLast(T value)
        {
            var node = new Node(value);

            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }

            Tail = node;
            Count++;
        }

        /// <summary>
        /// Removes the first node of the list.
        /// </summary>
        public void RemoveFirst()
        {
            if (Count > 0)
            {
                if (Head.Next != null)
                {
                    Head = Head.Next;
                    Head.Previous = null;
                }
                else
                {
                    Head = Tail = null;
                }

                Count--;
            }
        }

        /// <summary>
        /// Removes the last node of the list.
        /// </summary>
        public void RemoveLast()
        {
            if (Count == 0) return;

            if (Count == 1)
            {
                Head = Tail = null;
            }
            else
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }

            Count--;
        }

        /// <summary>
        /// Adds an item at the beginning of the list, implementing ICollection<T>.
        /// </summary>
        /// <param name="item">The item to add to the list.</param>
        public void Add(T item) => AddLast(item);

        /// <summary>
        /// Determines whether the list contains a specific value.
        /// </summary>
        /// <param name="item">The value to locate in the list.</param>
        /// <returns>true if the value is found; otherwise, false.</returns>
        public bool Contains(T item)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                    return true;

                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Copies the elements of the list to an array, starting at the specified array index.
        /// </summary>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">The zero-based index in the array at which copying begins.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            var current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the list is read-only. Always false.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Removes the first occurrence of a specific value from the list.
        /// </summary>
        /// <param name="item">The value to remove from the list.</param>
        /// <returns>true if the value was successfully removed; otherwise, false.</returns>
        public bool Remove(T item)
        {
            Node current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        Head = current.Next; // Remove head
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        Tail = current.Previous; // Remove tail
                    }

                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list, starting at the head.
        /// </summary>
        /// <returns>An enumerator for the list.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list, starting at the tail.
        /// </summary>
        /// <returns>An enumerator for the list.</returns>
        public IEnumerable<T> TraverseBackward()
        {
            var current = Tail;
            while (current != null)
            {
                yield return current.Value;
                current = current.Previous;
            }
        }

        /// <summary>
        /// Clears all nodes from the list.
        /// </summary>
        public void Clear()
        {
            Head = Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the list.
        /// </summary>
        /// <returns>An enumerator for the list.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
