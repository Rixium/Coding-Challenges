using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* You are the benevolent ruler of Rankhacker Castle, and today you're distributing bread to a straight line N of subjects. Each 
 * subject already has B loaves of bread.
 * 
 * Times are hard and your castle's food stocks are dwindling, so you must distribute as few loaves as possible according to the
 * following rules:
 *
 * Every time you give a loaf of bread to some person, you must also give a loaf of bread to the person immediately in front of or
 * behind them in the line. In other words, you can only give a loaf of bread each to two adjacent people at a time.
 * After all the bread is distributed, each person must have an even number of loaves.
 * 
 * Given the number of loaves already held by each citizen, find and print the minimum number of loaves you must distribute to satisfy
 * the two rules above. If this is not possible, print NO. */

class Solution {

    static void fairRations(int[] B) {
        int breadGiven = 0; // Number of loaves we have given out.
        for(int i = 0; i < B.Length; i++) { // Iterate through every person.
            if(B[i] % 2 == 0) { // If they currently hold an even number, then we can skip them.
                continue;
            }
            
            bool behindEven = true; // We create a flag, to hold whether the previous person has even loaves.
            
            B[i]++; // Increment the current persons loaves.
            breadGiven++; // And account for it with bread given.
            
            if(i > 0) { // We can check an index less than 0.
                if(B[i - 1] % 2 != 0) { // If the previous person doesn't have even loaves.
                    behindEven = false; // Then we set the flag to false.
                } else if(i == B.Length - 1) {
                    // If the person has even loaves, then we can complete the problem with all even loaves,
                    // As we can't give a loaf to the next person, as they don't exist, therefore we must
                    // cause the previous person to have uneven loaves.
                    Console.WriteLine("NO");
                    return;
                }
            }

            if(behindEven) { // If the person behind holds even.
                if (i < B.Length - 1) { // And we're less than the last number person.
                    B[i + 1]++; // We can give the netx person a loaf.
                    breadGiven++;
                }
            } else {
                B[i - 1]++; // Else, we prioritise the last person, and give them a loaf.
                breadGiven++;
            }
        }
        
        Console.WriteLine(breadGiven); // Finally, return the bread given.
    }

    static void Main(String[] args) {
        int N = Convert.ToInt32(Console.ReadLine());
        string[] B_temp = Console.ReadLine().Split(' ');
        int[] B = Array.ConvertAll(B_temp,Int32.Parse);
        fairRations(B);
    }
}
