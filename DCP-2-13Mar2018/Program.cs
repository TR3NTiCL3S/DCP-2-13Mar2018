using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Good morning. Here's your coding interview problem for today.
 * This problem was asked by Uber.
 * 
 * Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i. 
 * Solve it without using division and in O(n) time.
 * 
 * For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].
 * 
    */
namespace DCP_2_13Mar2018
{
    class Program
    {
        static void Main(string[] args)
        {
            testCase();
        }

        static void testCase()
        {
            int[] output;
            int[] input = new int[5] { 1, 2, 3, 4, 5 };
            output = processArray(input);
            for (int i = 0; i < output.Length; i++)
            {
                System.Console.Write(output[i] + " ");
            }
            System.Console.WriteLine();



            input = new int[3] { 3, 2, 1 };
            output = processArray(input);
            for(int i = 0; i < output.Length; i++)
            {
                System.Console.Write(output[i] + " ");
            }
            System.Console.WriteLine();

        }

        static int[] processArray(int[] input)
        {
            /* The kicker here is that they want it without division which means that
             * I can't just multiply the whole array and then divide by itself which
             * is probably the most elegant solution. The next obvious way to do this
             * would be to make a nested for loop, one for each element in the array 
             * and the next to multiply it, this will not be 0(n) time though.
             * 
             * This solution will be a  bit more RAM hungry but there is a downside 
             * to everything. The first will be to make a set of arrays so that there 
             * is one for each number in the input array. Then the i value will be 
             * changed to 1 so that it  is not significant in multiplication. Then
             * do the math
             * 
             * */

            int[] temp = new int[input.Length];
            int[] output = new int[input.Length];

            for(int i = 0; i < input.Length; i++)
            {
                Array.Copy(input, temp, input.Length);
                temp[i] = 1;
                // Not quite sure how this processes and fear it may not make this 0(n)
                output[i] = temp.Aggregate((int RP, int next) => RP * next);
            }

            return output;
        }
    }
}
