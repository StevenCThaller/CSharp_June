using System;
using System.Collections.Generic;


namespace TestProject
{
    class Program
    {
        public static bool isOldEnough(int age) 
        {
            if(age >= 21)
            {
                return true;
            }
            return false; 
        }


        static void Main(string[] args)
        {
            // Complete the type:
            int a = 15;
            string b = "Happy birthday!";
            double c = 1.5;
            char d = 'c';
            string test = "Hello \"hello\"";
            bool e = true;




            isOldEnough(15);

            int[] array1 = {1,2,3,4,5};
            // Method 1: Declare and then add values
            List<int> arrayList = new List<int>();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);

            // Method 2: Declare with pre-populated values
            List<int> prePop = new List<int>{1,2,3,4,5};

            List<string> stringList = new List<string>{"Hello", "darkness", "my", "old", "friend"};

            List<object> mixed = new List<object>{1, "Hello"};

            // Declare a dictionary with string keys and values

            Dictionary<bool,int> hawthorneExperiments = new Dictionary<bool,int>();

            hawthorneExperiments.Add(true, 11);
            hawthorneExperiments.Add(false, 1);

            // For loop to run 10 times
            // Python: for i in range(10):
            // JavaScript: for(var i = 0; i < 10; i++) {}
            for(int i = 0; i < 10; i++)
            {
                System.Console.WriteLine(i);
            }

            foreach(KeyValuePair<bool,int> entry in hawthorneExperiments) 
            {
                System.Console.WriteLine($"{entry.Key} - {entry.Value}");
            }

            System.Console.WriteLine($"My name is {0} and my name is", "Tim");
        

            System.Console.WriteLine(11/2);
        }
    }
}
