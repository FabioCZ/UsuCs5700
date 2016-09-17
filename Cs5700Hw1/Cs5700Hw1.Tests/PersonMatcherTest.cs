using System.Collections.Generic;
using Cs5700Hw1.Match.Matchers;
using Cs5700Hw1.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cs5700Hw1.Tests
{
    [TestClass]
    public class PersonMatcherTest
    {
        [TestMethod]
        public void TestName()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetAdult(),
                MockPersonFactory.GetAdult2()
            };

            var matches = new NamePersonMatcher().FindMatches(persons);
            Assert.AreEqual(1, matches.Count);
        }

        [TestMethod]
        public void TestName_NoMatch()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetAdult(),
                MockPersonFactory.GetChild()
            };

            var matches = new NamePersonMatcher().FindMatches(persons);
            Assert.AreEqual(0, matches.Count);
        }

        [TestMethod]
        public void TestMother()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetChild(),
                MockPersonFactory.GetChild2()
            };

            var matches = new MotherPersonMatcher().FindMatches(persons);
            Assert.AreEqual(1, matches.Count);
        }

        [TestMethod]
        public void TestMother_NoMatch()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetChild(),
                MockPersonFactory.GetAdult()
            };

            var matches = new MotherPersonMatcher().FindMatches(persons);
            Assert.AreEqual(0, matches.Count);
        }

        [TestMethod]
        public void TestUniqueNumber()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetChild(),
                MockPersonFactory.GetChild2()
            };

            var matches = new UniqueNumbersPersonMatcher().FindMatches(persons);
            Assert.AreEqual(1, matches.Count);
        }

        [TestMethod]
        public void TestUniqueNumber_NoMatch()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetChild(),
                MockPersonFactory.GetAdult()
            };

            var matches = new UniqueNumbersPersonMatcher().FindMatches(persons);
            Assert.AreEqual(0, matches.Count);
        }

        [TestMethod]
        public void TestGenderAndYear()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetChild3(),
                MockPersonFactory.GetAdult3()
            };

            var matches = new GenderAndYearPersonMatcher().FindMatches(persons);
            Assert.AreEqual(1, matches.Count);
        }


        [TestMethod]
        public void TestGenderAndYear_NoMatch()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetChild3(),
                MockPersonFactory.GetAdult4()
            };

            var matches = new GenderAndYearPersonMatcher().FindMatches(persons);
            Assert.AreEqual(0, matches.Count);
        }

        [TestMethod]
        public void TestPhoneNumber()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetAdult4(),
                MockPersonFactory.GetAdult3()
            };

            var matches = new PhonePersonMatcher().FindMatches(persons);
            Assert.AreEqual(1, matches.Count);
        }


        [TestMethod]
        public void TestPhoneNumber_NoMatch()
        {
            var persons = new List<Person>
            {
                MockPersonFactory.GetAdult2(),
                MockPersonFactory.GetAdult4()
            };

            var matches = new PhonePersonMatcher().FindMatches(persons);
            Assert.AreEqual(0, matches.Count);
        }
    }
}