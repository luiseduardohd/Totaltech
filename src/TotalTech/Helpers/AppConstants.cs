using System;
using System.IO;
using Xamarin.Forms;

namespace TotalTech.Helpers
{
    public static class AppConstants
    {
        // Put constants here that are not of a sensitive nature
        public static string RealmPath
        {
            get
            {
                var docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var libFolder = Path.Combine(docFolder, "..", "Library");
				var realmFile = "temp.realm";
                var realmDir  = Path.Combine(libFolder, realmFile);
				string result;
                switch (Device.RuntimePlatform)
                {
                  case Device.iOS:
						result = realmDir;
                        break;
                  case Device.Android:
                        result = realmFile;
						break;
                  default:
                        result = realmFile;
                        break;
                }
                return result;
            }
        }

        public static string StatesUrl = "http://datamx.io/dataset/73b08ca8-e955-4ea5-a206-ee618e26f081/resource/9c5e8302-221c-46f2-b9f7-0a93cbe5365b/download/estados.json";
        public static double TestLatitude = 25.6577556;
        public static double TestLongitude = -100.3192559;
    }
}
