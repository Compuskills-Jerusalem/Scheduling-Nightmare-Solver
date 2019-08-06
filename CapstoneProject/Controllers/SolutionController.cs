using System;
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

            //var clients = from c in _context.Clients
            //               where c.AvailableFrom > new DateTime(1984, 6, 1)
            //               select c;


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