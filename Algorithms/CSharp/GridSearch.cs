using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Given a 2D array of digits, try to find the occurrence of a given 2D pattern of digits. */

class Solution {

    static string gridSearch(string[] G, string[] P) {
        
        //Iterate through every column of the grid.
        for(int gCol = 0; gCol <= G.Length - P.Length; gCol++) {
            // And every row.
            for(int gRow = 0; gRow <= G[gCol].Length - P[0].Length; gRow++) {
                // Get if the current iteration number is equal to the first of the check grid.
                if(G[gCol][gRow] == P[0][0]) {
                    // Set a flag to see if we successfully find P.
                    bool found = true;
                    // Iterate through P columns and rows.
                    for(int currCheck = 0; currCheck < P.Length; currCheck++) {
                        for(int currChar = 0; currChar < P[currCheck].Length; currChar++) {
                            // Get the current character at the G, plus the col and row check,
                            char currCharCheck = G[gCol + currCheck][gRow + currChar];
                            // Compare the two, and if they're not equal..
                            if(P[currCheck][currChar] != currCharCheck) {
                                // We set found to false.
                                found = false;
                                // then break from the loop.
                                break;
                            }
                        }
                        // If it isn't found, break.
                        if(!found) {
                            break;
                        }
                    }
                    
                    //If found, we're done, and can return.
                    if(found) {
                        return "YES";
                    }
                }
            }
        }
        
        // If we found no grid in the boundary, we return no.
        return "NO";
    }

    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            string[] tokens_R = Console.ReadLine().Split(' ');
            int R = Convert.ToInt32(tokens_R[0]);
            int C = Convert.ToInt32(tokens_R[1]);
            string[] G = new string[R];
            for(int G_i = 0; G_i < R; G_i++){
               G[G_i] = Console.ReadLine();   
            }
            string[] tokens_r = Console.ReadLine().Split(' ');
            int r = Convert.ToInt32(tokens_r[0]);
            int c = Convert.ToInt32(tokens_r[1]);
            string[] P = new string[r];
            for(int P_i = 0; P_i < r; P_i++){
               P[P_i] = Console.ReadLine();   
            }
            string result = gridSearch(G, P);
            Console.WriteLine(result);
        }
    }
}
