using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * You wish to buy video games from the famous online video game store Mist.
 *
 * Usually, all games are sold at the same price,  dollars. However, they are planning to have the seasonal Halloween Sale next month
 * in which you can buy games at a cheaper price. Specifically, the first game you buy during the sale will be sold at p dollars, but
 * every subsequent game you buy will be sold at exactly d dollars less than the cost of the previous one you bought. This will
 * continue until the cost becomes less than or equal to m dollars, after which every game you buy will cost m dollars each.
 *
 * You have s dollars in your Mist wallet. How many games can you buy during the Halloween Sale?
 */

class Solution {

    static long howManyGames(long p, long d, long m, long s) {
        long purchased = 0; // Keep track of how many we've purchased.
        
        while(s - p >= 0) { // If we can afford the next game, continue.
            s -= p; // Lower our dollars by the current price.
            p -= d; // Subtract d from the price.
            
            if(p < m) { // If p is less than the final price..
                p = m; // ..set the price equal to the final price.
            }
            
            purchased++; // Finally, increment purchased.
        }
        
        return purchased;
    }

    static void Main(String[] args) {
        string[] tokens_p = Console.ReadLine().Split(' ');
        long p = Convert.ToInt32(tokens_p[0]);
        long d = Convert.ToInt32(tokens_p[1]);
        long m = Convert.ToInt32(tokens_p[2]);
        long s = Convert.ToInt32(tokens_p[3]);
        long answer = howManyGames(p, d, m, s);
        Console.WriteLine(answer);
    }
}
