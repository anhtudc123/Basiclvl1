using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using b4product;

namespace _4_6_Tu
{
    internal class Program
    {
        static Product findProduct(Product[] product, string Name)
        {
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].Name == Name)
                {
                    //Console.WriteLine(" ten product cua ban la " + product[i].Name);
                    
                    return product[i];

                }

            }
            return null;


        }
        static List<Product> findProductByCategory(Product[] product, int Categoryid)
        {
            List < Product > list=new List < Product >();
            //Console.WriteLine(" cac product thuoc id cua ban la  ");
            for (int i = 0; i < product.Length; i++)
            {
                
                if (product[i].Categoryid == Categoryid)
                {
                    //Console.WriteLine(" " + product[i].Name);
                    list.Add(product[i]);
                }
            }
            return list;
        }
        static List<Product> findProductByPrice(Product[] product, int Price)
        {
            List<Product> list = new List<Product>();
            for (int i = 0; i < product.Length; i++)
            {
                if (product[i].Price <= Price)
                {
                    //Console.WriteLine(" " + product[i].Name);
                    list.Add (product[i]);
                }
            }
            return null;
        }
        static List<Product> sortByPrice(Product[] product)
        {
            
            
            List<Product> list = new List<Product>();
            for(int i= 0; i < product.Length; i++)
            {
                for(int j = i + 1; j < product.Length; j++)
                {
                    if (product[i].Price > product[j].Price)
                    {
                        var k = product[i];
                        product[i] = product[j];
                        product[j] =  k;
                    }

                 }
                //Console.WriteLine(" " + product[i].Name);
                list.Add(product[i]);
            }
            return null;
        }
        static List<Product> sortByName(Product[] product)
        {
            List<Product> list = new List<Product>();
            for(int i=0; i < product.Length; i++)
            {
                int j = i + 1;                 
                while (j > 0 && product[j-1].Name.Count() < product[j].Name.Count())
                { 
                    string temp=product[j-1].Name;
                    product[j-1].Name = product[j].Name;
                    product[j].Name = temp;
                    j--;
                   }
                Console.WriteLine(" " + product[i].Name);
                list.Add(product[i]);
               
            }
            return null;
        }
        public static void Main(string[]args)
        {
            Product[] product = new Product[9];
            product[0] = new Product { Name = "CPU", Price = 750, Quality = 10, Categoryid = 1 };
            product[1] = new Product { Name = "Ram", Price = 50, Quality = 2, Categoryid = 2 };
            product[2] = new Product { Name = "HDD", Price = 70, Quality = 1, Categoryid = 2 };
            product[3] = new Product { Name = "Main", Price = 400, Quality = 3, Categoryid = 1 };
            product[4] = new Product { Name = "Keyboard", Price = 30, Quality = 8, Categoryid = 4 };
            product[5] = new Product { Name = "Mouse", Price = 25, Quality = 50, Categoryid = 4 };
            product[6] = new Product { Name = "VGA", Price = 60, Quality = 35, Categoryid = 3 };
            product[7] = new Product { Name = "Monitor", Price = 120, Quality = 28, Categoryid = 3 };
            product[8] = new Product { Name = "Case", Price = 120, Quality = 28, Categoryid = 5 };
            Console.WriteLine("nhap ten product: ");
            string ten = Console.ReadLine();
            findProduct(product,ten);
            Console.WriteLine("nhap id product: ");
            int id = Convert.ToInt32(Console.ReadLine());
            findProductByCategory(product,id);
            Console.WriteLine("nhap gia tien: ");
            int price = Convert.ToInt32(Console.ReadLine());
            findProductByPrice(product, price);
            sortByPrice(product);
            sortByName(product);

        }


    }
}
