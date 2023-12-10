using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using NumbersToWords.Models;
using System.Collections.Generic;

namespace NumbersToWords.Tests
{
    [TestClass]
    public class NumberConverterTests
    {
        // 1st Test: Creates an instance of Number converter class
        [TestMethod]
        public void NumberConverterConstructor_CreatesInstanceOfNumberCOnverterClass_NumberConverter()
        {
            NumberConverter convertNum = new NumberConverter();
            Assert.AreEqual(typeof(NumberConverter), convertNum.GetType());
        }

        // 2nd Test: Getting a number from my constructor(using auto-implemented properties)
        // public void GetNumber_GetsNumberToConvert_Int()
        // {
        //     // Arrange
        //     NumberConverter convertNum = new NumberConverter();

        //     // Act
        //     int 
        // }
    }
}