using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrormationSystem
{
    public static class JsonStorage
    {   
        private const string _jsonPath = "C:\\jsons";

        private static readonly string _personalsFilePath = $"{_jsonPath}{Path.DirectorySeparatorChar}personals.json";
        private static readonly string _usersPath = $"{_jsonPath}{Path.DirectorySeparatorChar}users.json";
        private static readonly string _idFilePath = $"{_jsonPath}{Path.DirectorySeparatorChar}id.json";

        public static void Save(IdGenerator? generator)
        {
            string json = JsonConvert.SerializeObject(generator);
            JsonSave(json, _idFilePath);
        }

        public static void Save(List<Personal> personals)
        {
            string json = JsonConvert.SerializeObject(personals);
            JsonSave(json, _personalsFilePath);
        }

        public static void Save(List<User> users)
        {
            string json = JsonConvert.SerializeObject(users);
            JsonSave(json, _usersPath);
        }

        public static Personal[]? GetPersonals()
        {
            using var sr = new StreamReader(_personalsFilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<Personal[]>(sr.ReadToEnd());
        }

        public static User[]? GetUsers()
        {
            using var sr = new StreamReader(_usersPath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<User[]>(sr.ReadToEnd());
        }

        public static IdGenerator? GetIdGenerator()
        {
            using var sr = new StreamReader(_idFilePath, Encoding.UTF8);
            return JsonConvert.DeserializeObject<IdGenerator>(sr.ReadToEnd());
        }

        private static void JsonSave(string json, string path)
        {
            using var streamWriter = new StreamWriter(path);
            streamWriter.WriteLine(json);
            streamWriter.Close();
        }
    }
}
