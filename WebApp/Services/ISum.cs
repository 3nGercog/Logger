using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public interface ISum
    {
        double SumX(List<Coordinate> coordinates);
        double SumY(List<Coordinate> coordinates);
    }
}
