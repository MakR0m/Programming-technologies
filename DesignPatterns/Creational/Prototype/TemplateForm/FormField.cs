namespace DesignPatterns.Creational.Prototype.TemplateForm
{
    public class FormField : IPrototype<FormField>
    {
        public string Label { get; set; }
        public string Value { get; set; }

        public FormField Clone()
        {
            return new FormField
            {
                Label = this.Label,
                Value = this.Value
            };
        }
    }
}