﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Command.Light
{
    internal interface ICommand
    {
        void Execute();
        void Undo();    
    }
}
