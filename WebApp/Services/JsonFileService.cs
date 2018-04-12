using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;
using Newtonsoft.Json;
using System.IO;

namespace WebApp
{
    public class JsonFileService : IJsonFile
    {
        string AppPath { get { return AppDomain.CurrentDomain.BaseDirectory ; } }
        public void Clear()
        {
            using (var streamWriter = new StreamWriter(Path.Combine(AppPath, "items.json")))
            {
                streamWriter.WriteLine("");
            }
        }

        public List<Coordinate> Read()
        {
            List<Coordinate> result;
            using (var streamReader = new StreamReader(Path.Combine(AppPath, "items.json")))
            {
                var str = streamReader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<Coordinate>>(str);
            }
            return result;
        }

        public void Write(object obj)
        {
            var str = JsonConvert.SerializeObject(obj);
            using (var streamWriter = new StreamWriter(Path.Combine(AppPath, "items.json")))
            {
                streamWriter.WriteLine(str);
            }
        }
    }
}