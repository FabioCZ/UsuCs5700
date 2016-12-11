using System;
using System.Collections.Generic;
using System.Drawing;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Cs5700Hw3.Test.DB
{
    [TestClass]
    public class DrawableJsonConverterTest
    {
        public const string DrawableJson = @"{ ""Drawables"" :[ {
  ""FileName"" : ""Assets/catBowl.png"",
  ""IsSelected"" : false,
  ""Location"" : ""98, 225"",
  ""ReadableName"" : ""Bowl"",
  ""Scale"" : 1.0,
  ""Size"" : ""150, 95""
}, {
  ""FileName"" : ""Assets/cat1.png"",
  ""IsSelected"" : false,
  ""Location"" : ""305, 129"",
  ""ReadableName"" : ""Cat"",
  ""Scale"" : 1.0,
  ""Size"" : ""300, 349""
}, {
  ""FileName"" : ""Assets/cat2.png"",
  ""IsSelected"" : false,
  ""Location"" : ""155, 50"",
  ""ReadableName"" : ""Sleeping Cat"",
  ""Scale"" : 1.0,
  ""Size"" : ""250, 231""
} ]
}
";
        [TestMethod]
        public void TestDeserialization()
        {
            var deserialized = JsonConvert.DeserializeObject<DrawablesMockClass>(DrawableJson);
            Assert.AreEqual("Assets/catBowl.png",deserialized.Drawables[0].FileName);
            Assert.AreEqual(false,deserialized.Drawables[1].IsSelected);
            Assert.AreEqual(new Point(155,50),deserialized.Drawables[2].Location );
        }
    }

    public class DrawablesMockClass
    {
        [JsonConverter(typeof(DrawableJsonConverter))]
        public List<DrawableWithState> Drawables;
    }

}
