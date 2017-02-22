using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using CommonFunctions;
using System.Drawing;


public partial class User_frmDownLoadFile : System.Web.UI.Page
{
    BusinessLayer BL = new BusinessLayer();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BE.Search = txtSearch.Text;
        pnlFile.Visible = true;
        DataSet dsGetFiles = BL.GetFiles();
        gvFile.DataSource = dsGetFiles;
        gvFile.DataBind();
    }
    protected void gvFile_RowCommand(object sender, GridViewCommandEventArgs e)
    {
if (e.CommandName == "Download")
        {
            lblKey.Visible = false;
            BE.FileId = Convert.ToInt32(e.CommandArgument.ToString());
            Session["FileId"] = BE.FileId;
            pnlSecret.Visible = true;
        }
        else if (e.CommandName == "Request")
        {
            lblKey.Visible = false;
            BE.FileId = Convert.ToInt32(e.CommandArgument.ToString());
            BE.Id = Convert.ToInt32(Session["UserId"].ToString());
            int result = BL.AddRequest();
            if (result > 0)
            {
                globalFunctions.Alert("Request Sent", Page);
            }
            else
            {
                globalFunctions.Alert("Request Already Sent...! Waiting for Accept", Page);
            }
        }
        else
        {
            BE.FileId = Convert.ToInt32(e.CommandArgument.ToString());
            BE.Id = Convert.ToInt32(Session["UserId"].ToString());
            string key = BL.RecieveKey();
            if(key==string.Empty)
            {
                globalFunctions.Alert("Your Request is not send (or) is not accept", Page);
            }
            else
            {
                lblKey.Text ="Key is : "+key;
                lblKey.Visible = true;
                lblKey.ForeColor = Color.Green;
            }
        }
    }
    private string ReturnExtension(string fileExtension)
    {
        switch (fileExtension)
        {
            case ".htm":
            case ".html":
            case ".log":
                return "text/HTML";
            case ".txt":
                return "text/plain";
            case ".docx":
                return "application/ms-word";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            case ".asf":
                return "video/x-ms-asf";
            case ".avi":
                return "video/avi";
            case ".zip":
                return "application/zip";
            case ".xls":
            case ".csv":
                return "application/vnd.ms-excel";
            case ".gif":
                return "image/gif";
            case ".jpg":
            case "jpeg":
                return "image/jpeg";
            case ".bmp":
                return "image/bmp";
            case ".wav":
                return "audio/wav";
            case ".mp3":
                return "audio/mpeg3";
            case ".mpg":
            case "mpeg":
                return "video/mpeg";
            case ".rtf":
                return "application/rtf";
            case ".asp":
                return "text/asp";
            case ".pdf":
                return "application/pdf";
            case ".fdf":
                return "application/vnd.fdf";
            case ".ppt":
                return "application/mspowerpoint";
            case ".dwg":
                return "image/vnd.dwg";
            case ".msg":
                return "application/msoutlook";
            case ".xml":
            case ".sdxl":
                return "application/xml";
            case ".xdp":
                return "application/vnd.adobe.xdp+xml";
            case ".doc":
                return "application/ms-word";
            default:
                return "application/octet-stream";
        }
    }
    protected void gvFile_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Download")
        {
pnlSecret.Visible = true;
        }
        else
        {

        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
BE.SecretKey = txtSecret.Text;
        BE.FileId = Convert.ToInt32(Session["FileId"].ToString());
        DataTable dtGetFilesForUser = BL.GetFilesForUser();

        if (dtGetFilesForUser.Rows.Count > 0)
        {
            byte[] fileData = (byte[])dtGetFilesForUser.Rows[0]["FileContent"];
            string file = dtGetFilesForUser.Rows[0]["FileName"].ToString();
            string[] fileSplit = file.Split('.');
            int Loc = fileSplit.Length;
            string FileExtention = "." + fileSplit[Loc - 1];

            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file);
            BinaryWriter bw = new BinaryWriter(Response.OutputStream);
            bw.Write(fileData);
            bw.Close();
            Response.ContentType = ReturnExtension(FileExtention);
            Response.End();
        }
        else
        {
            globalFunctions.Alert("Secret Key Not Matched", Page);
        }
    }
}
