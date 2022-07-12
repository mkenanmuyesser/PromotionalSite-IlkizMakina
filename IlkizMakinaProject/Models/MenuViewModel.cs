using IlkizMakinaProject.Data;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;

namespace IlkizMakinaProject.Models
{
    public class MenuViewModel
    {
        public IList<Product> GetMainProducts()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));

            var products = root.Elements("Products").Elements("Product").Select(p => new Product
            {
                Id = p.Attribute("Id").Value,
                ParentId = p.Attribute("ParentId").Value,
                NameTR = p.Element("NameTR").Value,
                DescriptionTR = p.Element("DescriptionTR").Value,
                NameEN = p.Element("NameEN").Value,
                DescriptionEN = p.Element("DescriptionEN").Value,
            }).Where(p => string.IsNullOrEmpty(p.ParentId)).ToList();

            return products;
        }

        public IList<Product> GetSubProducts(string id)
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));

            var products = root.Elements("Products").Elements("Product").Select(p => new Product
            {
                Id = p.Attribute("Id").Value,
                ParentId = p.Attribute("ParentId").Value,
                NameTR = p.Element("NameTR").Value,
                DescriptionTR = p.Element("DescriptionTR").Value,
                NameEN = p.Element("NameEN").Value,
                DescriptionEN = p.Element("DescriptionEN").Value,
            }).Where(p => p.ParentId == id).ToList();

            return products;
        }

    }
}