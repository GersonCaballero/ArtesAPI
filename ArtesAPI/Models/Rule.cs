using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class Rule
    {
        [Key]
        public int IdRule { get; set; }
        public String Rules { get; set; }

        [ForeignKey(nameof(IdCompany))]
        public virtual Company Company { get; set; }
        public int IdCompany { get; set; }
    }
}