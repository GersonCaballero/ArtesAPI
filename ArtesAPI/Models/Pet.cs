using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class Pet
    {
        [Key]
        public int IdPet { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImageURL { get; set; }
        public String ArchiveURL { get; set; }
        public Boolean Status { get; set; }
        public String UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public String UserModified { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(IdCompany))]
        public virtual Company Company { get; set; }
        public int IdCompany { get; set; }

        [ForeignKey(nameof(IdValueLogo))]
        public virtual ValueLogo ValueLogo { get; set; }
        public int IdValueLogo { get; set; }

        [ForeignKey(nameof(IdGarmentColor))]
        public virtual GarmentColor GarmentColor { get; set; }
        public int IdGarmentColor { get; set; }
    }
}