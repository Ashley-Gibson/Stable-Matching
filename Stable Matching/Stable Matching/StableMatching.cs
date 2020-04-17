// Algorithm from: https://en.wikipedia.org/wiki/Gale%E2%80%93Shapley_algorithm#Algorithm

using System;
using System.Collections.Generic;

namespace Stable_Matching
{
    public static class StableMatching
    {
        public static List<Male> men = new List<Male>();
        public static List<Female> women = new List<Female>();

        private static int menCount = 0;

        public static void InitPeople()
        {
            Male David = new Male("David"), James = new Male("James"), John = new Male("John"), Adam = new Male("Adam");
            Female Amy = new Female("Amy"), Elise = new Female("Elise"), Jessica = new Female("Jessica"), Donna = new Female("Donna");

            David.SetPreferences(new Female[]{ Donna, Elise, Donna, Amy });
            James.SetPreferences(new Female[] { Elise, Amy, Jessica, Donna });
            John.SetPreferences(new Female[] { Jessica, Elise, Amy, Jessica });
            Adam.SetPreferences(new Female[] { Elise, Amy, Donna, Jessica });

            Amy.SetPreferences(new Male[] { David, James, John, Adam });
            Elise.SetPreferences(new Male[] { James, David, John, Adam });
            Jessica.SetPreferences(new Male[] { James, John, David, James });
            Donna.SetPreferences(new Male[] { Adam, David, James, John });

            men.Add(David);
            men.Add(James);
            men.Add(John);
            men.Add(Adam);

            women.Add(Amy);
            women.Add(Elise);
            women.Add(Jessica);
            women.Add(Donna);
        }

        public static void OutputPreferences()
        {
            Console.WriteLine("\nPREFERENCES");
            foreach (Male man in men)
            {
                Person[] preferences = man.GetPreferences();
                Console.Write($"\n{man.Name} preference list - ");

                foreach (Female woman in preferences)
                {
                    Console.Write($"[{woman.Name}] ");
                }
            }
            Console.WriteLine("\n");
        }

        public static void OutputMatches()
        {
            Console.WriteLine("\nMATCHES");
            foreach (Male man in men)
            {
                Console.Write($"\n{man.Name} and {man.EngagedTo.Name} ");
            }
            Console.WriteLine("\n");
        }

        public static void FindMatches()
        {
            menCount = men.Count;
            while (menCount > 0)
            {
                foreach (Male man in men)
                    if(!man.IsMatched)
                        FindMatch(man);
            }
        }

        private static void FindMatch(Male man)
        {
            Console.WriteLine($"Matching {man.Name}...");

            foreach (Female woman in man.GetPreferences())
            {
                if (woman.EngagedTo == null)
                {
                    man.EngagedTo = woman;
                    woman.EngagedTo = man;
                    menCount--;
                    Console.WriteLine($"{man.Name} is no longer a free man and is now matched with {woman.Name}");
                    break;
                }
                else 
                {
                    Console.WriteLine($"{woman.Name} is matched already...");

                    int currentManIndex = Array.FindIndex(woman.GetPreferences(), x => x == woman.EngagedTo);
                    int potentialManIndex = Array.FindIndex(woman.GetPreferences(), x => x == man);

                    if (currentManIndex > potentialManIndex)
                        Console.WriteLine($"{woman.Name} is satisfied with {woman.EngagedTo.Name}");
                    else
                    {
                        Console.WriteLine($"{man.Name} is better than {woman.EngagedTo.Name}");
                        Console.WriteLine($"{woman.EngagedTo.Name} is now free");
                        Console.WriteLine($"{man.Name} can now be matched with {woman.Name}");

                        man.EngagedTo = woman;
                        woman.EngagedTo = man;
                        menCount--;
                        break;
                    }
                }
            }
        }
    }
}