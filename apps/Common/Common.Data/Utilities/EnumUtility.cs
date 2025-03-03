namespace TEI.Common.Data.Utilities;

using System.Reflection;
using System.Runtime.Serialization;

public static class EnumUtility
{
    public static string ToEnumString<T>(T instance, bool useAttribute = true)
        where T : struct, Enum
    {
        string enumString = instance.ToString();
        if (useAttribute)
        {
            FieldInfo? field = typeof(T).GetField(enumString);
            EnumMemberAttribute? attr = (EnumMemberAttribute?)field?.GetCustomAttributes(typeof(EnumMemberAttribute), false).SingleOrDefault();
            if (attr?.Value != null)
            {
                enumString = attr.Value;
            }
        }

        // if there's no EnumMember attr, use the default value
        return enumString;
    }
}
