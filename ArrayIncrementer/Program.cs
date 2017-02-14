using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayIncrementer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayToIncrement = new int[] { 2,7,8,9 };
            int[] result = IncrementArray(arrayToIncrement);
            Console.WriteLine(string.Format("Original array (preserved): {0}", string.Join("", arrayToIncrement)));
            Console.WriteLine(string.Format("New array: {0}", string.Join("", result)));
            Console.WriteLine("Hit 'Enter' to continue...");
            Console.ReadLine();

            int[] nextArrayToIncrement = new int[] { 9, 9, 9, 2 };
            for (int i = 1; i < 11; i++)
            {
                nextArrayToIncrement = IncrementArray(nextArrayToIncrement);
                Console.WriteLine(string.Join("", nextArrayToIncrement));
            }

            Console.WriteLine("Hit 'Enter' to end...");
            Console.ReadLine();
        }

        /// <summary>
        /// Returns a new array whose entries, if read as a single digit, is one digit
        /// higher than the provided array.
        /// </summary>
        /// <param name="arrayToIncrement">The array whose entries, when read as a single digit,
        /// is to be incremented by one.</param>
        /// <returns>A new array whose entries, if read as a single digit, is one digit
        /// higher than the provided array.</returns>
        private static int[] IncrementArray(int[] arrayToIncrement)
        {
            // Make a copy of the incoming array which we can modify
            int[] result = new int[arrayToIncrement.Length];
            arrayToIncrement.CopyTo(result, 0);

            // Move from right to left in the array checking digits
            // to increment them as necessary
            int lastIndexOfArray = result.Length - 1;
            for (int i = lastIndexOfArray; i >= 0; i--)
            {
                // If the digit is not 9, just increment it by 1 and you're done
                if (result[i] != 9)
                {
                    result[i]++;
                    break;
                }
                else
                {
                    // The digit is 9, so we have to set it to zero and
                    // loop again to increment the next digit; i.e. "carry the one"
                    result[i] = 0;

                    // If we need to "carry the one" again, but have reached
                    // the front of the array, we'll need to resize the array.
                    if (i == 0)
                    {
                        // Luckily, in this case, we'll always be creating an array
                        // whose first entry is 1, and the rest are zero. So
                        // initialize to all zeros, and set the first entry to 1.
                        result = new int[result.Length + 1];
                        result[0] = 1;
                    }
                }
            }

            return result;
        }
    }
}
