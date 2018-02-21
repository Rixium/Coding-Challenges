using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * David has n containers and n different types of balls, 
 * both of which are numbered from 0 to n - 1. The distribution of ball types per container are 
 * described by an n * n matrix of integers, M, where each M(c, t) is the number of balls of type in container .
 *
 * David wants to perform some number of swap operations such that both of the 
 * following conditions are satisfied:
 * 
 *  Each container contains only balls of the same type.
 *  No two balls of the same type are located in different containers.
 *
 * You must perform q queries where each query is in the form of a matrix, M. 
 * For each query, print Possible on a new line if David can satisfy the 
 * conditions above for the given matrix; otherwise, print Impossible instead.
 */

class Solution {

    static string organizingContainers(int[][] container) {
        
        int[] balls = new int[container.GetLength(0)]; // Holds the count of each ball.
        int[] containerIncorrect = new int[container.GetLength(0)]; // Holds the size of each container.
        
        for(int i = 0; i < container.Length; i++) {
            for(int b = 0; b < balls.Length; b++) {
                balls[b] += container[i][b]; // Add the ball to the correct ball count.
                containerIncorrect[i] += container[i][b]; // Increase the size of the container by number of balls.
            }
        }

		// We need to sort so we can directly check if the container size is equal to the ball count.
        Array.Sort(balls);
        Array.Sort(containerIncorrect);
        
        for(int i = 0; i < container.Length; i++) {
                if(containerIncorrect[i] != balls[i])
                    return "Impossible"; // If it's not equal, then it is 
										//impossible to put all the balls in the correct container.
        }
        
        return "Possible";
    }

    static void Main(String[] args) {
        int q = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < q; a0++){
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] container = new int[n][];
            for(int container_i = 0; container_i < n; container_i++){
               string[] container_temp = Console.ReadLine().Split(' ');
               container[container_i] = Array.ConvertAll(container_temp,Int32.Parse);
            }
            string result = organizingContainers(container);
            Console.WriteLine(result);
        }
    }
}
