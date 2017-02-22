using System;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;

public class Handler2 : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
public void ProcessRequest(HttpContext context)
    {
        using (System.Drawing.Bitmap b = new Bitmap(100, 40))
        {
            Font f = new Font("Impact", 20F);
            Graphics g = Graphics.FromImage(b);
            SolidBrush whiteBrush = new SolidBrush(Color.CornflowerBlue);
            SolidBrush blackBrush = new SolidBrush(Color.Blue);
            RectangleF canvas = new RectangleF(0, 0, 100, 50);
            g.FillRectangle(whiteBrush, canvas);
            context.Session["Captcha"] = GetRandomString();
            g.DrawString(context.Session["Captcha"].ToString(), f, blackBrush, canvas);
            context.Response.ContentType = "image/gif";
            b.Save(context.Response.OutputStream,ImageFormat.Gif);
        }


    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    private string GetRandomString()
    {
        string[] arrStr = "V,I,S,W,A,N,A,D,A,M,1,2,3,4,5,6,7,8,9,M,H,A,N,K,R,I,S,H,N,A,K,U,M,A,R".Split(",".ToCharArray());
        string strDraw = string.Empty;
        Random r = new Random();
        for (int i = 0; i < 5; i++)
        {
            strDraw += arrStr[r.Next(0, arrStr.Length - 1)];
        }
        return strDraw;
    }

}

