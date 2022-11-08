using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace NorthwindProductSerileştirme
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStrTest);
            cmd = con.CreateCommand();
        }

        public List<Product> ProductReader()
        {
            List<Product> products = new List<Product>();
            try
            {
                cmd.CommandText = "SELECT P.*, C.CategoryName FROM Products AS P JOIN Categories AS C ON C.CategoryID =P.CategoryID WHERE Discontinued=0 ";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product()
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        SupplierID = reader.GetInt32(2),
                        CategoryID = reader.GetInt32(3),
                        QuantityPerUnit = reader.GetString(4),
                        UnitPrice = reader.GetDecimal(5),
                        UnitsInStock = reader.GetInt16(6),
                        UnitsOnOrder = reader.GetInt16(7),
                        ReorderLevel = reader.GetInt16(8),
                        Discontinued = reader.GetBoolean(9),
                        CategoryName = reader.GetString(10)
                    });
                }
                return products;
            }
            catch (Exception)
            {

                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public string XmlSerializeList(Depo urunler)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Depo));
            TextWriter yazici = new StringWriter();
            serializer.Serialize(yazici, urunler);
            return yazici.ToString();
        }
        public  Depo XmlDeSerializeList(string data)
        {
            Depo urunler = new Depo();
            XmlSerializer serializer = new XmlSerializer(typeof(Depo));
            StringReader okuyucu = new StringReader(data);
            XmlReader xmlokuyucu = new XmlTextReader(okuyucu);
            urunler = (Depo)serializer.Deserialize(xmlokuyucu);
            return urunler;
        }
        public void DosyaYazma( string xml )
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\ufukg\\source\\repos\\NorthwindProductSerileştirme\\XML\\XMLFile1.xml");
            sw.WriteLine(xml);
            sw.Close();
            StreamWriter sw1 = new StreamWriter("C:\\Users\\ufukg\\source\\repos\\NorthwindProductSerileştirme\\XML\\TextFile1.txt");
            sw1.WriteLine(xml);
            sw1.Close();
        }
    }
}
