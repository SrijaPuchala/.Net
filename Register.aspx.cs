using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnregister_Click(object sender, EventArgs e)
    {

        Session["username"] = txtuname.Text;
        Session["password"] = txtpwd.Text;
        Session["mail"] = txtemail.Text;

        Response.Redirect("selectimg1.aspx");
}
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        txtuname.Text = "";
        txtpwd.Text = "";
        txtconfirm.Text = "";
        txtemail.Text = "";

    }
}
