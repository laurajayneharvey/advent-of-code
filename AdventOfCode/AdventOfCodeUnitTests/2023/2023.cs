using AdventOfCode._2023.Day1;
using AdventOfCode._2023.Day10;
using AdventOfCode._2023.Day11;
using AdventOfCode._2023.Day12;
using AdventOfCode._2023.Day13;
using AdventOfCode._2023.Day2;
using AdventOfCode._2023.Day3;
using AdventOfCode._2023.Day4;
using AdventOfCode._2023.Day5;
using AdventOfCode._2023.Day6;
using AdventOfCode._2023.Day7;
using AdventOfCode._2023.Day8;
using AdventOfCode._2023.Day9;
using AdventOfCodeUnitTests._2023;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests
{
    [TestClass]
    public class _2023
    {
        [TestMethod]
        [DataRow(SampleInput.Day1a, 142)]
        [DataRow(RealInput.Day1, 57346)]
        public void Day1_Part1(string input, int expected)
        {
            var program = new Day1_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day1b, 281)]
        [DataRow(RealInput.Day1, 57345)]
        public void Day1_Part2(string input, int expected)
        {
            var program = new Day1_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 8)]
        [DataRow(RealInput.Day2, 2006)]
        public void Day2_Part1(string input, int expected)
        {
            var program = new Day2_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day2, 2286)]
        [DataRow(RealInput.Day2, 84911)]
        public void Day2_Part2(string input, int expected)
        {
            var program = new Day2_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day3, 4361)]
        [DataRow(RealInput.Day3, 538046)]
        public void Day3_Part1(string input, int expected)
        {
            var program = new Day3_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day3, 467835)]
        [DataRow(RealInput.Day3, 81709807)]
        public void Day3_Part2(string input, int expected)
        {
            var program = new Day3_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 13)]
        [DataRow(RealInput.Day4, 23847)]
        public void Day4_Part1(string input, double expected)
        {
            var program = new Day4_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day4, 30)]
        [DataRow(RealInput.Day4, 8570000)]
        public void Day4_Part2(string input, int expected)
        {
            var program = new Day4_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, 35)]
        [DataRow(RealInput.Day5, 214922730)]
        public void Day5_Part1(string input, double expected)
        {
            var program = new Day5_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day5, 46)]
        [DataRow(RealInput.Day5, 148041808)]
        public void Day5_Part2(string input, double expected)
        {
            var program = new Day5_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day6, 288)]
        [DataRow(RealInput.Day6, 781200)]
        public void Day6_Part1(string input, int expected)
        {
            var program = new Day6_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day6, 71503)]
        [DataRow(RealInput.Day6, 49240091)]
        public void Day6_Part2(string input, int expected)
        {
            var program = new Day6_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 6440)]
        [DataRow(RealInput.Day7, 249748283)]
        public void Day7_Part1(string input, int expected)
        {
            var program = new Day7_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 5905)]
        [DataRow(RealInput.Day7, 248029057)]
        public void Day7_Part2(string input, int expected)
        {
            var program = new Day7_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day8a, 2)]
        [DataRow(SampleInput.Day8b, 6)]
        [DataRow(RealInput.Day8, 21389)]
        public void Day8_Part1(string input, double expected)
        {
            var program = new Day8_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day8c, 6)]
        [DataRow(RealInput.Day8, 21083806112641)]
        public void Day8_Part2(string input, double expected)
        {
            var program = new Day8_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day9, 114)]
        [DataRow(RealInput.Day9, 1904165718)]
        public void Day9_Part1(string input, int expected)
        {
            var program = new Day9_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day9, 2)]
        [DataRow(RealInput.Day9, 964)]
        public void Day9_Part2(string input, int expected)
        {
            var program = new Day9_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day10a, 4)]
        [DataRow(SampleInput.Day10b, 8)]
        [SkipDataRow("takes a while (~1.5 min)", RealInput.Day10, 6768)]
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
        [SkipDataRow("takes a while (~1.3 min)", RealInput.Day10, 351)]
        public void Day10_Part2(string input, int expected)
        {
            var program = new Day10_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day11, 374)]
        [DataRow(RealInput.Day11, 9639160)]
        public void Day11_Part1(string input, int expected)
        {
            var program = new Day11_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day11, 10, 1030)]
        [DataRow(SampleInput.Day11, 100, 8410)]
        [DataRow(RealInput.Day11, 1000000, 752936133304)]
        public void Day11_Part2(string input, int expansion, long expected)
        {
            var program = new Day11_Part2();
            var actual = program.Run(input, expansion);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day12, 21)]
        [DataRow(RealInput.Day12, 7843)]
        public void Day12_Part1(string input, long expected)
        {
            var program = new Day12_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day12, 525152)]
        [DataRow(RealInput.Day12, 10153896718999)]
        public void Day12_Part2(string input, long expected)
        {
            var program = new Day12_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day13, 405)]
        [DataRow(RealInput.Day13, 34918)]
        public void Day13_Part1(string input, int expected)
        {
            var program = new Day13_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SkipDataRowAttribute : Attribute
    {
        public SkipDataRowAttribute(string message, string input, object expectedResult)
        {
            Console.WriteLine($"Skipped test: {message}");
        }
    }
}