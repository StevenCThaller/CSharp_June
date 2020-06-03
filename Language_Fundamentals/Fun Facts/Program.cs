using System;

namespace Fun_Facts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Which room would you like to go to?");
            System.Console.WriteLine("1. Cave\n2. Farm\n3. House");

            string response = Console.ReadLine();

            if(response == "1" || response.ToLower().Contains("one") || response.ToLower().Contains("cave"))
            {
                System.Console.WriteLine("You went to the cave!");
            }
            else if (response == "House")
            {
                System.Console.WriteLine();
            }
            else if (response.ToLower().Contains("leave me alone")) 
            {
                System.Console.WriteLine("YOU LOSE");
            }
        }
    }
}
