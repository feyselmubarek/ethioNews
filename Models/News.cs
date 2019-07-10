using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthioNews.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Titile { get; set; }
        public string SourceUrl { get; set; }
        public string SourceWebsite { get; set; }
        public string PublishedDate { get; set; }
        public int Category { get; set; }
        public string ImageSource { get; set; }
        public string DetailInformation { get; set; }
    }
}
