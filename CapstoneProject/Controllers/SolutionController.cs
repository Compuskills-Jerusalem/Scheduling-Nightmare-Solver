
﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneProject.Models;
using CapstoneProject.ViewModels;
using System.Data;




namespace CapstoneProject.Controllers
{
    public class SolutionController : Controller
    {
        private ApplicationDbContext _context;

        public SolutionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Solution
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Solve()
        {

            ClientsPerDaySorted();


            return View();

        }

        public List<DateTime> DatesToLoopThru ()
        {
            List<DateTime> dates = new List<DateTime> { };

            foreach (Client client in _context.Clients)
            {
                if (!dates.Contains(client.AvailableFrom))
                {
                    dates.Add(client.AvailableFrom);
                }
            }

            return dates;
        }

        public List<Client> GetClientsPerDay (DateTime oneDay)
        { 
            var ClientsPerDay = from c in _context.Clients where c.AvailableFrom == oneDay select c;
            return ClientsPerDay.ToList();
        }

        public List<List<Client>> ClientsPerDaySorted()
        {
            var dates = DatesToLoopThru();

            List<List<Client>> ClientsPerDaySorted = new List<List<Client>> { };

            foreach (DateTime date in dates)
            {

                List<Client> ClientsPerDay = GetClientsPerDay(date);
                List<Client> ClientsGroup1 = new List<Client> { };
                List<Client> ClientsGroup2 = new List<Client> { };

                foreach (Client client in ClientsPerDay)
                {
                    if (client.GroupNameId == 1)
                    {
                        ClientsGroup1.Add(client);
                    }
                    if (client.GroupNameId == 2)
                    {
                        ClientsGroup2.Add(client);
                    }
                }

                ClientsPerDaySorted.Add(ClientsGroup1);
                ClientsPerDaySorted.Add(ClientsGroup2);
            }

            return ClientsPerDaySorted;

        }



        
    }
}

