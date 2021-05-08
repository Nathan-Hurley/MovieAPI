using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.App
{
	public static class CSVReader<T>
	{
		public static List<T> Read(string file)
		{
			var data = new List<T>();

			using (var streamReader = new StreamReader(file))
			{
				using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
				{
					data = csvReader.GetRecords<T>().ToList();
				}
			}

			return data;
		}
	}
}
