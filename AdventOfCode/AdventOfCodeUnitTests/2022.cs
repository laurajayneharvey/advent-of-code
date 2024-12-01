using AdventOfCode._2022.Day13;
using AdventOfCodeUnitTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.UnitTests
{
    [TestClass]
    public class _2022
    {
        [TestMethod]
        [DataRow(SampleInput.Day13, 13)]
        [DataRow(RealInput.Day13, 6272)]
        public void Day13_Part1(string input, int expected)
        {
            var program = new _2022_Day13_Part1();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(SampleInput.Day13, 140)]
        [DataRow(RealInput.Day13, 22288)]
        public void Day13_Part2(string input, int expected)
        {
            var program = new _2022_Day13_Part2();
            var actual = program.Run(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
