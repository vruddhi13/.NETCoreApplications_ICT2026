using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_38_Q1_AbstractDemo
{
    public abstract class DataProcessor<T>
    {
        public abstract void ProcessData(T data);

        public void DisplayData(T data)
        {
            Console.WriteLine("Displaying Data: "+data);
        }
    }
}
