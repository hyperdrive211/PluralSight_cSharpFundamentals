﻿using PluralSight_cSharpFundamentals;
using System;
using Xunit; 

namespace PluralSight_cSharpFundamentals_Tests
{
     public class UnitTest1
    {
        [Fact]
        public void Test1() {
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
        }
    }
}
