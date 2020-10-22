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
                try
                {
                    input = Console.ReadLine();
                    book.AddGrade(double.Parse(input));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                finally { 
                    //.. This code will always run
                    //good for taking precautions to protect data and close connections
                    Console.WriteLine("**")
                }
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
