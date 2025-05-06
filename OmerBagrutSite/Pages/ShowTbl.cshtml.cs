using OmerBagrutSite.DataModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace OmerBagrutSite.Pages
{
    public class ShowTblModel : PageModel
    {
        // Define the columns to display in the table
        public string[] displayColumns { get; set; } =
        {
            "Username", "Password", "BirthYear", "Email", "PhoneNumber", "City", "FirstName", "LastName", "Gender", "FavoritePasta"
        };

        // Store the table data retrieved from the database
        public DataTable? DataTableUsers { get; set; }

        public IActionResult OnGet()
        {
            DBHelper dBHelper = new DBHelper();

            // Query to retrieve data from the database
            string sqlQuery = $"SELECT * FROM {Utils.DB_USERS_TABLE}";

            // Retrieve the table data using the DBHelper
            DataTableUsers = dBHelper.RetrieveTable(sqlQuery, Utils.DB_USERS_TABLE);

            return Page();
        }
    }
}
