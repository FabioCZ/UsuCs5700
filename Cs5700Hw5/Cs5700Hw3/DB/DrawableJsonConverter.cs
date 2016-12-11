using System;
using System.Collections.Generic;
using System.Drawing;
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
                var drw = new DrawableWithState(DrawableFactory.FromReadableName(name));
                drw.Scale = obj["Scale"].Value<float>();
                var location = obj["Location"].Value<string>().Split(',');
                drw.Location = new Point(Convert.ToInt32(location[0]),Convert.ToInt32(location[1]));
                drw.IsSelected = false;
                
                drawables.Add(drw);

              }

            return drawables;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DrawableWithState);
        }
    }
}
