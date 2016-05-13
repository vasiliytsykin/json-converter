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
                .Select(JPropToJObj)))
                );
        }

        private JObject JPropToJObj(JProperty jProperty)
        {
            var name = jProperty.Name;
            JToken size;

            JObject val = (JObject)jProperty.Value;
            val.AddFirst(new JProperty("id", int.Parse(name)));

            if (val.TryGetValue("size", out size))
            {
                val.Property("size").Remove();
                val.Add(SizeToDimensions(size));           
            }

            return val;
        }

        private JProperty SizeToDimensions(JToken size)
        {                    
            return new JProperty("dimensions", 
                new JObject(new JProperty("w", size[0]), 
                new JProperty("h", size[1]), 
                new JProperty("l", size[2])));
        }
    }
}