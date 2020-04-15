using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Threading.Tasks;
using System.Xml;
using schools_identity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace schools_identity.Pages
{
    public class soleModel : PageModel
    {
        private readonly ILogger<soleModel> _logger;
        public List<News> list_sole = new List<News>();
        public string logo_sito { set; get; }

        public soleModel(ILogger<soleModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // news from Il Sole 24 Ore
            #region
            var path_sole = "https://www.ilsole24ore.com/rss/norme-e-tributi--scuola-e-universita.xml";
            var reader_sole = XmlReader.Create(path_sole);
            var feed_sole = SyndicationFeed.Load(reader_sole);
            reader_sole.Close();

            logo_sito = feed_sole.ImageUrl.ToString();
                
            foreach (var y in feed_sole.Items)
            {
                News obNews_sole = new News
                {
                    Title = y.Title.Text,
                    Description = y.Summary.Text,
                    PublishDate = y.PublishDate.DateTime,
                    img = y.Links[0].Uri.ToString(),
                    Link = y.Links[1].Uri.ToString()
                };
                list_sole.Add(obNews_sole);
            }
            #endregion
        }
    }
}
