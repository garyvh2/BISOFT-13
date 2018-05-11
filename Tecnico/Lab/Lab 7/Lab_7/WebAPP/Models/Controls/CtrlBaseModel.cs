using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPP.Models.Controls
{
    public class CtrlBaseModel
    {

        public string Id { get; set; }


        private string ReadFileText()
        {
            string path = @"C:\Users\Garyy\source\Workspaces\Laboratorio I\Tecnico\Lab_6\WebAPP\Models\Controls\";
            string name = this.GetType().Name;
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
                var value = prop.GetValue(this, null).ToString();

                var tag = string.Format("-#{0}-", prop.Name);
                html = html.Replace(tag, value);
            }
            return html;
        }
    }
}