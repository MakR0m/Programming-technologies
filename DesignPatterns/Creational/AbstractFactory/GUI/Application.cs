using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.GUI
{
    internal class Application
    {
        private readonly IButton _button;

        public Application (IGUIFactory factory)
        {
            _button = factory.CreateButton();
        }
        public void RenderUI()
        {
            _button.Render();
        }
    }
}
