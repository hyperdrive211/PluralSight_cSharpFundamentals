using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PluralSight_cSharpFundamentals
{
   public class Book
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

        public Statistics GetStats() {

            var result = new Statistics();
            result.Average = 0.0; 
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var num in grades) {
                result.Low = Math.Min(num, result.Low);
                result.High = Math.Max(num, result.High);
                result.Average += num;
            }

            result.Average /= grades.Count;
            return result; 
        }
    }
}
