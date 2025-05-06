using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OmerBagrutSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet() //need to change it from void to IActionResult so this will work.
        {
            return LocalRedirect("/Home"); //add this so when you start the program it starts on the page you want.
        }
    }
}
