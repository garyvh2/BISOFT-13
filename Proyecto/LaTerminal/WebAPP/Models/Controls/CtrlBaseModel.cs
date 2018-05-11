using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Hosting;

namespace WebAPP.Models.Controls
{
    public class CtrlBaseModel
    {

        public string Id { get; set; }
        public string Name { get; set; } = "Default";
        public string ViewName { get; set; } = "";
        public string ColumnDataName { get; set; } = "";

        public string UpperFirst (string text)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(text[0]) + text.Substring(1);
        }

        private string ReadFileText()
        {
            string path = HostingEnvironment.ApplicationPhysicalPath + @"/Models/Controls/";
            string name = this.Name == "Default" ? this.GetType().Name : this.Name;
            string fileName = name + "\\" + name + ".html";

            path = path + fileName;

            string text = System.IO.File.ReadAllText(path);

            return text;
        }

        public string GetHtml()
        {
            var html = ReadFileText();

            foreach (var prop in this.GetType().GetProperties())
            {
                var value = (prop.GetValue(this, null) ?? "" ).ToString();

                var tag = string.Format("-#{0}-", prop.Name);
                html = html.Replace(tag, value);
            }
            byte[] UTF8 = Encoding.UTF8.GetBytes(html);
            return Encoding.UTF8.GetString(UTF8);
        }
    }
}