using System;

namespace FileExtensionAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            FileExtensionInfo fileInfo = new FileExtensionInfo();

            while (true)
            {
                Console.WriteLine("\nEnter a file extension (or type 'exit' to quit):");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;

                fileInfo.GetInfo(input);
            }
        }
    }
}
