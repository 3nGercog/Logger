using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp
{
    public static class StringExtension
    {
        public static string StringFormat(this List<Coordinate> coordinates)
        {
            string result = "";
            int number = 1;
            for(int i = 0; i < coordinates.Count; i++)
            {
                result += string.Format("{0}.[ X = {1}, Y = {2}]; ",number.ToString(), coordinates[i].X, coordinates[i].Y);
                number++;
            }
            return result;
        }
    }
}