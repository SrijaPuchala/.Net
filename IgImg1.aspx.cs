using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class lgimage1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
    {
        Label1.Text = "you click " + e.PostBackValue + " portion";

        Session["lgimg1"] = e.PostBackValue;

        Response.Redirect("lgimage2.aspx");
    }
}
