using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Manasa is out on a hike with friends. 
 * She finds a trail of stones with numbers on them. 
 * She starts following the trail and notices that two consecutive stones 
 * have a difference of either a or b.
 * Legend has it that there is a treasure trove 
 * at the end of the trail and if Manasa can guess the value 
 * of the last stone, the treasure would be hers. 
 * Given that the number on the first stone was 0, find all the possible 
 * values for the number on the last stone. */

class Solution {

    static int[] stones(int n, int a, int b) {
        n--; // We have to start at 0 stones.
        List<int> possibles = new List<int>(); // List of all of possible outcomes.
        
        if(a == b) return new int[] { a * n }; // If a and b are equal, only 1 outcome.
        
        int largest = Math.Max(a, b); // Find the largest of the two increments.
        int smallest = Math.Min(a, b); // And the minimum.
        int smallCount = n; // And start the possibilities from the minimum.
        
        while(smallCount >= 0) { // Until smallcount is 0.
            int bigCount = n - smallCount; // Find the current big count, depending on small count.
            possibles.Add((smallCount * smallest) + (bigCount * largest)); // Multiply both together, to get possibility.
            smallCount--; // And decrease the smallcount.
        }
        
        return possibles.ToArray(); // Finally, return the list.
    }

    static void Main(String[] args) {
        int T = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < T; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int[] result = stones(n, a, b);
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
