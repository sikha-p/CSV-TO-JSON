using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Newtonsoft.Json;
namespace CsvToJson
{
    public class Class1
    {
        public string ConvertCsvToJson(string csvFilePath,string txtFilePath)
        {
            DataTable dt = ConvertCSVtoDataTable(csvFilePath);
            string JSONString = string.Empty;
            JSONString = JsonConvert.SerializeObject(dt);
            File.WriteAllText(txtFilePath, JSONString);
            return JSONString;
        }



        private DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }

            }
            return dt;
        }


    }
}
