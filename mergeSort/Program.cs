using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mergeSort
{
    class Program
    {
        /// <summary>
        /// Represent am algorithm for merging two sorted arrays 
        /// tmp is a helper temporary array
        /// The idea exploits the fact that the sorted array is located inside one big array 
        /// in a contiguous way
        /// </summary>
        static void merge(int[] arr, int start, int middle, int end)
        {
            int leftPtr = start;
            int rightPtr = middle + 1; //The very first element of the right array
            int len = end - start + 1;
            int[] tmp = new int[len]; //A temporary array to store result until it is written in the
            //given array
            for (int i = 0; i < len; i++)
            {
                //leftPtr > middle means that the left array is finished
                ////If the left side is finished, we have ‘false && smth’ = false anyway
                //If the right array is finished we get the true on the left side of || and it means that the right side won’t be checked
                if (rightPtr > end || (leftPtr <= middle && arr[leftPtr] < arr[rightPtr]))
               {
                    tmp[i] = arr[leftPtr];
                    leftPtr++;
                }
                else
                {
                    tmp[i] = arr[rightPtr];
                    rightPtr++;
                }
            }

            //Writing the result in the original array
            for(int i = 0; i < len; i++)
            {
                arr[start + i] = tmp[i];
            }
        } 

        static void mergeSort(int[]arr, int start, int end)
        {
            if (start == end)
                return;

            int middle = (start + end) / 2;
            mergeSort(arr, start, middle);
            mergeSort(arr, middle + 1, end);

            merge(arr, start, middle, end);
        }

        static void Main(string[] args)
        {
            int[] arr = {101, 4, 6, 8, 1, 39};

            mergeSort(arr, 0, arr.Length - 1);

            foreach (int el in arr)
                Console.WriteLine(el);
        }
    }
}
