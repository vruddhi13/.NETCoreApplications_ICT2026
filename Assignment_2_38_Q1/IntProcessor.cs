using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_38_Q1_AbstractDemo
{
    public class IntProcessor: DataProcessor<int>
    {
        public override void ProcessData(int data)
        {
            Console.WriteLine("Processing Integer Data: "+(data * 2));
        }
    }
}
