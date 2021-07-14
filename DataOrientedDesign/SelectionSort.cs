using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrientedDesign {
    class SelectionSort {

        public int[] SortArray(int[] arr, int n) {
            int temp, smallest;
            for (int i = 0; i < n - 1; i++) {
                smallest = i;
                for (int j = i + 1; j < n; j++) {
                    if (arr[j] < arr[smallest]) {
                        smallest = j;
                    }
                }
                temp = arr[smallest];
                arr[smallest] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }

        public SWP_Struct.SWP[] SortArray(SWP_Struct.SWP[] arr, int n)
        {
            int temp, smallest;

            for (int i = 0; i < n - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j].V1 < arr[smallest].V1)
                    {
                        smallest = j;
                    }
                }
                temp = arr[smallest].V1;
                arr[smallest] = arr[i];
                arr[i].V1 = temp;
            }

            return arr;
        }
    }
}
