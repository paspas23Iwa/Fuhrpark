using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace fuhrpark
{
    internal class JSONLoader
    {
        static string filepath = Path.Combine(AppContext.BaseDirectory, "fuhrpark.json");
        public static void Save(List<Fahrzeuge> _fahrzeugeToSave)
        {
            string jsonString = JsonConvert.SerializeObject(_fahrzeugeToSave, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            if (!File.Exists(filepath))
                File.Create(filepath).Close();

            try
            {
                File.WriteAllText(filepath, jsonString);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not save: {e}");
            }
        }

        public static List<Fahrzeuge> Load()
        {
            List<Fahrzeuge> fahrzeuge = new List<Fahrzeuge>();

            if (!File.Exists(filepath))
                File.Create(filepath).Close();

            try
            {
                string jsonString = File.ReadAllText(filepath);
                fahrzeuge = JsonConvert.DeserializeObject<List<Fahrzeuge>>(jsonString, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

                if (fahrzeuge == null)
                    fahrzeuge = new List<Fahrzeuge>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not load: {e}");
            }
            return fahrzeuge;
        }
    }
}
