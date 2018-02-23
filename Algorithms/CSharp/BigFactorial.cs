using System;
using System.IO;
using System.Numerics;

/* You are given an integer N. Print the factorial of this number.
 * Input consists of a single integer N, where 1 <= N <= 100. */

class Solution {

    static BigInteger Factorial(int num) {
        if(num == 1) { // Check if final level of factorial.
            return num; // If so return the num.
        }
        
        return num * Factorial(num - 1); // Multiply the curr, by the next factorial.
    }

    static void Main(String[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(Factorial(n));
    }
}
