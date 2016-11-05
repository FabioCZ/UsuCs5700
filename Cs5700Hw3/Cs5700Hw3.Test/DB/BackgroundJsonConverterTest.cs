using System;
using System.Drawing;
using Cs5700Hw3.DB;
using Cs5700Hw3.Drawables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Cs5700Hw3.Test.DB
{
    [TestClass]
    public class BackgroundJsonConverterTest
    {
        public const string BackgroundJson = @"{""Background"" : {
        ""Color"" : ""Black""
      }}";
        [TestMethod]
        public void TestBackgroundJsonConverter()
        {
            var deserialized = JsonConvert.DeserializeObject<BackgroundMockClass>(BackgroundJson);
            Assert.AreEqual(Color.Black,((SolidBackground)deserialized.Background).Color);
        }
    }

    public class BackgroundMockClass
    {
        [JsonConverter(typeof(BackgroundJsonConverter))]
        public IBackground Background;
    }
}
