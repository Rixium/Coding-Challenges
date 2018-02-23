using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Given the time in numerals we may convert it into words.
 * Write a program which prints the time in words for the input given.
 */

class Solution {

    static string timeInWords(int h, int m) {
        string hour = GetNumberInWords(h); // Getting the string value of hour.
        string minutes = "";
            
        if(m == 0) { // If minutes is zero, then we're on the hour.
            return hour + " o' clock";
        }
        
        int minuteCheck = m; // For use in subtraction.
        
        if(minuteCheck > 30) {
            minuteCheck = 60 - minuteCheck; // Deduct a minute count from 60 to get the value less than 30.
        }

        if(minuteCheck % 15 == 0) { // Check if the value is divisible by 15, to get cases where quarter or half.
            minutes = GetNumberInWords(minuteCheck);
        } else if(minuteCheck >= 14) {
             // If not divisible by 15, and over 13. We need to build correct string.
            minutes = GetCorrectNumberString(minuteCheck) + " minutes";
        } else {
            // If it is less than 14, then we need to get the number value, as a string.
            // No need to concatenate with twenty or teen.
            minutes = GetNumberInWords(minuteCheck) + " minute";
            if(minuteCheck > 1) {
                minutes += "s"; // Extra s, if multiple minutes.
            }
        }
            
        if(m <= 30) { // Finally, the inital m less than 30, then we use past.
            return minutes + " past " + hour;
        }
        
        // Else, we increment the hour.
        hour = GetNumberInWords(++h);
        // And return minutes to hour.
        return minutes + " to " + hour; 
    }

    // Checking whether we need to use teen or twenty.
    static string GetCorrectNumberString(int n) {
        string wordNum = GetNumberInWords(n % 10);
        int topMinVal = (int)Math.Floor(n / 10.0);
        
        if(topMinVal * 10 == 10) {
            return wordNum + "teen";
        } else if (topMinVal * 10 == 20) {
            return "twenty " + wordNum;
        }
        
        return "";
    }
    
    // Defining the single number cases.
    static string GetNumberInWords(int n) {
        switch(n) {
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
            case 10:
                return "ten";
            case 11:
                return "eleven";
            case 12:
                return "twelve";
            case 13:
                return "thirteen";
            case 15:
                return "quarter";
            case 20:
                return "twenty";
            case 30:
                return "half";
        }
        
        return "";
    }
    
    static void Main(String[] args) {
        int h = Convert.ToInt32(Console.ReadLine());
        int m = Convert.ToInt32(Console.ReadLine());
        string result = timeInWords(h, m);
        Console.WriteLine(result);
    }
}