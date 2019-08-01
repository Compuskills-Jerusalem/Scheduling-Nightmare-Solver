using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CapstoneProject.ViewModels;

namespace CapstoneProject.Models
{
    public class GroupName 
    {
        [Display(Name = "Group Name Id #")]
        public int Id { get; set; }

        [Display(Name = "Group Name")]
        public string Name { get; set; }
        
    }
}