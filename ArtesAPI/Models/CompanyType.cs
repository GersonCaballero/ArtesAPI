using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class CompanyType
    {
        [Key]
        public int IdCompanyType { get; set; }
        public String CompanyTypeName { get; set; }
        public Boolean State { get; set; }
        public String UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public String UserModified { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}