using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Mini_TDD;

namespace FizzBuzz
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class FizzBuzzTest
    {
        FizzBuzz fizzBuzz = new FizzBuzz();
        [Test]
        public void ThirtyShouldPrintFizzBuzz()
        {
            Assert.AreEqual("FizzBuzz", fizzBuzz.Print(30));
        }
        [Test]
        public void TenShouldPrintBuzz()
        {
            Assert.AreEqual("Buzz", fizzBuzz.Print(10));
        }
        [Test]
        public void SixShouldPrintFizz()
        {
            Assert.AreEqual("Fizz", fizzBuzz.Print(6));
        }
        [Test]
        public void FifteenShouldPrintFizzBuzz()
        {
            Assert.AreEqual("FizzBuzz", fizzBuzz.Print(15));
        }
        [Test]
        public void TwoShouldPrintTwo()
        {
            Assert.AreEqual("2", fizzBuzz.Print(2));
        }
        [Test]
        public void FiveShouldPrintBuzz()
        {
            Assert.AreEqual("Buzz", fizzBuzz.Print(5));
        }
        [Test]
        public void ThreeShouldPrintFizz()
        {
            Assert.AreEqual("Fizz", fizzBuzz.Print(3));
        }
        [Test]
        public void OneShouldPrintOne()
        {
            Assert.AreEqual("1", fizzBuzz.Print(1));
        }
    }

    public class FizzBuzz
    {
        public string Print(int i)
        {
            if (i % 15 == 0)
                return "FizzBuzz";

            if (i % 5 == 0)
                return "Buzz";

            if (i % 3 == 0)
                return "Fizz";

            return i.ToString();
        }
    }
}
