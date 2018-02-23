using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Given an integer, N , traverse its digits (1,2,...,n) and determine how many digits evenly divide N
 * (i.e.: count the number of times N divided by each digit i has a remainder of 0). 
 * Print the number of evenly divisible digits. */
 
class Solution {

    static int CheckDivisible(int count, int startNumber, int currentNumber) {
        if(currentNumber == 0) return count; // If the current number is 0, return the count.
        
        if(currentNumber % 10 != 0) { // Check the current number doesn't divide equally in to 10.
            if(startNumber % (currentNumber % 10) == 0) { // If so, check if start number can divide into the remainder.
                count++; // Increment the count.
            }
        }
        
        return CheckDivisible(count, startNumber, currentNumber / 10); // Finally, recall the function with the new values.
    }

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(CheckDivisible(0, n, n));
        }
    }
}
