using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ArtesAPI.Models
{
    public class Company
    {
        [Key]
        public int IdCompany { get; set; }
        public String CompanyName { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
        public String Direction { get; set; }
        public String City { get; set; }
        public String Department { get; set; }
        public String ImageURL { get; set; }
        public Boolean State { get; set; }
        public String UserCreate { get; set; }
        public DateTime CreateDate { get; set; }
        public String UserModified { get; set; }
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(IdCompanyType))]
        public virtual CompanyType CompanyType { get; set; }
        public int IdCompanyType { get; set; }
    }
}