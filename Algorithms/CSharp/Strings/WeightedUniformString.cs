using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* A weighted string is a string of lowercase English letters where each 
 * letter has a weight in the inclusive range from 1 to 26.
 * 
 * We define the following terms:
 * 
 * The weight of a string is the sum of the weights of all the string's characters.
 * A uniform string is a string consisting of a single character repeated zero or more times. 
 * For example, ccc and a are uniform strings, but bcb and cd are not (i.e., they consist of more than one distinct character).
 * 
 * Given a string, s, let U be the set of weights for all 
 * possible uniform substrings (contiguous) of string . 
 * You have to answer n queries, where each query i consists of a 
 * single integer, x. 
 * For each query, print Yes on a new line if x is in U; 
 * otherwise, print No instead. */
 
class Solution {

	// A hashset of our calculated weights in the string.
    static HashSet<int> weights = new HashSet<int>();
    
    private static void GetWeights(string s) {
		// A character bias, 'a' is character code 97, so we deduct 96, to make it 1.
        int bias = 96;
		// Our accumulative value of a character sequence.
        int accumulative = 0;

		// Iterate through the entire string.
        for(int c = 0; c < s.Length; c++) {
            bool shouldReset = false; // Reset flag, if the next character isn't the same.

			// Add the current character minus the bias to our accumulative weight.
            accumulative += s[c] - bias;
            
			// If the accumulative value isn't in weights, then add it.
            if(!weights.Contains(accumulative))  weights.Add(accumulative);
            
			// Only do this test if we're not at last character.
            if(c < s.Length - 1) {
				// If next character is not the same, we can reset our accumulative value.
                if(s[c] != s[c + 1]) shouldReset = true;
            } else {
				// Also if we're at last character, we can reset the accumulative.
                shouldReset = true;
            }

			// If we should reset, then reset accumulative value.
            if(shouldReset) {
                accumulative = 0;
            }
        }
    }
    
    static void Main(String[] args) {
        string s = Console.ReadLine();
        int n = Convert.ToInt32(Console.ReadLine());
        
		// Calculating all the available weights.
        GetWeights(s);
        
        for(int a0 = 0; a0 < n; a0++){
            int x = Convert.ToInt32(Console.ReadLine());
			// If the inputted value is in the weights.
            if(weights.Contains(x)) {
				// We can print "Yes".
                Console.WriteLine("Yes");
                continue;
            }
			// Else we print "No".
            Console.WriteLine("No");
        }
    }
}