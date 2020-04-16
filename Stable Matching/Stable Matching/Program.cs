using System;

namespace Stable_Matching
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("STABLE MATCHING ALGORITHM");
            
            StableMatching.InitPeople();
            StableMatching.OutputPreferences();

            Console.Write("To begin matching press any key...");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("STABLE MATCHING ALGORITHM");
            StableMatching.OutputPreferences();

            StableMatching.FindMatches();

            Console.WriteLine("\nStable Matching Complete.");

            StableMatching.OutputMatches();

            Console.Write("Press any key to end...");
            Console.ReadKey();
        }
    }
}
