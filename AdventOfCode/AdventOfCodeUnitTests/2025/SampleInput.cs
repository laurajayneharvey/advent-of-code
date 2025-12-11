namespace AdventOfCodeUnitTests._2025
{
    public class SampleInput
    {
        public const string Day1 = @"L68
L30
R48
L5
R60
L55
L1
L99
R14
L82";

        public const string Day2 = @"11-22,95-115,998-1012,1188511880-1188511890,222220-222224,
1698522-1698528,446443-446449,38593856-38593862,565653-565659,
824824821-824824827,2121212118-2121212124";

        public const string Day3 = @"987654321111111
811111111111119
234234234234278
818181911112111";

        public const string Day4 = @"..@@.@@@@.
@@@.@.@.@@
@@@@@.@.@@
@.@@@@..@.
@@.@@@@.@@
.@@@@@@@.@
.@.@.@.@@@
@.@@@.@@@@
.@@@@@@@@.
@.@.@@@.@.";

        public const string Day5 = @"3-5
10-14
16-20
12-18

1
5
8
11
17
32";

        public const string Day6 = @"123 328  51 64 
 45 64  387 23 
  6 98  215 314
*   +   *   +  ";

        public const string Day7 = @".......S.......
...............
.......^.......
...............
......^.^......
...............
.....^.^.^.....
...............
....^.^...^....
...............
...^.^...^.^...
...............
..^...^.....^..
...............
.^.^.^.^.^...^.
...............";

        public const string Day8 = @"162,817,812
57,618,57
906,360,560
592,479,940
352,342,300
466,668,158
542,29,236
431,825,988
739,650,466
52,470,668
216,146,977
819,987,18
117,168,530
805,96,715
346,949,466
970,615,88
941,993,340
862,61,35
984,92,344
425,690,689";

        /*
         * A(0,0,0)-----1st-----B(1,1,1)-----3rd-----C(4,4,4)-----4th-----D(100,100,100)
         *                                                                      |
         *                                                                      |
         *                                                                      2nd
         *                                                                      |
         *                                                                      |
         * E(1000,1000,1000)    F(2000,2000,2000)    G(3000,3000,3000)    H(102,102,102) 
         * 
         * shortest
         * A-B 1ST
         * A-C 3RD OR 4TH
         * A-D 8TH
         * A-H 10TH...
         * B-C 3RD OR 4TH
         * B-D 7TH
         * B-H 9TH
         * C-D 5TH
         * C-H 6TH
         * D-H 2ND
         * 
         * after connection 1 made, circuits are [[A,B]]
         * after connection 2 made, circuits are [[A,B],[D,H]]
         * after connection 3 made, circuits are [[A,B,C],[D,H]]
         * after connection 4 made, circuits are [[A,B,C],[D,H]] no change
         * after connection 5 made, circuits are [[A,B,C,D,H]]
         * 
         * count = 5 * 1 * 1 = 5
         */
        public const string Day8b = @"0,0,0
1,1,1
4,4,4
100,100,100
102,102,102
1000,1000,1000
2000,2000,2000
3000,3000,3000";

        public const string Day9 = @"7,1
11,1
11,7
9,7
9,5
2,5
2,3
7,3";

        public const string Day10 = @"[.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
[...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
[.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}";

        public const string Day11 = @"aaa: you hhh
you: bbb ccc
bbb: ddd eee
ccc: ddd eee fff
ddd: ggg
eee: out
fff: out
ggg: out
hhh: ccc fff iii
iii: out";

        public const string Day12 = @"";
    }
}