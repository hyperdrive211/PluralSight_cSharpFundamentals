using System;
using System.Collections.Generic;

namespace PluralSight_cSharpFundamentals
{

   
    class Program
    {

        static void Main(string[] args)
        {

            Book book = new Book("Our Book Object");
            book.AddGrade(30.0);
            book.AddGrade(60.0);
            book.AddGrade(77.5);
            var stats = book.GetStats();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The Highest grade is {stats.High}");
            Console.WriteLine($"The aerage grade is {stats.Average:N1}"); 
        }

       
    }


}
