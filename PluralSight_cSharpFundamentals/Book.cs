using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PluralSight_cSharpFundamentals
{
    class Book
    {

        public Book() {
            grades = new List<double>(); 
        }
     
        public void AddGrade(double grade) {
            grades.Add(grade); 
        }
    }
}
