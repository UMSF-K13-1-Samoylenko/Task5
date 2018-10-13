// <copyright file="NumberConverters_TestClass.cs" company="My company">
//     Copyright (c) My company". All rights reserved.
// </copyright>

namespace Task5_UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Task5_Lib;

    /// <summary>
    /// Class with numberConverters tests
    /// </summary>
    [TestClass]
    public class NumberConverters_TestClass
    {
        /// <summary>
        /// Test method for units
        /// </summary>
        /// <param name="initValue">Value to convert</param>
        /// <param name="expected">String of converted value</param>
        [DataTestMethod]
        [DataRow(0, "zero")]
        [DataRow(1, "one")]
        [DataRow(2, "two")]
        [DataRow(3, "three")]
        [DataRow(4, "four")]
        [DataRow(5, "five")]
        [DataRow(6, "six")]
        [DataRow(7, "seven")]
        [DataRow(8, "eight")]
        [DataRow(9, "nine")]
        [DataRow(-1, "minus one")]
        [DataRow(-5, "minus five")]
        [DataRow(-9, "minus nine")]
        public void UnitsTests(int initValue, string expected)
        {
            Assert.AreEqual(expected, NumberConverters.IntToString(initValue));
        }

        /// <summary>
        /// Tests for dozens
        /// </summary>
        /// <param name="initValue">Value to convert</param>
        /// <param name="expected">String of converted value</param>
        [DataTestMethod]
        [DataRow(10, "ten")]
        [DataRow(20, "twenty")]
        [DataRow(30, "thirty")]
        [DataRow(40, "forty")]
        [DataRow(50, "fifty")]
        [DataRow(60, "sixty")]
        [DataRow(70, "seventy")]
        [DataRow(80, "eighty")]
        [DataRow(90, "ninety")]
        [DataRow(-10, "minus ten")]
        [DataRow(-50, "minus fifty")]
        [DataRow(-90, "minus ninety")]
        public void DozensTests(int initValue, string expected)
        {
            Assert.AreEqual(expected, NumberConverters.IntToString(initValue));
        }

        /// <summary>
        /// Tests for hundreds
        /// </summary>
        /// <param name="initValue">Value to convert</param>
        /// <param name="expected">String of converted value</param>
        [DataTestMethod]
        [DataRow(100, "one hundred")]
        [DataRow(200, "two hundred")]
        [DataRow(300, "three hundred")]
        [DataRow(400, "four hundred")]
        [DataRow(500, "five hundred")]
        [DataRow(600, "six hundred")]
        [DataRow(700, "seven hundred")]
        [DataRow(800, "eight hundred")]
        [DataRow(900, "nine hundred")]
        [DataRow(-100, "minus one hundred")]
        [DataRow(-500, "minus five hundred")]
        [DataRow(-900, "minus nine hundred")]
        public void HundeedTests(int initValue, string expected)
        {
            Assert.AreEqual(expected, NumberConverters.IntToString(initValue));
        }

        /// <summary>
        /// Different tests
        /// </summary>
        /// <param name="initValue">Value to convert</param>
        /// <param name="expected">String of converted value</param>
        [DataTestMethod]
        [DataRow(11, "eleven")]
        [DataRow(12, "twelve")]
        [DataRow(13, "thirteen")]
        [DataRow(14, "fourteen")]
        [DataRow(15, "fifteen")]
        [DataRow(16, "sixteen")]
        [DataRow(17, "seventeen")]
        [DataRow(18, "eighteen")]
        [DataRow(19, "nineteen")]
        [DataRow(25, "twenty five")]
        [DataRow(145, "one hundred forty five")]
        [DataRow(6789, "six thousand seven hundred eighty nine")]
        [DataRow(987654321, "nine hundred eighty seven million six hundred fifty four thousand three hundred twenty one")]
        public void OthersTests(int initValue, string expected)
        {
            Assert.AreEqual(expected, NumberConverters.IntToString(initValue));
        }

        /// <summary>
        /// Exceptions tests
        /// </summary>
        /// <param name="initValue">Value to convert</param>
        [DataTestMethod]
        [DataRow(-1234567890)]
        [DataRow(1234567890)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArgumentOutOfRangeTests(int initValue)
        {
            NumberConverters.IntToString(initValue);
        }
    }
}
