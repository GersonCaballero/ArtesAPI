using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class Login
    {
        [Key]
        public int IdLogin { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public Boolean State { get; set; }
    }
}