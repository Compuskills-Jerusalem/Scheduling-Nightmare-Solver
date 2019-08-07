
﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneProject.Models;
using CapstoneProject.ViewModels;
using System.Data;
using CapstoneProject.Logic;




namespace CapstoneProject.Controllers
{
    public class SolutionController : Controller
    {
        //private ApplicationDbContext _context;

        public SolutionController()
        {
            //_context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //_context.Dispose();
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
            SortingAlgorithm sortingAlgorithm = new SortingAlgorithm();
            sortingAlgorithm.MatchClients();
            //SortClientsPerDay();


                //int Group1Count = ClientsGroup1.Count();
                //int Group2Count = ClientsGroup2.Count();
                //int longer = 0;

                //if (Group1Count < Group2Count)
                //    longer = Group2Count;
                //if (Group2Count < Group1Count)
                //    longer = Group1Count;



                    //_context.Matches.Add(new Match()
                    //{
                    //    Date = ClientsPerDay.First().AvailableFrom,
                    //    Group1 = ClientsGroup1[b],
                    //    Group2 = ClientsGroup2[b],
                    //});
          

                    //ClientsPerDaySorted.Add(ClientsGroup1);
                    //ClientsPerDaySorted.Add(ClientsGroup2);

                //ClientsSorted.Add(ClientsPerDaySorted);
 
                //for (int i = 0; i < j; i++)
                //{
                //    _context.Matches.Add(new Match()
                //    {
                //        Date = ClientsPerDay.First().AvailableFrom,
                //        Group1 = ClientsGroup1[i],
                //        Group2 = ClientsGroup2[i],
                //    });
          
                //}


            
            return View();

        }

        

        

        



        
    }
}

