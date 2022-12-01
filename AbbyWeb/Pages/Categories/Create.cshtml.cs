using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class CreateModel : PageModel

    {
        public CreateModel(AbbyDbContext db)
        {
            _dbContext = db;
        }
        [BindProperty]
        public Category Category { get; set; }
        public AbbyDbContext _dbContext { get; }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {   if (Category.Name == Category.DisplayOrder.ToString())
            { 
            ModelState.AddModelError("identical inputs error","Category name and Display orders must not be same");
            
            }
            if (ModelState.IsValid)
            {
                await _dbContext.Categories.AddAsync(Category);
                await _dbContext.SaveChangesAsync();
                TempData["success"] = "Category created succesfully";
                return RedirectToPage("Index");
            }
            return Page();
                
                
        }

       
    }
}
