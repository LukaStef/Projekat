using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat
{
    public class Album
    {
        public Album(string name, string band, string date, string cover)
        {
            this.name = name;
            this.band = band;
            this.date = date;
            this.cover = cover;
        }

        public string name { get; set; }
        public string band { get; set; }
        public string date { get; set; }
        public string cover { get; set; }
    }
}