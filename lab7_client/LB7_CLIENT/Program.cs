using System;
using System.ServiceModel.Syndication;
using System.Xml;

namespace LB7_CLIENT
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            string result2 = "";
            XmlReader xmlReader = XmlReader.Create("http://localhost:8735/Design_Time_Addresses/lab_7_feed/Feed1/");


            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

            foreach (SyndicationItem item in feed.Items)
            {
                result += item.Title.Text + "\n";
                Console.WriteLine(result);
                TextSyndicationContent textContent = item.Content as TextSyndicationContent;
                if (textContent != null)
                {
                    Console.WriteLine("  {0}", textContent.Text);
                }
                result = "";
                Console.WriteLine("-");

            }


            Console.ReadLine();

        }
    }
}
