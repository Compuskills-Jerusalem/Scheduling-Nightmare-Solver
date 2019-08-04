using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CapstoneProject.Models;
using System.Web.Mvc;

namespace CapstoneProject.ViewModels
{
    public class CreateClientNameViewModel
    {
        public Client Client { get; set; }
        //public IEnumerable<SelectListItem> GroupName { get; set; }
        public List<GroupName> GroupName { get; set; }
    }
}