namespace AdventOfCode._2023.Day10
{
    public class Day10_Part2
    {
        private readonly Day10 _day10 = new();

        public int? Run(string input)
        {
            var (tiles, width, height) = _day10.GetTiles(input);
            var (mainLoop, stepCount) = _day10.GetMainLoop(tiles, width, height);

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
                            case '-':
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (inside)
                        {
                            insideCount++;
                        }
                    }
                    tileIndex++;
                }
                line = string.Empty;
            }

            return insideCount;
        }
    }
}
