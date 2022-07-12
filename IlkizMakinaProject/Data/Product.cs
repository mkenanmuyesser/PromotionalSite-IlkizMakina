using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IlkizMakinaProject.Data
{
    public class Product
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string NameTR { get; set; }
        public string DescriptionTR { get; set; }
        public string NameEN { get; set; }
        public string DescriptionEN { get; set; }
    }
}