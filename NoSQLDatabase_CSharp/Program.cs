using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NoSQLDatabase
{
    internal class NoSQLDatabase
    {
        public static string JsonFile = "F:\\dat.json";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddNewData();
        }

        private static void AddNewData()
        {
            Entidade obj = new Entidade();

            obj.Name = "teste de nome";

            // Inicialize a lista atribbuts antes de adicionar um novo elemento
            obj.Atribbuts = new List<Atribbuts>();

            Atribbuts at = new()
            {
                Name = "testando",
                Dat = "exemplo de dado"
            };

            obj.Atribbuts.Add(at);

            var opt = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(obj, opt);

            File.WriteAllText(JsonFile, json);
        }

    }

    [Serializable]
    public struct Entidade 
    {
        public string Name { get; set; }
        public List<Atribbuts> Atribbuts { get; set; }

    }

    [Serializable]
    public struct Atribbuts 
    {
        public string Name { get; set; }
        public string Dat { get; set; }
        public byte AttKey { get; set; }
    }
}