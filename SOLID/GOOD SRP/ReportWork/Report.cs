using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.GOOD_SRP
{
    internal class Report
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public string Generate ()
        {
            return $"[Report: {Title}]\n{Content}";
        }
    }
}
