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
    public class ProductController : Controller
    {
        private readonly GestionareProduseContext _context;


        public ProductController(GestionareProduseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
		{
            List<Product> products = _context.Products.ToList();
            return View(products);
        }


        public IActionResult IndexAjax()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Product prod = new Product();
            return View(prod);
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Details(string Id)
        {
            Product prod = _context.Products.Where(p => p.ProdId == Id).FirstOrDefault();
            return View(prod);
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            Product prod = _context.Products.Where(p => p.ProdId == Id).FirstOrDefault();
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(string Id)
        {
            Product prod = _context.Products.Where(p => p.ProdId == Id).FirstOrDefault();
            return View(prod);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

   
        #region "Ajax Functions"

        [HttpPost]
        public IActionResult DeleteProduct(string Id)
        {
            Product prod = _context.Products.Where(p => p.ProdId == Id).FirstOrDefault();                
            _context.Entry(prod).State = EntityState.Deleted;
            _context.SaveChanges();            
            return Ok();
        }

        public IActionResult ViewProduct(string Id)
        {
            Product prod = _context.Products.Where(p => p.ProdId == Id).FirstOrDefault();
            return PartialView("_detail", prod);
        }


        public IActionResult EditProduct(string Id)
        {
            Product prod = _context.Products.Where(p => p.ProdId == Id).FirstOrDefault();
            return PartialView("_Edit", prod);
        }

        public IActionResult UpdateProduct(Product product)
        {
            _context.Attach(product);
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return PartialView("_Product", product);
        }

        public IActionResult CreateProduct()
        {
            Product prod = new Product();
            return PartialView("_Create", prod);
        }

        [HttpPost]
        public IActionResult SaveProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return PartialView("_Product", product);
        }
        #endregion
    }
}
