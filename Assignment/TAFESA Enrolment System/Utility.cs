using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System
{
    public class Utility
    {
        /// <summary>
        /// Binary search method that looks for any generic parameter within an array
        /// Note: Array must be sorted before passing the array to this method
        /// </summary>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearchArray<T>(T[] array, T target) where T : IComparable<T>
        {
            int min = 0;
            int max = array.Length - 1;
            int mid;

            while (min <= max) // Binary search
            {
                mid = (min + max) / 2;

                // Compare the criteriaSearch with the middle element of the array
                if (target.CompareTo(array[mid]) == 0)  // If they are equal, return the index mid
                    return mid;

                if (target.CompareTo(array[mid]) > 0)   // If criteriaSearch is greater, search in the upper half
                    min = mid + 1;
                else                        // Otherwise, search in the lower half
                    max = mid - 1;
            }

            return -1;  // -1 is returned when not found 
        }
        /// <summary>
        /// Linear search method that looks for any generic parameter within an array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int LinearSeachArray<T>(T[] array, T target) where T:IComparable<T> //
        {
            int i = 0;
            bool found = false;

            while (!found && i < array.Length) //While not found and not at the end of the array
            {
                if (target.CompareTo(array[i])==0)
                    found = true;
                else
                    i++; //If no match, then move to the next element
            }

            if (i < array.Length)
                return i; // Return index
            else
                return -1; // If not found
        }
        /// <summary>
        /// Bubble sort method of Type <T> to sort in ascending order 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void BubbleSort<T>(T[] array) where T : IComparable<T>
        {
            //bool swapped;

            for (int i = 0; i < array.Length - 1; i++)
            {
               // Last i elements are already sorted, so the inner loop can go till n-i-1
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    // Compare adjacent elements and swap if they are in the wrong order
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        // Swap array[j] and array[j + 1]
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        /// <summary>
        /// Selection sort method of Type <T> to sort in descending order 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void SelectionSortDescending<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                // Assume the i-th element is the largest
                int maxIndex = i;

                // Find the largest element in the unsorted portion of the array
                for (int j = i + 1; j < array.Length; j++)
                {
                    // If the current element is greater than the current max, update maxIndex
                    if (array[j].CompareTo(array[maxIndex]) > 0)
                    {
                        maxIndex = j;
                    }
                }

                // Swap the largest element found with the i-th element
                if (maxIndex != i)
                {
                    T temp = array[i];
                    array[i] = array[maxIndex];
                    array[maxIndex] = temp;
                }
            }
        }




    }
}
