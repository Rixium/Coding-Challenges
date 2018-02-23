using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Erica wrote an increasing sequence of n numbers in her notebook.
 * Given the sequence and the value of d, can you help Erica count 
 * the number of beautiful triplets in the sequence?
 */

class Solution {

    static int beautifulTriplets(int d, int[] arr) {
        int count = 0; // Stores all possible beautiful triplets.
        
        for(int i = 0; i < arr.Length - 1; i++) {
            int currTest = arr[i]; // Setting our current number check.
            int currentCount = 1; // Amount of numbers in the sequence.
            for(int j = i + 1; j < arr.Length; j++) {
                if(i == j) continue;
                
                if(arr[j] == currTest + d) { // If the current iteration is d size more than d, then we can add it to the                                                           // currentcount.
                    currentCount++;
                    
                    if(currentCount == 3) { // If the count is 3, then it's a beautiful triplet.
                        count++; // So we can add it to our count, and break.
                        break;
                    }
                    
                    currTest = arr[j];
                } else if (arr[j] > currTest + d) { // We don't need to keep checking if the value is more than the curr test + d;
                    break;
                }
            }
        }
        
        return count;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int d = Convert.ToInt32(tokens_n[1]);
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        int result = beautifulTriplets(d, arr);
        Console.WriteLine(result);
    }
}
