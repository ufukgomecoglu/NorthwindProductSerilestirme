using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NorthwindProductSerileştirme
{
    [Serializable]
    public class Product
    {
        [XmlElement(ElementName = "UrunKimlik")]
        public int ProductID { get; set; }
        [XmlElement(ElementName = "UrunIsim")]
        public string ProductName { get; set; }
        [XmlIgnore]
        public int SupplierID { get; set; }
        [XmlIgnore]
        public int CategoryID { get; set; }
        [XmlElement(ElementName = "KategoriAdi")]
        public string CategoryName { get; set; }
        [XmlIgnore]
        public string QuantityPerUnit { get; set; }
        [XmlElement(ElementName = "Fiyati")]
        public decimal UnitPrice { get; set; }
        [XmlElement(ElementName = "Stok")]
        public short UnitsInStock { get; set; }
        [XmlIgnore]
        public short UnitsOnOrder { get; set; }
        [XmlIgnore]
        public short ReorderLevel { get; set; }
        [XmlIgnore]
        public bool Discontinued { get; set; }

    }
}
