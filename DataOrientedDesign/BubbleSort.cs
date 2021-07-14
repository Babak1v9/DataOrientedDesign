using System;
using System.Collections.Generic;
using System.Text;

namespace DataOrientedDesign {
    class BubbleSort {

        public int[] SortArray(int[] array) {

            int temp = 0;

            for (int write = 0; write < array.Length; write++) {
                for (int sort = 0; sort < array.Length - 1; sort++) {
                    if (array[sort] > array[sort + 1]) {
                        temp = array[sort + 1];
                        array[sort + 1] = array[sort];
                        array[sort] = temp;
                    }
                }
            }
            return array;
        }

        public SWP_Struct.SWP[] SortArray(SWP_Struct.SWP[] array)
        {
            int temp = 0;

            for (int write = 0; write < array.Length; write++)
            {
                for (int sort = 0; sort < array.Length - 1; sort++)
                {
                    if (array[sort].V1 > array[sort + 1].V1)
                    {
                        temp = array[sort + 1].V1;
                        array[sort + 1].V1 = array[sort].V1;
                        array[sort].V1 = temp;
                    }
                }
            }
            return array;
        }
    }
}
