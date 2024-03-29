﻿using AdventOfCode._2022.Day1;
using AdventOfCode._2022.Day10;
using AdventOfCode._2022.Day11;
using AdventOfCode._2022.Day12;
using AdventOfCode._2022.Day13;
using AdventOfCode._2022.Day2;
using AdventOfCode._2022.Day3;
using AdventOfCode._2022.Day4;
using AdventOfCode._2022.Day5;
using AdventOfCode._2022.Day6;
using AdventOfCode._2022.Day7;
using AdventOfCode._2022.Day8;
using AdventOfCode._2022.Day9;
using AdventOfCodeUnitTests._2022;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests
{
    [TestClass]
    public class _2022
    {
        [TestMethod]
        [DataRow(SampleInput.Day1, 24000)]
        [DataRow(RealInput.Day1, 74394)]
        public void Day1_Part1(string input, int expected)
        {
            var program = new Day1_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day1, 45000)]
        [DataRow(RealInput.Day1, 212836)]
        public void Day1_Part2(string input, int expected)
        {
            var program = new Day1_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 15)]
        [DataRow(RealInput.Day2, 12645)]
        public void Day2_Part1(string input, int expected)
        {
            var program = new Day2_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 12)]
        [DataRow(RealInput.Day2, 11756)]
        public void Day2_Part2(string input, int expected)
        {
            var program = new Day2_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day3, 157)]
        [DataRow(RealInput.Day3, 7701)]
        public void Day3_Part1(string input, int expected)
        {
            var program = new Day3_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day3, 70)]
        [DataRow(RealInput.Day3, 2644)]
        public void Day3_Part2(string input, int expected)
        {
            var program = new Day3_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 2)]
        [DataRow(RealInput.Day4, 560)]
        public void Day4_Part1(string input, int expected)
        {
            var program = new Day4_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 4)]
        [DataRow(RealInput.Day4, 839)]
        public void Day4_Part2(string input, int expected)
        {
            var program = new Day4_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, "CMZ")]
        [DataRow(RealInput.Day5, "WCZTHTMPS")]
        public void Day5_Part1(string input, string expected)
        {
            var program = new Day5_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, "MCD")]
        [DataRow(RealInput.Day5, "BLSGJSDTS")]
        public void Day5_Part2(string input, string expected)
        {
            var program = new Day5_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day6a, 7)]
        [DataRow(SampleInput.Day6b, 5)]
        [DataRow(SampleInput.Day6c, 6)]
        [DataRow(SampleInput.Day6d, 10)]
        [DataRow(SampleInput.Day6e, 11)]
        [DataRow(RealInput.Day6, 1760)]
        public void Day6_Part1(string input, int expected)
        {
            var program = new Day6_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day6a, 19)]
        [DataRow(SampleInput.Day6b, 23)]
        [DataRow(SampleInput.Day6c, 23)]
        [DataRow(SampleInput.Day6d, 29)]
        [DataRow(SampleInput.Day6e, 26)]
        [DataRow(RealInput.Day6, 2974)]
        public void Day6_Part2(string input, int expected)
        {
            var program = new Day6_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 95437)]
        [DataRow(RealInput.Day7, 1348005)]
        public void Day7_Part1(string input, int expected)
        {
            var program = new Day7_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 24933642)]
        [DataRow(RealInput.Day7, 12785886)]
        public void Day7_Part2(string input, int expected)
        {
            var program = new Day7_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day8, 21)]
        [DataRow(RealInput.Day8, 1851)]
        public void Day8_Part1(string input, int expected)
        {
            var program = new Day8_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day8, 8)]
        [DataRow(RealInput.Day8, 574080)]
        public void Day8_Part2(string input, int expected)
        {
            var program = new Day8_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day9a, 13)]
        [DataRow(RealInput.Day9, 6090)]
        public void Day9_Part1(string input, int expected)
        {
            var program = new Day9_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day9a, 1)]
        [DataRow(SampleInput.Day9b, 36)]
        [DataRow(RealInput.Day9, 2566)]
        public void Day9_Part2(string input, int expected)
        {
            var program = new Day9_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day10, 13140)]
        [DataRow(RealInput.Day10, 13720)]
        public void Day10_Part1(string input, int expected)
        {
            var program = new Day10_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day10, SampleInput.Day10Output)]
        [DataRow(RealInput.Day10, RealInput.Day10Output)] // "FBURHZCH"
        public void Day10_Part2(string input, string expected)
        {
            var program = new Day10_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day11, (ulong)10605)]
        [DataRow(RealInput.Day11, (ulong)98280)]
        public void Day11_Part1(string input, ulong expected)
        {
            var program = new Day11_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day11, (ulong)2713310158)]
        [DataRow(RealInput.Day11, (ulong)17673687232)]
        public void Day11_Part2(string input, ulong expected)
        {
            var program = new Day11_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day12, 31)]
        [DataRow(RealInput.Day12, 528)]
        public void Day12_Part1(string input, int expected)
        {
            var program = new Day12_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day12, 29)]
        [DataRow(RealInput.Day12, 522)]
        public void Day12_Part2(string input, int expected)
        {
            var program = new Day12_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day13, 13)]
        [DataRow(RealInput.Day13, 6272)]
        public void Day13_Part1(string input, int expected)
        {
            var program = new Day13_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day13, 140)]
        [DataRow(RealInput.Day13, 22288)]
        public void Day13_Part2(string input, int expected)
        {
            var program = new Day13_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
