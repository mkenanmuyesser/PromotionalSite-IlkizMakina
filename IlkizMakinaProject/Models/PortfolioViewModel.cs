using IlkizMakinaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IlkizMakinaProject.Models
{
    public class PortfolioViewModel : MenuViewModel
    {
        public IList<Portfolio> GetPortfolios()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));

            var portfolios = root.Elements("Portfolios").Elements("Portfolio").Select(p => new Portfolio
            {
                Id = p.Attribute("Id").Value,
                HeaderTR = p.Element("HeaderTR").Value,
                DescriptionTR = p.Element("DescriptionTR").Value,            
                HeaderEN = p.Element("HeaderEN").Value,
                DescriptionEN = p.Element("DescriptionEN").Value,
                Image = p.Element("Image").Value,
            }).ToList();

            return portfolios;
        }
    }
}