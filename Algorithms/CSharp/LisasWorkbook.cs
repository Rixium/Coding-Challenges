using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/* Lisa believes a problem to be special if its index (within a chapter) 
 * is the same as the page number where it's located. 
 * Given the details for Lisa's workbook, can you count its number of special problems? */
    
class Solution {

    static int workbook(int n, int k, int[] arr) {
        int specialProblems = 0; // Keep track of the total special problems.
        int currentPage = 1; // Starting from page 1.
        
        for(int i = 0; i < arr.Length; i++) { // For every chapter.
            for(int j = 1; j <= arr[i]; j++) { // For every problem in the chapter.
                if(j == currentPage) // If the problem index is equal to the current page.
                    specialProblems++; // Then its a special problem.
                if(j % k == 0 && j < arr[i]) // J % Max Problems will return 0 when we should increment pages.
                    // We should only increment the page if j is less than the count of problems, otherwise we skip two pages.
                    currentPage++;
            }
            
            // Finally, chapters start on a new page.
            currentPage++;
        }
        
        return specialProblems;
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int k = Convert.ToInt32(tokens_n[1]);
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp,Int32.Parse);
        int result = workbook(n, k, arr);
        Console.WriteLine(result);
    }
}
