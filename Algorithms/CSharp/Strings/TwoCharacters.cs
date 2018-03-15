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
        int maxStringLength = 0; // Current maxStringLength.
        List<char> checkedChars = new List<char>(); // All the checked characters.
        
        for(int i = 0; i < s.Length - 1; i++) { // Iterate through the entire string except last character.
            char c1 = s[i]; // Set current character equal to the value at s[i].
            
            if(checkedChars.Contains(c1)) continue; // if it's in the checkedChars list, we can skip this round.
            
            for(int j = i + 1; j < s.Length; j++) { // Iterate for the second character.
                char c2 = s[j]; // Get the second character value.
                if(c1 == c2) continue; // If it's equal to c1, then we skip this.
                
                string newString = ""; // Create the new string.
                
                for(int c = 0; c < s.Length; c++) { // Then iterate through the entire string.
                    if(s[c] != c1 && s[c] != c2) continue; // If current char doesn't match either of our testing chars, then skip.
                    
                    newString += s[c]; // Otherwise, add it to the new string.
                    
                    if(newString.Length > 1) { // Only do this check if the length is more than 1.
						// If the last two characters of our new string are equal, then this isn't a valid string.
                        if(newString[newString.Length - 2] == newString[newString.Length - 1]) {
                            newString = ""; // So we can empty it, and break.
                            break;
                        }
                    }
                    
                }
                
				// If the length is more than the maxStringLength, then we can set the maxStringLength.
                if(newString.Length > maxStringLength) {
                    maxStringLength = newString.Length;
                }
            }
            
			// And add our c1 to the checkedChars list.
            checkedChars.Add(c1);
        }

		// Finally, return our calculated maxStringLength.
        return maxStringLength;
    }

    static void Main(String[] args) {
        int l = Convert.ToInt32(Console.ReadLine());
        string s = Console.ReadLine();
        int result = twoCharaters(s);
        Console.WriteLine(result);
    }
}

