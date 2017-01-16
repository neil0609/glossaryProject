using GlossaryProject.Models.Requests.AddRequest;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GlossaryProject.Models.Requests.UpdateRequest
{
    public class UpdateGlossaryItem : AddGlossaryItem
    {
        [Required]
        public int Id { get; set; }
    }
}