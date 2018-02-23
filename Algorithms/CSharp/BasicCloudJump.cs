using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Emma is playing a new mobile game involving clouds numbered from 0 to n - 1. 
 * A player initially starts out on cloud 0, and they must jump to cloud n - 1. 
 * In each step, she can jump from any cloud i to cloud i + 1 or cloud  i + 2.
 *
 * There are two types of clouds, ordinary clouds and thunderclouds. 
 * The game ends if Emma jumps onto a thundercloud, but if she reaches 
 * the last cloud (i.e., n - 1), she wins the game! */
 
class Solution {

    static int jumpingOnClouds(int[] c) {
        int jumps = 0; // No jumps to begin with.
        
        for(int i = 0; i < c.Length - 1; i++) { // Iterate through every cloud.
            jumps++; // Increment jumps for iterations.
            
            if(i + 2 > c.Length - 1) continue; // If we can't jump two clouds ahead, we need to continue.
            
            if(c[i + 2] == 0) { // If we can jump two clouds.
                i++; // Increment i again.
            }
        }
        
        return jumps;
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] c_temp = Console.ReadLine().Split(' ');
        int[] c = Array.ConvertAll(c_temp,Int32.Parse);
        int result = jumpingOnClouds(c);
        Console.WriteLine(result);
    }
}
