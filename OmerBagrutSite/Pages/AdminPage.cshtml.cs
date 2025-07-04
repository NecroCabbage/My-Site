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
        [BindProperty] public int IsAdmin { get; set; }
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
        public IActionResult OnPostToggleAdmin(int userId)
        {
            DBHelper db = new DBHelper();
            string sql = $"UPDATE UserTbl SET IsAdmin = IIF(IsAdmin = 1, 0, 1) WHERE UserId = {userId}";
            db.ExecuteNonQuery(sql);

            return RedirectToPage();
        }

        public IActionResult OnGet()
        {

            int? isAdmin = HttpContext.Session.GetInt32("IsAdmin");

            if (isAdmin != 1)
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