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
using Microsoft.AspNetCore.Http;

namespace schools_identity.Pages
{
    public class miurModel : PageModel
    {
        private readonly ILogger<miurModel> _logger;
        public List<News> list_miur = new List<News>();

        public miurModel(ILogger<miurModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
            // news from MIUR
            #region
            var path_miur = "https://www.miur.gov.it/news?p_p_id=com_liferay_asset_publisher_web_portlet_AssetPublisherPortlet_INSTANCE_iN8BfUdw8tJl&p_p_lifecycle=2&p_p_state=normal&p_p_mode=view&p_p_resource_id=getRSS&p_p_cacheability=cacheLevelPage";
            var reader_miur = XmlReader.Create(path_miur);
            var feed_miur = SyndicationFeed.Load(reader_miur);
            reader_miur.Close();

            foreach (var i in feed_miur.Items)
            {
                News obNews_miur = new News
                {
                    Title = i.Title.Text,
                    Description = i.Summary.Text,
                    PublishDate = i.PublishDate.DateTime,
                    Link = i.Links[0].Uri.ToString()
                };
                list_miur.Add(obNews_miur);
            }
            #endregion
        }   
    }
}
