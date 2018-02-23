using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * A queen is standing on an n * n chessboard. The chessboard's rows are numbered from 1 to n, 
 * going from bottom to top; its columns are numbered from 1 to n, going from left to right. 
 * Each square on the board is denoted by a tuple, (r, c), describing the row, r, 
 * and column, c, where the square is located.
 *
 * Given the queen's position and the locations of all the obstacles, 
 * find and print the number of squares the queen can attack from her position at (r_q, c_q).
*/

class Solution {

    static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles) {        
        int possibleSquares = 0; // Counts all the possible squares the queen can move to.
        
		
		// Defining outside the border to be the closest edges to the queen, before obstacle checks.
        int[] closestTopLeft = new int[2];
        int[] closestTopRight = new int[2];        
        int[] closestBottomLeft = new int[2];
        int[] closestBottomRight = new int[2];
        
        int[] closestTop = new int[] {0, c_q };
        int[] closestBottom = new int[] {n + 1, c_q };
        int[] closestRight = new int[] { r_q , n + 1};
        int[] closestLeft = new int[] { r_q , 0};

		// Flags while we set the closest edges.
        bool l = true;
        bool r = true;
        bool t = true;
        bool b = true;
        
		// We will iterate outwards from the queen until we hit an obstacle.
        int diff = 1;
        
        while(l || r || t || b) {
            
			// Iterating out from the queen, check whether we hit an edge, and set the position accordingly.
            if(l) {
                if(c_q - diff  < 1 || r_q - diff < 1) {
                    closestTopLeft = new int[] { r_q - diff, c_q - diff };
                    l = false;
                }
            }
            
            if(b) {
                if(c_q - diff < 1 || r_q + diff > n) {
                    closestBottomLeft = new int[] { r_q + diff, c_q - diff };
                    b = false;
                }
            }
            
            if(r) {
                if(c_q + diff > n || r_q + diff > n) {
                    closestBottomRight = new int[] { r_q + diff, c_q + diff };
                    r = false;
                }
            }
            
            if(t) {
                if(c_q + diff > n || r_q - diff < 1) {
                    closestTopRight = new int[] { r_q - diff, c_q + diff };
                    t = false;
                }
            }
            
			// Incrementing the diff for next iteration.
           diff++;
        }
        
		// Check through all obstacles, until the queen can't move passed it.
		
        foreach(int[] p in obstacles) {
            
			// Calculation to make sure that the obstacle lies on a diagonal of the queen.
			// If it does, and it's closer than the current edge to the queen, we need to update our current stored closest tile.
            if(Math.Abs(c_q - p[1]) == Math.Abs(r_q - p[0])) {
                // Top Left
                if(p[0] < r_q && p[1] < c_q) {
                    if(p[0] > closestTopLeft[0] && p[1] > closestTopLeft[1]) {
                        closestTopLeft = p;
                    }
                    continue;
                }

                // Bottom Right
                if(p[0] > r_q && p[1] > c_q) {
                    if(p[0] < closestBottomRight[0] && p[1] < closestBottomRight[1]) {
                        closestBottomRight = p;
                    }
                    continue;
                }

                // Top Right
                if(p[0] < r_q && p[1] > c_q ) {
                    if(p[0] > closestTopRight[0] && p[1] < closestTopRight[1]) {
                        closestTopRight = p;
                    }
                    continue;
                }

                // Bottom Left
                if(p[0] > r_q && p[1] < c_q) {
                    if(p[0] < closestBottomLeft[0] && p[1] > closestBottomLeft[1]) {
                        closestBottomLeft = p;
                    }
                    continue;
                }
            }
            
			// For each other direction, check if the obstacle lies on that column and row, and if it's closer update the position for the relevant tile.
			
            // Left
            if(p[0] == r_q && p[1] < c_q) {
                if(p[1] > closestLeft[1]) {
                    closestLeft = p;
                }
                continue;
            }
            
            // Top
            if(p[0] < r_q && p[1] == c_q) {
                if(p[0] > closestTop[0]) {
                    closestTop = p;
                }
                continue;
            }
            
            // Bottom
            if(p[0] > r_q && p[1] == c_q) {
                if(p[0] < closestBottom[0]) {
                    closestBottom = p;
                }
                continue;
            }
            
            // Right
            if(p[0] == r_q && p[1] > c_q) {
                if(p[1] < closestRight[1]) {
                    closestRight = p;
                }
                continue;
            }
        }
        
		// We add the differences between the queen and all the stored positions now, to calculate all the places she can move to.
        // Left
        possibleSquares += Math.Abs((c_q - 1) - closestLeft[1]);
        // Right
        possibleSquares += Math.Abs(closestRight[1] - (c_q + 1)); 
        // Top
        possibleSquares += Math.Abs((r_q - 1) - closestTop[0]);
        // Bottom
        possibleSquares += Math.Abs(closestBottom[0] - (r_q + 1));
        // Top Left
        int sumTopLeft = Math.Min(Math.Abs((r_q - 1) - closestTopLeft[0]), Math.Abs((c_q - 1) - closestTopLeft[1]));
        possibleSquares += sumTopLeft;
        // Top Right
        int sumTopRight = Math.Min(Math.Abs((r_q - 1) - closestTopRight[0]), Math.Abs(closestTopRight[1] - (c_q + 1)));
        possibleSquares += sumTopRight;        
        // Bottom Left
        int sumBottomLeft = Math.Min(Math.Abs(closestBottomLeft[0] - (r_q + 1)), Math.Abs((c_q - 1) - closestBottomLeft[1]));
        possibleSquares += sumBottomLeft;
        // Bottom Right
        int sumBottomRight = Math.Min(Math.Abs(closestBottomRight[0] - (r_q + 1)), Math.Abs(closestBottomRight[1] - (c_q + 1)));
        possibleSquares += sumBottomRight;
        
        
		// Finally, return the final calculation.
        return possibleSquares;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] tokens_r_q = Console.ReadLine().Split(' ');
        int r_q = Convert.ToInt32(tokens_r_q[0]);
        int c_q = Convert.ToInt32(tokens_r_q[1]);
        int[][] obstacles = new int[k][];
        for(int obstacles_i = 0; obstacles_i < k; obstacles_i++){
           string[] obstacles_temp = Console.ReadLine().Split(' ');
           obstacles[obstacles_i] = Array.ConvertAll(obstacles_temp,Int32.Parse);
        }
        int result = queensAttack(n, k, r_q, c_q, obstacles);
        Console.WriteLine(result);
    }
}
