using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15
{

    internal class Program
    {
        public static void mergesort(int[] arr)
        {
            mergesort(arr, 0, arr.Length - 1);
        }

        private static void mergesort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                mergesort(arr, left, mid);
                mergesort(arr, mid + 1, right);
                merge(arr, left, mid, right);
            }
        }

        private static void merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftarray = new int[n1];
            int[] rightarray = new int[n2];
            Array.Copy(arr, left, leftarray, 0, n1);
            Array.Copy(arr, mid + 1, rightarray, 0, n2);
            int i = 0;
            var j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (leftarray[i] <= rightarray[j])
                {
                    arr[k] = leftarray[i];
                    i++;

                }
                else
                {
                    arr[k] = rightarray[j];
                    j++;

                }
                k++;

            }
            while (i < n1)
            {
                arr[k] = leftarray[i];
                i++;
                k++;

            }
            while (j < n2)
            {
                arr[k] = rightarray[j];
                j++;
                k++;
            }
        }


        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        public static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int PivotIndex = Partition(array, left, right);
                QuickSort(array, left, PivotIndex - 1);
                QuickSort(array, PivotIndex + 1, right);
            }
        }
        public static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }
        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] arr1 = { 38, 42, 65, 87, 11, 2, 6, 100 };
            int[] arr = { 38, 42, 65, 87, 11, 2, 6, 100 };

            Console.WriteLine("Before Sorting:");
            Print(arr);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            QuickSort(arr);
            sw.Stop();

            Console.WriteLine("After Quick Sorting:");
            Print(arr);
            Console.WriteLine("");
            Console.WriteLine("original array:" + string.Join(",", arr1));
            Stopwatch sw1 = Stopwatch.StartNew();
            sw1.Start();
            mergesort(arr1);
            sw1.Stop();
            Console.WriteLine("merge sorted array:" + string.Join(",", arr1));
            Console.WriteLine("");
            Console.WriteLine($"Array size: {arr.Length} Time Taken(Quick sort): {sw.Elapsed.TotalMilliseconds} milliseconds");
            Console.WriteLine($"Array Size: {arr.Length} Time taken(Merge Sort): {sw1.Elapsed.TotalMilliseconds} milliSeconds");
            Console.ReadKey();
        }
    }
}
