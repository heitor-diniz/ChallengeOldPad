// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOldPad.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        [DataRow("0#", " ")]
        [DataRow("1#", "&")]
        [DataRow("11#", "'")]
        [DataRow("111#", "(")]
        [DataRow("2#", "a")]
        [DataRow("22#", "b")]
        [DataRow("222#", "c")]
        [DataRow("3#", "d")]
        [DataRow("33#", "e")]
        [DataRow("333#", "f")]
        [DataRow("4#", "g")]
        [DataRow("44#", "h")]
        [DataRow("444#", "i")]
        [DataRow("5#", "j")]
        [DataRow("55#", "k")]
        [DataRow("555#", "l")]
        [DataRow("6#", "m")]
        [DataRow("66#", "n")]
        [DataRow("666#", "o")]
        [DataRow("7#", "p")]
        [DataRow("77#", "q")]
        [DataRow("777#", "r")]
        [DataRow("7777#", "s")]
        [DataRow("8#", "t")]
        [DataRow("88#", "u")]
        [DataRow("888#", "v")]
        [DataRow("9#", "w")]
        [DataRow("99#", "x")]
        [DataRow("999#", "y")]
        [DataRow("9999#", "z")]
        public void TestOldPhonePad_SendOneCharacter_ReturnCorrectOutput(string input, string expectedOutput)
        {
            string result = Program.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        [DataRow("1112 222 3 333111#", "(acdf(")]
        [DataRow("8333527777 222 3 333111#", "tfjascdf(")]
        [DataRow("4433555 555666#", "hello")]
        [DataRow("4433555 555666#", "hello")]
        [DataRow("227*#", "b")]
        [DataRow("33#", "e")]
        public void TestOldPhonePad_SendMultipleCharacters_ReturnCorrectOutput(string input, string expectedOutput)
        {
            string result = Program.OldPhonePad(input);
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        [DataRow("0wq#")]
        [DataRow("amareloverdecinza12345#")]
        [DataRow("123*ik#")]
        [DataRow("-5#")]
        public void TestMain_InputWithInvalidCharacter_ThrowException(string input)
        {
            string messageExpected = "Invalid Input!";
            var exception = Assert.ThrowsException<Exception>(() => Program.OldPhonePad(input));

            Assert.AreEqual(messageExpected, exception.Message);
        }
        [TestMethod]
        [DataRow("0wq")]
        [DataRow("amareloverdecinza12345")]
        [DataRow("-5")]
        [DataRow("7777")]
        [DataRow("8")]
        [DataRow("88")]
        [DataRow("1112 222 3 333111")]
        public void TestMain_InputWithoutSendComand_ThrowException(string input)
        {
            string messageExpected = "Without send command!";
            var exception = Assert.ThrowsException<Exception>(() => Program.OldPhonePad(input));

            Assert.AreEqual(messageExpected, exception.Message);
        }
        [TestMethod]
        [DataRow(" ")]
        [DataRow("#*#*")]
        [DataRow("*")]
        [DataRow("#")]
        public void TestMain_InputNullOrEmpty_ThrowException(string input)
        {
            string messageExpected = "Input null or Empty!";
            var exception = Assert.ThrowsException<Exception>(() => Program.OldPhonePad(input));

            Assert.AreEqual(messageExpected, exception.Message);
        }

        class TestClass
        {
            static void Main(string[] args)
            {
                // Display the number of command line arguments.
              //  Console.WriteLine(args.Length);
            }
        }
    }
}

