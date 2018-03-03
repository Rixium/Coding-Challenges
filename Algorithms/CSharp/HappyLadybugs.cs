using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Given the values of n and b for g games of Happy Ladybugs, determine if it's possible to make
 * all the ladybugs happy. For each game, print YES on a new line if all the 
 * ladybugs can be made happy through some number of moves; otherwise, print NO to indicate 
 * that no number of moves will result in all the ladybugs being happy. */
 
class Solution {

    
    static string CheckHappy(string b) {
		
        bool hasEmpty = false; // For whether we have space free to use when moving ladybugs around.
        bool needsEmpty = false; // This check if all ladybugs have a neighbour.
        List<char> doubleList = new List<char>(); // Stores all partnered ladybug types.
		
        for(int i = 0; i < b.Length; i++) { // Iterate through the entire string.
            char currLadyBird = b[i]; // Get the current ladybug.
            
			// If the current space is empty, we can set our empty flag and continue.
            if(currLadyBird == '_') {
                hasEmpty = true;
                continue;
            }
			
			// We check if the ladybug at the current iteration has a neighbour that is the same colour.
            if(i > 0 && i < b.Length - 1) {
				// If not, then we need an empty space to move around ladybugs.
                if(b[i - 1] != currLadyBird && b[i + 1] != currLadyBird) needsEmpty = true;
            }
            
            // Continue if the list already contains our ladybug.
            if(doubleList.Contains(currLadyBird)) {
               continue;
            }
            
			// Our has a double flag, for checking if there is more than 1 of the ladybugs present.
            bool hasDouble = false;
            
			// Iterating through the rest of the lady bugs.
            for(int y = i; y < b.Length; y++) {
                if(y == i) continue; // We don't need to count the same ladybug.
                
				// If it's an empty cell, we can continue, and set our empty flag.
                if(b[y] == '_') {
                    hasEmpty = true;
                    continue;
                }
                
				// Otherwise, if the current cell ladybug is the same colour as our check, we can add it to the double list.
                if(b[y] == currLadyBird) {
                    hasDouble = true;
                    doubleList.Add(currLadyBird);
                    break;
                }
                
            }
            
			// If no double for the current ladybug, then we can't give them all a partner, so return "NO".
            if(!hasDouble) return "NO";
        }
        
		// needsempty is for checking if no ladybugs are neighboured.
		// So, if it doesn't need an empty, they should all be neighoured.
		// And if we have an empty cell, for the moves, we can return "YES".
        if(hasEmpty || !needsEmpty) return "YES";
        return "NO";
    }
    
    static void Main(String[] args) {
        int Q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < Q; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            string b = Console.ReadLine();
            Console.WriteLine(CheckHappy(b));
        }
    }
}
