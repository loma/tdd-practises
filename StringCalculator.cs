using System;
using System.Linq;
using NUnit.Framework;

namespace StringCalculatorTest
{
    [TestFixture]
    public class StringCalculatorTest
    {
        StringCalculator calculator = new StringCalculator();

        [TestCase("", 0)]
        [TestCase("1", 1)]
        [TestCase("1,2", 3)]
        [TestCase("0,2", 2)]
        [TestCase(",2", 2)]
        [TestCase(",", 0)]
        [TestCase("1,", 1)]
        [TestCase("1,3,4", 8)]
        [TestCase(",1,3,0", 4)]
        [TestCase(",1,3,0,", 4)]
        [TestCase(",-1,3,0,", 2)]
        [TestCase("0/n1/n", 1)]
        [TestCase("/n1/n2", 3)]
        [TestCase("/n1,2", 3)]
        [TestCase("/n,", 0)]
        [TestCase("\\n,", 0)]
        public void ItAddNumberFromStringInput(string input, int expected)
        {
            Assert.AreEqual(expected, calculator.Add(input)); 
        }
    }

    public class StringCalculator
    {
        static readonly string[] Delimiters = new string[]{",", "/n", "\\n"};
        public int Add(string input)
        {
            if (HasDelimiter(input))
            {
                var token = input.Split(Delimiters, StringSplitOptions.None) ;
                return token.Sum(each => ParseNumber(each));
            }
            return ParseNumber(input);
        }

        private static bool HasDelimiter(string input)
        {
            return Delimiters.Any(input.Contains);
        }

        private static int ParseNumber(string a)
        {
            return int.Parse(string.IsNullOrEmpty(a) ? "0" : a);
        }
    }
}
