using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.ChainOfResponsibility.UserValidation
{
    internal abstract class Handler
    {
        protected Handler? Next;

        public void SetNext(Handler? next)
        {
            Next = next;
        }

        public void Handle(Request request)
        {
            if (Process(request))
                Next?.Handle(request);
        }
        protected abstract bool Process(Request request);
    }
}
