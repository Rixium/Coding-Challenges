using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Watson gives two integers (A and B) to Sherlock and asks if he can 
 * count the number of square integers between A and B (both inclusive).
 * Note: A square integer is an integer which is the square of any integer. 
 * For example, 1, 4, 9, and 16 are some of the square integers as 
 * they are squares of 1, 2, 3, and 4, respectively. */

class Solution {
    
    static int CountSquares(int start, int end, int count) {
        if(start > end) return count; // Return the count if we're passed the end.
        
        float sqrt = (float)Math.Sqrt(start); // Get the square root as a float, so we can check remainder.

        if(sqrt % 1 != 0) { // If the remainder isn't zero, it's not a square number, so increment the start.
            return CountSquares(++start, end, count);
        }
        
        // If the remainder is zero, then it is a square number, so we can increment the count.
        // Square numbers have a pattern of (2 * sqrt) + 1 of the previous square.
        // Example:
        // Square root of 4 is 2.
        // (2 * 2) + 1 is 5
        // Therefore, the next square is, 4 + 5 = 9.
        // We reduce the redundant loops with this.
        
        return CountSquares(start + (int)(2 * sqrt) + 1, end, ++count);
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string[] tokens_a = Console.ReadLine().Split(' ');
            int a = Convert.ToInt32(tokens_a[0]);
            int b = Convert.ToInt32(tokens_a[1]);
            int result = CountSquares(a, b, 0);
            Console.WriteLine(result);
        }
    }
}