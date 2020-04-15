// Algorithm from: https://en.wikipedia.org/wiki/Gale%E2%80%93Shapley_algorithm#Algorithm

using System.Collections.Generic;

namespace Stable_Matching
{
    public class StableMatching
    {
        public readonly List<Male> men = new List<Male>();

        public readonly List<Female> women = new List<Female>();

        public void InitPeople()
        {
            Male David = new Male(), James = new Male(), John = new Male(), Adam = new Male();
            Female Amy = new Female(), Elise = new Female(), Jessica = new Female(), Donna = new Female();

            David.SetPreferences(new Person[]{ Amy, Elise, Jessica, Donna});
            James.SetPreferences(new Person[] { Amy, Elise, Jessica, Donna });
            John.SetPreferences(new Person[] { Amy, Elise, Jessica, Donna });
            Adam.SetPreferences(new Person[] { Amy, Elise, Jessica, Donna });

            Amy.SetPreferences(new Person[] { Amy, Elise, Jessica, Donna });
            Elise.SetPreferences(new Person[] { Amy, Elise, Jessica, Donna });
            Jessica.SetPreferences(new Person[] { Amy, Elise, Jessica, Donna });
            Donna.SetPreferences(new Person[] { Amy, Elise, Jessica, Donna });

            men.Add(David);
            men.Add(James);
            men.Add(John);
            men.Add(Adam);

            women.Add(Amy);
            women.Add(Elise);
            women.Add(Jessica);
            women.Add(Donna);
        }

        public List<Person> FindMatches()
        {
            List<Person> matches = new List<Person>();

            while(men.Exists(x => !x.IsMatched))
            {

            }

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
