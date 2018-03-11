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
        // Count all uppercase characters in string, and add 1 for first string.
        return s.Count(char.IsUpper) + 1;
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        int result = camelcase(s);
        Console.WriteLine(result);
    }
}
