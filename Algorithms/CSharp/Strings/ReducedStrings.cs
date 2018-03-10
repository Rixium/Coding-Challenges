using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Steve has a string of lowercase characters in range ascii[‘a’..’z’]. 
 * He wants to reduce the string to its shortest length by doing a series of operations 
 * in which he selects a pair of adjacent lowercase letters that match, and then he deletes them. 
 * For instance, the string aab could be shortened to b in one operation.
 * 
 * Steve’s task is to delete as many characters as possible using this method 
 * and print the resulting string. If the final string is empty, print Empty String. */

class Solution {

    static string super_reduced_string(string s){
        bool hasChanged = false; // Flag for when he remove adjacents.
        
        string reduced = ""; // Set the initial reduced equal to an empty string.
		
        for(int i = 0; i < s.Length; i++) { // Iterate through each character of the passed string.
            if(i < s.Length - 1) { // If i < last character.
                if(s[i] == s[i + 1]) { // If this character is the same as the next.
                    i++; // We pass both characters.
                    hasChanged = true; // Set our adjacent remover flag.
                    continue; // And continue the loop.
                }
            }
            
            reduced += s[i]; // If not, then we can add this character to our reduced string.
        }
        
        if(hasChanged) reduced = super_reduced_string(reduced); // Depending on if we've removed an adjacent pair, recursively call function.
        
        if(reduced == "") return "Empty String"; // If our reduced is empty, we return "Empty String".
        
        return reduced; // Otherwise, we return the final string.
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        string result = super_reduced_string(s);
        Console.WriteLine(result);
    }
}
