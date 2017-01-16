using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GlossaryProject.Domain
{
    public class GlossaryItem
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }

    }
}