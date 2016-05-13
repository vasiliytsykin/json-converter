using System.IO;
using NUnit.Framework;
using FluentAssertions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonConverter
{
    [TestFixture]
    class JsonVersionConverter_Should
    {
        private JObject oldVersion;
        private JObject newVersion;
        private JsonVersionConverter converter;

        [SetUp]
        public void Setup()
        {
            
            converter = new JsonVersionConverter();
        }

        [Test]
        public void Do_ProperConversion_OnEx1()
        {

            oldVersion = JObject.Parse(File.ReadAllText(
                @"c:\Users\VasyaSavincov\Documents\Visual Studio 2015\Projects\json-converter\JsonSamples1\1.v2.json"));
            newVersion = JObject.Parse(File.ReadAllText(
                @"c:\Users\VasyaSavincov\Documents\Visual Studio 2015\Projects\json-converter\JsonSamples1\1.v3.json"));

            var oldConverted = converter.Convert(oldVersion);
          
            JToken.DeepEquals(newVersion, oldConverted).Should().BeTrue();
        }

        [Test]
        public void Do_ProperConversion_OnEx2()
        {

            oldVersion = JObject.Parse(File.ReadAllText(
                @"c:\Users\VasyaSavincov\Documents\Visual Studio 2015\Projects\json-converter\JsonSamples2\2.v2.json"));
            newVersion = JObject.Parse(File.ReadAllText(
                @"c:\Users\VasyaSavincov\Documents\Visual Studio 2015\Projects\json-converter\JsonSamples2\2.v3.json"));          

            var oldConverted = converter.Convert(oldVersion);           

            JToken.DeepEquals(newVersion, oldConverted).Should().BeTrue();
        }
    }
}
