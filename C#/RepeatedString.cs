using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Lilah has a string, s, of lowercase English letters
 * that she repeated infinitely many times.
 * Given an integer, n, find and print the number of letter 
 * a's in the first n letters of Lilah's infinite string. */

class Solution {

    static long repeatedString(string s, long n) {
        long count = 0; // Counting the number of A's.
        long aCount = 0; // Holds how many A's in initial string.
        
        // Go through string, and add to aCount for every A.
        for(int i = 0; i < s.Length; i++) {
            if(s[i] == 'a') {
                aCount++;
            }
        }
        
        // Get the total number of times we can complete the string with n.
        long totals = n / s.Length;
        // Count is at least the number of times the string can be completed, multiplied by number of A's.
        count += (totals) * aCount;
        
        // Finally, we can iterate through the remainder.
        for(int i = 0; i < n % s.Length; i++) {
            if(s[i] == 'a') count++; 
        }
        
        return count;
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        long n = Convert.ToInt64(Console.ReadLine());
        long result = repeatedString(s, n);
        Console.WriteLine(result);
    }
}
