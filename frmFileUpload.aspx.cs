using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

public partial class Admin_frmFileUpload : System.Web.UI.Page
{
    byte[] file;
    BusinessLayer BL = new BusinessLayer();
    string strPassWord = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DisplayKey();
        }
    }

    public void DisplayKey()
    {
        txtSK.ReadOnly = false;
        txtSK.Text = getkey();
        txtSK.ReadOnly = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BE.FileName = txtFName.Text;
        BE.Desc = txtDesc.Text;
        PreapareByteArray();
        BE.FileContent = file;
        BE.SecretKey = txtSK.Text; 
        BE.Email = txtEmail.Text;
        int UserId = Convert.ToInt32(Session["UserId"].ToString());
        BE.Id = UserId;
        int Result = BL.FileUpload();
        if (Result > 0)
        {
            lblMsg.Text = "File Uploaded Successfully";
            lblMsg.Visible = true;
            lblMsg.ForeColor = Color.Green;
            lblMsg.Font.Bold = true;
            txtDesc.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFName.Text = string.Empty;
            txtSK.Text = string.Empty;
        }
        else
        {
            lblMsg.Text = "File Uploaded Failure";
            lblMsg.Visible = true;
            lblMsg.ForeColor = Color.Red;
            lblMsg.Font.Bold = true;
            txtDesc.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFName.Text = string.Empty;
            txtSK.Text = string.Empty;
        }
    }

    protected string getkey()
    {
        string[] GenerateList = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        Random r = new Random();
        for (int i = 0; i < 6; i++)
        {
            int j;
            j = r.Next(GenerateList.Length);
            strPassWord += GenerateList[j];
        }
        return strPassWord;
    }


    private void PreapareByteArray()
    {
        if (FileUpload1.HasFile)
        {
            using (BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream))
            {
                file = reader.ReadBytes(FileUpload1.PostedFile.ContentLength);                
            }            
        }
        else
        {
            throw new Exception("File Not Uploded...!");
        }

    }
    
}
