using System;
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
             var products = oldVersion["products"];
         
            //products.Children().Select(t => JToken)

            return new JObject();
            
        }
    }
}