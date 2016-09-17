using Cs5700Hw1.Model;

namespace Cs5700Hw1.Tests
{
    public static class MockPersonFactory
    {
        public static Child GetChild()
        {
            return new Child
            {
                ObjectId = 1,
                FirstName = "TestFirstC",
                MiddleName = "TestLastC",
                LastName = "TestLastC",
                NewbornScreeningNumber = "123456",
                Gender = "",
                BirthDay = 20,
                MotherFirstName = "MotherC",
                MotherLastName = "MotherC2",
                IsPartOfMultipleBirth = "T",
                BirthOrder = 2
            };
        }

        public static Child GetChild2()
        {
            return new Child
            {
                ObjectId = 2,
                FirstName = "TestFirstC",
                MiddleName = "TestLastC",
                LastName = "TestLastC",
                NewbornScreeningNumber = "123456",
                Gender = "",
                BirthDay = 20,
                MotherFirstName = "MotherC",
                MotherLastName = "MotherC2",
                IsPartOfMultipleBirth = "T",
                BirthOrder = 2
            };
        }

        public static Child GetChild3()
        {
            return new Child
            {
                ObjectId = 3,
                FirstName = "GY1",
                MiddleName = "GY2",
                LastName = "GY3",
                NewbornScreeningNumber = "123456",
                Gender = "M",
                BirthDay = 20,
                BirthYear = 1969,
                MotherFirstName = "MotherC",
                MotherLastName = "MotherC2",
                IsPartOfMultipleBirth = "T",
                BirthOrder = 2
            };
        }

        public static Adult GetAdult()
        {
            return new Adult
            {
                ObjectId = 50,
                FirstName = "TestFirstA",
                MiddleName = "TestLastA",
                LastName = "TestLastA",
                Phone1 = "435-555-1234",
                Gender = "",
                BirthDay = 21
            };
        }

        public static Adult GetAdult2()
        {
            return new Adult
            {
                ObjectId = 51,
                FirstName = "TestFirstA",
                MiddleName = "TestLastA",
                LastName = "TestLastA",
                Phone1 = "435-555-1235",
                Gender = "",
                BirthDay = 21
            };
        }

        public static Adult GetAdult3()
        {
            return new Adult
            {
                ObjectId = 52,
                FirstName = "GY1",
                MiddleName = "GY2",
                LastName = "GY3",
                Phone1 = "435-555-1234",
                Gender = "M",
                BirthDay = 21,
                BirthYear = 1969
            };
        }

        public static Adult GetAdult4()
        {
            return new Adult
            {
                ObjectId = 53,
                FirstName = "GY1",
                MiddleName = "GY2",
                LastName = "GY3",
                Phone2 = "435-555-1234",
                Gender = "M",
                BirthDay = 21,
                BirthYear = 1970
            };
        }
    }
}