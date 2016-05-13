using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace JsonConverter
{
    class JsonVersionConverter
    {

        public JObject Convert(JObject oldVersion)
        {
            IList<JProperty> products = oldVersion["products"].Children<JProperty>().ToList();

            return new JObject(
                new JProperty("version", "3"),
                new JProperty("products", new JArray(products
                .Select(p => new JObject(
                    new JProperty("id", int.Parse(p.Name)),
                    new JProperty("name", p.Value["name"]),
                    new JProperty("price", p.Value["price"]),
                    new JProperty("count", p.Value["count"])))))
                );
        }
    }
}