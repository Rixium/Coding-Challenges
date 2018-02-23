using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * You are given the two positive integers p and q, where p is lower than q. 
 * Write a program to determine how many Kaprekar numbers there are in 
 * the range between p and q (both inclusive) and display them all.
 */

class Solution {

    static void kaprekarNumbers(int p, int q) {
        List<int> values = new List<int>(); // A list to store all possible numbers.

        for(int n = p; n <= q; n++) { // Checking the range.
            string square = Math.Pow(n, 2) + ""; // Converting the power to a string for comparisons.

            if(square.Length == 1) { // If the squares length is 1, then we can't split it into half.
                if(Math.Pow(n, 2) == n) { // Check if the power is equal to the number.
                    values.Add(n); // If it is, then it's a valid number.
                }
                continue; // We don't need to continue this iteration.
            }
            
            // We need to split the square into two halves, using parse, and substring.
            int left = Int32.Parse(square.Substring(0, square.Length / 2));
            int right = Int32.Parse(square.Substring(square.Length / 2));
            
            // If the left and right sum to n, then it is a valid number.
            if(left + right == n) {
                values.Add(n);
            }
        }
        
        if(values.Count != 0) {
            Console.WriteLine(String.Join(" ", values.ToArray()));
            return;
        }
        
        // If there are no numbers in our values
        Console.WriteLine("INVALID RANGE");
    }

    static void Main(String[] args) {
        int p = Convert.ToInt32(Console.ReadLine());
        int q = Convert.ToInt32(Console.ReadLine());
        kaprekarNumbers(p, q);
    }
}
