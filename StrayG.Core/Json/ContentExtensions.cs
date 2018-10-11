namespace StrayG.Core.Json
{
    using System.Net.Http;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    using System.Web;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Extensions for <see cref="HttpContent"/>.
    /// </summary>
    public static class ContentExtensions
    {
        /// <summary>
        /// Converts an object to JSON <see cref="StringContent"/>.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <returns>The <see cref="StringContent"/> object specifying the JSON formatted object.</returns>
        public static StringContent ToJsonContent(this object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        /// <summary>
        /// Converts an object to JSON <see cref="StringContent"/>.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <param name="settings">Custom json serialization settings.</param>
        /// <returns>The <see cref="StringContent"/> object specifying the JSON formatted object.</returns>
        public static StringContent ToJsonContent(this object obj, JsonSerializerSettings settings)
        {
            string json = JsonConvert.SerializeObject(obj, settings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        public static IDictionary<string, string> ToKeyValue(this object metaToken)
        {
            if (metaToken == null)
            {
                return null;
            }

            JToken token = metaToken as JToken;
            if (token == null)
            {
                return ToKeyValue(JObject.FromObject(metaToken));
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = child.ToKeyValue();
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                                                 .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            var value = jValue?.Type == JTokenType.Date ?
                            jValue?.ToString("o", CultureInfo.InvariantCulture) :
                            jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }
    }
}