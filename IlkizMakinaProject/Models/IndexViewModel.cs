using IlkizMakinaProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IlkizMakinaProject.Models
{
    public class IndexViewModel:MenuViewModel
    {
        public string GetHeader()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));
            var header = root.Elements("MainPage").Select(p => p.Element("HeaderTR").Value).Single().ToString();

            return header;
        }

        public string GetDescription()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));
            var description = root.Elements("MainPage").Select(p => p.Element("DescriptionTR").Value).Single().ToString();

            return description;
        }

        public IList<Banner> GetBanners()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));

            var banners = root.Elements("MainPage").Elements("Banners").Elements("Banner").Select(p => new Banner
            {
                Id = p.Attribute("Id").Value,
                HeaderTR = p.Element("HeaderTR").Value,
                DescriptionTR = p.Element("DescriptionTR").Value,
                TooltipTR = p.Element("TooltipTR").Value,
                HeaderEN = p.Element("HeaderEN").Value,
                DescriptionEN = p.Element("DescriptionEN").Value,
                TooltipEN = p.Element("TooltipEN").Value,
                Image = p.Element("Image").Value,
            }).ToList();

            return banners;
        }

        public IList<SubBanner> GetSubBanners()
        {
            XElement root = XElement.Load(HttpContext.Current.Server.MapPath("~/Data/ProjectData.xml"));

            var subbanners = root.Elements("MainPage").Elements("SubBanners").Elements("SubBanner").Select(p => new SubBanner
            {
                Id = p.Attribute("Id").Value,
                HeaderTR = p.Element("HeaderTR").Value,
                DescriptionTR = p.Element("DescriptionTR").Value,               
                HeaderEN = p.Element("HeaderEN").Value,
                DescriptionEN = p.Element("DescriptionEN").Value,
                Image = p.Element("Image").Value,
            }).ToList();

            return subbanners;
        }
    }
}