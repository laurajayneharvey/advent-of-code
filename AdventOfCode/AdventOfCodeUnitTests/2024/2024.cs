using AdventOfCode._2024.Day1;
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
    }
}