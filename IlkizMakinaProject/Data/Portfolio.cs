using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace IlkizMakinaProject.Data
{
    public class Portfolio
    {
        public string Id { get; set; }
        public string HeaderTR { get; set; }
        public string DescriptionTR { get; set; }
        public string HeaderEN { get; set; }
        public string DescriptionEN { get; set; }
        public string Image { get; set; }
    }
}