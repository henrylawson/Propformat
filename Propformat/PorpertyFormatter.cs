namespace Propformat
{
    using System;

    public static class PorpertyFormatter
    {
        public static string FormatUsingProperties<TProperty>(this string str, TProperty instance, params Func<TProperty, string>[] properties)
        {
            var stringsToParse = new object[properties.Length];
            for (var i = 0; i < properties.Length; i++)
            {
                stringsToParse[i] = properties[i](instance);
            }
            return string.Format(str, stringsToParse);
        }
    }
}
