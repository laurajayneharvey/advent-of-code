using System;
using System.Collections.Generic;
using System.Linq;

public class RuleSet
{
    public List<char> Up = new();
    public List<char> Down = new();
    public List<char> Left = new();
    public List<char> Right = new();
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

    private List<Tile> GetNextTiles(List<Tile> tiles, Tile currentTile, bool allowS = false)
    {
        var nextTiles = new List<Tile>();
        var nextToS = false;
        var width = Math.Sqrt(tiles.Count) - 1;

        var up = new Coordinate { X = currentTile.Coordinate.X, Y = currentTile.Coordinate.Y - 1 };
        var canGoUp = up.X >= 0 && up.X <= width && up.Y >= 0 && up.Y <= width;
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
        var canGoDown = down.X >= 0 && down.X <= width && down.Y >= 0 && down.Y <= width;
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
        var canGoLeft = left.X >= 0 && left.X <= width && left.Y >= 0 && left.Y <= width;
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
        var canGoRight = right.X >= 0 && right.X <= width && right.Y >= 0 && right.Y <= width;
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

    private List<Tile> FloodSketch(List<Tile> tiles)
    {
        // replace any pipe that can't be in a loop with '.'
        while (true)
        {
            var countBefore = tiles.Count(x => x.Pipe == '.');

            tiles = tiles.Select(tile =>
            {
                if (tile.Pipe != 'S' && tile.Pipe != '.' && !GetNextTiles(tiles, tile, true).Any())
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

    public void Run()
    {
        var input = @"7-F7-
.FJ|7
SJLL7
|F--J
LJ.LJ";

        var rows = input.Split("\n");
        var tiles = CreateTiles(rows.ToList());
        tiles = FloodSketch(tiles);

        var start = tiles.First(x => x.Pipe == 'S');
        var loops = new List<List<Tile>>();
        var nextTiles = GetNextTiles(tiles, start);

        // up to four potential loop starts to examine (U/D/L/R), eventually will be two remaining (both ends of same loop)
        foreach (var tile in nextTiles)
        {
            loops.Add(new List<Tile> { start, tile });
        }

        var stepCount = 0;
        while (loops.Any())
        {
            var oldLoops = loops;
            loops = new List<List<Tile>>();
            foreach (var oldLoop in oldLoops.ToList())
            {
                nextTiles = GetNextTiles(tiles, oldLoop.Last(), true);
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
        }

        Console.WriteLine((stepCount + 1) / 2);
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