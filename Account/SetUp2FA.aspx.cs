using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using WebApplication1.Entity;
using WebApplication1.Helper;

namespace WebApplication1.Account
{
    public partial class SetUp2FA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = (int)Session["UserIdFor2FA"];

                using (var db = new AppEntities())
                {
                    var user = db.Users.First(x => x.UserId == userId);

                    string issuer = "MyWebApp";
                    string otpauth = $"otpauth://totp/{issuer}:{user.Username}?secret={user.TwoFactorSecret}&issuer={issuer}";

                    // Create QR
                    QRCodeGenerator qr = new QRCodeGenerator();
                    QRCodeData data = qr.CreateQrCode(otpauth, QRCodeGenerator.ECCLevel.Q);
                    QRCode code = new QRCode(data);

                    using (Bitmap bit = code.GetGraphic(20))
                    using (MemoryStream ms = new MemoryStream())
                    {
                        bit.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        imgQr.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                    }

                    lblSecret.Text = user.TwoFactorSecret;
                }
            }
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserIdFor2FA"];

            using (var db = new AppEntities())
            {
                var user = db.Users.First(x => x.UserId == userId);

                if (TotpHelper.ValidateCode(user.TwoFactorSecret, txtCode.Text))
                {
                    user.TwoFactorEnabled = true;
                    db.SaveChanges();

                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    lblSecret.Text = "Invalid code!";
                }
            }
        }
    }
}