using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace PluralSight_cSharpFundamentals
{
    public delegate void GradeAddedDelegate(Object sender, EventArgs args);

    public class DiskBook : Book {

        public DiskBook(string name) : base(name) { 
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt")) {
                writer.WriteLine(grade);
                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs()); 
                }
            }      
        }

        public override Statistics GetStatistics()
        {
            return base.GetStatistics();
        }


    }

    public class NamedObject
    {

        public NamedObject(string name)
        {
            Name = name;
        }
        public string Name
        {
            get;
            set;
        }
    }

    public abstract class Book : NamedObject, IBook{
        public Book(string name) : base(name) { 
        }

        public abstract event GradeAddedDelegate GradeAdded; 
        public abstract void AddGrade(double grade);

        public virtual Statistics GetStatistics() {
            throw new NotImplementedException(); 
        }
    }
    
    public interface IBook {
        void AddGrade(double grade);

        Statistics GetStatistics(); 

        string Name { get;  }
        event GradeAddedDelegate GradeAdded; 
    }

   public class InMemoryBook: Book
    {
        public List<double> grades;
        private string name; 

        public InMemoryBook(string name) : base(name)  {
            this.name = name; 
            grades = new List<double>(); 
        }

        public void AddLetterGrade(char letter) { 
        }
     
        public override void AddGrade(double grade) {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
            }
            else {
                throw new ArgumentException($"Invalid{nameof(grade)}");
            }
            
        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics() {

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
