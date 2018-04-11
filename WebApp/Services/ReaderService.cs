using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using WebAp;
using WebApp.Models;

namespace WebApp
{
    public class ReaderService : IReader
    {
        string AppPath { get { return AppDomain.CurrentDomain.BaseDirectory + "bin\\logs"; ; } }
        List<FileModel> ReadAll()
        {
            DirectoryInfo dir = new DirectoryInfo(AppPath);
            List<FileModel> result = new List<FileModel>();

            string p = "";
            string fileName = "";
            string[] rows, arr;
            //CultureInfo provider = new CultureInfo("en-US");

            foreach (var item in dir.GetFiles())
            {
                p = Path.Combine(AppPath, item.Name);
                rows = File.ReadAllLines(p);
                fileName = Path.GetFileNameWithoutExtension(p);
                foreach (var r in rows)
                {
                    arr = r.Split(new char[] { '\t' });
                    result.Add(new FileModel { FileName = fileName, Id = arr[0] , Level = arr[1], Message = arr[2]});
                }
                
            }
            return result;
        }
        public List<FileModel> GetdAll()
        {
            return this.ReadAll();
        }

        public string GetOne(string fileName, string idRow)
        {
            return File.ReadAllLines(Path.Combine(AppPath, fileName + ".log")).FirstOrDefault(r => r.StartsWith(idRow));
        }

        public List<FileModel> GetSorted(IndexViewModel model)
        {
            var allRows = this.ReadAll();
            if(model.Level == SiteLevel.All && string.IsNullOrEmpty(model.Search))
            {
                return allRows;
            }
            else if(model.Level == SiteLevel.All && !string.IsNullOrEmpty(model.Search))
            {
                return allRows.Where(fm => fm.Id.Contains(model.Search) || fm.Message.Contains(model.Search)).ToList();
            }
            else if (model.Level != SiteLevel.All && !string.IsNullOrEmpty(model.Search))
            {
                return allRows.Where(fm => fm.Id.Contains(model.Search) || fm.Level.Contains(model.Level.ToString()) || fm.Message.Contains(model.Search)).ToList();
            }
            else if (model.Level != SiteLevel.All && string.IsNullOrEmpty(model.Search))
            {
                return allRows.Where(fm => fm.Level.Contains(model.Level.ToString())).ToList();
            }
            else
            {
                return allRows.ToList();
            }
        }
    }
}