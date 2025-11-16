using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Entity;
using WebApplication1.Helper;

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

                string secretKey = TotpHelper.GenerateSecretKey();

                var user = new User
                {
                    Username = username,
                    PasswordHash = passwordHash,
                    TwoFactorSecret = secretKey,
                    TwoFactorEnabled = true
                };

                db.Users.Add(user);
                db.SaveChanges();

                ShowUserQr(username, secretKey);
            }
        }

        private void ShowUserQr(string username, string secretKey)
        {
            string issuer = "MyWebApp";
            string otpauth = $"otpauth://totp/{issuer}:{username}?secret={secretKey}&issuer={issuer}&digits=6";

            // Generate QR Code
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(otpauth, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            using (Bitmap bit = code.GetGraphic(20))
            using (MemoryStream ms = new MemoryStream())
            {
                bit.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                string base64 = Convert.ToBase64String(ms.ToArray());
                imgQrCode.ImageUrl = "data:image/png;base64," + base64;
                imgQrCode.Visible = true;
            }

            lblSecret.Text = secretKey;
            lblSecret.Visible = true;
        }
    }
}