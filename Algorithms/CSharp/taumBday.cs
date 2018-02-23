using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Taum is planning to celebrate the birthday of his friend, Diksha.
 * There are two types of gifts that Diksha wants from Taum: 
 * one is black and the other is white. To make her happy, 
 * Taum has to buy B number of black gifts and W number of white gifts.
 * 
 *  The cost of each black gift is X units.
 *  The cost of every white gift is Y units.
 *  The cost of converting each black gift into white gift or vice versa is Z units.
 *
 * Help Taum by deducing the minimum amount he needs to spend on Diksha's gifts. */

class Solution {

    static long taumBday(long b, long w, long x, long y, long z) {
        
        // Using long as values will overflow.
        long currentCost = 0; // Stores our current cost.
        
        if(x <= y) { // If x is less than y or equal, then we can add the current cost of x * b, as we can't get cheaper.
            currentCost += b * x;
            
            if(x + z < y) { // If the price of x and z combined is less than the cost of y, then it's cheaper to convert.
                currentCost += w * (x + z);    
            } else 
                currentCost += w * y;
            
        } else if (x > y) {
            currentCost += w * y;
                 
            if(y + z < x) { // If the price of y and z combined is less than the cost of x, then it's cheaper to convert.
                currentCost += b * (y + z);
            } else
                currentCost += b * x;
        }
        
        return currentCost;
    }

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            string[] tokens_b = Console.ReadLine().Split(' ');
            long b = Convert.ToInt32(tokens_b[0]);
            long w = Convert.ToInt32(tokens_b[1]);
            string[] tokens_x = Console.ReadLine().Split(' ');
            long x = Convert.ToInt32(tokens_x[0]);
            long y = Convert.ToInt32(tokens_x[1]);
            long z = Convert.ToInt32(tokens_x[2]);
            long result = taumBday(b, w, x, y, z);
            Console.WriteLine(result);
        }
    }
}
