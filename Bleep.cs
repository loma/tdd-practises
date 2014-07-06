using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Bleep
{
    /// <summary>
    /// Summary description for Bleep
    /// </summary>
    [TestFixture]
    public class BleepTest
    {
        Bleep b = new Bleep();

        [Test]
        public void FrankBecomesF___k()
        {
            Assert.AreEqual("F***k", b.Filter("Frank"));
        }

        [Test]
        public void frankBecomesf___k()
        {
            Assert.AreEqual("f***k", b.Filter("frank"));
        }

        [Test]
        public void frAnkBecomesf___k()
        {
            Assert.AreEqual("f***k", b.Filter("frAnk"));
        }

        [Test]
        public void BobBecomesB_b()
        {
            Assert.AreEqual("B*b", b.Filter("Bob"));
        }

        [Test]
        public void FranklyShouldNotBeFiltered()
        {
            Assert.AreEqual("Frankly", b.Filter("Frankly"));
        }

        [Test]
        public void FrankFordShouldBeFilteredAsF___kFord()
        {
            Assert.AreEqual("F***k Ford", b.Filter("Frank Ford"));
        }

        [Test]
        public void FrankFordWithQuoteShouldBeFilteredAsF___kFord()
        {
            Assert.AreEqual("\"F***k Ford\"", b.Filter("\"Frank Ford\""));
        }

        [Test]
        public void FrankWithFullStopShouldBeFilteredAsF___kFullStop()
        {
            Assert.AreEqual("F***k.", b.Filter("Frank."));
        }

        [Test]
        public void BobBobbyShouldBeFilteredAsB_bBobby()
        {
            Assert.AreEqual("B*b Bobby", b.Filter("Bob Bobby"));
        }

        [Test]
        public void FrankWhiteSpacesShouldBeFilteredOnlyF___k()
        {
            Assert.AreEqual("~!@#$%^&*(()_+{}|\":?>< F***k~!@#$%^&*(()_+{}|\":?>< F***k", b.Filter("~!@#$%^&*(()_+{}|\":?>< Frank~!@#$%^&*(()_+{}|\":?>< Frank"));
        }
    }

    public class Bleep
    {
        public string Filter(string input)
        {
            string[] filteredWords = new string[] { "frank", "bob" };
            string[] replacementWords = new string[] { "ran", "o" };
            string[] starsWords = new string[] { "***", "*" };

            string[] words = input.Split(new string[] { "~","!","@","#","$","%","^","&","*","(",")","_","+","{","}","|","\\"," ",":","?",">","<",",",".","?","<",">","\"" }, StringSplitOptions.None);

            string output = "";
            foreach (string word in words)
            {
                string result = word;
                for (int i = 0; i < filteredWords.Length; i++)
                {
                    if (result.ToLower() == filteredWords[i])
                    {
                        result = Regex.Replace(result, replacementWords[i], starsWords[i], RegexOptions.IgnoreCase);
                    }
                }
                output += result + '\u200c';
            }

            return Restore(input, output);
        }

        public string Restore(string input, string output)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (output[i] == '\u200c')
                {
                    sb.Append(input[i]);
                }
                else
                {
                    sb.Append(output[i]);
                }
            }

            return sb.ToString();
        }
    }
}
