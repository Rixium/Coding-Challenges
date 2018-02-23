using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * You are given N sticks, where the length of each stick is a positive integer. 
 * A cut operation is performed on the sticks such that all of them are reduced by the 
 * length of the smallest stick.
 *
 * Suppose we have six sticks of the following lengths:
 *
 * 5 4 4 2 2 8
 *
 * Then, in one cut operation we make a cut of length 2 from each of the six sticks. 
 * For the next cut operation four sticks are left (of non-zero length), 
 * whose lengths are the following:
 *
 * 3 2 2 6
 *
 * The above step is repeated until no sticks are left.
 *
 * Given the length of N sticks, print the number of sticks that are left before each 
 * subsequent cut operations.
 */
 
class Solution {

    static int[] cutTheSticks(int[] arr) {
        Array.Sort(arr); // Initially sort the array, smallest to largest.
        List<int> cuts = new List<int>(); // A list of all the cuts we do.
        
        while(arr[arr.Length - 1] > 0) { // While the last sticks length is more than 0.
            int cutCount = 0; // Initialise a cut count for this iteration.
            int smallest = -1; // Store the smallest stick.
            for(int i = 0; i < arr.Length; i++) { // Iterate through the stick list.
                if(arr[i] > 0) { // If the length of the stick is more than 0.
                    if(smallest == -1) { // If we haven't set the smallest stick.
                        smallest = arr[i]; // The smallest stick must be the current iteration, as it's ordered.
                    }
                    
                    arr[i] -= smallest; // Subtract the smallest stick size off the current iteration stick.
                    cutCount++; // Increment the stick cut count.
                }
            }
            cuts.Add(cutCount); // Finally, add our cuts to the list.
        }
        
        return cuts.ToArray(); // Return the cut results.
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        int[] result = cutTheSticks(arr);
        Console.WriteLine(String.Join("\n", result));
    }
}
