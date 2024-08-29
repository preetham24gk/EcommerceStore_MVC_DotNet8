using EcomerceStore_Razor.Data;
using EcomerceStore_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomerceStore_Razor.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public Category? Category { get; set; }
        public DeleteModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? Id)
        {
            if (Id != null || Id != 0)
            {
                Category = _db.Categories.Find(Id);
            }
        }

        public IActionResult OnPost() 
        {
            _db.Categories.Remove(Category);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToPage("Index");

        }
    }
}
