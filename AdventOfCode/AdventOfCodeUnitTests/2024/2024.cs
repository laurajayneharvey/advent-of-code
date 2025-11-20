using AdventOfCode._2024.Day1;
using AdventOfCode._2024.Day10;
using AdventOfCode._2024.Day11;
using AdventOfCode._2024.Day12;
using AdventOfCode._2024.Day13;
using AdventOfCode._2024.Day14;
using AdventOfCode._2024.Day15;
using AdventOfCode._2024.Day17;
using AdventOfCode._2024.Day19;
using AdventOfCode._2024.Day2;
using AdventOfCode._2024.Day3;
using AdventOfCode._2024.Day4;
using AdventOfCode._2024.Day5;
using AdventOfCode._2024.Day6;
using AdventOfCode._2024.Day7;
using AdventOfCode._2024.Day8;
using AdventOfCode._2024.Day9;
using AdventOfCodeUnitTests;
using AdventOfCodeUnitTests._2024;

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

        [TestMethod]
        [DataRow(SampleInput.Day6, 41)]
        [DataRow(RealInput.Day6, 5551)]
        public void Day6_Part1(string input, int expected)
        {
            var program = new Day6_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day6, 6)]
        [SkipDataRow("brute force, unbelievably slow and contains a hack for the particular case", RealInput.Day6, 1939)]
        public void Day6_Part2(string input, int expected)
        {
            var program = new Day6_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 3749)]
        [SkipDataRow("slow", RealInput.Day7, 1620690235709)]

        public void Day7_Part1(string input, long expected)
        {
            var program = new Day7_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day7, 11387)]
        [DataRow(RealInput.Day7, 145397611075341)]
        public void Day7_Part2(string input, long expected)
        {
            var program = new Day7_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day8, 14)]
        [DataRow(RealInput.Day8, 276)]

        public void Day8_Part1(string input, int expected)
        {
            var program = new Day8();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day8, 34)]
        [DataRow(RealInput.Day8, 991)]

        public void Day8_Part2(string input, int expected)
        {
            var program = new Day8();
            var actual = program.Run(input, true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day9, 1928)]
        [DataRow(RealInput.Day9, 6320029754031)]

        public void Day9_Part1(string input, long expected)
        {
            var program = new Day9_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day9, 2858)]
        [DataRow(RealInput.Day9, 6347435485773)]

        public void Day9_Part2(string input, long expected)
        {
            var program = new Day9_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day10a, 1)]
        [DataRow(SampleInput.Day10b, 36)]
        [DataRow(RealInput.Day10, 552)]

        public void Day10_Part1(string input, int expected)
        {
            var program = new Day10();
            var actual = program.Run(input, true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day10b, 81)]
        [DataRow(RealInput.Day10, 1225)]

        public void Day10_Part2(string input, int expected)
        {
            var program = new Day10();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day11, 55312)]
        [DataRow(RealInput.Day11, 194782)]

        public void Day11_Part1(string input, long expected)
        {
            var program = new Day11();
            var actual = program.Run(input, 25);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(RealInput.Day11, 233007586663131)]

        public void Day11_Part2(string input, long expected)
        {
            var program = new Day11();
            var actual = program.Run(input, 75);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day12a, 140)]
        [DataRow(SampleInput.Day12b, 772)]
        [DataRow(SampleInput.Day12c, 1930)]
        [DataRow(RealInput.Day12, 1363682)]

        public void Day12_Part1(string input, int expected)
        {
            var program = new Day12();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day12a, 80)]
        [DataRow(SampleInput.Day12b, 436)]
        [DataRow(SampleInput.Day12c, 1206)]
        [DataRow(SampleInput.Day12d, 236)]
        [DataRow(SampleInput.Day12e, 368)]
        [DataRow(RealInput.Day12, 787680)]

        public void Day12_Part2(string input, int expected)
        {
            var program = new Day12();
            var actual = program.Run(input, true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day13, 480)]
        [DataRow(RealInput.Day13, 31897)]

        public void Day13_Part1(string input, long expected)
        {
            var program = new Day13();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(RealInput.Day13, 87596249540359)]

        public void Day13_Part2(string input, long expected)
        {
            var program = new Day13();
            var actual = program.Run(input, true);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day14, 11, 7, 12)]
        [DataRow(RealInput.Day14, 101, 103, 220971520)]

        public void Day14_Part1(string input, int width, int height, int expected)
        {
            var program = new Day14_Part1();
            var actual = program.Run(input, width, height, 100);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [SkipDataRow("3.8 mins", RealInput.Day14, 101, 103, 6355)]

        public void Day14_Part2(string input, int width, int height, int expected)
        {
            var program = new Day14_Part2();
            var actual = program.Run(input, width, height);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day15a, 2028)]
        [DataRow(SampleInput.Day15b, 10092)]
        [DataRow(RealInput.Day15, 1527563)]

        public void Day15_Part1(string input, int expected)
        {
            var program = new Day15_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        // skipped Day15_Part2 and Day16, just going for ones that look easier now!

        [TestMethod]
        [DataRow(SampleInput.Day17a_1, "", -1, 1, -1)]
        [DataRow(SampleInput.Day17a_2, "0,1,2", -1, -1, -1)]
        [DataRow(SampleInput.Day17a_3, "4,2,5,6,7,7,7,7,3,1,0", 0, -1, -1)]
        [DataRow(SampleInput.Day17a_4, "", -1, 26, -1)]
        [DataRow(SampleInput.Day17a_5, "", -1, 44354, -1)]
        [DataRow(SampleInput.Day17a, "4,6,3,5,6,3,5,2,1,0", -1, -1, -1)]
        [DataRow(RealInput.Day17, "6,5,7,4,5,7,3,1,0", -1, -1, -1)]
        public void Day17_Part1(string input, string expectedOutput, int expectedA, int expectedB, int expectedC)
        {
            var program = new Day17_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expectedOutput, actual.output);
            if (expectedA != -1)
            {
                Assert.AreEqual(expectedA, actual.a);
            }
            if (expectedB != -1)
            {
                Assert.AreEqual(expectedB, actual.b);
            }
            if (expectedC != -1)
            {
                Assert.AreEqual(expectedC, actual.c);
            }
        }

        // skipped Day18

        [TestMethod]
        [DataRow(SampleInput.Day19, 6)]
        [DataRow(RealInput.Day19, 355)]

        public void Day19_Part1(string input, int expected)
        {
            var program = new Day19_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }
    }
}