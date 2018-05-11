using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI.Integrations.Templates.TextEmailTemplate
{
    public class EmailTemplate : BaseEmailTemplate
    {
        public string Body { get; set; } = "";
        public string Plain { get; set; } = "";
        public string Sender { get; set; }
        // >> 
        public EmailTemplate ()
        {

        }
        // >>=========================================================================<<
        //                          >> Metodos de agregacion <<
        // >>=========================================================================<<
        // >> Add Text Element
        public void AddText (string text)
        {
            var element = "";
            element += "<div class='col'>";
            element += text;
            element += "</div>";
            this.Body += element;
            this.Plain += text + "\n\n";
        }
        // >> Add Image Element
        public void AddImage(string src)
        {
            var element = "";
            element += "<div class='col'>";
            element += $"<img src='{src}' width='85%' height='auto'  alt=''>";
            element += "</div>";
            this.Body += element;
            this.Plain += src + "\n\n";
        }
        // >> Add Button Element
        public void AddButton(string url, string text)
        {
            var element = "";
            element += "<div class='col'>";
            element += $"<a href='{url}'><button type='button' class='button'>{text}</button></a>";
            element += "</div>";
            this.Body += element;
            this.Plain += url + "\n\n";
        }
        // >> Add Table Element
        public void AddTable(List<string> heads, List<List<string>> rows)
        {
            var element = "";
            element += "<div class='col' align='center'>";
            element += "<table class='pure-table'>";
            element += "<thead><tr>";
            heads.ForEach(head =>
            {
                element += $"<th scope='col'>{head}</th>";
            });
            element += "</tr></thead>";
            element += "<tbody>";
            rows.ForEach(row =>
            {
                element += "<tr>";
                row.ForEach(el =>
                {
                    element += $"<td>{el}</td>";
                });
                element += "</tr>";
            });
            element += "</tbody>";
            element += "</div>";
            this.Body += element;

            var elementPlain = "";
            heads.ForEach(head =>
            {
                elementPlain += head + "\t";
            });
            elementPlain += "\n";
            rows.ForEach(row =>
            {
                row.ForEach(el =>
                {
                    elementPlain += el + "\t";
                });
                elementPlain += "\n";
            });
            this.Plain += elementPlain + "\n\n";
        }
    }
}
