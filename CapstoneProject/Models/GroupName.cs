using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CapstoneProject.Models
{
    public class GroupName 
    {
        [Key]
        public int GroupNamesId { get; set; }
        public string Name { get; set; }

    }
}