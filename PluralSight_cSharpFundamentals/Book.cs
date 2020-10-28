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
            Statistics result = new Statistics();
            using (var reader = File.OpenText($"{Name}.txt")) {
                var line = reader.ReadLine();
                while (line != null) {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine(); 
                }
            }

            return result; 
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

            Statistics result = new Statistics();

            for (int i = 0; i < grades.Count; i++) {
                result.Add(grades[i]); 
            }

            return result; 
        }
    }
}
