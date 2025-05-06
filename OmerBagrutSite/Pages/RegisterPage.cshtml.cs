using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OmerBagrutSite.DataModel;
using System.Data;

namespace OmerBagrutSite.Pages
{
    public class RegisterPageModel : PageModel
    {
        [BindProperty]public User user { get; set; } = new User();

        public string errorMessage = "";

        public IActionResult OnPost()
        {
            DBHelper dB = new DBHelper();
            int numRowsAffected = dB.Insert(user, Utils.DB_USERS_TABLE);

            if (numRowsAffected != 1)
            {
                errorMessage = "This email is already registered"; //not shure where to put this to actually show it
                return Page(); // stay on this page
            }

            return RedirectToPage("/LoginPage"); // go to main page
        }

        public void OnGet()
        {
            // Nothing needed here unless you're pre-loading data
        }

        
        
    }
    
}