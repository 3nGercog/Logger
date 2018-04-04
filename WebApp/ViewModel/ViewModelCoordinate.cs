using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.ViewModel
{
    public class ViewModelCoordinate
    {
        [Display(Name = "Coordinate X")]
        [UIHint("Number", "HTML")]
        [Required()]
        [Range(-100, 100, ErrorMessage = "Coordinate must be between -100 and 100")]
        public int X { get; set; }
        [Display(Name = "Coordinate Y")]
        [UIHint("Number", "HTML")]
        [Required()]
        [Range(-100, 100, ErrorMessage = "Coordinate must be between -100 and 100")]
        public int Y { get; set; }

        public List<Coordinate> Coordinates { get; set; }
    }
}