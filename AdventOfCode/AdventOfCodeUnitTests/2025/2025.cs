using AdventOfCode._2025.Day1;
using AdventOfCode._2025.Day2;
using AdventOfCode._2025.Day3;
using AdventOfCode._2025.Day4;
using AdventOfCode._2025.Day5;
using AdventOfCode._2025.Day6;
using AdventOfCode._2025.Day7;
using AdventOfCode._2025.Day8;
using AdventOfCode._2025.Day9;
using AdventOfCode._2025.Day10;
using AdventOfCode._2025.Day11;
using AdventOfCode._2025.Day12;
using AdventOfCodeUnitTests._2025;

namespace AdventOfCode.UnitTests
{
    [TestClass]
    public class _2025
    {
        [TestMethod]
        [DataRow(SampleInput.Day1, 3)]
        [DataRow(RealInput.Day1, 992)]
        public void Day1_Part1(string input, int expected)
        {
            var program = new Day1_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 0)]
        [DataRow(RealInput.Day2, 0)]
        public void Day2_Part1(string input, int expected)
        {
            var program = new Day2_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day3, 0)]
        [DataRow(RealInput.Day3, 0)]
        public void Day3_Part1(string input, int expected)
        {
            var program = new Day3_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 0)]
        [DataRow(RealInput.Day4, 0)]
        public void Day4_Part1(string input, int expected)
        {
            var program = new Day4_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, 0)]
        [DataRow(RealInput.Day5, 0)]
        public void Day5_Part1(string input, int expected)
        {
            var program = new Day5_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day6, 0)]
        [DataRow(RealInput.Day6, 0)]
        public void Day6_Part1(string input, int expected)
        {
            var program = new Day6_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 0)]
        [DataRow(RealInput.Day7, 0)]
        public void Day7_Part1(string input, int expected)
        {
            var program = new Day7_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day8, 0)]
        [DataRow(RealInput.Day8, 0)]
        public void Day8_Part1(string input, int expected)
        {
            var program = new Day8_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day9, 0)]
        [DataRow(RealInput.Day9, 0)]
        public void Day9_Part1(string input, int expected)
        {
            var program = new Day9_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day10, 0)]
        [DataRow(RealInput.Day10, 0)]
        public void Day10_Part1(string input, int expected)
        {
            var program = new Day10_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day11, 0)]
        [DataRow(RealInput.Day11, 0)]
        public void Day11_Part1(string input, int expected)
        {
            var program = new Day11_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day12, 0)]
        [DataRow(RealInput.Day12, 0)]
        public void Day12_Part1(string input, int expected)
        {
            var program = new Day12_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }
    }
}