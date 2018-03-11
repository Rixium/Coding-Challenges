using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Louise joined a social networking site to stay in touch with her friends.
 * The signup page required her to input a name and a password. 
 * However, the password must be strong. 
 * The website considers a password to be strong if it satisfies the following criteria:
 *
 * Its length is at least 6.
 * It contains at least one digit.
 * It contains at least one lowercase English character.
 * It contains at least one uppercase English character.
 * It contains at least one special character. The special characters are: !@#$%^&*()-+
 * 
 * She typed a random string of length n in the password field but 
 * wasn't sure if it was strong. 
 * Given the string she typed, can you find the minimum number 
 * of characters she must add to make her password strong? */

class Solution {

    static int minimumNumber(int n, string password) {
		
		// Defining our required characters.
        string numbers = "0123456789";
        string lower_case = "abcdefghijklmnopqrstuvwxyz";
        string upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string special_characters = "!@#$%^&*()-+";
        
		// Setting up our counting variables.
        int requiredChars = 0;
        int numCount = 0;
        int lowerCaseCount = 0;
        int upperCaseCount = 0;
        int specialCharacterCount = 0;
        
		// Iterate through the password.
		for(int i = 0; i < password.Length; i++) {
            
			// Iterate through the longest character string.
            for(int c = 0; c < lower_case.Length; c++) {
				
				// Only perform this check if c is less than number length.
                if(c < numbers.Length) {
					// If the character at c in numbers is equal to the current password iteration.
                    if(numbers[c] == password[i]) {
						// Increase numCount.
                        numCount++;
                        break;
                    }
                } 
                
				// Similar logic for the following statements.
                if(c < special_characters.Length) {
                    if(special_characters[c] == password[i]) {
                        specialCharacterCount++;
                        break;
                    }    
                }
                
                if(lower_case[c] == password[i]) {
                    lowerCaseCount++;
                    break;
                }
                
                if(upper_case[c] == password[i]) {
                    upperCaseCount++;
                    break;
                }
            }
        }
        
		// We need at least one of each character from the strings.
		// So we only need to add an extra character for each that is zero.
        if(numCount == 0) requiredChars++;
        if(lowerCaseCount == 0) requiredChars++;
        if(upperCaseCount == 0) requiredChars++;
        if(specialCharacterCount == 0) requiredChars++;
        
		// If our current string, plus the requiredcharacters is still less than 6.
		// We need to add a few more required characters to make up the missing characters.
        if(n + requiredChars < 6) requiredChars += (6 - (n + requiredChars));
        
		
		// Finally, return the count.
        return requiredChars;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string password = Console.ReadLine();
        int answer = minimumNumber(n, password);
        Console.WriteLine(answer);
    }
}
