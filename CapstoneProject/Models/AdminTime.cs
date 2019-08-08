using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Collections;

namespace CapstoneProject.Models
{
    public class AdminTime
    {
        public int Id { get; set; }

        [Required]
        public DateTime AdminDate { get; set; }
    }
}