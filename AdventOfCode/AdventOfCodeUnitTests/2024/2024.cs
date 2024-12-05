﻿using AdventOfCode._2024.Day1;
using AdventOfCode._2024.Day2;
using AdventOfCode._2024.Day3;
using AdventOfCode._2024.Day4;
using AdventOfCode._2024.Day5;
using AdventOfCodeUnitTests._2024;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests
{
    [TestClass]
    public class _2024
    {
        [TestMethod]
        [DataRow(SampleInput.Day1, 11)]
        [DataRow(RealInput.Day1, 2264607)]
        public void Day1_Part1(string input, int expected)
        {
            var program = new Day1_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day1, 31)]
        [DataRow(RealInput.Day1, 19457120)]
        public void Day1_Part2(string input, int expected)
        {
            var program = new Day1_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 2)]
        [DataRow(RealInput.Day2, 332)]
        public void Day2_Part1(string input, int expected)
        {
            var program = new Day2_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 4)]
        [DataRow(RealInput.Day2, 398)]
        public void Day2_Part2(string input, int expected)
        {
            var program = new Day2_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day3a, 161)]
        [DataRow(RealInput.Day3, 175615763)]
        public void Day3_Part1(string input, int expected)
        {
            var program = new Day3_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day3b, 48)]
        [DataRow(RealInput.Day3, 74361272)]
        public void Day3_Part2(string input, int expected)
        {
            var program = new Day3_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 18)]
        [DataRow(RealInput.Day4, 2639)]
        public void Day4_Part1(string input, int expected)
        {
            var program = new Day4_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 9)]
        [DataRow(RealInput.Day4, 2005)]
        public void Day4_Part2(string input, int expected)
        {
            var program = new Day4_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, 143)]
        [DataRow(RealInput.Day5, 6267)]
        public void Day5_Part1(string input, int expected)
        {
            var program = new Day5_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, 123)]
        [DataRow(RealInput.Day5, 5184)]
        public void Day5_Part2(string input, int expected)
        {
            var program = new Day5_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }
    }
}