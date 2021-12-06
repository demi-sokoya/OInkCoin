using System;
using System.Collections.Generic;
using System.Text;

namespace OinkCoin.Models
{
    public class Category
    {
        //[Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public Xamarin.Forms.Brush BrushColor { get; set; }


    }
}
