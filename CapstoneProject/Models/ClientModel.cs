using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CapstoneProject.Controllers;
using CapstoneProject.Models;

namespace CapstoneProject.Models
{


    public class Client
    {
        public int Id { get; set; }


        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }


        public DateTime test { get; set; }

        [Required]
        public int AvailableFrom { get; set; }

        [Required]
        public int AvailableUntil { get; set; }

        [Required]
        [Display(Name = "Client Group")]
        public int GroupNameId { get; set; }
        [ForeignKey("GroupNameId")]
        public IEnumerable<GroupName> ClientGroup { get; set; }
        
    }
}
