using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* You are given a square map of size n * n. 
 * Each cell of the map has a value denoting its depth. 
 * We will call a cell of the map a cavity if and only if 
 * this cell is not on the border of the map and each cell adjacent 
 * to it has strictly smaller depth. 
 * Two cells are adjacent if they have a common side (edge).
 *
 * You need to find all the cavities on the map and
 * depict them with the uppercase character X. */
 
class Solution {

    static string[] cavityMap(string[] grid) {
        string[] newGrid = new string[grid.Length]; // Store the new grid, with cavities marked.
        
        for(int i = 0; i < grid.Length; i++) { // Iterate through every string in the grid.
            string currString = ""; // And make a new string for the current row.
            for(int c = 0; c < grid[i].Length; c++) { // Iterate through every character of the string.
                var currentVal = grid[i][c]; // Get the value of the current position.
                
				// We don't change edges, so whenever we're at an edge, we add the currentVal to the string, and continue.
                if(i == 0 || c == 0 || i == grid.Length - 1 || c == grid[i].Length - 1) {
                    currString += currentVal; 
                    continue;
                }
                
				// Otherwise, we check the edges of the current iteration, and check if they're all smaller.
                if(currentVal > grid[i-1][c] && currentVal > grid[i+1][c] 
                  && currentVal > grid[i][c-1] && currentVal > grid[i][c+1])
                    currString += "X"; // If they are, mark it as a cavity, with X.
                else
                    currString += currentVal; // Otherwise, we keep the current value.
            }
            newGrid[i] = currString; // We set the current iteration of the new grid to our newly constructed string.
        }
        
        return newGrid; // Finally, return the cavity map.
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] grid = new string[n];
        for(int grid_i = 0; grid_i < n; grid_i++){
           grid[grid_i] = Console.ReadLine();   
        }
        string[] result = cavityMap(grid);
        Console.WriteLine(String.Join("\n", result));


    }
}
