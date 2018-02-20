using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * You are given a list of people who are attending ACM-ICPC World Finals. 
 * Each of them are either well versed in a topic or they are not. 
 * Find out the maximum number of topics a 2-person team can know. 
 * And also find out how many teams can know that maximum number of topics. 
 */
 
class Solution {

    static int[] acmTeam(string[] topic) {
        
        int maxTopics = 0; // Keep track of the maximum number of topics.
        int teamCount = 0; // Keep track of number of teams that know that count.
        
        for(int i = 0; i < topic.Length - 1; i++) { // Iterating through each possible pair of teams.
            for(int j = i + 1; j < topic.Length; j++) {
                int currentTopics = 0; // Setting a current topic count, to keep track of team topics.
                for(int c = 0; c < topic[i].Length; c++) { // Checking through the team string for their topics.
                    if(topic[i][c] == '1' || topic[j][c] == '1') { // If either of the team knows the topic.
                        currentTopics++; // We can increment the topic count.
                    }
                }
                
                if(currentTopics > maxTopics) {
                    maxTopics = currentTopics; // Set max topics to current topics if this team pair knows more.
                    teamCount = 1; // And reset the team count.
                } else if(currentTopics == maxTopics) {
                    teamCount++; // Else we can increment the team count if they know the same amount of topics.
                }
            }
        }
        
        return new int[] { maxTopics, teamCount };
    }

    static void Main(String[] args) {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] topic = new string[n];
        for(int topic_i = 0; topic_i < n; topic_i++){
           topic[topic_i] = Console.ReadLine();   
        }
        int[] result = acmTeam(topic);
        Console.WriteLine(String.Join("\n", result));


    }
}
