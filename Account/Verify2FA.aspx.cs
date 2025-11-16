using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Entity;
using WebApplication1.Helper;

namespace WebApplication1.Account
{
    public partial class Verify2FA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserIdFor2FA"];

            using (var db = new AppEntities())
            {
                var user = db.Users.First(x => x.UserId == userId);

                if (TotpHelper.ValidateCode(user.TwoFactorSecret, txtCode.Text.Trim()))
                {
                    Session["LoggedInUser"] = user.Username;
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    lblMsg.Text = "Invalid code!";
                }
            }
        }
    }
}