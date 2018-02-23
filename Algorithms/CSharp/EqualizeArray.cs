using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Karl has an array of n integers. In one operation, he can delete any element from the array.
 * Karl wants all the elements of the array to be equal to one another. 
 * To do this, he must delete zero or more elements from the array. 
 * Find and print the minimum number of deletion operations Karl must 
 * perform so that all the array's elements are equal.
 */


class Solution {

    static int equalizeArray(int[] arr) {
        
        int bigCount = 1; // Most occurring number count.
        int number = arr[0]; // Most occurring number.
        
        for(int i = 0; i < arr.Length; i++) {
            int currCount = 1; // Initialising count of current iteration number.
            for(int j = 0; j < arr.Length; j++) {
                if(i == j) continue; // Don't count the same index.
                
                if(arr[i] == arr[j]) currCount++; // If the numbers are equal, increment the count;
            }
            
            if(currCount > bigCount) { 
                bigCount = currCount; // If current occurs more, set the bigcount.
                number = arr[i]; // Set the most occurring to current number.
            }
        }
        
        return Math.Abs(bigCount - arr.Length); // Finally, return the absolute count - the arr length,
												// to find the changes.
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        int result = equalizeArray(arr);
        Console.WriteLine(result);
    }
}
