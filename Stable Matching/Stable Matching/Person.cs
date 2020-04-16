namespace Stable_Matching
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public bool IsMatched { get; set; }
        private Person[] Preferences { get; set; }

        public Person EngagedTo { get; set; }

        public void SetPreferences(Person[] people) 
        { 
            Preferences = people;           
        }

        public Person[] GetPreferences()
        {
            return Preferences;
        }
    }

    public class Male : Person {
        public Male(string name)
        {
            Name = name;
        }
    }

    public class Female : Person {
        public Female(string name)
        {
            Name = name;
        }
    }
}
