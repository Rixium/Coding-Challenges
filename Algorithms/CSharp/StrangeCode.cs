using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Bob has a strange counter. At the first second, t = 1, it displays the number 3. At each 
 * subsequent second, the number displayed by the counter decrements by 1.
 * 
 * The counter counts down in cycles. In the second after the counter counts 
 * down to 1, the number becomes 2 times the initial number for that countdown cycle and then 
 * continues counting down from the new initial number in a new cycle.
 *
 * Given a time, t, find and print the value displayed by the counter at time t. */
 
 
class Solution {

    static long strangeCode(long t) {
        long i = 1; // Starting at 1.
        long val = 3; // With an initial value of 3.
        
        while(i < t) { // Until i > t.
            if(i + val > t) { // If i + val > t, we don't want to go further.
                // If val is currently 768, then adding the new val to i, would take us over.
                // So, we need to find the difference between the values, to calculate the correct end value.
                return val + i - t;
            } else {
                i += val; // Add the current value to i.
                val *= 2; // And double the new value.
            }
        }
        return val;
    }

    static void Main(String[] args) {
        long t = Convert.ToInt64(Console.ReadLine());
        long result = strangeCode(t);
        Console.WriteLine(result);
    }
}
