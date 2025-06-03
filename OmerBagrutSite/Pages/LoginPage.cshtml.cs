using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OmerBagrutSite.DataModel;
using System.Data;

namespace OmerBagrutSite.Pages
{
    public class LoginPageModel : PageModel
    {
        public void OnGet()
        {
        }

        public string errorMessage = "";

        [BindProperty] public string LoginEmail { get; set; } 
        [BindProperty] public string LoginPassword { get; set; }

        public IActionResult OnPost() //string email, string password)
        {
            // Check DB Credentials and respond appropriately

            DBHelper dBHelper = new DBHelper();
            DataTable userTable;

            string sqlQuery = $"SELECT * FROM {Utils.DB_USERS_TABLE} WHERE Email = '{LoginEmail}' " + $"AND Password = '{LoginPassword}'";
            userTable = dBHelper.RetrieveTable(sqlQuery, "UserTbl");

            if (userTable.Rows.Count != 1)
            {
                errorMessage = "Invalid email or password.";
                return Page();
            }
  
            // Save login data to session from userTable
            DataRow row = userTable.Rows[0];
            HttpContext.Session.SetString("Email", row["Email"].ToString());
            HttpContext.Session.SetString("FirstName", row["FirstName"].ToString());
            HttpContext.Session.SetString("LastName", row["LastName"].ToString());
            HttpContext.Session.SetInt32("UserId", Convert.ToInt32(row["UserId"]));
            HttpContext.Session.SetInt32("IsAdmin", Convert.ToInt32(row["IsAdmin"]));


            return RedirectToPage("/Home");
        }

    }
}
