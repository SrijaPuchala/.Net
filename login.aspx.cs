using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    ClsAccount obj = new ClsAccount();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //UserLOgin();
        }
    }
    protected void btnsignin_Click(object sender, EventArgs e)
    {

        Session["usmae"] = txtuname.Text;
        Session["lgpassword"] = txtpwd.Text;
        Response.Redirect("lgimage1.aspx");
}
}
