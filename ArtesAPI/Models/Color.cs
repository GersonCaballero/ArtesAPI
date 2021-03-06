﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class Color
    {
        [Key]
        public int IdColor { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImageURL { get; set; }
        public Boolean State { get; set; }
        public String UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public String UserModified { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(IdCompany))]
        public virtual Company Company { get; set; }
        public int IdCompany { get; set; }
    }
}