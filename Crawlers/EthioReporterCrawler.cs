using EthioNews.Data;
using EthioNews.Models;
using EthioNews.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthioNews.Crawlers
{
    public class EthioReporterCrawler
    {
        private static INewsData _newsInterface;

        public EthioReporterCrawler(INewsData memoryNews)
        {
            _newsInterface = memoryNews;
        }

        public static void AddPolotics()
        {

            var driver = new ChromeDriver("C:\\Users\\Feysel\\source\\repos");
            driver.Url = "https://www.ethiopianreporter.com/index.php/zena";
            //System.Threading.Thread.Sleep(5000);

            var news = driver.FindElement(By.ClassName("main-content")).FindElements(By.ClassName("item"));

            foreach (var newsElement in news)
            {
                try
                {
                    var date = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-created")).Text;
                    var titile = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-title")).FindElement(By.TagName("span")).Text;
                    var body = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-body")).FindElement(By.TagName("div")).Text;
                    var category = 1;
                    var webSource = "https://www.ethiopianreporter.com";
                    var newsSource = newsElement.FindElement(By.ClassName("post-content"))
                        .FindElement(By.ClassName("post-title"))
                        .FindElement(By.TagName("a"))
                        .GetAttribute("href");
                    var image = newsElement.FindElement(By.TagName("img")).GetAttribute("src");

                    if (image == null)
                    {
                        image = "NO";
                    }

                    Console.WriteLine();
                    Console.WriteLine(date);
                    Console.WriteLine(titile);
                    Console.WriteLine(body);
                    Console.WriteLine(category);
                    Console.WriteLine(webSource);
                    Console.WriteLine(newsSource);
                    Console.WriteLine(image.ToString());
                    Console.WriteLine();

                    var n = new News
                    {
                        Category = category,
                        DetailInformation = body,
                        ImageSource = image,
                        PublishedDate = date,
                        SourceUrl = newsSource,
                        SourceWebsite = "Reporter",
                        Titile = titile
                    };

                    _newsInterface.Add(n);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Hello World!");
        }

    }
}
