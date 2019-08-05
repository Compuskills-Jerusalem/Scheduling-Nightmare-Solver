using System;
using System.Collections.Generic;
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
            //string query = "SELECT Id, ClientID, StartTime, EndTime FROM AvailableSlots";
            //IEnumerable<AvailableSlot> data = _context.Database.SqlQuery<AvailableSlot>(query);

            //return View(data.ToList());

            //var query = (from cl in _context.Clients
            //             join avsl in _context.AvailableSlots on cl.AvailableFrom equals avsl.StartTime
            //             select new
            //             {
            //                 cl.FirstName,
            //                 avsl.StartTime,
            //                 cl.AvailableFrom
            //             }).ToList();

            //return View(query);

            //var joinedTables = from cl in _context.Clients
            //                   join avsl in _context.AvailableSlots on cl.AvailableFrom equals avsl.StartTime
            //                   //where cl.GroupNameId != avsl.Client.GroupNameId

            //                   select new AvailabilityVM { ClientVm = cl, AvailableSlotVm = avsl };
            //return View(joinedTables);

            //var selectWithWhere = from c in _context.Clients where c.AvailableFrom == c.AvailableFrom select c;

            return View(GetClientsPerDay());
        }

        public IEnumerable<Client> GetClientsPerDay ()
        {
            string query = "SELECT c1.AvailableFrom, c1.FirstName + ' ' + c1.LastName client_1, c2.FirstName + ' ' + c2.LastName client_2 FROM Clients c1 INNER JOIN Clients c2 ON c1.Id > c2.Id AND c1.GroupNameId = c2.AvailableFrom";
            IEnumerable<Client> data = _context.Database.SqlQuery<Client>(query);

            return (data);
        }

















    }
}