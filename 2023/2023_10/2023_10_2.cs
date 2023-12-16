using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class RuleSet
{
    public List<char> Up = new List<char>();
    public List<char> Down = new List<char>();
    public List<char> Left = new List<char>();
    public List<char> Right = new List<char>();
}

public class Coordinate
{
    public int X;
    public int Y;
}

public class Tile
{
    public char Pipe;
    public Coordinate Coordinate;
}

public class PipeMaze
{
    private readonly IDictionary<char, RuleSet> rules = new Dictionary<char, RuleSet> {
        {'|', new RuleSet { Up = new List<char> {'7','F','|' }, Down = new List<char> {'J','L','|' }}},
        {'-', new RuleSet { Left = new List<char> {'F','L','-' }, Right = new List<char> { '7', 'J', '-' }}},
        {'7', new RuleSet { Down = new List<char> {'J','L','|' }, Left = new List<char> { 'F', 'L', '-' }}},
        {'F', new RuleSet { Down = new List<char> {'J','L','|' }, Right = new List<char> {'7','J','-'}}},
        {'J', new RuleSet { Up = new List<char> {'7','F','|'}, Left = new List<char> { 'F', 'L', '-' }}},
        {'L', new RuleSet { Up = new List<char> { '7', 'F', '|' }, Right = new List<char> { '7', 'J', '-' }}},
        {'S', new RuleSet { Up = new List<char> { '7', 'F', 'J', 'L', '|', '-' }, Down = new List<char> { '7', 'F', 'J', 'L', '|', '-' }, Left = new List<char> { '7', 'F', 'J', 'L', '|', '-' }, Right = new List<char> { '7', 'F', 'J', 'L', '|', '-' }}}
    };

    private List<Tile> GetNextTiles(List<Tile> tiles, Tile currentTile, int width, int height, bool allowS = false)
    {
        var nextTiles = new List<Tile>();
        var nextToS = false;

        var up = new Coordinate { X = currentTile.Coordinate.X, Y = currentTile.Coordinate.Y - 1 };
        var canGoUp = up.X >= 0 && up.X < width && up.Y >= 0 && up.Y < height;
        if (canGoUp)
        {
            var upTile = tiles.First(tile => tile.Coordinate.X == up.X && tile.Coordinate.Y == up.Y);
            var upChar = upTile.Pipe;
            if (upChar == 'S')
            {
                nextToS = true;
            }
            var gotPipeRules = rules.TryGetValue(currentTile.Pipe, out var pipeRules);
            if ((allowS && upChar == 'S') || gotPipeRules && pipeRules != null && pipeRules.Up.Contains(upChar))
            {
                nextTiles.Add(upTile);
            }
        }

        var down = new Coordinate { X = currentTile.Coordinate.X, Y = currentTile.Coordinate.Y + 1 };
        var canGoDown = down.X >= 0 && down.X < width && down.Y >= 0 && down.Y < height;
        if (canGoDown)
        {
            var downTile = tiles.First(tile => tile.Coordinate.X == down.X && tile.Coordinate.Y == down.Y);
            var downChar = downTile.Pipe;
            if (downChar == 'S')
            {
                nextToS = true;
            }
            var gotPipeRules = rules.TryGetValue(currentTile.Pipe, out var pipeRules);
            if ((allowS && downChar == 'S') || gotPipeRules && pipeRules != null && pipeRules.Down.Contains(downChar))
            {
                nextTiles.Add(downTile);
            }
        }

        var left = new Coordinate { X = currentTile.Coordinate.X - 1, Y = currentTile.Coordinate.Y };
        var canGoLeft = left.X >= 0 && left.X < width && left.Y >= 0 && left.Y < height;
        if (canGoLeft)
        {
            var leftTile = tiles.First(tile => tile.Coordinate.X == left.X && tile.Coordinate.Y == left.Y);
            var leftChar = leftTile.Pipe;
            if (leftChar == 'S')
            {
                nextToS = true;
            }
            var gotPipeRules = rules.TryGetValue(currentTile.Pipe, out var pipeRules);
            if ((allowS && leftChar == 'S') || gotPipeRules && pipeRules != null && pipeRules.Left.Contains(leftChar))
            {
                nextTiles.Add(leftTile);
            }
        }

        var right = new Coordinate { X = currentTile.Coordinate.X + 1, Y = currentTile.Coordinate.Y };
        var canGoRight = right.X >= 0 && right.X < width && right.Y >= 0 && right.Y < height;
        if (canGoRight)
        {
            var rightTile = tiles.First(tile => tile.Coordinate.X == right.X && tile.Coordinate.Y == right.Y);
            var rightChar = rightTile.Pipe;
            if (rightChar == 'S')
            {
                nextToS = true;
            }
            var gotPipeRules = rules.TryGetValue(currentTile.Pipe, out var pipeRules);
            if ((allowS && rightChar == 'S') || gotPipeRules && pipeRules != null && pipeRules.Right.Contains(rightChar))
            {
                nextTiles.Add(rightTile);
            }
        }

        // both an input and output needed in order for it to be part of the loop
        if (nextTiles.Count >= 2)
        {
            // two non-S
            return nextTiles;
        }

        if (nextToS && nextTiles.Count == 1 && nextTiles.First().Pipe != 'S')
        {
            // one S, one other
            return nextTiles;
        }

        return new List<Tile>();
    }

