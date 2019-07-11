using System;
using System.Threading;
using EthioNews.Models;
using EthioNews.Services;
using Microsoft.AspNetCore.Mvc;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EthioNews.Controllers
{
    public class HomeController : Controller
    {
        private INewsData _news;

        public HomeController(INewsData memoryNews)
        {
            _news = memoryNews;
        }

        [HttpGet("{catergory}")]
        public ActionResult Polotics(int category)
        {
            var news = _news.GetCategory(category);
            return View(news);
        }

        public ActionResult Index()
        {
            Thread thread = new Thread(new ThreadStart(AddNews));
            thread.Start();
            var news = _news.GetAll();
            return View(news);
        }

        public void AddNews()
        {
            AddReporterPolotics();
            AddReporterBusiness();
            AddReporterSport();

            AddAddisAdmasPolotics();
            AddAddisAdmasSport();
            AddAddisAdmasSport();
        }
        public void AddReporterPolotics()
        {
            var driver = new ChromeDriver("C:\\Users\\Feysel\\source\\repos")
            {
                Url = "https://www.ethiopianreporter.com/poletika"
            };

            driver.Manage().Window.Minimize();
            var news = driver.FindElement(By.ClassName("main-content")).FindElements(By.ClassName("item"));

            foreach (var newsElement in news)
            {
                try
                {
                    var date = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-created")).Text;
                    var titile = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-title")).FindElement(By.TagName("span")).Text;
                    var body = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-body")).FindElement(By.TagName("div")).Text;
                    var category = 1;
                    var newsSource = newsElement.FindElement(By.ClassName("post-content"))
                        .FindElement(By.ClassName("post-title"))
                        .FindElement(By.TagName("a"))
                        .GetAttribute("href");
                    string image;
                    try
                    {
                        image = newsElement.FindElement(By.TagName("img")).GetAttribute("src");
                    }
                    catch (Exception e)
                    {
                        image = "~/img/l5.png";
                    }

                    driver.Close();

                    var n = new News
                    {
                        Category = category,
                        DetailInformation = body,
                        ImageSource = image,
                        PublishedDate = date,
                        SourceUrl = newsSource,
                        SourceWebsite = "ሪፖርተር",
                        Titile = titile
                    };

                    if (!_news.Any(titile))
                    {
                        _news.Add(n);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Hello World!");
        }
        public void AddReporterBusiness()
        {
            var driver = new ChromeDriver("C:\\Users\\Feysel\\source\\repos")
            {
                Url = "https://www.ethiopianreporter.com/index.php/bizines"
            };
            driver.Manage().Window.Minimize();

            var news = driver.FindElement(By.ClassName("main-content")).FindElements(By.ClassName("item"));

            foreach (var newsElement in news)
            {
                try
                {
                    var date = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-created")).Text;
                    var titile = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-title")).FindElement(By.TagName("span")).Text;
                    var body = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-body")).FindElement(By.TagName("div")).Text;
                    var category = 2;
                    var newsSource = newsElement.FindElement(By.ClassName("post-content"))
                        .FindElement(By.ClassName("post-title"))
                        .FindElement(By.TagName("a"))
                        .GetAttribute("href");
                    string image;
                    try
                    {
                        image = newsElement.FindElement(By.TagName("img")).GetAttribute("src");
                    }
                    catch (Exception e)
                    {
                        image = "~/img/l5.png";
                    }

                    driver.Close();

                    var n = new News
                    {
                        Category = category,
                        DetailInformation = body,
                        ImageSource = image,
                        PublishedDate = date,
                        SourceUrl = newsSource,
                        SourceWebsite = "ሪፖርተር",
                        Titile = titile
                    };

                    if (!_news.Any(titile))
                    {
                        _news.Add(n);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Hello World!");
        }
        public void AddReporterSport()
        {
            var driver = new ChromeDriver("C:\\Users\\Feysel\\source\\repos")
            {
                Url = "https://www.ethiopianreporter.com/sport"
            };
            driver.Manage().Window.Minimize();

            var news = driver.FindElement(By.ClassName("main-content")).FindElements(By.ClassName("item"));

            foreach (var newsElement in news)
            {
                try
                {
                    var date = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-created")).Text;
                    var titile = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-title")).FindElement(By.TagName("span")).Text;
                    var body = newsElement.FindElement(By.ClassName("post-content")).FindElement(By.ClassName("post-body")).FindElement(By.TagName("div")).Text;
                    var category = 3;
                    var newsSource = newsElement.FindElement(By.ClassName("post-content"))
                        .FindElement(By.ClassName("post-title"))
                        .FindElement(By.TagName("a"))
                        .GetAttribute("href");
                    string image;
                    try
                    {
                        image = newsElement.FindElement(By.TagName("img")).GetAttribute("src");
                    }
                    catch (Exception e)
                    {
                        image = "~/img/l5.png";
                    }

                    driver.Close();

                    var n = new News
                    {
                        Category = category,
                        DetailInformation = body,
                        ImageSource = image,
                        PublishedDate = date,
                        SourceUrl = newsSource,
                        SourceWebsite = "ሪፖርተር",
                        Titile = titile
                    };

                    if (!_news.Any(titile))
                    {
                        _news.Add(n);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Hello World!");
        }

        public void AddAddisAdmasPolotics()
        {
            var driver = new ChromeDriver("C:\\Users\\Feysel\\source\\repos")
            {
                Url = "https://www.addisadmassnews.com/index.php?option=com_k2&view=itemlist&layout=category&task=category&id=20&Itemid=213"
            };

            driver.Manage().Window.Minimize();
            var news = driver.FindElement(By.ClassName("main-content")).FindElements(By.ClassName("item"));

            foreach (var newsElement in news)
            {
                try
                {
                    var date = newsElement.FindElement(By.CssSelector("span.catItemDateCreated")).Text;
                    var titile = newsElement.FindElement(By.CssSelector("h3.catItemTitle a")).Text;
                    var body = newsElement.FindElement(By.CssSelector("div.catItemIntroText")).Text;
                    var category = 1;
                    var newsSource = "https://www.addisadmassnews.com";
                    string image;
                    try
                    {
                        image = newsElement.FindElement(By.TagName("img")).GetAttribute("src");
                    }
                    catch (Exception e)
                    {
                        image = "~/img/l5.png";
                    }

                    driver.Close();

                    var n = new News
                    {
                        Category = category,
                        DetailInformation = body,
                        ImageSource = image,
                        PublishedDate = date,
                        SourceUrl = newsSource,
                        SourceWebsite = "Addis Admass",
                        Titile = titile
                    };

                    if (!_news.Any(titile))
                    {
                        _news.Add(n);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Hello World!");
        }
        public void AddAddisAdmasBusiness()
        {
            var driver = new ChromeDriver("C:\\Users\\Feysel\\source\\repos")
            {
                Url = "https://www.addisadmassnews.com/index.php?option=com_k2&view=itemlist&layout=category&task=category&id=7&Itemid=240"
            };
            driver.Manage().Window.Minimize();

            var news = driver.FindElement(By.ClassName("main-content")).FindElements(By.ClassName("item"));

            foreach (var newsElement in news)
            {
                try
                {
                    var date = newsElement.FindElement(By.CssSelector("span.catItemDateCreated")).Text;
                    var titile = newsElement.FindElement(By.CssSelector("h3.catItemTitle a")).Text;
                    var body = newsElement.FindElement(By.CssSelector("div.catItemIntroText")).Text;
                    var category = 2;
                    var newsSource = "https://www.addisadmassnews.com";
                    string image;
                    try
                    {
                        image = newsElement.FindElement(By.TagName("img")).GetAttribute("src");
                    }
                    catch (Exception e)
                    {
                        image = "~/img/l5.png";
                    }

                    driver.Close();

                    var n = new News
                    {
                        Category = category,
                        DetailInformation = body,
                        ImageSource = image,
                        PublishedDate = date,
                        SourceUrl = newsSource,
                        SourceWebsite = "Addis Admass",
                        Titile = titile
                    };

                    if (!_news.Any(titile))
                    {
                        _news.Add(n);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Hello World!");
        }
        public void AddAddisAdmasSport()
        {
            var driver = new ChromeDriver("C:\\Users\\Feysel\\source\\repos")
            {
                Url = "https://www.addisadmassnews.com/index.php?option=com_k2&view=itemlist&layout=category&task=category&id=1&Itemid=180"
            };
            driver.Manage().Window.Minimize();

            var news = driver.FindElement(By.ClassName("main-content")).FindElements(By.ClassName("item"));

            foreach (var newsElement in news)
            {
                try
                {
                    var date = newsElement.FindElement(By.CssSelector("span.catItemDateCreated")).Text;
                    var titile = newsElement.FindElement(By.CssSelector("h3.catItemTitle a")).Text;
                    var body = newsElement.FindElement(By.CssSelector("div.catItemIntroText")).Text;
                    var category = 3;
                    var newsSource = "https://www.addisadmassnews.com";
                    string image;
                    try
                    {
                        image = newsElement.FindElement(By.TagName("img")).GetAttribute("src");
                    }
                    catch (Exception e)
                    {
                        image = "~/img/l5.png";
                    }

                    driver.Close();

                    var n = new News
                    {
                        Category = category,
                        DetailInformation = body,
                        ImageSource = image,
                        PublishedDate = date,
                        SourceUrl = newsSource,
                        SourceWebsite = "Addis Admass",
                        Titile = titile
                    };

                    if (!_news.Any(titile))
                    {
                        _news.Add(n);
                    }
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