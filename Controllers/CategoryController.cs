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
    public class CategoryController : Controller
    {
        private readonly GestionareProduseContext _context;


        public CategoryController(GestionareProduseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categorii.ToList();
            return View(categories);
        }

        public IActionResult IndexAjax()
        {
            List<Category> categories = _context.Categorii.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(string Id)
        {
            Category category = _context.Categorii.Where(p => p.CatId == Id).FirstOrDefault();
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            Category category = _context.Categorii.Where(p => p.CatId == Id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            Category category = _context.Categorii.Where(p => p.CatId == Id).FirstOrDefault();
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Attach(category);
            _context.Entry(category).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        #region "Ajax Functions"

        [HttpPost]
        public IActionResult DeleteCategory(string Id)
        {
            Category category = _context.Categorii.Where(p => p.CatId == Id).FirstOrDefault();
            _context.Entry(category).State = EntityState.Deleted;
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult ViewCategory(string Id)
        {
            Category category = _context.Categorii.Where(p => p.CatId == Id).FirstOrDefault();
            return PartialView("_detail", category);
        }


        public IActionResult EditCategory(string Id)
        {
            Category category = _context.Categorii.Where(p => p.CatId == Id).FirstOrDefault();
            return PartialView("_Edit", category);
        }

        public IActionResult UpdateCategory(Category category)
        {
            _context.Attach(category);
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return PartialView("_Category", category);
        }

        public IActionResult CreateCategory()
        {
            Category category = new Category();
            return PartialView("_Create", category);
        }

        [HttpPost]
        public IActionResult SaveCategory(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return PartialView("_Category", category);
        }
        #endregion
    }
}
