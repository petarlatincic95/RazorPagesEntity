using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class DeleteModel : PageModel

    {
        public DeleteModel(AbbyDbContext db)
        {
            _dbContext = db;
        }
        [BindProperty]
        public Category Category { get; set; }
        public AbbyDbContext _dbContext { get; }

        public void OnGet(int id)
        {
            Category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (Category == null)
                TempData["error"] = "There is no record with given Id";
        }
        public async Task<IActionResult> OnPost()
        {   
            _dbContext.Categories.Remove(Category);
            await _dbContext.SaveChangesAsync();
            TempData["success"] = "Category deleted succesfully";

            return RedirectToPage("Index");
                
                
        }

       
    }
}
