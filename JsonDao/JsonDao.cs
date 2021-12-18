using IContract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDao
{
    public class JsonDao : IDao
    {
        String _filename = "basePreset.json";
        public string Description => "Read JSON File";
        public Dictionary<String, String> Preset { get; set; }
        public JsonDao()
        {
            StreamReader reader = new StreamReader(_filename);
            String jsonString = reader.ReadToEnd();
            JObject dJson = JObject.Parse(jsonString);
            Preset = dJson.ToObject<Dictionary<String, String>>();
        }

        public Boolean Create(String key, String value){
            Preset.Add(key, value);
            SavePreset();
            return true;
        }
        
        public String Read(String key){
            return Preset[key];  
        }
        public Boolean Update(String key, String value){
            Preset[key] = value;
            SavePreset();
            return true;
        }
        public Boolean Delete(String key){
            Preset.Remove(key);
            SavePreset();
            return true;
        }
        public Boolean SavePreset()
        {
            String result = JsonConvert.SerializeObject(Preset);
            File.WriteAllText(_filename, result);
            return true;
        }
        public List<String> GetKeys()
        {
            return Preset.Keys.ToList<String>();
        }

        public bool Contains(string key)
        {
            return Preset.ContainsKey(key);
        }
    }
}
