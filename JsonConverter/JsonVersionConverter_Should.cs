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
            oldVersion = JObject.Parse(File.ReadAllText(
                @"c:\Users\VasyaSavincov\Documents\Visual Studio 2015\Projects\json-converter\JsonSamples1\1.v2.json"));
            newVersion = JObject.Parse(File.ReadAllText(
                @"c:\Users\VasyaSavincov\Documents\Visual Studio 2015\Projects\json-converter\JsonSamples1\1.v3.json"));
            converter = new JsonVersionConverter();
        }

        [Test]
        public void Do_ProperConversion()
        {
            var newSerialized = JsonConvert.SerializeObject(newVersion);

            var oldConverted = converter.Convert(oldVersion);
            var oldConvertedSerialized = JsonConvert.SerializeObject(oldConverted);

            oldConvertedSerialized.Should().Be(newSerialized);
        }
    }
}
