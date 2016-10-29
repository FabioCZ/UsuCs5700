using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cs5700Hw3.DB
{
    public class BackgroundJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serialization.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            if (jsonObject["Color"] != null)
            {
                return new SolidBackground(Color.FromName(jsonObject["Color"].ToString()));
            }
            else if (jsonObject["ImageFileName"] != null)
            {
                return new ImageBackground(jsonObject["ImageFileName"].ToString());
            }
            throw new InvalidDataException("Cannot convert to concrete IBackground");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(IBackground);
        }
    }
}
