using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat
{
    public class Bend
    {
        public string name { get; set; }
        public string date { get; set; }
        public string logo { get; set; }

        public string link { get; set; }
        public string linkText { get; set; }
        
        public Bend(string name, string date, string logo, string link, string linkText)
        {
            this.name = name;
            this.date = date;
            this.logo = logo;
            this.link = link;
            this.linkText = linkText;
        }
    }
}