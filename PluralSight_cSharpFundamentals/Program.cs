using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace PluralSight_cSharpFundamentals
{


    class Program
    {

        static void Main(string[] args)
        {

            DiskBook book = new DiskBook("Our Book Object");
            // ..getting the user to input grades
            EnterGrades(book);

           
        }

        private static void EnterGrades(DiskBook book) {
            string input = "";
            Console.WriteLine("Welcome to this program");
            Console.WriteLine("Please enter a grade or press q to quit");
            while (input != "q")
            {
                try
                {
                    input = Console.ReadLine();
                    book.AddGrade(double.Parse(input));
                    //... 
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                finally
                {
                    //.. This code will always run
                    //good for taking precautions to protect data and close connections
                    Console.WriteLine("**");
                }
            }
          
            DisplayStats(book.GetStatistics());
        }
        static void DisplayStats(Statistics stats)
        {
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The Highest grade is {stats.High}");
            Console.WriteLine($"The aerage grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade for this is: {stats.Letter}");
        }

    }


  
}

       

