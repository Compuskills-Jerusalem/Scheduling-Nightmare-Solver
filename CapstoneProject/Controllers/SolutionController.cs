//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using CapstoneProject.Models;
//using CapstoneProject.ViewModels;
//using System.Data;

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

//            //return View(query);

//            //try select:


//            var joinedTables = from cl in _context.Clients
//                               join avsl in _context.AvailableSlots on cl.AvailableFrom equals avsl.StartTime
//                               //where cl.GroupNameId != avsl.Client.GroupNameId

//                               select new AvailabilityVM { ClientVm = cl, AvailableSlotVm = avsl };
//            return View(joinedTables);

//            //var selectWithWhere = from c in _context.Clients where c.AvailableFrom == c.AvailableFrom select c;

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
            
         

//        //    //return(query);
//        //}

















//    }
//}