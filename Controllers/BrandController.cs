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
	public class BrandController : Controller
	{
		private readonly GestionareProduseContext _context;


		public BrandController(GestionareProduseContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			List<Brand> brands = _context.Branduri.ToList();
			return View(brands);
		}

		public IActionResult IndexAjax()
		{
			List<Brand> brands = _context.Branduri.ToList();
			return View(brands);
		}

		[HttpGet]
		public IActionResult Create()
		{
			Brand brand = new Brand();
			return View(brand);
		}

		[HttpPost]
		public IActionResult Create(Brand brand)
		{
			_context.Add(brand);
			_context.SaveChanges();
			return RedirectToAction("index");
		}

		public IActionResult Details(String Id)
		{
			Brand brand = _context.Branduri.Where(p => p.BrandId == Id).FirstOrDefault();
			return View(brand);
		}

		[HttpGet]
		public IActionResult Edit(String Id)
		{
			Brand brand = _context.Branduri.Where(p => p.BrandId == Id).FirstOrDefault();
			return View(brand);
		}

		[HttpPost]
		public IActionResult Edit(Brand brand)
		{
			_context.Attach(brand);
			_context.Entry(brand).State = EntityState.Modified;
			_context.SaveChanges();
			return RedirectToAction("index");
		}

		[HttpGet]
		public IActionResult Delete(String Id)
		{
			Brand brand = _context.Branduri.Where(p => p.BrandId == Id).FirstOrDefault();
			return View(brand);
		}

		[HttpPost]
		public IActionResult Delete(Brand brand)
		{
			_context.Attach(brand);
			_context.Entry(brand).State = EntityState.Deleted;
			_context.SaveChanges();
			return RedirectToAction("index");
		}


		#region "Ajax Functions"

		[HttpPost]
		public IActionResult DeleteBrand(String Id)
		{
			Brand brand = _context.Branduri.Where(p => p.BrandId == Id).FirstOrDefault();
			_context.Entry(brand).State = EntityState.Deleted;
			_context.SaveChanges();
			return Ok();
		}

		public IActionResult ViewBrand(String Id)
		{
			Brand brand = _context.Branduri.Where(p => p.BrandId == Id).FirstOrDefault();
			return PartialView("_detail", brand);
		}


		public IActionResult EditBrand(String Id)
		{
			Brand brand = _context.Branduri.Where(p => p.BrandId == Id).FirstOrDefault();
			return PartialView("_Edit", brand);
		}

		public IActionResult UpdateBrand(Brand brand)
		{
			_context.Attach(brand);
			_context.Entry(brand).State = EntityState.Modified;
			_context.SaveChanges();
			return PartialView("_Brand", brand);
		}

		public IActionResult CreateBrand()
		{
			Brand brand = new Brand();
			return PartialView("_Create", brand);
		}

		[HttpPost]
		public IActionResult SaveBrand(Brand brand)
		{
			_context.Add(brand);
			_context.SaveChanges();
			return PartialView("_Brand", brand);
		}
		#endregion
	}
}
