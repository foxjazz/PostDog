using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PostDog
{
    // https://localhost:44390/weatherforecast
    public class Content
    {
        private string appDataFolder;
        public Content()
        {
            appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PostDog";

            if (File.Exists(appDataFolder + "\\PostDog.json"))
            {
                string json = File.ReadAllText(appDataFolder + "\\PostDog.json");
                Uris = JsonSerializer.Deserialize<List<UriData>>(json);
            }
            else
            {
                Uris = new List<UriData>();
            }

            for (int i = 0; i < Uris.Count; i++)
            {
                if (Uris[i].name is null)
                {
                    Uris.RemoveAt(i);
                    i--;
                }
            }
            string jsonr = JsonSerializer.Serialize(Uris);
            File.WriteAllText($"{appDataFolder}\\PostDog.json", jsonr);
        }
        public List<UriData> Uris;

        public void addUri(UriData ud)
        {
            Uris.Add(ud);
            string json = JsonSerializer.Serialize(Uris);
            if (!Directory.Exists(appDataFolder))
                Directory.CreateDirectory(appDataFolder);
            File.WriteAllText($"{appDataFolder}\\PostDog.json", json);

        }
        
    }

    public class UriData
    {
        public string name { get; set; }//https://localhost:44390/weatherforecast
        public string Uri { get; set; }
        public string body { get; set; }
        public string type { get; set;  }
        public Dictionary<string,string> headers { get; set; }


    }
}
