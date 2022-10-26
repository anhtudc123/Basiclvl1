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
                    
                    return product[i];

                }

            }
            return null;


        }
        static List<Product> findProductByCategory(Product[] product, int Categoryid)
        {
            List < Product > list=new List < Product >();
            for (int i = 0; i < product.Length; i++)
            {
                
                if (product[i].Categoryid == Categoryid)
                {
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
                for(int j = i + 1; j < product.Length-1; j++)
                {
                    if (product[i].Price > product[j].Price)
                    {
                        var temp = product[i];
                        product[i] = product[j];
                        product[j] =  temp;
                    }

                 }
                
                
            }
            for(int i=0 ; i < product.Length; i++)
            {
                list.Add(product[i]);

            }
            return list;
        }
        static List<Product> sortByName(Product[] product)
        {
            List<Product> list = new List<Product>();
            for(int i=1; i < product.Length; i++)
            {
                var temp = product[i];
                int j = i;

                while (j > 0 && product[j-1].Name.Length < temp.Name.Length)
                {
                    product[j]=product[j-1];
                    j--;
                }
                product[j] = temp;

            }
            for (int i = 0; i < product.Length; i++)
            {
                list.Add(product[i]);

            }
            return list;
           
        }
        static string GetCategorythroughid(int categoryid, Category[] category)
        {
            for(int i = 0; i < category.Length; i++)
            {
                if (categoryid == category[i].Categoryid)
                {
                    return category[i].Name;
                }
            }
            return null;
        }
        static List<Product> sortByCategoryName(Product[] product, Category[] category)
        {

            List<Product> list = new List<Product>();
            for (int i = 0; i < product.Length; i++)
            {
                for(int j = i+1; j < category.Length; j++)
                {
                    string Ccategory = GetCategorythroughid(product[j].Categoryid, category);
                    string Pcategory = GetCategorythroughid(product[i].Categoryid, category);
                    if (Ccategory.CompareTo(Pcategory) > 0)
                    {
                        int temp = product[i].Categoryid;
                        product[i].Categoryid = product[j].Categoryid;
                        product[j].Categoryid = temp;
                    }
                }
            }
            for (int i = 0; i < product.Length; i++)
            {
                list.Add(product[i]);

            }
            return list;
        }
        static List<Product> mapProductBCategory(Product[] product, Category[] category)
        {
            List<Product> list = new List<Product>();
            for(int i=0; i < product.Length; i++)
            {
                list.Add(product[i]);
            }
            return list;
        }
        static Product minByPrice(Product[] product)
        {
            Product min = new Product();
            min = product[0];
            for (int i = 0; i < product.Length; i++)
            {
                if( min.Price >product[i].Price )
                {
                    min = product[i];
                }
            }
            return min;
        }
        static Product maxByPrice(Product[] product)
        {
            Product max = new Product();    
            max = product[0];
            for (int i = 0; i < product.Length; i++)
            {
                if (max.Price < product[i].Price)
                {
                        max = product[i];
                }
            }
            return max;
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

            Category[] categorie = new Category[4];
            categorie[0] = new Category { Categoryid = 1, Name = "Computer" };
            categorie[1] = new Category { Categoryid = 2, Name = "Memory" };
            categorie[2] = new Category { Categoryid = 3, Name = "Card" };
            categorie[3] = new Category { Categoryid = 4, Name = "Acsesory" };

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
            List<Product> list = new List<Product>();
            list = sortByCategoryName(product, categorie);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Name + "  " + list[i].Categoryid);
            }
            List<Product> name = new List<Product>();
            name= mapProductBCategory(product, categorie);
            for(int i = 0; i < name.Count; i++)
            {
                var getname = GetCategorythroughid(product[i].Categoryid, categorie);
                Console.WriteLine(name[i].Name + " " + getname);
            }
            minByPrice(product);
            maxByPrice(product);
        }


    }
}
