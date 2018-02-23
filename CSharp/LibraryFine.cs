using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * Your local library needs your help! Given the expected and actual return dates for a library book, create a program that calculates the fine (if any). The fee structure is as follows:
 *
 *   If the book is returned on or before the expected return date, no fine will be charged (i.e.: fine = 0).
 *   If the book is returned after the expected return day but still within the same calendar month and year as the expected return date, fine = 15 * Days Late.
 *   If the book is returned after the expected return month but still within the same calendar year as the expected return date, the fine = 500 * Months Late.
 *   If the book is returned after the calendar year in which it was expected, there is a fixed fine of 10000.
 */

class Solution {

    static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2) {
        if(y1 > y2) return 10000;
        if(y1 < y2 || m1 < m2 || (d1 < d2 && m1 == m2)) return 0;
        if(m1 > m2) return (m1 - m2) * 500;
        return Math.Abs(d1 - d2) * 15;
    }

    static void Main(String[] args) {
        string[] tokens_d1 = Console.ReadLine().Split(' ');
        int d1 = Convert.ToInt32(tokens_d1[0]);
        int m1 = Convert.ToInt32(tokens_d1[1]);
        int y1 = Convert.ToInt32(tokens_d1[2]);
        string[] tokens_d2 = Console.ReadLine().Split(' ');
        int d2 = Convert.ToInt32(tokens_d2[0]);
        int m2 = Convert.ToInt32(tokens_d2[1]);
        int y2 = Convert.ToInt32(tokens_d2[2]);
        int result = libraryFine(d1, m1, y1, d2, m2, y2);
        Console.WriteLine(result);
    }
}