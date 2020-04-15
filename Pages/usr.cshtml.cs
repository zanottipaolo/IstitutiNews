using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using schools_identity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Xml;
using System.ServiceModel.Syndication;

namespace schools_identity.Pages
{
    public class usrModel : PageModel
    {
        private readonly ILogger<usrModel> _logger;
        public List<News> list_ufficio = new List<News>();

        public usrModel(ILogger<usrModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            // news from Ufficio Scolastico Regionale per la Lombardia
            #region
            var path_ufficio = "http://usr.istruzione.lombardia.gov.it/rub_argomenti/racconti-dalle-scuole/feed/";
            var reader_ufficio = XmlReader.Create(path_ufficio);
            var feed_ufficio = SyndicationFeed.Load(reader_ufficio);
            reader_ufficio.Close();

            foreach (var z in feed_ufficio.Items)
            {
                News obNews_ufficio = new News
                {
                    Title = z.Title.Text,
                    Description = z.Summary.Text,
                    PublishDate = z.PublishDate.DateTime,
                    Link = z.Links[0].Uri.ToString()
                };
                list_ufficio.Add(obNews_ufficio);
            }
            #endregion
        }
    }
}
