﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.Loggers
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }
    internal abstract class Logger
    {
        protected Logger? Next;
        public void SetNext(Logger next)
        {
            Next = next;
        }

        public void Log(LogLevel level, string message)
        {
            if (CanHandle(level))
                Write(message);
            else
                Next?.Log(level, message);
        }

        protected abstract bool CanHandle(LogLevel level);
        protected abstract void Write(string message);
    }
}
