using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_38_Q1_AbstractDemo
{
    public class StringProcessor : DataProcessor<string>
    {
        public override void ProcessData(string data)
        {
            Console.WriteLine("Processing String Data: "+ data.ToUpper());
        }
    }
}
