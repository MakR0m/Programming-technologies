using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.BADS.LSP
{
    class Bird 
    { 
        public virtual void Fly() 
        { 
            //Летит
        } 
    }

    class Ostrich : Bird
    {
        public override void Fly() => throw new NotSupportedException("I'm flightless!");
    }

    //Нарушен LSP: Ostrich (страус) — не может летать, но Bird предполагает, что может.
    //Здесь нужно не наследоваться, а выделить интерфейсы по способностям
}
