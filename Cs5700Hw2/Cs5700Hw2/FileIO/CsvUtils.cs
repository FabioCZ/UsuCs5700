using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Cs5700Hw2.Model;
using CsvHelper;

namespace Cs5700Hw2.FileIO
{
    public static class CsvUtils
    {
        public static async Task<List<Company>> ParseCompanyList(StorageFile file)
        {
            var list = new List<Company>();
            var stream = await file.OpenStreamForReadAsync();
            var streamReader = new StreamReader(stream);
            var csv = new CsvReader(streamReader);
            if (csv.ReadHeader())
            {
                list.Add(new SimpleCompany(csv.FieldHeaders[0],Convert.ToDouble(csv.FieldHeaders[1]),csv.FieldHeaders[2]));
            }
            while (csv.Read())
            {
                double? price;
                csv.TryGetField(1, out price);
                list.Add(new SimpleCompany(csv.GetField<string>(0), price,csv.GetField<string>(2)));
            }
            return list;
        }
    }
}
