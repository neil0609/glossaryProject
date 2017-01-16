using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlossaryProject.Models.Requests.AddRequest
{
    public class AddGlossaryItem
    {
        [StringLength(256, MinimumLength = 3)]
        [Required]
        public string Term { get; set; }

        [StringLength(4000, MinimumLength = 3)]
        [Required]
        public string Definition { get; set; }
    }
}