﻿using PluralSight_cSharpFundamentals;
using System;
using Xunit; 

namespace PluralSight_cSharpFundamentals_Tests
{

    public delegate string WriteLogDelegate(string logMessage); 

     public class BookTests
    {

        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod() {
            WriteLogDelegate log = ReturnMessage; 
            log += ReturnMessage;
            log += IncrementCount; 
            var result = log("Hello!");
            Assert.Equal(3, count); 
            
            
        }

        string IncrementCount(string message) {
            count++;
            return message.ToLower(); 
        }

        string ReturnMessage(string message) {
            count++; 
            return message; 
        }
        [Fact]
        public void BookCalculatesStats() {
            //arrange 
            var book = new Book("Time to test some code");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            //act 
            var result = book.GetStats(); 

            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High,1);
            Assert.Equal(77.3, result.Low,1);
            Assert.Equal('B', result.Letter); 
        }
    }
}
