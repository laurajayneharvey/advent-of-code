using AdventOfCode._2023.Day10;
using AdventOfCodeUnitTests._2023;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests
{
    [TestClass]
    public class _2023
    {
        [TestMethod]
        [DataRow(SampleInput.Day1, 0)]
        [DataRow(RealInput.Day1, 0)]
        public void Day1_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day1, 0)]
        [DataRow(RealInput.Day1, 0)]
        public void Day1_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 0)]
        [DataRow(RealInput.Day2, 0)]
        public void Day2_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 0)]
        [DataRow(RealInput.Day2, 0)]
        public void Day2_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day3, 0)]
        [DataRow(RealInput.Day3, 0)]
        public void Day3_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day3, 0)]
        [DataRow(RealInput.Day3, 0)]
        public void Day3_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 0)]
        [DataRow(RealInput.Day4, 0)]
        public void Day4_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 0)]
        [DataRow(RealInput.Day4, 0)]
        public void Day4_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, 0)]
        [DataRow(RealInput.Day5, 0)]
        public void Day5_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, 0)]
        [DataRow(RealInput.Day5, 0)]
        public void Day5_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day6, 0)]
        [DataRow(RealInput.Day6, 0)]
        public void Day6_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day6, 0)]
        [DataRow(RealInput.Day6, 0)]
        public void Day6_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 0)]
        [DataRow(RealInput.Day7, 0)]
        public void Day7_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 0)]
        [DataRow(RealInput.Day7, 0)]
        public void Day7_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day8, 0)]
        [DataRow(RealInput.Day8, 0)]
        public void Day8_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day8, 0)]
        [DataRow(RealInput.Day8, 0)]
        public void Day8_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day9, 0)]
        [DataRow(RealInput.Day9, 0)]
        public void Day9_Part1(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day9, 0)]
        [DataRow(RealInput.Day9, 0)]
        public void Day9_Part2(string input, int expected)
        {
        }

        [TestMethod]
        [DataRow(SampleInput.Day10a, 4)]
        [DataRow(SampleInput.Day10b, 8)]
        [DataRow(RealInput.Day10, 6768)] // takes a while (~1.5 min)
        public void Day10_Part1(string input, int expected)
        {
            var program = new Day10_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day10c, 4)]
        [DataRow(SampleInput.Day10d, 8)]
        [DataRow(SampleInput.Day10e, 10)]
        [DataRow(RealInput.Day10, 351)] // takes a while (~1.3 min)
        public void Day10_Part2(string input, int expected)
        {
            var program = new Day10_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
