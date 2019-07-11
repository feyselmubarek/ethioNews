using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EthioNews.Data;
using EthioNews.Models;
using Microsoft.EntityFrameworkCore;

namespace EthioNews.Services
{
    public class NewsRepository : INewsData
    {
        private EthioNewsDbContext _context;

        public NewsRepository(EthioNewsDbContext context)
        {
            _context = context;
        }
        public News Add(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
            return news;
        }

        public News Get(int id)
        {
            return _context.News.FirstOrDefault(N => N.Id == id);
        }

        public IEnumerable<News> GetAll()
        {
            return _context.News.OrderBy(n => n.Id);
        }

        public Boolean Any(string titile)
        {
            var exists = _context.News.Any(n => n.Titile.Equals(titile));
            return exists;
        }

        public IEnumerable<News> GetCategory(int category)
        {
            return _context.News.Where(n => n.Category == category);
        }
    }
}
