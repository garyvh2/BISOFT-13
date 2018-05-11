using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace CoreAPI.Integrations.Templates
{
    public class BaseEmailTemplate
    {
        // >> Read the HTML file
        private string ReadFileText()
        {
            string path = GetCurrentLocation();
            string name = this.GetType().Name;
            string fileName = name + "\\" + name + ".html";

            path = path + fileName;

            string text = System.IO.File.ReadAllText(path);

            return text;
        }
        // >> Get Current Path
        private string GetCurrentLocation()
        {
            //var projectLocation = System.IO.Directory.GetParent(@"./").FullName;
            //return projectLocation + "\\Integrations\\Templates\\";
            //var appDomain = System.AppDomain.CurrentDomain;
            //var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            //return Path.Combine(basePath, "Integrations", "Templates");
            string AssemblyName = Assembly.GetExecutingAssembly().GetName().Name + ".DLL";
            string AssemblyPath = new Uri(Assembly.GetExecutingAssembly().EscapedCodeBase).LocalPath;
            
            return AssemblyPath.Replace(AssemblyName, String.Empty) + "Integrations\\Templates\\"; 
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
