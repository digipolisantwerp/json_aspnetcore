using Newtonsoft.Json;
using Toolbox.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Salga.UnitTests.JsonConverterTests
{
    public class NullStringConverterTests
    {
        private const string JsonObject = "{ id:1, name: 'null', contactinfo:{telephone:'null', email:'test@test.com', fax:null }}";
        private class Persoon
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ContactInfo ContactInfo { get; set; }
        }
        private class ContactInfo
        {
            public string Telephone { get; set; }
            public string Email { get; set; }
            public string Fax { get; set; }
        }

        [Fact]
        public void NullConverterCanConvertNullStringToNull()
        {
            var objString = JsonObject;
            var persoon = JsonConvert.DeserializeObject<Persoon>(objString, new JsonConverter[1] { new NullStringConverter() });

            Assert.Null(persoon.Name);
            Assert.Null(persoon.ContactInfo.Telephone);
        }
        [Fact]
        public void NullConverterCanHandleNullValues()
        {
            var objString = JsonObject;
            var persoon = JsonConvert.DeserializeObject<Persoon>(objString, new JsonConverter[1] { new NullStringConverter() });

            Assert.Null(persoon.ContactInfo.Fax);
        }
        [Fact]
        public void NullConverterIgnoresOtherStrings()
        {
            var objString = JsonObject;
            var persoon = JsonConvert.DeserializeObject<Persoon>(objString, new JsonConverter[1] { new NullStringConverter() });

            Assert.NotNull(persoon.ContactInfo.Email);
        }
    }
}
