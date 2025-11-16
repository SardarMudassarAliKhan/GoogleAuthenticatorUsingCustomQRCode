using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedInUser"] == null)
                Response.Redirect("~/Account/Login.aspx");

            lblUser.Text = "Welcome " + Session["LoggedInUser"].ToString(); ;
        }
    }
}