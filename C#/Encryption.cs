using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

	/* Encrypt an english text with the following constraints
	 * Sqrt(Length of String) <= rows x <= columns y <= Sqrt(Length of String).
	 * x is floor, while y is ceiling.
	 * Spaces are removed from the string.
	 * The encoded message is obtained by displaying the characters in a column,
	 * inserting a space, and then displaying the next column and inserting a space, and so on. 
	 */
	 
class Solution {

    static string encryption(string s) {
        int cols = (int)Math.Ceiling(Math.Sqrt(s.Length));
        int rows = (int)Math.Floor(Math.Sqrt(s.Length));
        int currCol = 0;
        int currStringPos = 0; // Current string pos.
        int charCount = 0; // Keep track of characters we've printed.
        string encrypted = "";
        
        while(charCount != s.Length) { // If we've iterated through all the characters, we can finish.
            encrypted += s[currStringPos]; // We insert the current character into the encryption.
            currStringPos += cols; // Increment the string pos by the cols.
            charCount++; // And the number of characters we've been through.
            if(currStringPos >= s.Length) { // If we're passed the length of the string.
                currCol++; // We need to increment the column check.
                currStringPos = currCol; // and set the current string now to the current col.
                encrypted += " "; // And add the ending space.
            }
        }

        return encrypted; // Finally, return the encrypted string.
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        Console.WriteLine(encryption(s));
    }
}