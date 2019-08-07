<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapstoneProject.Models;
using CapstoneProject.ViewModels;
using System.Data;
=======
﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using CapstoneProject.Models;
//using CapstoneProject.ViewModels;
//using System.Data;
>>>>>>> c4fd359a9a7b1c0a51291fc00ad2c817fb0156d0

//namespace CapstoneProject.Controllers
//{
//    public class SolutionController : Controller
//    {
//        private ApplicationDbContext _context;

//        public SolutionController()
//        {
//            _context = new ApplicationDbContext();
//        }

//        protected override void Dispose(bool disposing)
//        {
//            _context.Dispose();
//        }

//        // GET: Solution
//        public ActionResult Index()
//        {
//            return View();
//        }
//        public ActionResult Test()
//        {
//            return View();
//        }

<<<<<<< HEAD
        public ActionResult Solve()
        {
            //var query = (from cl in _context.Clients
            //             join avsl in _context.AvailableSlots on cl.AvailableFrom equals avsl.StartTime
            //             select new
            //             {
            //                 cl.FirstName,
            //                 avsl.StartTime,
            //                 cl.AvailableFrom
            //             }).ToList();
=======
//        public ActionResult Solve()
//        {
//            //string query = "SELECT Id, ClientID, StartTime, EndTime FROM AvailableSlots";
//            //IEnumerable<AvailableSlot> data = _context.Database.SqlQuery<AvailableSlot>(query);

//            //return View(data.ToList());

//            //var query = (from cl in _context.Clients
//            //             join avsl in _context.AvailableSlots on cl.AvailableFrom equals avsl.StartTime
//            //             select new
//            //             {
//            //                 cl.FirstName,
//            //                 avsl.StartTime,
//            //                 cl.AvailableFrom
//            //             }).ToList();
>>>>>>> c4fd359a9a7b1c0a51291fc00ad2c817fb0156d0

//            //return View(query);

<<<<<<< HEAD
            //var joinedTables = from cl in _context.Clients
            //                   join avsl in _context.AvailableSlots on cl.AvailableFrom equals avsl.StartTime
            //                   //where cl.GroupNameId != avsl.Client.GroupNameId

            //                   select new AvailabilityVM { ClientVm = cl, AvailableSlotVm = avsl };
            //return View(joinedTables);
=======
//            //try select:


//            var joinedTables = from cl in _context.Clients
//                               join avsl in _context.AvailableSlots on cl.AvailableFrom equals avsl.StartTime
//                               //where cl.GroupNameId != avsl.Client.GroupNameId

//                               select new AvailabilityVM { ClientVm = cl, AvailableSlotVm = avsl };
//            return View(joinedTables);
>>>>>>> c4fd359a9a7b1c0a51291fc00ad2c817fb0156d0

//            //var selectWithWhere = from c in _context.Clients where c.AvailableFrom == c.AvailableFrom select c;

<<<<<<< HEAD
            //var clients = from c in _context.Clients
            //               where c.AvailableFrom > new DateTime(1984, 6, 1)
            //               select c;
=======
//            //var query = (from c in _context.Clients
//            //             where c.FirstName == "Rochel"
//            //             select new
//            //             {
//            //                 c.FirstName,
//            //                 c.AvailableFrom
//            //             }).ToList();

//            //string query = "SELECT Id, FirstName, AvailableFrom FROM Clients";
//            //IEnumerable<Client> data = _context.Database.SqlQuery<Client>(query);
//            //return View(data);

//            //return View(GetClientsPerDay());
//        }

//        //public IEnumerable<Client> GetClientsPerDay (DateTime oneDay)
//        //{
//        //    //string query = "SELECT c1.Id, c1.AvailableFrom, c1.FirstName + ' ' + c1.LastName client_1, c2.Id, c2.FirstName + ' ' + c2.LastName client_2 FROM Clients c1 INNER JOIN Clients c2 ON c1.Id > c2.Id AND c1.AvailableFrom = c2.AvailableFrom";
//        //    //string query = "SELECT * FROM Clients";


>>>>>>> c4fd359a9a7b1c0a51291fc00ad2c817fb0156d0

//        //    //return(query);
//        //}

            //var clients = _context.Clients.OrderBy(s => s.AvailableFrom).ToList();

            var dates = DatesToLoopThru();

            List<List<Client>> ClientsPerDaySorted = new List<List<Client>> { };
            List<List<List<Client>>> ClientsSorted = new List<List<List<Client>>> { };

                foreach (DateTime date in dates)
                {
                    IEnumerable<Client> ClientsPerDay = GetClientsPerDay(date);
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

                ClientsSorted.Add(ClientsPerDaySorted);
                }
            
           
            return View(ClientsSorted);

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


        public IEnumerable<Client> GetClientsPerDay (DateTime oneDay)
        { 
            var ClientsPerDay = from c in _context.Clients where c.AvailableFrom == oneDay select c;
            return ClientsPerDay.ToList();
        }



        
    }
}

