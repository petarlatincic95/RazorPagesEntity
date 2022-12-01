using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class EditModel : PageModel

    {
        public EditModel(AbbyDbContext db)
        {
            _dbContext = db;
        }
        [BindProperty]
        public Category Category { get; set; }
        public AbbyDbContext _dbContext { get; }

        public void OnGet(int id)
        {
            Category=_dbContext.Categories.FirstOrDefault(c => c.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {   if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("identical inputs error", "Category name and Display orders must not be same");
                
            
            }
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(Category);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Category edited succesfully";

                return RedirectToPage("Index");
            }
            return Page();
                
                
        }

       
    }
}
