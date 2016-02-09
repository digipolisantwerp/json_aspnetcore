using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Toolbox.Json.Converters
{
    public class NullStringConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object retVal = new Object();
            if (reader.Value == null) return null;
            if (reader.TokenType == JsonToken.StartObject || reader.TokenType == JsonToken.String)
            {
                if (reader.Value.ToString() == "null")
                {
                    retVal = null;
                }
                else
                {
                    retVal = reader.Value;
                }
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                retVal = serializer.Deserialize(reader, objectType);
            }
            return retVal;
        }

        public override bool CanConvert(Type objectType)
        {
            if (typeof(String) == objectType) return true;
            return false;
        }
    }
}
