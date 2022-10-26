using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b4product
{
    internal class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quality { get; set; }
        public int Categoryid { get; set; }
    }
    internal class Category
    {
        public int Categoryid { get; set; }
        public string Name { get; set; }

    }
}