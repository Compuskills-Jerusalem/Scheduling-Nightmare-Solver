using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProject.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int Group1_Id { get; set; }
        public int Group2_Id { get; set; }
        public DateTime Date { get; set; }
    }
}