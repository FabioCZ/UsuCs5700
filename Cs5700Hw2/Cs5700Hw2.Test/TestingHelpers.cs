using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw2.Model;

namespace Cs5700Hw2.Test
{
    public static class TestingHelpers
    {
        public static List<Company> GetMockCompanies() => new List<Company>()
            {
                new SimpleCompany("A", 1, "Company A"),
                new SimpleCompany("B", 1, "Company B"),
                new SimpleCompany("C", 1, "Company C"),
                new SimpleCompany("D", 1, "Company D")

            };

        public static byte[] GetMockCompAMessageBytes() => new byte[] { 65, 32, 32, 32, 32, 32, 8, 211, 242, 224, 128, 86, 52, 103, 0, 0, 19, 131, 0, 0, 19, 205, 0, 0, 19, 84, 0, 0, 19, 49, 0, 0, 20, 24, 0, 0, 0, 50, 0, 14, 85, 160 };

    }
}
