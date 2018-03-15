using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Julius Caesar protected his confidential information by encrypting it using a cipher. 
 * Caesar's cipher shifts each letter by a number of letters. 
 * If the shift takes you past the end of the alphabet, just rotate back to the 
 * front of the alphabet. In the case of a rotation by 3, w, x, y and z would map to z, a, b and c. 
 * Given a string, and a number k, cipher a string using Caesars' Cipher.
 */
 
class Solution {

    static string caesarCipher(string s, int k) {
		// Defining our alphabet array.
        char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 
                                      'f', 'g', 'h', 'i', 'j', 'k', 'l', 
                                      'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 
                                      'w', 'x', 'y', 'z'};
        
		// The newly built string will be stored here.
        string newStr = "";
        
		// Iterate through the strings length.
        for(int i = 0; i < s.Length; i++) {
			// Creating a new index variable to store position of new character.
            int newIndex = 0;
			// And a flag, to set when we find an applicable character.
            bool found = false;
			// Iterate through the alphabet.
            for(int c = 0; c < alphabet.Length; c++) {
				// If the character at the current alphabet pos is equal to our string character at index i,
                if(alphabet[c] == s.ToLower()[i]) {
					// Then create the new index, and wrap around if we overflow.
                    newIndex += (c + k + alphabet.Length) % alphabet.Length;
					// Set our found flag.
                    found = true;
                    break;
                }
            }
			
			// If we have found a character.
            if(found) {
				// If the original character is uppercase
                if(char.IsUpper(s[i])) {
					// We add the uppercase version to our new string.
                    newStr += alphabet[newIndex].ToString().ToUpper();
                    continue;
                }
				// Otherwise, we add the lowercase version.
                newStr += alphabet[newIndex];
            } else newStr += s[i]; // If it wasn't found, it must be a special character, so we add the original character.
        }
        
		// Finally, return new string.
        return newStr;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string s = Console.ReadLine();
        int k = Convert.ToInt32(Console.ReadLine());
        string result = caesarCipher(s, k);
        Console.WriteLine(result);
    }
}