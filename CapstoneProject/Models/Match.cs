using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CapstoneProject.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Client Group1 { get; set; }
        public Client Group2 { get; set; }
        public DateTime Date { get; set; }
    }
}