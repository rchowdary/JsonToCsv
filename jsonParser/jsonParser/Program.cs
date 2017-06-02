using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsonParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Work\csvOutput.txt";
            using (StreamReader r = new StreamReader(@"C:\Work\jsonInput.txt"))
            {
                string json = r.ReadToEnd();
                var csv = new StringBuilder();
                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(item.LastModified+",");
                    sb.Append(item.Id + ","); 
                    sb.Append(item.Name + ",");

                    foreach (var score in item.ScoreComponents)
                    {                       
                        sb.Append(score.Name + ", ");
                    }

                    sb.Append(item.Status+ Environment.NewLine);

                    Console.WriteLine("{0} chars: {1}", sb.Length, sb.ToString());

                    csv.AppendLine(sb.ToString()); 
                }
                File.WriteAllText(filePath, csv.ToString());                
            }
        }

        

    }
}
