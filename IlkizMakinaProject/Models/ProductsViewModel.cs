using IlkizMakinaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IlkizMakinaProject.Models
{
    public class ProductsViewModel : MenuViewModel
    {
        public string Id { get; set; }

        public ProductsViewModel(int id)
        {
            Id = id.ToString();
        }
        public Product GetProduct()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));

            var product = root.Elements("Products").Elements("Product").Select(p => new Product
            {
                Id = p.Attribute("Id").Value,
                ParentId = p.Attribute("ParentId").Value,
                NameTR = p.Element("NameTR").Value,
                DescriptionTR = p.Element("DescriptionTR").Value,
                NameEN = p.Element("NameEN").Value,
                DescriptionEN = p.Element("DescriptionEN").Value,
            }).Single(p => p.Id == Id);

            return product;
        }

        public List<string> GetProductImages()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));

            var productImages = root.Elements("Products").Elements("Product").Single(p => p.Attribute("Id").Value == Id).Elements("Images").Elements("Image").Select(p=>p.Value).ToList();

            return productImages;
        }
    }
}