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
            NumberConverter convertNum = new NumberConverter(4);
            Assert.AreEqual(typeof(NumberConverter), convertNum.GetType());
        }

        // 2nd Test: Getting a number from a field
        [TestMethod]
        public void GetNumber_GetsNumber_Int()
        {
            // Arrange
            NumberConverter convertNum = new NumberConverter(7);
            int expectedNum = 7;

            // Act
            int returnedNum = convertNum.Number;

            // Assert
            Assert.AreEqual(expectedNum, returnedNum);

        }

        // 3rd Test: Setting a number for a field
        [TestMethod]
        public void SetNumber_SetsNumber_Void()
        {
            // Arrange
            NumberConverter convertNum = new NumberConverter(7);
            int convertedNum = 10;

            // Act
            convertNum.Number = convertedNum;

            Assert.AreEqual(convertedNum, convertNum.Number);
        }
    }
}