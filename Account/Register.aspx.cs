using QRCoder;
using System;
using System.Drawing;
using System.IO;
using WebApplication1.Entity;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            using (var db = new AppEntities())
            {
                string username = txtUsername.Text.Trim();
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                var user = new User
                {
                    Username = username,
                    PasswordHash = passwordHash,
                    TwoFactorSecret = null,
                    TwoFactorEnabled = false
                };

                db.Users.Add(user);
                db.SaveChanges();

                Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}