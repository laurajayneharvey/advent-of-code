namespace AdventOfCode._2024.Day15
{
    public static class Day15
    {
        public static string Print(List<MapItem> mapItems, int width, int height, char direction)
        {
            var output = $"Move {direction}:\r\n";
            width *= 2;
            for (var i = 0; i < height; i++)
            {
                var line = string.Empty;
                for (var j = 0; j < width; j++)
                {
                    line += mapItems.First(r => r.X == j && r.Y == i).Value;
                }

                output += line;
                output += "\r\n";
            }
            output += "\r\n";

            return output;
        }
    }

    public class MapItem
    {
        public int X;
        public int Y;
        public char Value;
        public bool IsBox => Value == 'O' || Value == '[' || Value == ']';
        public bool IsRobot => Value == '@';
        public bool IsSpace => Value == '.';
        public bool IsWall => Value == '#';
    }
}
