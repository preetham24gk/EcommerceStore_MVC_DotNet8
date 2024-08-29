using EcomerceStore_Razor.Data;
using EcomerceStore_Razor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EcomerceStore_Razor.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        public Category? Category { get; set; }
        public EditModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? Id)
        {
            if(Id != null || Id != 0)
            {
                Category = _db.Categories.Find(Id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
