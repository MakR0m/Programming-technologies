using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.AbstractFactory.GUI
{
    internal interface IGUIFactory
    {
        IButton CreateButton();
    }
}
