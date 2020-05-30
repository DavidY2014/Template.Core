using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace Nba.Core.Common
{
    public class CsvConvertHelper
    {
		public static List<CsvModel> ParseCsvDemo(string filePath)
		{
            using (TextReader reader = new StreamReader(filePath))
            {
                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<CsvModel>().ToList();
                return records;
            }
            

        }
	}
}