    private List<Tile> FloodSketch(List<Tile> tiles, int width, int height)
    {
        // replace any pipe that can't be in a loop with '.'
        while (true)
        {
            var countBefore = tiles.Count(x => x.Pipe == '.');

            tiles = tiles.Select(tile =>
            {
                if (tile.Pipe != 'S' && tile.Pipe != '.' && !GetNextTiles(tiles, tile, width, height, true).Any())
                {
                    tile.Pipe = '.';
                }

                return tile;
            }).ToList();

            var countAfter = tiles.Count(x => x.Pipe == '.');

            if (countBefore == countAfter)
            {
                break;
            }
        }

        return tiles;
    }

    private List<Tile> CreateTiles(List<string> rows)
    {
        var tiles = new List<Tile>();
        for (var i = 0; i < rows.Count(); i++)
        {
            var columns = rows[i].ToCharArray();
            for (var j = 0; j < columns.Count(); j++)
            {
                var tile = new Tile
                {
                    Coordinate = new Coordinate
                    {
                        X = j,
                        Y = i
                    },
                    Pipe = columns[j]
                };
                tiles.Add(tile);
            }
        }

        return tiles;
    }

    private List<Tile> GetMainLoop(List<Tile> tiles, int width, int height)
    {
        var start = tiles.First(x => x.Pipe == 'S');
        var loops = new List<List<Tile>>();
        var nextTiles = GetNextTiles(tiles, start, width, height);

        // up to four potential loop starts to examine (U/D/L/R), eventually will be two remaining (both ends of same loop)
        foreach (var tile in nextTiles)
        {
            loops.Add(new List<Tile> { start, tile });
        }

        var stepCount = 1; // first tile already added
        var mainLoop = new List<Tile>();
        while (loops.Any())
        {
            var oldLoops = loops;
            loops = new List<List<Tile>>();
            foreach (var oldLoop in oldLoops.ToList())
            {
                nextTiles = GetNextTiles(tiles, oldLoop.Last(), width, height, true);
                nextTiles = nextTiles.Where(tile => !oldLoop.Contains(tile)).ToList();

                // copy the loop n times
                // add a next tile into each
                // add the new loops to the new list
                foreach (var tile in nextTiles)
                {
                    var newLoop = oldLoop;
                    newLoop.Add(tile);
                    loops.Add(newLoop);
                }
            }

            stepCount++;

            if (!loops.Any())
            {
                mainLoop = oldLoops.First(x => x.Count() == stepCount).ToList();
            }
        }

        return mainLoop;
    }

