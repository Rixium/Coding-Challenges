using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* You have a string, s, of lowercase English alphabetic letters. 
 * You can perform two types of operations on :
 *
 *  1. Append a lowercase English alphabetic letter to the end of the string.
 *  1. Delete the last character in the string. Performing this operation on an empty string results in an empty string.
 *
 * Given an integer, k, and two strings, s and t, determine whether or not you can 
 * convert to by performing exactly k of the above operations on s.
 * If it's possible, print Yes; otherwise, print No. */
 
class Solution {

    static string appendAndDelete(string start, string goal, int changes) {
        int count = 0; // Intially set a change count to zero.
        
        if(start.Length == goal.Length) { // If the strings are equal.
            if(start.Length * 2 + 1 == changes) return "Yes"; // Easy catch for strings that are the same.
        }

        while(count <= changes) { // Continue the loop while count is less than changes.
            if(count == changes && goal == start) return "Yes"; // Retrun Yes if we have successfully matched strings and counts.
            
            if(start.Length > goal.Length) { // For cases when start is longer than goal.
                start = start.Substring(0, start.Length - 1); // We need to subtract the last character from start.
            } else if (start.Length <= goal.Length) { // For when start character count is less than goals character count.
                bool canAdd = true; // Set a can add flag to true;

                for(int i = start.Length - 1; i > 0; i--) {
                    if(start[i] != goal[i]) {
                        canAdd = false; // Iterate through each start character, and if its not the same as goal, we cannot add another character.
                        break; // So we break.
                    }
                }
                
                if(start.Length == 1) { // If a single character in start.
                    if(start[0] != goal[0]) { // If they're not the same,
                        canAdd = false; // We cannot add.
                    }
                }

                if(canAdd && start.Length != goal.Length) { // If we can add.
                    start += goal[start.Length]; // Append the goal character to the end of start string.
                } else {
                    if(start.Length > 1) { // if the length is more than 1, we need to subtract.
                        start = start.Substring(0, start.Length - 1);
                    } else {
                        start = ""; // If not, we set the start string to empty.
                        if(changes - count >= goal.Length) return "Yes"; // As we can keep subtracting from an empty string, 
																		 //as long as the changes - count is more than the length of the string, we can complete it.
                    }
                }
            }
            
            count++; // Finally, increment the count for the change committed.
            
        }
        
        return "No"; // If count > changes, return "No";
    }

    static void Main(String[] args) {
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        int k = Convert.ToInt32(Console.ReadLine());
        string result = appendAndDelete(s, t, k);
        Console.WriteLine(result);
    }
}
