using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Madison, is a little girl who is fond of toys. Her friend Mason works in a toy manufacturing factory. Mason has a 2D board A of
 * size H x W with H rows and W columns. The board is divided into cells of size 1 x 1 with each cell indicated by it's coordinate 
 * (i ,j). 
 * The cell (i, j) has an integer A written on it. 
 * To create the toy Mason stacks number of cubes of size 1 x 1 x 1 on the cell (i, j).
 * 
 * Given the description of the board showing the values of A and that the price of the toy is equal to the 3d surface area find the
 * price of the toy.
*/

class Solution {

    static int surfaceArea(int[][] A) {
        int surfaceArea = 0; // Store the complete surface area of the given toy.
        
        int width = A[0].Length; // Defining our width variable.
        int height = A.Length; // And our height
        
        for(int i = 0; i < height; i++) { // Iterating through each row
            for(int j = 0; j < width; j++) { // And each column of the array.
                int currentStackSurface = 2; // The initial stack surface is 2, as the top and bottom surfaces always show.
                int current = A[i][j]; // Getting the current stack size at i, j.
                int leftSize = 0; // Initial value of left.
                int rightSize = 0; // Initial value of right.
                int topSize = 0; // Initial value of the above stack.
                int botSize = 0; // Initial valye of the stack below.
                
                if(i > 0) { // Can't test above if no block exists.
                    topSize = A[i - 1][j]; // Gets the stack above.
                }
                if(i < height - 1) { // Can't test the bottom if i is the bottom block.
                    botSize = A[i + 1][j]; // Get the stack below.
                }
                if(j > 0) { // Can't test left if j is 0.
                    leftSize = A[i][j - 1]; // Get left stack size.
                }
                if(j < width - 1) { // Can't test right if j is the width.
                    rightSize = A[i][j + 1]; // Get the right stack size.
                }
                
                // If the left size is smaller than the current.
                if(leftSize < current) {
                    // Therefore, the current stack is showing faces equal to the current size subtracted by the left side size.
                    // If the current stack is 4 high, and the left is 2. Then 2 faces are showing on the current, so we add 2 to the
                    // currentstack surface, where current = 4, left = 2, 4 - 2 = 2 faces.
                    currentStackSurface += (current - leftSize);
                }
                
                // Similar process as above for all other sides.
                if(rightSize < current) {
                    currentStackSurface += (current - rightSize);
                }
                if(topSize < current) {
                    currentStackSurface += (current - topSize);
                }
                if(botSize < current) {
                    currentStackSurface += (current - botSize);
                }
                
                // Finally, add the calculated surface area to the whole surface area.
                surfaceArea += currentStackSurface;
            }
        }
        
        // Return the final value.
        return surfaceArea;
    }

    static void Main(String[] args) {
        string[] tokens_H = Console.ReadLine().Split(' ');
        int H = Convert.ToInt32(tokens_H[0]);
        int W = Convert.ToInt32(tokens_H[1]);
        int[][] A = new int[H][];
        for(int A_i = 0; A_i < H; A_i++){
           string[] A_temp = Console.ReadLine().Split(' ');
           A[A_i] = Array.ConvertAll(A_temp,Int32.Parse);
        }
        int result = surfaceArea(A);
        Console.WriteLine(result);
    }
}