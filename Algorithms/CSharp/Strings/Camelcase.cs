using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Alice wrote a sequence of words in CamelCase as a string of letters, s, 
 * having the following properties:
 *
 * It is a concatenation of one or more words consisting of English letters.
 * All letters in the first word are lowercase.
 * For each of the subsequent words, the first letter is uppercase and rest of the letters are lowercase.
 *
 * Given , print the number of words in s on a new line. */

class Solution {

    static int camelcase(string s) {
        int wordCounts = 1; // Initial wordcount is 1, for the lowercase string.
        
        for(int i = 1; i < s.Length; i++) { // Iterate through the rest of the string.
            // If the uppercase of our current character is equal to the current character.
            if(s[i].ToString().ToUpper() == s[i].ToString()) {
                // Increase the word count.
                wordCounts++;
            }
        }
        
        // Finally, return the word count.
        return wordCounts;
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        int result = camelcase(s);
        Console.WriteLine(result);
    }
}
