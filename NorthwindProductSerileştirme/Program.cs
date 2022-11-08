using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProductSerileştirme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataModel dm = new DataModel();
            List<Product> products = dm.ProductReader();
            Depo d = new Depo();
            d.Products = products;
            string serilestirilmis = dm.XmlSerializeList(d);
            Console.WriteLine(serilestirilmis);

            Depo d2 = dm.XmlDeSerializeList(serilestirilmis);
            Console.WriteLine("*-*-*-*-*-*-De Serialization-*-*-*-*-*--*");
            foreach (Product item in d2.Products)
            {
                Console.WriteLine(item.ProductID);
                Console.WriteLine(item.ProductName);
                Console.WriteLine(item.SupplierID);
                Console.WriteLine(item.CategoryID);
                Console.WriteLine(item.QuantityPerUnit);
                Console.WriteLine(item.UnitPrice);
                Console.WriteLine(item.UnitsInStock);
                Console.WriteLine(item.UnitsOnOrder);
                Console.WriteLine(item.ReorderLevel);
                Console.WriteLine(item.Discontinued);
                Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-");
            }
            dm.DosyaYazma(serilestirilmis);
        }
    }
}
