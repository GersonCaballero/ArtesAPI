using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class Art
    {
        [Key]
        public int IdArt { get; set; }
        public String ArtName { get; set; }
        public String Description { get; set; }
        public String ImageURL { get; set; }
        public Boolean State { get; set; }
        public String UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public String UserModified { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(IdUser))]
        public virtual User User { get; set; }
        public int IdUser { get; set; }
    }
}