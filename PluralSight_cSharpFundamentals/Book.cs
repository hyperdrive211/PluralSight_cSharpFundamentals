using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PluralSight_cSharpFundamentals
{
    class Book
    {
        private List<double> grades;
        private string name; 

        public Book(string name) {
            this.name = name; 
            grades = new List<double>(); 
        }
     
        public void AddGrade(double grade) {
            grades.Add(grade);
        }

        public void ShowStats() {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var num in grades) {
                lowGrade = Math.Min(num, lowGrade);
                highGrade = Math.Max(num, highGrade);
                result += num;
            }

            result /= grades.Count;
            Console.WriteLine($"The lowest grade is {lowGrade}");
            Console.WriteLine($"The highest grade is {highGrade}");
            Console.WriteLine($"The average grade is {result:N1}"); 
        }
    }
}
