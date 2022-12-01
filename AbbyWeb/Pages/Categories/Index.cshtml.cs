using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        public IndexModel(AbbyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AbbyDbContext _dbContext { get; set; }
        public IEnumerable<Category> Categories;

        public  void OnGet()
        {
           Categories=_dbContext.Categories;
        }
    }
}
