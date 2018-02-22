using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Given a word , rearrange the letters of w to construct another word s in such a way that s is lexicographically greater than w.
 * In case of multiple possible answers, find the lexicographically smallest one among them.
 */

class Solution {

    static string biggerIsGreater(string w) {
        if(w.Length == 0) return "no answer";
        
        // Starting from the final character.
        int i = w.Length - 1;
        
        // Check if a higher character exists in the string.
        // If it doesn't then the highest character is at the end of the string.
        // We will swap the selected highest character, with the highest index lowest character.
        while(i > 0 && w[i - 1] >= w[i]) {
            i--;    
        }
        
        if(i <= 0) {
            // No other possible higher permutation.
            return "no answer";
        }
        
        int j = w.Length - 1;
        
        // We need to check for a lower or equal character after i, that we should swap.
        while(w[j] <= w[i - 1]) {
            j--;
        }
        
        // Convert the string to an array, so we can move character positions.
        char[] c = w.ToArray();
        
        // Swap the characters.
        c[i - 1] = w[j];
        c[j] = w[i - 1];
       
        // Reset J, ready for swapping characters.
        j = w.Length - 1;
        
        // Loop and reverse characters following i.
        // Meeting in the middle.
        while(i < j) {
            // Temp char storage for swap.
            char temp = c[i];
            c[i] = c[j];
            c[j] = temp;
            
            // Increment i and decrease j for next swap.
            i++;
            j--;
        }
        
        return new string(c);
    }

    static void Main(String[] args) {
        int T = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < T; a0++){
            string w = Console.ReadLine();
            string result = biggerIsGreater(w);
            Console.WriteLine(result);
        }
    }
}