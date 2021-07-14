using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrientedDesign {
    class CountingSort {

        public int[] SortArray(int[] array) {

            int[] sortedArray = new int[array.Length];

            // find smallest and largest value
            int minVal = array[0];
            int maxVal = array[0];
            for (int i = 1; i < array.Length; i++) {
                if (array[i] < minVal) minVal = array[i];
                else if (array[i] > maxVal) maxVal = array[i];
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < array.Length; i++) {
                counts[array[i] - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++) {
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = array.Length - 1; i >= 0; i--) {
                sortedArray[counts[array[i] - minVal]--] = array[i];
            }

            return sortedArray;
        }

        public SWP_Struct.SWP[] SortArray(SWP_Struct.SWP[] array)
        {

            SWP_Struct.SWP[] sortedArray = new SWP_Struct.SWP[array.Length];

            // find smallest and largest value
            int minVal = array[0].V1;
            int maxVal = array[0].V1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].V1 < minVal) minVal = array[i].V1;
                else if (array[i].V1 > maxVal) maxVal = array[i].V1;
            }

            // init array of frequencies
            int[] counts = new int[maxVal - minVal + 1];

            // init the frequencies
            for (int i = 0; i < array.Length; i++)
            {
                counts[array[i].V1 - minVal]++;
            }

            // recalculate
            counts[0]--;
            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }

            // Sort the array
            for (int i = array.Length - 1; i >= 0; i--)
            {
                sortedArray[counts[array[i].V1 - minVal]--] = array[i];
            }

            return sortedArray;
        }
    }
}
