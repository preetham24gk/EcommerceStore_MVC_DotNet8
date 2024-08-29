﻿using EcommerceStore.DataAccess.Data;
using EcommerceStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EcommerceStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name");
            }
            if (!ModelState.IsValid) { return View(obj); }
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToAction("Index");
            
        }

        public IActionResult Edit( int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            } 
            Category? category = _db.Categories.Find(id);
            //Category? category1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? category2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (category == null) 
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (!ModelState.IsValid) { return View(obj); }
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = _db.Categories.Find(id);
            //Category? category1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //Category? category2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? category = _db.Categories.Find(id);
            if (category == null)
                return NotFound();
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

        }

    }
}
