using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stable_Matching;
using System;
using System.Collections.Generic;

namespace Unit_Testing
{
    [TestClass]
    public class Dataset_Tests
    {
        [TestMethod]
        public void TenPairs_Test()
        {
            // Arrange
            Male David = new Male("David"), James = new Male("James"), John = new Male("John"), Adam = new Male("Adam"), Isaac = new Male("Isaac");
            Male Greg = new Male("Greg"), Craig = new Male("Craig"), Tom = new Male("Tom"), Roger = new Male("Roger"), Harry = new Male("Harry");

            Female Amy = new Female("Amy"), Elise = new Female("Elise"), Jessica = new Female("Jessica"), Donna = new Female("Donna"), Kelly = new Female("Kelly");
            Female Charlotte = new Female("Charlotte"), Hanna = new Female("Hanna"), Megan = new Female("Megan"), Mary = new Female("Mary"), Sarah = new Female("Sarah");

            David.SetPreferences(       new Female[] { Amy, Elise, Jessica, Donna, Kelly, Charlotte, Hanna, Megan, Mary, Sarah });
            James.SetPreferences(       new Female[] { Sarah, Amy, Jessica, Donna, Kelly, Charlotte, Hanna, Megan, Mary, Elise });
            John.SetPreferences(        new Female[] { Amy, Sarah, Elise, Donna, Kelly, Charlotte, Hanna, Megan, Mary, Jessica });
            Adam.SetPreferences(        new Female[] { Amy, Elise, Sarah, Jessica, Kelly, Charlotte, Hanna, Megan, Mary, Donna });
            Greg.SetPreferences(        new Female[] { Amy, Elise, Jessica, Sarah, Donna, Charlotte, Hanna, Megan, Mary, Kelly });
            Isaac.SetPreferences(       new Female[] { Amy, Elise, Jessica, Donna, Sarah, Kelly, Hanna, Megan, Mary, Charlotte });
            Craig.SetPreferences(       new Female[] { Amy, Elise, Jessica, Donna, Kelly, Sarah, Charlotte, Megan, Mary, Hanna });
            Tom.SetPreferences(         new Female[] { Amy, Elise, Jessica, Donna, Kelly, Charlotte, Sarah, Hanna, Mary, Megan });
            Roger.SetPreferences(       new Female[] { Amy, Elise, Jessica, Donna, Kelly, Charlotte, Hanna, Sarah, Megan, Mary });
            Harry.SetPreferences(       new Female[] { Amy, Elise, Jessica, Donna, Kelly, Charlotte, Hanna, Megan, Sarah, Mary });

            Amy.SetPreferences(         new Male[] { David, James, John, Adam, Greg, Isaac, Craig, Tom, Roger, Harry });
            Elise.SetPreferences(       new Male[] { James, John, Adam, Greg, Isaac, Craig, Tom, Roger, Harry, David });
            Jessica.SetPreferences(     new Male[] { John, Adam, Greg, Isaac, Craig, Tom, Roger, Harry, David, James });
            Donna.SetPreferences(       new Male[] { Adam, Greg, Isaac, Craig, Tom, Roger, Harry, David, James, John });
            Kelly.SetPreferences(       new Male[] { Greg, Isaac, Craig, Tom, Roger, Harry, David, James, John, Adam });
            Charlotte.SetPreferences(   new Male[] { Isaac, Craig, Tom, Roger, Harry, David, James, John, Adam, Greg });
            Hanna.SetPreferences(       new Male[] { Craig, Tom, Roger, Harry, David, James, John, Adam, Greg, Isaac });
            Megan.SetPreferences(       new Male[] { Tom, Roger, Harry, David, James, John, Adam, Greg, Isaac, Craig });
            Mary.SetPreferences(        new Male[] { Roger, Harry, David, James, John, Adam, Greg, Isaac, Craig, Tom });
            Sarah.SetPreferences(       new Male[] { Harry, David, James, John, Adam, Greg, Isaac, Craig, Tom, Roger });

            StableMatching.men = new List<Male>() { David, James, John, Adam, Greg, Isaac, Craig, Tom, Roger, Harry };
            StableMatching.women = new List<Female>() { Amy, Elise, Jessica, Donna, Kelly, Charlotte, Hanna, Megan, Mary, Sarah };

            List<Tuple<Male, Female>> expectedResult = new List<Tuple<Male, Female>>()
            { 
                Tuple.Create(David, Amy),
                Tuple.Create(James, Mary),
                Tuple.Create(John, Elise),
                Tuple.Create(Adam , Jessica),
                Tuple.Create(Greg , Donna),
                Tuple.Create(Isaac , Kelly),
                Tuple.Create(Craig , Charlotte),
                Tuple.Create(Tom , Hanna),
                Tuple.Create(Roger , Megan),
                Tuple.Create(Harry , Sarah),
            };

            List<Tuple<Male, Female>> actualResult = new List<Tuple<Male, Female>>();

            // Act
            StableMatching.FindMatches();

            foreach (Male man in StableMatching.men)
                actualResult.Add(Tuple.Create(man, (Female)man.EngagedTo));

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
