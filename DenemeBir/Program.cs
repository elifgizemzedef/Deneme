using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using HtmlAgilityPack;

namespace Scraping
{
    class Deneme
    {//https://scholar.google.com/scholar?start=10&hl=en&as_sdt=2005&sciodt=0,5&cites=15782149898879873389&scipsc=
     //https://scholar.google.com/scholar?start=10&amp;hl=tr&amp;as_sdt=2005&amp;sciodt=0,5&amp;cites=15782149898879873389&amp;scipsc=
        static void Main(string[] args)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://scholar.google.com/scholar?cites=14777953555745916246&as_sdt=2005&sciodt=0,5&hl=tr");
            //div[@class="gs_fl"]/a 
            //"/scholar?cites=15782149898879873389&as_sdt=2005&sciodt=0,5&hl=tr"
            //https://scholar.google.com/scholar?cites=15782149898879873389&as_sdt=2005&sciodt=0,5&hl=tr
            //h3[@class="gs_rt"]/a
            int i = 1;
            foreach (var item in doc.DocumentNode.SelectNodes("//h3[@class=\"gs_rt\"]/a "))
            {
                Console.WriteLine(i + " - " + item.InnerText);
                i++;
            }
            foreach (var itemm in doc.DocumentNode.SelectNodes("//a[@class='gs_nma' and @href]"))
            {
                String link = "https://scholar.google.com" + itemm.Attributes["href"].Value.ToString().Replace("&amp;", "&");

                //Console.WriteLine(link);
                HtmlAgilityPack.HtmlDocument docc = web.Load(link);
                foreach (var item in docc.DocumentNode.SelectNodes("//h3[@class=\"gs_rt\"]/a "))
                {
                    Console.WriteLine(i + " - " + item.InnerText);
                    
                    i++;
                }

                //}
                //foreach (var itemm in doc.DocumentNode.SelectNodes("//a[@class='gs_nma' and @href]"))
                //{
                //    HtmlAttribute link = itemm.Attributes["href"];
                //    Console.WriteLine(link.Value);
                //}

            }
        }
    } }

