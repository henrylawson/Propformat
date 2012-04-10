namespace Propformat
{
    using System;

    public class PropertyFormatter<TProperty>
    {
        private readonly string formatString;

        private readonly Func<TProperty, string>[] properties;

        public PropertyFormatter(string formatString, params Func<TProperty, string>[] properties)
        {
            this.formatString = formatString;
            this.properties = properties;
        }

        public string Format(TProperty instance)
        {
            var stringsToParse = new object[properties.Length];
            for (var i = 0; i < properties.Length; i++)
            {
                stringsToParse[i] = properties[i](instance);
            }
            return string.Format(formatString, stringsToParse);
        }
    }
}
