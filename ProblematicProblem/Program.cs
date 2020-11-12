
using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        public static Random rng = new Random();        
        
        public static bool cont { get; set; } = true;
        
        public static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        
        
        public static bool YesNo(string answer) 
        {
            string yesno;
            do
            {
                yesno = answer;
                if (yesno.ToLower() != "yes" && yesno.ToLower() != "no" && yesno.ToLower() != "y" && yesno.ToLower() != "n") 
                {
                    Console.WriteLine("Please respond with 'yes' or 'no'");
                    yesno = Console.ReadLine();
                }
            } 
            while (yesno.ToLower() != "yes" && yesno.ToLower() != "no" && yesno.ToLower() != "y" && yesno.ToLower() != "n");

            return yesno == "yes" || yesno == "y" ? true : false;
        }


        static void Main(string[] args)
        {
            string userName = "user";
            int userAge = 0;

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");

            cont = YesNo(Console.ReadLine());
            Console.WriteLine();
            if (cont)
            {

            Console.Write("We are going to need your information first! What is your name? ");
            userName = Console.ReadLine();
                if (userName == "") 
                {
                    userName = "Batman";
                    Console.WriteLine($"you're awfully quiet there. we'll just call you {userName}");
                }

            Console.WriteLine();

            Console.Write("What is your age? ");
                string theirAge;
                bool endLoop;
                do
                {
                    theirAge = Console.ReadLine();
                    endLoop = int.TryParse(theirAge, out userAge);
                    if (endLoop == false) { Console.WriteLine("Please give a number using numerals.\n"); }
                }
                while (endLoop == false);


            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Yes/No: ");
            bool seeList = YesNo(Console.ReadLine());

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = YesNo(Console.ReadLine());
                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();

                        if (userAddition == "")
                        {
                            Console.WriteLine("if you don't respond i can't add it");
                        }
                        else 
                        {
                            activities.Add(userAddition); 
                        }

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                        addToList = YesNo(Console.ReadLine()); }
                    Console.WriteLine();
                    
                }
            }
            
            while (cont)
            {
                Console.WriteLine("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(100);
                }

                Console.WriteLine();

                Console.WriteLine("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(100);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}.");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Would you like to pick again? Yes/No: ");
                Console.WriteLine();
                cont = YesNo(Console.ReadLine());
            }
        }
    }
}
