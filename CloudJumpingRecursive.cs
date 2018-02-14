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
    
    static int JumpToCloud(int currCloud, int jumpSize, int energy, int[] clouds) {
        
        currCloud = (currCloud + jumpSize) % clouds.Length; // Set the current cloud after the jump.
        energy--; // Negate the energy for the jump.
        
        if(clouds[currCloud] == 1) {
            energy -= 2; // If the cloud is a thunder cloud, subtract 2 additional energy.
        }
        
		return currCloud == 0 ? energy : JumpToCloud(currCloud, jumpSize, energy, clouds); // Return energy, or call function recursively depending on current cloud.
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        int[] c = Array.ConvertAll(c_temp,Int32.Parse);
        int result = JumpToCloud(0, k, 100, c); // Call the recursive function, with the initial values.
        Console.WriteLine(result);
    }
}
