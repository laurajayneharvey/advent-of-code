namespace AdventOfCodeUnitTests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SkipDataRowAttribute : Attribute
    {
        public SkipDataRowAttribute(string message, params object[] _)
        {
            Console.WriteLine($"Skipped test: {message}");
        }
    }
}
