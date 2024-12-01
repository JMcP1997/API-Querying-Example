//This app is meant to demonstrate API querying competancy by reading data from the SWAPI (open Star Wars API)
//And presenting information about planets from the Star Wars Universe

public static class StringExtensions
{
    public static int? ToIntOrNull(this string? input)
    {
        return int.TryParse(input, out int resultParsed) ?
            resultParsed
            : null;
    }

    public static long? ToLongOrNull(this string? input)
    {
        return long.TryParse(input, out long resultParsed) ?
            resultParsed
            : null;
    }
}
