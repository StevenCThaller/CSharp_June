using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQIntro
{
    class Program
    {
        public class User
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public User(string fName, string lName, int age)
            {
                FirstName = fName;
                LastName = lName;
                Age = age;
            }
        }

        static void Main(string[] args)
        {
            List<string> WeirdWords = new List<string>{"Hello", "darkness", "my", "old", "friend", "octopus"};

            List<string> OWords = new List<string>();

            foreach(string word in WeirdWords) 
            {
                if(word[0] == 'o' || word[0] == 'O')
                {
                    OWords.Add(word);
                }
            }




            // In this query, the 'word' before the => is simply a variable declaration. This variable will refer to each
            // object within the set of data being queried through
            List<string> StartWithO = WeirdWords.Where(word => word[0] == 'o' || word[0] == 'O').ToList();


            // IEnumerable is a set of data similar to an array or list, but the only real functionality
            // attached to it is the ability to iterate through it with a for or foreach loop


            List<User> MyUsers = new List<User>
            {
                new User("Bill", "Gates", 64),
                new User("Geoffrey", "Bezos", 47),
                new User("Elon", "Musk", 48),
                new User("Steve", "Jobs", 70)
            };

            // This is a list of all users whose name contains the letter e
            List<User> ContainsE = MyUsers
                .Where(user => user.FirstName.ToLower().Contains("e") || user.LastName.ToLower().Contains("e"))
                .ToList();

            // This is getting the first user in the list whose first name is Bill and last name is Bezos
            User Jeff = MyUsers.FirstOrDefault(user => user.FirstName == "Bill" && user.LastName == "Bezos");
            
            // This is a list of all users not named "Steve," and ordered by their age from oldest to youngest
            List<User> ByAgeNotSeve = MyUsers.OrderByDescending(user => user.Age).Where(user => user.FirstName != "Steve").ToList();


            List<int> Numbers = new List<int>{1,2,3,45,65,67,2,34,1243,6,2,34};
            // Getting the largest number from our list
            int Biggest = Numbers.Max();

            // Getting the AGE of the oldest user
            int Oldest = MyUsers.Max(user => user.Age);

            // Getting the oldest user
            User OldestUser = MyUsers.OrderByDescending(user => user.Age).First();
            User OldestUserTwo = MyUsers.FirstOrDefault(user => user.Age == MyUsers.Max(u => u.Age));

            // This is getting a list of users whose age matches the maximum age of all users
            List<User> ThoseWhoAreOld = MyUsers.Where(user => user.Age == MyUsers.Max(u => u.Age)).ToList();
            
            // Getting a boolean for whether or not any users in the list have a first name of "Jeff"
            bool AreAnyJeffs = MyUsers.Any(user => user.FirstName == "Jeff");

            // Are all users older than 21?
            bool OldEnough = MyUsers.All(user => user.Age > 21);

            // A list of users whose names 
            List<User> Jeffs = MyUsers.Where(user => user.FirstName == "Jeff").ToList();

            // Gettings just the user's first names
            List<string> UserNames = MyUsers.Select(user => user.FirstName).ToList();
            System.Console.WriteLine("Stop here!");
        }

    }
}
