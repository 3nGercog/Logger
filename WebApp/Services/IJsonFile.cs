using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public interface IJsonFile
    {
        List<Coordinate> Read();
        void Write(object obj);
        void Clear();
    }
}
