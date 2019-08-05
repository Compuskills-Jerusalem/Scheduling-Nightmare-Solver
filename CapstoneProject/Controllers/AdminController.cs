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
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;

        public AdminController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Admin2
        public ActionResult Index()
        {
            var groupNames = _context.GroupNames.ToList();
            return View(groupNames);
        }

        // GET: Admin2/Details/5
        public ActionResult Details(int id)
        {
            var groupNames = _context.GroupNames.SingleOrDefault(c => c.Id == id);
            if (groupNames == null)
                return HttpNotFound();

            return View(groupNames);
        }

        // GET: Admin2/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Admin2/Create
        [HttpPost]
        public ActionResult Create(GroupName groupName1, GroupName groupName2)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                _context.GroupNames.Add(groupName1);
                _context.GroupNames.Add(groupName2);
                _context.SaveChanges();
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateAdminTime()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult CreateAdminTime(AdminTime adminTime)
        {
            if (!ModelState.IsValid)
                return View();
            _context.AdminTimes.Add(adminTime);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult SolutionCalendar()
        {
            var ListOfAdminTimes = _context.AdminTimes.ToList();
            return View(ListOfAdminTimes);
        }

        //GET: Admin2/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin2/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin2/Delete/5
        public ActionResult Delete(int id)
        {
            var groupName = _context.GroupNames.Where(g => g.Id == id).FirstOrDefault();
            return View();
        }

        // POST: Admin2/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, GroupName groupName)
        {
            try
            {
                groupName = _context.GroupNames.Where(g => g.Id == id).FirstOrDefault();
                _context.GroupNames.Remove(groupName);
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
