using CsvHelper;
using Json.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CSVHelper
{
    class ReadCSV_And_WriteJSON
    {
        public static void ImplementCSVToJson()
        {
            string importFilePath = @"C:\Users\prat\source\repos\CSVHelper\CSVHelper\Utility\Addresses.csv";
            string exportFilePath = @"C:\Users\prat\source\repos\CSVHelper\CSVHelper\Utility\export.csv";

            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data Successfully from adressess.csv");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.firstname);
                    Console.WriteLine("\t" + addressData.lastname);
                    Console.WriteLine("\t" + addressData.address);
                    Console.WriteLine("\t" + addressData.city);
                    Console.WriteLine("\t" + addressData.state);
                    Console.WriteLine("\t" + addressData.code);

                    Console.WriteLine("******************Reading From csv file and write to  csv file*******************");
                    //Writeing json file
                    Newtonsoft.Json.JsonSerializer serializer = new JsonSerializer();
                    using (StreamWriter sw = new StreamWriter(exportFilePath))
                    using (JsonWriter writer = new JsonTextWriter(sw))
                    {
                        serializer.Serialize(writer, records);
                    }
                }

            }
        }
    }
}
