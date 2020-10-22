using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace PluralSight_cSharpFundamentals
{

   
    class Program
    {

        static void Main(string[] args)
        {

            Book book = new Book("Our Book Object");
            bool done = false; 

            // ..getting the user to input grades
            string input = ""; 
            Console.WriteLine("Welcome to this program");
            Console.WriteLine("Please enter a grade or press q to quit");
            while (input != "q") {
                input = Console.ReadLine();
                book.AddGrade(double.Parse(input));
            }
            Console.WriteLine($"The amount of grades you have entered: {book.grades.Count}");
            DisplayStats(book.GetStats());
        }

           static void DisplayStats(Statistics stats) {
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The Highest grade is {stats.High}");
            Console.WriteLine($"The aerage grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade for this is: {stats.Letter}");
        }

       
    }


}
