using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cs5700Hw3.DB
{
    public class DrawableJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;
        public override bool CanRead => true;

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new InvalidOperationException("Use default serialization.");
        }


        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var drawables = new List<DrawableWithState>();
            var arr = JArray.Load(reader);
            foreach (var obj in arr)
            {
                var name = obj["ReadableName"].Value<string>();
                drawables.Add(new DrawableWithState(DrawableFactory.FromReadableName(name)));
              }

            return drawables;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DrawableWithState);
        }
    }
}