    public void Run()
    {
        // expected 4
        var input1 = @"...........
.S-------7.
.|F-----7|.
.||.....||.
.||.....||.
.|L-7.F-J|.
.|..|.|..|.
.L--J.L--J.
...........";

        // expected 8
        var input2 = @".F----7F7F7F7F-7....
.|F--7||||||||FJ....
.||.FJ||||||||L7....
FJL7L7LJLJ||LJ.L-7..
L--J.L7...LJS7F-7L7.
....F-J..F7FJ|L7L7L7
....L7.F7||L7|.L7L7|
.....|FJLJ|FJ|F7|.LJ
....FJL-7.||.||||...
....L---J.LJ.LJLJ...";

        // expected 10
        var input3 = @"FF7FSF7F7F7F7F7F---7
L|LJ||||||||||||F--J
FL-7LJLJ||||||LJL-77
F--JF--7||LJLJ7F7FJ-
L---JF-JLJ.||-FJLJJ7
|F|F-JF---7F7-L7L|7|
|FFJF7L7F-JF7|JL---7
7-L-JL7||F7|L7F-7F7|
L.L7LFJ|||||FJL7||LJ
L7JLJL-JLJLJL--JLJ.L";

        var regex = new Regex("\n");
        var rows = regex.Split(input3);
        var tiles = CreateTiles(rows.ToList());

        var width = rows[0].ToCharArray().Count();
        var height = rows.Count();
        tiles = FloodSketch(tiles, width, height);
        var mainLoop = GetMainLoop(tiles, width, height);

        var line = string.Empty;
        var tileIndex = 0;
        var inside = false;
        var insideCount = 0;
        char? corner = null;
        for (var i = 0; i < height; i++)
        {
            for (var j = 0; j < width; j++)
            {
                var tile = tiles[tileIndex];
                var mainLoopTile = mainLoop.FirstOrDefault(x => x.Coordinate.X == tile.Coordinate.X && x.Coordinate.Y == tile.Coordinate.Y);
                if (mainLoopTile != null)
                {
                    if (mainLoopTile.Pipe == 'S')
                    {
                        //var nextTiles = GetNextTiles(tiles, mainLoopTile, width, height);
                        var nextOne = mainLoop.Last();
                        var nextTwo = mainLoop[1];
                        var nextTiles = new List<Tile> { nextOne, nextTwo };
                        var hasUp = nextTiles.Any(x => x.Coordinate.X == mainLoopTile.Coordinate.X
                                                            && x.Coordinate.Y == mainLoopTile.Coordinate.Y - 1);

                        var hasDown = nextTiles.Any(x => x.Coordinate.X == mainLoopTile.Coordinate.X
                                                            && x.Coordinate.Y == mainLoopTile.Coordinate.Y + 1);

                        var hasLeft = nextTiles.Any(x => x.Coordinate.X == mainLoopTile.Coordinate.X - 1
                                                            && x.Coordinate.Y == mainLoopTile.Coordinate.Y);

                        var hasRight = nextTiles.Any(x => x.Coordinate.X == mainLoopTile.Coordinate.X + 1
                                                            && x.Coordinate.Y == mainLoopTile.Coordinate.Y);

                        if (hasUp)
                        {
                            if (hasLeft)
                            {
                                mainLoopTile.Pipe = 'J';
                            }
                            else if (hasRight)
                            {
                                mainLoopTile.Pipe = 'L';
                            }
                            else if (hasDown)
                            {
                                mainLoopTile.Pipe = '|';
                            }
                        }

                        if (hasLeft)
                        {
                            if (hasRight)
                            {
                                mainLoopTile.Pipe = '-';
                            }
                            else if (hasDown)
                            {
                                mainLoopTile.Pipe = '7';
                            }
                        }

                        if (hasDown)
                        {
                            if (hasRight)
                            {
                                mainLoopTile.Pipe = 'F';
                            }
                        }
                    }

                    switch (mainLoopTile.Pipe)
                    {
                        case '|':
                            inside = !inside;
                            break;
                        case 'F':
                        case '7':
                        case 'L':
                        case 'J':
                            if (corner == null)
                            {
                                corner = mainLoopTile.Pipe;
                            }
                            else
                            {
                                if ((corner == 'L' && mainLoopTile.Pipe == 'J') ||
                                    (corner == 'F' && mainLoopTile.Pipe == '7'))
                                {
                                    // U-bend
                                }
                                else
                                {
                                    inside = !inside;
                                }
                                corner = null; // finished assessing a pair of corners
                            }
                            break;
                        //case 'S':
                        //    break;
                        case '-':
                        default:
                            break;
                    }
                    Console.Write(tile.Pipe);
                }
                else
                {
                    if (inside)
                    {
                        insideCount++;
                        Console.Write("I");
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                tileIndex++;
            }
            Console.WriteLine(line);
            line = string.Empty;
        }

        Console.WriteLine($"\nInsides count = {insideCount}");
    }
}

public class Program
{
    public static void Main()
    {
        var pipeMaze = new PipeMaze();
        pipeMaze.Run();
    }
}