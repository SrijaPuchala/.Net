using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class selectimg1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


    }
    protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
    {
        //Response.Write("you click " + e.PostBackValue + " portion");

        Label1.Text = "you click " + e.PostBackValue + " portion";

        Session["img1"] = e.PostBackValue;

        Response.Redirect("selectimage2.aspx");        

    }}
