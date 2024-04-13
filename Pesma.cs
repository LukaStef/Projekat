using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat
{
    public class Pesma
    {
        public Pesma(string name, string album, string cover, string band, string link, string linkText)
        {
            this.name = name;
            this.album = album;
            this.cover = cover;
            this.band = band;
            this.link = link;
            this.linkText = linkText;
        }

        public string name { get; set; }
        public string album { get; set; }
        public string cover { get; set; }
        public string band { get; set; }
        public string link { get; set; }
        public string linkText { get; set; }

        
    }
}