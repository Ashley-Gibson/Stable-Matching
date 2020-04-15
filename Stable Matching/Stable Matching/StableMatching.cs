// Algorithm from: https://en.wikipedia.org/wiki/Gale%E2%80%93Shapley_algorithm#Algorithm

using System;
using System.Collections.Generic;

namespace Stable_Matching
{
    public class StableMatching
    {
        public readonly Dictionary<string, string[]> men = new Dictionary<string, string[]>(){
            { "David", new string[] { "Amy", "Jessica", "Elise" }},
            { "John", new string[] { "Jessica","Elise", "Amy" }},
            { "Adam", new string[] { "Elise","Amy", "Jessica" }}
        };

        public readonly Dictionary<string, string[]> women = new Dictionary<string, string[]>(){
            { "Amy", new string[] { "David", "John", "Adam" }},
            { "Jessica", new string[] { "John", "David", "Adam" }},
            { "Elise", new string[] { "Adam", "John", "David" }}
        };

        public List<(string, string)> FindMatches()
        {
            List<(string, string)> matches = new List<(string, string)>();



            return matches;
        }
    }
}

/*
algorithm stable_matching is
    Initialize all m ∈ M and w ∈ W to free
    while ∃ free man m who still has a woman w to propose to do
        w := first woman on m's list to whom m has not yet proposed
        if w is free then
            (m, w) become engaged
        else some pair (m', w) already exists
            if w prefers m to m' then
                m' becomes free
                (m, w) become engaged 
            else
                (m', w) remain engaged
            end if
        end if
    repeat 


    while there exist a free man m who still has a woman w to propose to 
    {
        w = m's highest ranked such woman to whom he has not yet proposed
        if w is free
           (m, w) become engaged
        else some pair (m', w) already exists
           if w prefers m to m'
              (m, w) become engaged
               m' becomes free
           else
              (m', w) remain engaged    
    }
 */
