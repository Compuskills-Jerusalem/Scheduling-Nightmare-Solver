using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Device.Location;

namespace CapstoneProject.Controllers
{
    public class LocationController : Controller
    {      
        // GET: Location
        public ActionResult Index()
        {
            
            return View();
        }            
    }
}
    
