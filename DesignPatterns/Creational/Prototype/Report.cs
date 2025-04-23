using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Prototype
{
    internal class Report : IPrototype<Report>
    {
        public string Title {  get; set; }
        public string Author { get; set; }
        public List<string> Pages { get; set; } = new List<string>();

        public Report Clone()
        {
            // глубокое копирование
            return new Report
            {
                Title = this.Title,
                Author = this.Author,
                Pages = new List<string>(this.Pages)
            };
        }


        public override string ToString()
        {
            return $"{Title} by {Author}, pages: {Pages.Count}";
        }
    }
}
