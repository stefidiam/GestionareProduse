using Microsoft.AspNetCore.Mvc;
using GestionareProduse.Data;
using System.Collections.Generic;
using GestionareProduse.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Immutable;
using System;

namespace GestionareProduse.Controllers
{
    public class WarehouseController : Controller
    {
        private readonly GestionareProduseContext _context;


        public WarehouseController(GestionareProduseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Warehouse> warehouses = _context.Depozite.ToList();
            return View(warehouses);
        }

        public IActionResult IndexAjax()
        {
            List<Warehouse> warehouses = _context.Depozite.ToList();
            return View(warehouses);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Warehouse warehouse = new Warehouse();
            return View(warehouse);
        }

        [HttpPost]
        public IActionResult Create(Warehouse warehouse)
        {
            _context.Add(warehouse);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(string Id)
        {
            Warehouse warehouse = _context.Depozite.Where(p => p.DepId == Id).FirstOrDefault();
            return View(warehouse);
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            Warehouse warehouse = _context.Depozite.Where(p => p.DepId == Id).FirstOrDefault();
            return View(warehouse);
        }

        [HttpPost]
        public IActionResult Edit(Warehouse warehouse)
        {
            _context.Attach(warehouse);
            _context.Entry(warehouse).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            Warehouse warehouse = _context.Depozite.Where(p => p.DepId == Id).FirstOrDefault();
            return View(warehouse);
        }

        [HttpPost]
        public IActionResult Delete(Warehouse warehouse)
        {
            _context.Attach(warehouse);
            _context.Entry(warehouse).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        #region "Ajax Functions"

        [HttpPost]
        public IActionResult DeleteWarehouse(string Id)
        {
            Warehouse warehouse = _context.Depozite.Where(p => p.DepId == Id).FirstOrDefault();
            _context.Entry(warehouse).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult ViewWarehouse(string Id)
        {
            Warehouse warehouse = _context.Depozite.Where(p => p.DepId == Id).FirstOrDefault();
            return PartialView("_detail", warehouse);
        }


        public IActionResult EditWarehouse(string Id)
        {
            Warehouse warehouse = _context.Depozite.Where(p => p.DepId == Id).FirstOrDefault();
            return PartialView("_Edit", warehouse);
        }

        public IActionResult UpdateWarehouse(Warehouse warehouse)
        {
            _context.Attach(warehouse);
            _context.Entry(warehouse).State = EntityState.Modified;
            _context.SaveChanges();
            return PartialView("_Warehouse", warehouse);
        }

        public IActionResult CreateWarehouse()
        {
            Warehouse warehouse = new Warehouse();
            return PartialView("_Create", warehouse);
        }

        [HttpPost]
        public IActionResult SaveWarehouse(Warehouse warehouse)
        {
            _context.Add(warehouse);
            _context.SaveChanges();
            return PartialView("_Warehouse", warehouse);
        }
        #endregion
    }
}
