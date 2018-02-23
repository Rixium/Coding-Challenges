using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Consider an array of n integers. The distance between two indices, i and j, is denoted by d = i - j.
 *
 * Given A, find the minimum d such that i == j. In other words, find the minimum distance between any pair of equal elements in the 
 * array. If no such value exists, print -1.
 */

class Solution {

    static int minimumDistances(int[] a) {
        int minimum = -1; // Initial value, incase no pair is found.
        
        for(int i = 0; i < a.Length - 1; i++) { // Iterating through all pairs.
            int val = a[i]; // Value is equal to current iteration of i.
            for(int j = i + 1; j < a.Length; j++) {
                if(a[j] == val) { // If j value is equal to i value, we can use it in the test.
                     // Check that the absolute difference is less than the minimum.
                    // Or if minimum is -1, we should set it regardless.
                    if(Math.Abs(i - j) < minimum || minimum == -1) {
                        minimum = Math.Abs(i - j);
                    }
                }
            }
        }
        
        return minimum;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp,Int32.Parse);
        int result = minimumDistances(a);
        Console.WriteLine(result);
    }
}
