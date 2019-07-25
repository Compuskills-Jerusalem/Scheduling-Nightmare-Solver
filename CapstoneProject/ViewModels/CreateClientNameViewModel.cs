using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapstoneProject.Models;

namespace CapstoneProject.ViewModels
{
    public class CreateClientNameViewModel
    {
        public Client Client { get; set; }
        public IEnumerable<GroupName> GroupName { get; set; }
    }
}