using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Given the entry and exit point of Calvin's vehicle in the service lane, output the type of the largest vehicle which can pass
 * through the service lane (including the entry and exit segments).
 */

class Solution {

    static int[] serviceLane(int[] width, int[][] cases) {
        int[] maximums = new int[cases.Length];

        for(int i = 0; i < cases.Length; i++) { // Iterate through every case.
            int start = cases[i][0]; // Entrance point.
            int end = cases[i][1]; // Exit point.
            int[] newRange = new int[end - start + 1]; // To store all of the widths, between start and exit.
            Array.Copy(width, start, newRange, 0, end - start + 1); // Copy the values between the range into new array.
            maximums[i] = newRange.Min(); // Take the minimum value, for largest possible vehicle.
        }
        
        return maximums;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int t = Convert.ToInt32(tokens_n[1]);
        string[] width_temp = Console.ReadLine().Split(' ');
        int[] width = Array.ConvertAll(width_temp,Int32.Parse);
        int[][] cases = new int[t][];
        
        for(int cases_i = 0; cases_i < t; cases_i++){
           string[] cases_temp = Console.ReadLine().Split(' ');
           cases[cases_i] = Array.ConvertAll(cases_temp,Int32.Parse);
        }
        int[] result = serviceLane(width, cases);
        Console.WriteLine(String.Join("\n", result));
    }
    
}