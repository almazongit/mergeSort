using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Collections;

namespace laba1
{

    class textSort
    {

        public static T[] removeDuplicates<T>(T[] array)
        {
            HashSet<T> set = new HashSet<T>(array);
            T[] result = new T[set.Count];
            set.CopyTo(result);
            return result;
        }

        public void MergeArray(string[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            string[] leftTempArray = new string[leftArrayLength];
            string[] rightTempArray = new string[rightArrayLength];
            int i, j;

            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];

            i = 0;
            j = 0;
            int k = left;

            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i].Length <= rightTempArray[j].Length)
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }

            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }

            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }
        public string[] SortArray(string[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;

                SortArray(array, left, middle);
                SortArray(array, middle + 1, right);

                MergeArray(array, left, middle, right);
            }

            return array;
        }


        static void Main(string[] args)
        {

            char[] Delimiters = { ',', ' ', ';' };
            Console.WriteLine("Введите текст: ");
            string text = Console.ReadLine();
            // text = "hello my hello friend and your my friend";
            string[] words = text.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
            words = removeDuplicates(words);

            textSort sortFunction = new textSort();
            words = sortFunction.SortArray(words, 0, words.Length - 1);
            foreach (var item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
