using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace PluralSight_cSharpFundamentals
{
   public class Book
    {
        public List<double> grades;
        public string Name; 

        public Book(string name) {
            Name = name; 
            grades = new List<double>(); 
        }

        public void AddLetterGrade(char letter) { 
        }
     
        public void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else {
                throw new ArgumentException($"Invalid{nameof(grade)}");
            }
            
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

            switch (result.Average) {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;
                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;
                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;
                case var d when d >= 60:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }
            return result; 
        }
    }
}
