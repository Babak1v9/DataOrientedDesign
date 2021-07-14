using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArrayCreator
{
    public class IntArray
    {
        public static int[] GenerateIntArray(int intsInCache)
        {
            int Min = 0;
            int Max = 1000;

            int[] array = new int[intsInCache];

            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(Min, Max);
            }
            return array;
        }

        public static int[] GenerateIntArray(int intsInCache, int Min, int Max)
        {

            int[] array = new int[intsInCache];

            Random randNum = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randNum.Next(Min, Max);
            }

            return array;
        }

        public static void PrintIntArray(int[] array, string name)
        {
            string filename = $"{name}.csv";

            string destPath = Path.Combine("..\\..\\..\\..\\DataOrientedDesign\\Arrays\\", filename);

            using StreamWriter sw = File.CreateText(destPath);
            foreach (var elm in array)
            {
                sw.Write(elm.ToString());
                sw.Write(",");
            }
            sw.Flush();
            sw.Close();
        }
    }
}
