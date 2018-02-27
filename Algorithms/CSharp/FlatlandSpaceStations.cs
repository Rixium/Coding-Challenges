using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Flatland is a country with n cities, m of which have space stations. 
 * Each city, c, is numbered with a distinct index from 0 to n - 1, and
 * each city c is connected to c(n + 1) by a bidirectional road that is 1km in length.
 * For each city, determine its distance to the nearest space station and print the maximum of these distances.
 */

class Solution {

    static int flatlandSpaceStations(int n, int[] c) {
        Array.Sort(c); // Initially sorting the array from lowest to highest.
        int maxDistance = c[0]; // The max distance is initially going to be equal to the first value.
        
        for(int i = 1; i < c.Length; i++) // Iterating through every station.
        {
            // As we want the largest distance between two stations, we need to divide the distance in 2, to get the center point
            // between the two stations.
            int distance = (c[i] - c[i - 1]) / 2;
            
            // Finally, if the distance calculated is more than the max distance,
            // then it's the new max distance.
            if(distance > maxDistance)
                maxDistance = distance;            
        }
        
        // We now look for the distance between the number of cities, and the final station.
        // In cases where the final station isn't on the last city.
        int finalStation = n - 1 - c[c.Length - 1];
        
        // Depending on the value of final station, we either return it's value or the max distance found.
        return finalStation > maxDistance ? finalStation : maxDistance;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        int[] c = Array.ConvertAll(c_temp,Int32.Parse);
        int result = flatlandSpaceStations(n, c);
        Console.WriteLine(result);
    }
}