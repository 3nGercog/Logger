using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp
{
    public class SumService : ISum
    {
        public double SumX(List<Coordinate> coordinates)
        {
            double item = 0;
            for (int i = 0; i < coordinates.Count; i++)
            {
                if(i == 0)
                {
                    item = coordinates[i].X * (coordinates[i + 1].Y - coordinates[i].Y);
                }
                else if(i == coordinates.Count - 1)
                {
                    item += coordinates[i].X * (coordinates[i].Y - coordinates[i - 1].Y);
                }
                else
                {
                    item += coordinates[i].X * (coordinates[i + 1].Y - coordinates[i - 1].Y);
                }
            }
            return item / 2;
        }

        public double SumY(List<Coordinate> coordinates)
        {
            double item = 0;
            for (int i = 0; i < coordinates.Count; i++)
            {
                if (i == 0)
                {
                    item = coordinates[i].Y * (coordinates[i].X - coordinates[i + 1].X);
                }
                else if (i == coordinates.Count - 1)
                {
                    item += coordinates[i].Y * (coordinates[i - 1].X - coordinates[i].X);
                }
                else
                {
                    item += coordinates[i].Y * (coordinates[i - 1].X - coordinates[i + 1].X);
                }
            }
            return item / 2;
        }
    }
}