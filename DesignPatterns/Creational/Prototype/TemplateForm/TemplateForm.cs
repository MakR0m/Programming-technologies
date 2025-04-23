using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Prototype.TemplateForm
{
    internal class TemplateForm : IPrototype<TemplateForm>
    {
        public string Title { get; set; }
        public List<FormField> Fields { get; set; } = new();

        public TemplateForm Clone()
        {
            return new TemplateForm
            {
                Title = this.Title,
                Fields = this.Fields.Select(f => f.Clone()).ToList()
            };
        }

        public void Print()
        {
            Console.WriteLine($"Форма: {Title}");
            foreach (var field in Fields)
            {
                Console.WriteLine($"- {field.Label}: {field.Value}");
            }
            Console.WriteLine();
        }
    }
}
