namespace Stable_Matching
{
    interface IPerson
    {
        void SetPreferences(Person[] people);
        Person[] GetPreferences();
    }
}
