using Assignment_2_38_Q1_AbstractDemo;

namespace Assignment_2_38_Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataProcessor<int> intProcesser = new IntProcessor();
            intProcesser.DisplayData(24);
            intProcesser.ProcessData(20);

            Console.WriteLine();

            DataProcessor<string> stringProcessor = new StringProcessor();
            stringProcessor.DisplayData("generic abstract class");
            stringProcessor.ProcessData("generic string abstract class");

            Console.ReadLine();
            
        }
    }
}
