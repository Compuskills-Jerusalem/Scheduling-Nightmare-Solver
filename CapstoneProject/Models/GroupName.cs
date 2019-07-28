using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapstoneProject.Models
{
    public class GroupName 
    {
        [Key]
        [Display(Name = "Group Name Id #")]
        public int GroupNamesId { get; set; }

        [Display(Name = "Group Name")]
        public string Name { get; set; }

    }
}