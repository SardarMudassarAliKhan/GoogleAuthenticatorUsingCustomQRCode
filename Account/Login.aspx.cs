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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (var db = new AppEntities())
            {
                string user = txtUsername.Text.Trim();
                string pass = txtPassword.Text;

                var u = db.Users.FirstOrDefault(x => x.Username == user);

                if (u == null || !BCrypt.Net.BCrypt.Verify(pass, u.PasswordHash))
                {
                    Response.Write("Invalid credentials");
                    return;
                }

                // Store temporarily for next page
                Session["UserIdFor2FA"] = u.UserId;

                // FIRST LOGIN → Setup 2FA
                if (u.TwoFactorEnabled== false)
                {
                    // GENERATE SECRET KEY ONLY IF NOT CREATED BEFORE
                    if (string.IsNullOrEmpty(u.TwoFactorSecret))
                    {
                        u.TwoFactorSecret = TotpHelper.GenerateSecretKey();
                        db.SaveChanges();
                    }

                    Response.Redirect("Setup2FA.aspx");
                    return;
                }

                // User already set up → Go to verification page
                Response.Redirect("Verify2FA.aspx");
            }
        }

    }
}