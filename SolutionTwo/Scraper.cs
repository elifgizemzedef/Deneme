using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrapper
{
    public class Scraper
    {
        private HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
        private string url;
        private HtmlAgilityPack.HtmlDocument htmlDoc;
        public Scraper(string query)
        {

            url = "https://scholar.google.com/scholar?hl=tr&as_sdt=2005&sciodt=0%2C5&cites=13068108630464812856&scipsc=&q=" + query + "&btnG=";
           // url = "https://scholar.google.com/scholar?cites=14777953555745916246&as_sdt=2005&sciodt=0,5&hl=tr";
            
            
        }
        public void call()
        {
            htmlDoc = web.Load(url);

            string str = htmlDoc.DocumentNode.SelectSingleNode("//a[starts-with(@href,'/scholar?cites') ]").Attributes["href"].Value.ToString().Replace("&amp;", "&");
            this.url = "https://scholar.google.com" +str ;
          
            writeNames();
        }
        private void writeNames()
        {
            int i = 1;
            htmlDoc=web.Load(url);
            foreach (var item in this.htmlDoc.DocumentNode.SelectNodes("//h3[@class=\"gs_rt\"]/a "))
            {
                Console.WriteLine(i + " - " + item.InnerText);
                i++;
            }
            foreach (var itemm in htmlDoc.DocumentNode.SelectNodes("//a[@class='gs_nma' and @href]"))
            {
                String link = "https://scholar.google.com" + itemm.Attributes["href"].Value.ToString().Replace("&amp;", "&");

                //Console.WriteLine(link);
                HtmlAgilityPack.HtmlDocument docc = web.Load(link);
                foreach (var item in docc.DocumentNode.SelectNodes("//h3[@class=\"gs_rt\"]/a "))
                {
                    Console.WriteLine(i + " - " + item.InnerText);

                    i++;
                }

            }
        }

    }


}
