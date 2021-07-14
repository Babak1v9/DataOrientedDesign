using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DataOrientedDesign {
    class Program {

        const int cacheSize = 12 * 1024 * 1024; 

        static void ClearCache()
        {
            int[] buffA = new int[cacheSize];
            int[] buffB = new int[cacheSize];

            Array.Copy(buffA, buffB, cacheSize);
            
        }

        static SWP_Struct.SWP[] GetStructArray(string name)
        {
            string filename = $"{name}.csv";

            string destPath = Path.Combine("..\\..\\..\\..\\DataOrientedDesign\\Arrays\\", filename);

            using var sr = new StreamReader(destPath);

            var list = new List<SWP_Struct.SWP>();

            while (!sr.EndOfStream)
            {
                var swp = new SWP_Struct.SWP();
                var line = sr.ReadLine();
                var values = line.Split(',');

                int count = 0;

                foreach(string elm in values)
                {
                    if(elm == "")
                    {
                        continue;
                    }

                    if(count == 0)
                    {
                        swp.V1 = Int32.Parse(elm);
                    }
                    if(count == 1)
                    {
                        swp.V2 = Int32.Parse(elm);
                    }
                    if(count == 2)
                    {
                        swp.V3 = elm;
                    }
                    if(count == 3)
                    {
                        swp.V4 = elm;
                        list.Add(swp);
                        count = -1;
                    }
                    count++;
                }
            }

            return list.ToArray();
        }


        static int[] GetIntArray(string name)
        {
            string filename = $"{name}.csv";

            string destPath = Path.Combine("..\\..\\..\\..\\DataOrientedDesign\\Arrays\\", filename);

            using var sr = new StreamReader(destPath);

            var list = new List<int>();

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var values = line.Split(',');
                foreach(var elm in values)
                {
                    if(elm != "")
                    {
                        list.Add(Int32.Parse(elm));
                    }        
                }
            }

            return list.ToArray();
        }

        static int[] MockArray()
        {
            int[] array = { 31, 123, 33, 21, 1, 43, 53 };
            return array;
        }

        private static void PrintTime(TimeSpan elapsed) {
            Console.WriteLine("\nTime spent: " + elapsed);
            TimeSpan ts = elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }


        static void Main(string[] args) {

            Stopwatch sw = new Stopwatch();
            
            BubbleSort bs = new BubbleSort();
            CountingSort cs = new CountingSort();
            SelectionSort ss = new SelectionSort();

            //Variationen
            //Array 


            Console.WriteLine("Which algorithm do you want to benchmark? \n" +
                "(c -> Counting Sort, b -> Bubble Sort, s -> Selection Sort)" );
            var choice = Console.ReadLine();

            Console.WriteLine("Which Array do you want to benchmark? \n" +
                "(f -> FatArray, t -> ThinArray, s -> StructArray, o -> ZeroOneArray, z -> ZeroTenThousandArray)");

            var ArrayChoice = Console.ReadLine();

            ClearCache();

            int[] array1;

            SWP_Struct.SWP[] array2;

            if(ArrayChoice == "f")
            {
                array1 = GetIntArray("FatArray");
                array2 = new SWP_Struct.SWP[1];
            }
            else
            if(ArrayChoice == "t")
            {
                array1 = GetIntArray("ThinArray");
                array2 = new SWP_Struct.SWP[1];
            }
            else
            if(ArrayChoice == "s")
            {
                array1 = new int[1];
                array2 = GetStructArray("ThinStructArray");
            }else
            if(ArrayChoice == "o")
            {
                array1 = GetIntArray("ZeroOneArray");
                array2 = new SWP_Struct.SWP[1];
            }
            else
            if(ArrayChoice == "z")
            {
                array1 = GetIntArray("ZeroTenThousandArray");
                array2 = new SWP_Struct.SWP[1];
            }
            else
            {
                array1 = new int [1];
                array2 = new SWP_Struct.SWP[1];
                Console.WriteLine("No array selected");
                Environment.Exit(0);
            }
            


            int[] sortedArray;

            SWP_Struct.SWP[] StructArray;

            if (choice == "b" && ArrayChoice != "s")
            {
                //first algorithm

                Console.WriteLine("\nBubble Sort:");
                sw.Start();
                sortedArray = bs.SortArray(array1);
                sw.Stop();

                //output sorted array + Time
                //PrintArray(sortedArray);
                PrintTime(sw.Elapsed);

                sw.Reset();
            }
            else
            if (choice == "c" && ArrayChoice != "s")
            {
                //second algorithm
                Console.WriteLine("\nCounting Sort:");
                sw.Start();
                sortedArray = cs.SortArray(array1);
                sw.Stop();

                //PrintArray(sortedArray);
                PrintTime(sw.Elapsed);

                sw.Reset();
            }
            else
            if (choice == "s" && ArrayChoice != "s")
            {
                //third algorithm
                Console.WriteLine("\nSelection Sort:");
                sw.Start();
                sortedArray = ss.SortArray(array1, array1.Length);
                sw.Stop();

                //PrintArray(sortedArray);
                PrintTime(sw.Elapsed);
            }else
            if (choice == "b" && ArrayChoice == "s")
            {
                //first algorithm

                Console.WriteLine("\nBubble Sort:");
                sw.Start();
                StructArray = bs.SortArray(array2);
                sw.Stop();

                //output sorted array + Time
                //PrintArray(sortedArray);
                PrintTime(sw.Elapsed);

                sw.Reset();
            }
            else
            if (choice == "c" && ArrayChoice == "s")
            {
                //second algorithm
                Console.WriteLine("\nCounting Sort:");
                sw.Start();
                StructArray = cs.SortArray(array2);
                sw.Stop();

                //PrintArray(sortedArray);
                PrintTime(sw.Elapsed);

                sw.Reset();
            }
            else
            if (choice == "s" && ArrayChoice == "s")
            {
                //third algorithm
                Console.WriteLine("\nSelection Sort:");
                sw.Start();
                StructArray = ss.SortArray(array2, array2.Length);
                sw.Stop();

                //PrintArray(sortedArray);
                PrintTime(sw.Elapsed);
            }

            else
            {
                Console.WriteLine("No Algorithm selected");
                Environment.Exit(0);
            }
                
                

        }
    }
}
