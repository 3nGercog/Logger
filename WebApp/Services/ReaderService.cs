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
        string AppPath { get { return AppDomain.CurrentDomain.BaseDirectory + "bin\\logs"; } }
        List<FileModel> ReadAll()
        {
            DirectoryInfo dir = new DirectoryInfo(AppPath);
            if (!Directory.Exists(AppPath))
            {
                Directory.CreateDirectory(AppPath);
            }
            List<FileModel> result = new List<FileModel>();

            string p = "";
            string fileName = "";
            string[] rows, arr;
            //CultureInfo provider = new CultureInfo("en-US");
            StreamReader streamReader = new StreamReader(Stream.Null);

            foreach (var item in dir.GetFiles())
            {
                p = Path.Combine(AppPath, item.Name);
                streamReader = new StreamReader(p);
                rows = streamReader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                fileName = Path.GetFileNameWithoutExtension(p);
                foreach (var r in rows)
                {
                    arr = r.Split(new char[] { '\t' });
                    result.Add(new FileModel { FileName = fileName, Id = arr[0], Level = arr[1], Message = arr[2] });
                }
            }
            streamReader.Close();
            return result;
        }
        List<FileModel> ReadAllSort(IndexViewModel model)
        {
            DirectoryInfo dir = new DirectoryInfo(AppPath);
            if (!Directory.Exists(AppPath))
            {
                Directory.CreateDirectory(AppPath);
            }
            List<FileModel> result = new List<FileModel>();

            string p = "";
            string fileName = "";
            string[] rows, arr;
            //CultureInfo provider = new CultureInfo("en-US");
            StreamReader streamReader = new StreamReader(Stream.Null);

            foreach (var item in dir.GetFiles())
            {
                p = Path.Combine(AppPath, item.Name);
                streamReader = new StreamReader(p);
                rows = streamReader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                fileName = Path.GetFileNameWithoutExtension(p);
                foreach (var r in rows)
                {
                    arr = r.Split(new char[] { '\t' });
                    switch (model.Level)
                    {
                        case SiteLevel.All:
                            if (!string.IsNullOrEmpty(model.Search))
                            {
                                if (arr.Contains(model.Level.ToString()) || arr.Contains(model.Search))
                                    result.Add(new FileModel { FileName = fileName, Id = arr[0], Level = arr[1], Message = arr[2] });
                            }
                            else
                            {
                                if (arr.Contains(model.Level.ToString()))
                                    result.Add(new FileModel { FileName = fileName, Id = arr[0], Level = arr[1], Message = arr[2] });
                                else
                                    result.Add(new FileModel { FileName = fileName, Id = arr[0], Level = arr[1], Message = arr[2] });
                            }
                            break;
                        case SiteLevel.Debug:
                            
                        case SiteLevel.Info:
                            
                        case SiteLevel.Warn:
                            
                        case SiteLevel.Error:
                            
                        case SiteLevel.Fatal:
                            
                        default:
                            if (!string.IsNullOrEmpty(model.Search))
                            {
                                if (arr.Contains(model.Level.ToString()) || arr.Contains(model.Search))
                                    result.Add(new FileModel { FileName = fileName, Id = arr[0], Level = arr[1], Message = arr[2] });
                            }
                            else
                            {
                                if (arr.Contains(model.Level.ToString()))
                                    result.Add(new FileModel { FileName = fileName, Id = arr[0], Level = arr[1], Message = arr[2] });
                            }
                            break;
                    }
                    
                }
            }
            streamReader.Close();
            return result;
        }
        public List<FileModel> GetAll()
        {
            return this.ReadAll();
        }
        public string GetOne(string fileName, string idRow)
        {
            return File.ReadAllLines(Path.Combine(AppPath, fileName + ".log")).FirstOrDefault(r => r.StartsWith(idRow));
        }
        public List<FileModel> Sort(IndexViewModel model)
        {
            return this.ReadAllSort(model);
        }
    }
}