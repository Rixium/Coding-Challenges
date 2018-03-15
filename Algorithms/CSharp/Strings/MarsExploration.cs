using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Letters in some of the SOS messages are altered by cosmic radiation during transmission. 
 * Given the signal received by Earth as a string, s, 
 * determine how many letters of Sami's SOS have been changed by radiation. */

class Solution {

    static int marsExploration(string s) {
        
        char[] sosString = new char[] { 'S', 'O', 'S' }; // Defining our expected character sequence.
        int expected = 0; // Starting from index 0 ['S']
        int changed = 0; // And our changed to count incorrect sequence characters.
        
        // Iterate through entire string.
        for(int i = 0; i < s.Length; i++) {
			// If expect > final character of array, reset to 0, as expected.
            if(expected > sosString.Length - 1) expected = 0;
			// If the character isn't equal to expected, then incremented changed.
            if(s[i] != sosString[expected]) changed++;
            // Increment expected, for next character check.
            expected++;
        }
        
		// Finally, return the changed count;
        return changed;
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        int result = marsExploration(s);
        Console.WriteLine(result);
    }
}
