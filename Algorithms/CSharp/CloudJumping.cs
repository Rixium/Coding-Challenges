using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Aerith is playing a cloud game! In this game, there are  clouds numbered sequentially from 0 to n - 1. 
 * Each cloud is either an ordinary cloud or a thundercloud.
 *
 * Aerith starts out on cloud 0 with energy level 100.
 * She can use 1 unit of energy to make a jump of size k to cloud (i + k) % n, and she jumps 
 * until she gets back to cloud 0.
 * If Aerith lands on a thundercloud, her energy decreases by 2 additional units. 
 * The game ends when Aerith lands back on cloud .
 * 
 * Given the values of n, k, and the configuration of the clouds, 
 * can you determine the final value of E after the game ends? */

class Solution {

    static int jumpingOnClouds(int[] c, int k) {
        int currCloud = 0; // Set the initial cloud to 0.
        int currEnergy = 100; // Initialize the energy at 100.
        
        do {
            currCloud = (currCloud + k) % c.Length; // Set next cloud equal to current cloud plus the jump, mod number of clouds.
            currEnergy--; // Negate the energy for the jump.
            
            if(c[currCloud] == 1) { // Checking if the cloud is a thunder cloud.
                currEnergy -= 2; // If so remove 2 more additional enery.
            }
            
        } while(currCloud != 0); // Repeat until land back on the first cloud.
        
        return currEnergy; // Finally, return the remaining energy.
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        int[] c = Array.ConvertAll(c_temp,Int32.Parse);
        int result = jumpingOnClouds(c, k);
        Console.WriteLine(result);
    }
}
