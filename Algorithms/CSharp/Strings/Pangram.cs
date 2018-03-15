using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Roy wanted to increase his typing speed for programming contests. 
 * His friend suggested that he type the sentence 
 * "The quick brown fox jumps over the lazy dog" repeatedly. 
 * This sentence is known as a pangram because it contains every letter of the alphabet.
 * 
 * After typing the sentence several times, 
 * Roy became bored with it so he started to look for other pangrams.
 * 
 * Given a sentence, determine whether it is a pangram. */
 
namespace Solution {
    
    class Solution {

        private static string CheckPangram(string s) {
			// Create our character list.
            List<char> chars = new List<char>();
            
			// Iterate through the string.
            for(int i = 0; i < s.Length; i++) {
				// Get the current character and convert it to lower.
                char testChar = char.ToLower(s[i]);
				// If its a space, then continue.
                if(s[i] == ' ') continue;
				// If the list doesn't already contain the character, put it in the list.
                if(!chars.Contains(testChar)) chars.Add(testChar);
				// If the list count is equal to the length of the alphabet, then it's a pangram.
                if(chars.Count == 26) return "pangram";
            }
            
			// Otherwise, it's not a pangram.
            return "not pangram";
        }

        static void Main(string[] args) {
            string givenString = Console.ReadLine();
            Console.WriteLine(CheckPangram(givenString));
        }

    }
    
}