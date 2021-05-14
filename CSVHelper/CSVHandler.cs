using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.Globalization;


namespace CSVHelper
{
    class CSVHandler
    {
        public static void ImplementCSVdataHandling()
        {
            string importFilePath = @"C:\Users\prat\source\repos\CSVHelper\CSVHelper\Utility\Addresses.csv";
            string exportFilePath = @"C:\Users\prat\source\repos\CSVHelper\CSVHelper\Utility\export.csv";

            using (var reader = new StreamReader(importFilePath))
            using (var csv=new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data Successfully from adressess.csv");
                foreach(AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.firstname);
                    Console.WriteLine("\t" + addressData.lastname);
                    Console.WriteLine("\t" + addressData.address);
                    Console.WriteLine("\t" + addressData.city);
                    Console.WriteLine("\t" + addressData.state);
                    Console.WriteLine("\t" + addressData.code);

                    Console.WriteLine("******************Reading From csv file and write to  csv file*******************");
                    //Writeing csv file

                    using (var writer=new StreamWriter(exportFilePath))
                    using (var csvExport=new CsvWriter(writer, CultureInfo.InvariantCulture))
                    {
                        csvExport.WriteRecords(records);   
                    }
                }
            }
        }
    }
}
