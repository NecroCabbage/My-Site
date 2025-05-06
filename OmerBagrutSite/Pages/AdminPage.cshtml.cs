using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OmerBagrutSite.DataModel;

namespace OmerBagrutSite.Pages
{
    public class AdminPageModel : PageModel
    {

        [BindProperty] public string FilterColumn { get; set; } = string.Empty;
        [BindProperty] public string FilterValue { get; set; } = string.Empty;
        [BindProperty] public string SortColumn { get; set; } = "UserId";
        [BindProperty] public int DeleteId { get; set; }

        public List<User> Users { get; set; } = new();

        public void OnPost()
        {
            string sql = "SELECT * FROM UserTbl";

            if (!string.IsNullOrEmpty(FilterValue) && !string.IsNullOrEmpty(FilterColumn))
            {
                sql += $" WHERE {FilterColumn} LIKE '%{FilterValue}%'";
            }

            sql += $" ORDER BY {SortColumn}";

            DBHelper db = new DBHelper();
            Users = db.RetrieveList<User>(sql, "UserTbl");
        }

        public IActionResult OnPostDelete()
        {
            if (DeleteId > 0)
            {
                DBHelper db = new DBHelper();
                string sql = $"DELETE FROM UserTbl WHERE UserId = {DeleteId}";
                db.ExecuteNonQuery(sql);
            }

            return RedirectToPage();
        }
        public IActionResult OnGet(int? id)
        {
            int userId = id ?? HttpContext.Session.GetInt32("UserId") ?? 0;
            if (userId == 0)
            {
                return RedirectToPage("/LoginPage");
            }

            string sql = $"SELECT * FROM UserTbl ORDER BY {SortColumn}";
            DBHelper db = new DBHelper();
            Users = db.RetrieveList<User>(sql, "UserTbl");

            return Page();
        }

    }
}