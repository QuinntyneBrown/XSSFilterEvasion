using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace XSSFilterEvasion.Api.ValueObjects
{
    public class Html : ValueObject
    {
        [JsonIgnore]
        public string Value { get; private set; }

        protected Html() { }

        private Html(string value)
        {
            Value = new Ganss.XSS.HtmlSanitizer().Sanitize(value);
        }

        public static Result<Html> Create(string value)
        {
            value = (value ?? string.Empty).Trim();

            return Result.Success(new Html(value));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static implicit operator string(Html html)
        {
            return html.Value;
        }

        public static explicit operator Html(string html)
        {
            return Create(html).Value;
        }
    }
}
