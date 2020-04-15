namespace Stable_Matching
{
    public class Person : IPerson
    {
        public string Name { get; set; }
        public bool IsMatched { get; set; }
        internal Person[] Preferences { get; set; }

        public void SetPreferences(Person[] people) 
        { 
            Preferences = people; 
        }
    }

    public class Male : Person {
        public Male()
        {
            Name = GetType().GetProperties()[0].Name;
        }
    }

    public class Female : Person {
        public Female()
        {
            Name = GetType().GetProperties()[0].Name;
        }
    }
}
