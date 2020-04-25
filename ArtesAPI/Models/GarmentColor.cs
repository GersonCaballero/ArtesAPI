using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class GarmentColor
    {
        [Key]
        public int IdGarmentColor { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
    }
}