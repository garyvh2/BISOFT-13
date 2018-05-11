using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using WebAPP.Models.Controls;

namespace WebApp.Models.Controls.CtrlBlog
{
    public class CtrlBlog : CtrlBaseModel
    {

        // =========================================== Attributes ===========================================
        private List<CtrlBlogEntry> _Entries = new List<CtrlBlogEntry>();
        public List<CtrlBlogEntry> Entries
        {
            get
            {
                var API_Entries = GetOptionsFromAPI();
                
                API_Entries.ForEach(Entry =>
                {
                    var content = GetXMLText(Entry.content);
                    var CtrlEntry = new CtrlBlogEntry()
                    {
                        Id = Entry.id,
                        Title = Entry.title == "" ? "Sin Titulo" : Entry.title,
                        Image = GetImageURL(Entry.content),
                        Content = content.Length > 100 ? content.Substring(0, 100) : content,
                        Author = Entry.author.displayName,
                        PublishedDate = Entry.published,
                        Replies = Entry.replies.totalItems
                    };

                    _Entries.Add(CtrlEntry);
                });
                return _Entries;
            }
            set
            {
                this._Entries = value;
            }
        }

        public string DisplayEntries
        {
            get
            {
                var HTMLEntries = "";
                _Entries.ForEach(_Entry =>
                {
                    HTMLEntries += _Entry.GetHtml();
                });
                return HTMLEntries;
            }
        }


        // =========================================== Blogger API Data ===========================================
        private string API_BASE_URL = ConfigurationManager.AppSettings["Blogger_BaseURL"] +
                                      ConfigurationManager.AppSettings["Blogger_BlogId"];
        private string API_KEY      = ConfigurationManager.AppSettings["Blogger_APIKey"];


        // =========================================== Constructor ===========================================
        public CtrlBlog ()
        {
        }

        // =========================================== Methods ===========================================
        // Get Data From API
        private List<BloggerPost> GetOptionsFromAPI()
        {
            // >> Get Posts From API
            var client = new WebClient();
            var response = client.DownloadString(API_BASE_URL + "/posts?key=" + API_KEY);
            var options = JsonConvert.DeserializeObject<CtrlAPIResponse<List<BloggerPost>>>(response);

            return options.items;
        }
        // Remove All Html Tags
        public string StripHTML(string input)
        {
            var text = HttpUtility.HtmlDecode(input);
            text = Regex.Replace(text, "<.*?>", String.Empty);
            text = Regex.Unescape(text);
            text = text.Replace("\r\n", string.Empty)
                       .Replace("\n", string.Empty)
                       .Replace("\r", string.Empty);
            return text;
        }
        // Process HTML as XML
        public string GetXMLText (string HTML)
        {
            XmlDocument XML = new XmlDocument();
            XML.LoadXml(string.Format("<root>{0}</root>", StripHTML(HTML)));
            return XML.InnerText;
        }
        // Get Post Image
        public string GetImageURL (string HTML)
        {
            var image = Regex.Match(HTML ?? "", "<img.+?src=[\"'](.+?)[\"'].+?>", RegexOptions.IgnoreCase).Groups[1].Value;
            if (image == "") return "http://cssslider.com/sliders/demo-10/data1/images/3.jpg";
            else return image;
        }
    }
}