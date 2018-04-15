using System;

namespace Parcial3_Base
{
    internal static class Utils
    {
        public static string GetString(this int[,] A)
        {
            string result = string.Empty;

            if (A != null)
            {
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        result += string.Format("{0}  ", A[i, j]);
                    }

                    result += "\n";
                }
            }

            return result;
        }

        public static void Print(this int[,] A)
        {
            string stringMatrix = A.GetString();
            Console.WriteLine(string.IsNullOrEmpty(stringMatrix) ? "null" : stringMatrix);
        }

        public static void Print(this int[] arr)
        {
            string elements = string.Empty;

            for (int i = 0; i < arr.Length; i++)
            {
                elements += i == 0 ? arr[i].ToString() : string.Format(", {0}", arr[i]);
            }

            Console.WriteLine("arr = [{0}]", elements);
        }
    }
}