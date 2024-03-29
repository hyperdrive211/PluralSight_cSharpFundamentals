﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PluralSight_cSharpFundamentals
{
    public class Statistics
    {
        public double Average {
            get {
                return Sum / Count; 
            }
        }

        public char Letter
        {

            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60:
                        return 'D';
                    default:
                        return 'F';


                }
            }

        }

        public double High;
        public double Low;
        public double Sum;
        public int Count;

        public void Add(double number) {
            Sum += number;
            Count += 1;
            Low = Math.Min(number, Low);
            High = Math.Max(number, High); 
        }

        public Statistics() {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }

       

        

}
}
