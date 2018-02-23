using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* 
 * Little Bobby loves chocolate, and he frequently goes to his favorite store, Penny Auntie, with n dollars to buy chocolates. Each
 * chocolate has a flat cost of c dollars, and the store has a promotion where they allow you to trade in m chocolate wrappers in
 * exchange for 1 free piece of chocolate.
 *
 * Given total dollars (n), chocolate price (c), wrapper cost (m), 
 * can you determine how many chocolates Bobby eats during each trip?
 */

class Solution {

    static int chocolateFeast(int n, int c, int m) {
        int wrapperCount = 0; // Total count of wrappers collected from chocolates.
        int totalChocolates = 0; // The total number of chocolates eaten.
        
        // Our wrapper count can be set by our dollars divided by the cost of chocolate.
        wrapperCount += (int)Math.Floor((double)n / c);
        // Then we've eaten the same amount of chocolates.
        totalChocolates = wrapperCount;
        
        // While we still have wrappers left, we can trade them for more
		// chocolates, which also increases wrapper count again,
		// So loop until no longer possible.
		
		while(wrapperCount - m >= 0) {
            wrapperCount -= m;
            wrapperCount++;
            totalChocolates++;
        }
        
        return totalChocolates;
    }

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int c = Convert.ToInt32(tokens_n[1]);
            int m = Convert.ToInt32(tokens_n[2]);
            int result = chocolateFeast(n, c, m);
            Console.WriteLine(result);
        }
    }
}
