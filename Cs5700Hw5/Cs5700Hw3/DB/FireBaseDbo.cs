using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using Cs5700Hw3.Drawables;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace Cs5700Hw3.DB
{
    /// <summary>
    /// This class is a singleton
    /// </summary>
    public class FireBaseDbo
    {
        private static FireBaseDbo instance;
        private FirebaseClient client;

        public static FireBaseDbo Instance => instance ?? (instance = new FireBaseDbo());

        private FireBaseDbo()
        {
            client = new FirebaseClient("https://cs5700hw3.firebaseio.com/");
        }

        public async void Save(PictureState picture)
        {
            var res = await client.Child("pictures").PostAsync(picture);
            Debug.WriteLine(res.Key);
        }

        public async Task<List<PictureState>> AvailablePictures()
        {
            var list = new List<PictureState>();
            var res = await client.Child("pictures").OrderByKey().OnceAsync<PictureState>();
            foreach (var r in res)
            {
                list.Add(r.Object);
                Debug.WriteLine(r.Object.PictureName);
            }
            return list;
        }

    }
}
