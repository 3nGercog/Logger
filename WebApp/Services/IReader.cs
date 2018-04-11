using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebAp
{
    public interface IReader
    {
        List<FileModel> GetAll();
        List<FileModel> Sort(IndexViewModel model);
        string GetOne(string fileName, string idRow);
    }
}
