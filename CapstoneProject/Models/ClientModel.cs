using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CapstoneProject.Controllers;
using CapstoneProject.Models;
using System.Data;
using CapstoneProject.ViewModels;

namespace CapstoneProject.Models
{


    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string Town { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string Email { get; set; }

        
        public DateTime AvailableFrom { get; set; }
        
        public DateTime AvailableUntil { get; set; }

        [MatchingMonth]
        
        public DateTime AvailableDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        //[Required]
        public double dLatitude { get; set; }
        public double dLongitude { get; set; }

        //[Required]
        [Display(Name = "Client Group")]
        public int GroupNameId { get; set; }

        [ForeignKey("GroupName")]
        public IEnumerable<GroupName> ClientGroup { get; set; }

        public virtual GroupName GroupName { get; set; }

  
        
    }
}
