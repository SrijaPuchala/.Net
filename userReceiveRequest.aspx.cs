using CommonFunctions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserRecieveRequest : System.Web.UI.Page
{
    BusinessLayer BL = new BusinessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BE.Id = Convert.ToInt32(Session["UserId"].ToString());
            DataTable dsGetFiles = BL.GetFileRequest();
            gvFile.DataSource = dsGetFiles;
            gvFile.DataBind();
        }
    }
    protected void gvFile_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int result = BL.UpdateFileRequest(Convert.ToInt32(e.CommandArgument.ToString()));
        if (result > 0)
        {
            globalFunctions.Alert("Request Sent", Page);
        }
    }}





