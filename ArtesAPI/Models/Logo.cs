using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class Logo
    {
        [Key]
        public int IdLogo { get; set; }
        public String NameLogo { get; set; }
        public String Description { get; set; }
        public Boolean Status { get; set; }
        public String UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public String UserModified { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(IdCompany))]
        public virtual Company Company { get; set; }
        public int IdCompany { get; set; }
    }
}