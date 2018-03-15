using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* In this challenge, you will be given a string. 
 * You must remove characters until the string is made up of any two alternating characters. 
 * When you choose a character to remove, all instances of that character must be removed. 
 * Your goal is to create the longest string possible that contains just two alternating letters.
 *
 * As an example, consider the string abaacdabd. If you delete the character a, 
 * you will be left with the string bcdbd. 
 * Now, removing the character c leaves you with a valid string bdbd having a length of 4.
 * Removing either b or d at any point would not result in a valid string.
 *
 * Given a string , convert it to the longest possible string  
 * made up only of altrenating characters. 
 * Print the length of string  on a new line. 
 * If no string  can be formed, print 0 instead. */

class Solution {

    static int twoCharaters(string s) {
        int maxStringLength = 0; // Stores the longest string with alternating characters.
        List<char[]> occurringPairs = new List<char[]>(); // Stores all of the possible pairs of characters.
        
		
		// Creating our pairs.
        for(int i = 0; i < s.Length; i++) { // Iterating until end of string.
            char c1 = s[i]; // Setting currChar equal to the value at the s[i] index.
            for(int j = 0; j < s.Length; j++) { // Iterate until end of string again.
                if(i == j) continue; // Ignoring same index.
                
                char c2 = s[j]; // Getting value of second character at s[j] index.
                
                if(c1 != c2) { // If they're not the same, they can be a pair.
                    char[] a = new char[] { c1, c2 }; // Create my pair array.
                    bool canAdd = true; // Flag to check if we can add it.
                    
                    foreach(var p in occurringPairs) { // Checking all the current pairs in our list.
                        if((p[0] == c1 && p[1] == c2) || (p[0] == c2 && p[1] == c1)) { // Checking both left and right values of the occurringPair.
                            canAdd = false; // If their is a similar pair, we can't add this pair, so set the flag as false.
                            break; // and break.
                        }
                    }
                    
                    if(canAdd) occurringPairs.Add(a); // If we can add it, then put it in the list.
                }
            }
        }
        
        // Finally, using our occurringPairs to calculate the longest string.
        foreach(var p in occurringPairs) { // For each pair.
            string currString = ""; // Create a new string for this pair.
            for(int i = 0; i < s.Length; i++) { // Iterate through the entire string.
                if(s[i] != p[0] && s[i] != p[1]) continue; // If the index of s[i] is equal to either of the values in our pair, then we skip.
                
                currString += s[i]; // Otherwise add it to the string.
            }
            
            bool canAdd = true; // A flag to check if we can test it for maxStringLength.
            
			// Iterate through entire string again.
            for(int i = 1; i < currString.Length; i++) {
				// If the value before i, is the same character, then they're not alternating, so we can't add it.
                if(currString[i] == currString[i - 1]) {
                    canAdd = false; // Set the flag.
                    break; // and break.
                }
            }
            
			// Only if the currentstring is longer than the longest found string, and the characters are alternating..
			// Can we use it as our maxStringLength.
            if(currString.Length > maxStringLength && canAdd) maxStringLength = currString.Length;
        }
        
		// Finally return our calculated maxStringLength.
        return maxStringLength;
    }

    static void Main(String[] args) {
        int l = Convert.ToInt32(Console.ReadLine());
        string s = Console.ReadLine();
        int result = twoCharaters(s);
        Console.WriteLine(result);
    }
}
