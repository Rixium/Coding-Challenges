import java.util.*; 
import java.io.*;

// Programmed on 13th February 2018.
// Challenge from https://coderbyte.com/editor/guest:Vowel%20Square:Java

/* Using the Java language, have the function VowelSquare(strArr) take the strArr parameter 
 * being passed which will be a 2D matrix of some arbitrary size filled with letters from the alphabet, 
 * and determine if a 2x2 square composed entirely of vowels exists in the matrix. 
 *
 * For example: strArr is ["abcd", "eikr", "oufj"] then this matrix looks like the following: 
 *
 * a b c d
 * e i k r
 * o u f j 
 *
 * Within this matrix there is a 2x2 square of vowels starting in the second row and first column, 
 * namely, ei, ou. If a 2x2 square of vowels is found your program should return 
 * the top-left position (row-column) of the square, so for this example your program should 
 * return 1-0. If no 2x2 square of vowels exists, then return the string not found. 
 * If there are multiple squares of vowels, return the one that is at 
 * the most top-left position in the whole matrix. The input matrix will at least be of size 2x2. */
		
class Main {  
  public static String VowelSquare(String[] strArr) { 
    char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' }; // Set of all vowels.
    
    for(int layer = 0; layer < strArr.length - 1; layer++) { // Iterate through each layer (string) in the array, not including the final line.
        for(int character = 0; character < strArr[layer].length() - 1; character++) { // Iterate through each character of the given string, not including final character.
            boolean found = true; // Set the flag to found.
            for(int y = layer; y <= layer + 1; y++) { // Iterate through 2 layers.
                for(int x = character; x <= character + 1; x++) { // Iterate through 2 characters of the string.
                    boolean hasC = false; // Initially set the flag to false, to indicate a character is present.
                    for(char c : vowels) { // Iterate through each character in the vowels array.
                        if(strArr[y].charAt(x) == c) { // Check if the character is present at the position in the string.
                            hasC = true; // If so we can set the flag to true, and break from the check.
                            break;
                        }
                    }
                    if(!hasC) { // If the character wasn't found, then this isn't a valid square, so we can break from the loop.
                        found = false;
                        break;
                    }
                }
                if(!found) break; // Break if not a valid square.
            }
            
            if(found) { // If it is a valid square, we can return the starting position of the square.
                return layer + "-" + character;
            }
        }
    }
    return "not found"; // Return not found if no valid square found.
  } 
  
  public static void main (String[] args) {
	String[] strings = new String[]{"zzzzzzzzzz","zzzaezzzzz","zzziozzzzz"}; // Strings to check for vowel square.
    System.out.print(VowelSquare(strings));
  }   
  
}