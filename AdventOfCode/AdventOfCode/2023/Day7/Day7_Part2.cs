﻿namespace AdventOfCode._2023.Day7
{
    public class Day7_Part2
    {
        private readonly Day7 _day7;

        public Day7_Part2()
        {
            _day7 = new Day7();
        }

        public int Run(string input)
        {
            return _day7.Run(input, true);
        }
    }
}
