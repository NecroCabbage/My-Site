using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OmerBagrutSite.DataModel;


namespace OmerBagrutSite.Pages
{
    public class UpdatePageModel : PageModel
    {
        [BindProperty]
        public User user { get; set; } = new User();

        public string errorMessage = "";

        //If id is passed from Admin page it uses that.
        //If not, it uses the session UserId.
        //If neither found: redirects to Login.
        public IActionResult OnGet(int? id)
        {
            DBHelper db = new DBHelper();

            int userId = id ?? HttpContext.Session.GetInt32("UserId") ?? 0;
            if (userId == 0)
            {
                return RedirectToPage("/LoginPage");
            }

            string sql = $"SELECT * FROM UserTbl WHERE UserId = {userId}";
            var list = db.RetrieveList<User>(sql, "UserTbl");
            user = list.FirstOrDefault();

            return Page();
        }


        public IActionResult OnPost()
        {
            int userId = HttpContext.Session.GetInt32("UserId") ?? 0;
            if (userId == 0)
            {
                return RedirectToPage("/LoginPage");
            }

            DBHelper db = new DBHelper();

            //Check if email exists but NOT for the current user
            string sql = $"SELECT * FROM UserTbl WHERE Email = '{user.Email}' AND UserId <> {userId}";
            if (db.Find(sql))
            {
                ViewData["errorMessage"] = "This email is already in use by another account.";
                return Page();
            }

            user.UserId = userId;
            int rows = db.Update_disconnected(user, "UserTbl");

            ViewData["Message"] = rows > 0 ? "Information Updated Successfully!" : "Update Failed.";
            return Page();
        }

        //public IActionResult OnPost()
        //{
        //    DBHelper dB = new DBHelper();
        //    int numRowsAffected = dB.Insert(user, Utils.DB_USERS_TABLE);

        //    if (numRowsAffected != 1)
        //    {
        //        errorMessage = "This email is already registered"; //not shure where to put this to actually show it
        //        return Page(); // stay on this page
        //    }

        //    return RedirectToPage("/LoginPage"); // go to main page
        //}
    }
}
