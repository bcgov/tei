namespace TEI.Common.Server;

public static class StringUtility
{
    public static int? AsInt(this string? s)
    {
        if (int.TryParse(s, out int i))
        {
            return i;
        }

        return null;
    }
}
