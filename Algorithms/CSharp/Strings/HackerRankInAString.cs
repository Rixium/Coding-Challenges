using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* We say that a string, s, contains the word hackerrank if a 
 * subsequence of the characters in s spell the word hackerrank. 
 * For example, haacckkerrannkk does contain hackerrank, but haacckkerannk does not 
 * (the characters all appear in the same order, but it's missing a second r).
 * 
 * You must answer q queries, where each query consists of a string, s. 
 * For each query, print YES on a new line if contains hackerrank; otherwise, print NO instead. */
 
class Solution {

    static string hackerrankInString(string s) {
        int expectedChar = 0; // Setting expectedCharacter index for our teststring.
        char[] testString = new char[] { 'h', 'a', 'c', 'k', 'e', 'r', 'r', 'a', 'n', 'k'}; // Defining our testString.
        
		// Iterate til end of string.
        for(int i = 0; i < s.Length; i++) {
			// If the character at s[i] is equal to our testing character, than we can increment the character test.
            if(s[i] == testString[expectedChar]) expectedChar++;
			// If we have reached the end of the testString, then we have found the subsequence, return "YES".
            if(expectedChar == testString.Length) return "YES";
        }
        
		// If we didn't return "YES" yet, then we can only return "NO".
        return "NO";
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            string s = Console.ReadLine();
            string result = hackerrankInString(s);
            Console.WriteLine(result);
        }
    }
}
