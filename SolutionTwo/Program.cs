using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using HtmlAgilityPack;

namespace Scrapper
{
    //  //a[starts-with(@href, '/scholar?cites') ]
    class webscrapping
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Makale adını giriniz.");
            string name = Console.ReadLine();
            name = name.Trim();
            name = name.Replace(" ", "+");
            Scraper scraper = new Scraper(name);
            scraper.call();
        }
    }
}

//https://scholar.google.com/scholar?hl=en&as_sdt=0%2C5&q=An+overview+of+peak-to-average+power+ratio+reduction+techniques+for+OFDM+systems&btnG=
//https://scholar.google.com/scholar?hl=en&as_sdt=2005&sciodt=0%2C5&cites=15782149898879873389&scipsc=&q=An+overview%3A+Peak-to-average+power+ratio+reduction+techniques+for+OFDM+signals&btnG=