using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IlkizMakinaProject.Models
{
    public class AboutViewModel : MenuViewModel
    {
        public string GetTitle()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));
            var header = root.Elements("AboutPage").Select(p => p.Element("TitleTR").Value).Single().ToString();

            return header;
        }

        public string GetHeader()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));
            var header = root.Elements("AboutPage").Select(p => p.Element("HeaderTR").Value).Single().ToString();

            return header;
        }

        public string GetDescription()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));
            var description = root.Elements("AboutPage").Select(p => p.Element("DescriptionTR").Value).Single().ToString();

            return description;
        }

        public string GetFooter()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));
            var description = root.Elements("AboutPage").Select(p => p.Element("FooterTR").Value).Single().ToString();

            return description;
        }

        public string GetImage()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));
            var description = root.Elements("AboutPage").Select(p => p.Element("Image").Value).Single().ToString();

            return description;
        }
    }
}