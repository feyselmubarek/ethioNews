using EthioNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthioNews.Services
{
    public interface INewsData
    {
        IEnumerable<News> GetAll();
        News Get(int id);
        News Add(News news);
        Boolean Any(string titile);
        IEnumerable<News> GetCategory(int category);
    }
}
