using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CapstoneProject.Models;
using CapstoneProject.ViewModels;
using System.ComponentModel.DataAnnotations;


namespace CapstoneProject.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext _context;

        public ClientController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Client
        public ActionResult Index()
        {
            var clients = _context.Clients.ToList();

            return View(clients);
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var client = _context.Clients.SingleOrDefault(c => c.Id == id);
            if (client == null)
                return HttpNotFound();

            return View(client);
        }
        

        // GET: Client/Create
        public ActionResult Create()
        {
            var groupName = _context.GroupNames.ToList();
            var viewModel = new CreateClientNameViewModel
            {
                GroupName = groupName
            };
            return View("Create", viewModel);
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client client)
        {

            if (!ModelState.IsValid)
                return View();
            try
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var currrentClient = _context.Clients.Where(c => c.Id == id).FirstOrDefault();
            return View(currrentClient);
        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                _context.Entry(client).State = EntityState.Modified;
                _context.SaveChanges();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();
            return View(client);
        }

        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Client client)
        {
            try
            {
                client = _context.Clients.Where(c => c.Id == id).FirstOrDefault();
                _context.Clients.Remove(client);
                _context.SaveChanges();
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
