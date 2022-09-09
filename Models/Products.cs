using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Models
{
    class Products
    {
        private static int _id;
        public int Id { get; }
        public string PizzaName { get; set; }
        public double Priaece { get; set; }
        public string PizzaInside { get; set; }
        public Products()
        {
            _id++;
            Id = _id;
        }
    }
}
