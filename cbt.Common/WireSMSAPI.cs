using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace cbt.Common
{
    public  class WireSMSAPI: System.Web.UI.Page
    {

        public string SendSMS(string server, string port,string UserName, string Password, string Destination, string Message)
        {

            System.Net.WebRequest WebRequest;
            System.Net.WebResponse WebResonse;

            //string Server = "";
            //string Port = "";
            //string UserName = "";
            //string Password = "";

            int type = 0;
            //string Message = "Test Message";
            Message = HttpUtility.UrlEncode(Message);
            if ((Message == "2") | (Message == "6"))
                Message = ConvertToUnicode(Message); /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
            int DLR = 1;
            string Source = "Skyline";

            string WebResponseString = "";
            string URL = "http://" + server + ":" + port + "/bulksms/bulksms?username=" + UserName + "&password=" + Password + "&type=" + type + "&dlr=" + DLR + "&destination=" + Destination + "&source=" + Source + "&message=" + Message + "";
            WebRequest = System.Net.HttpWebRequest.Create(URL);
            WebRequest.Timeout = 25000;
            try
            {
                WebResonse = WebRequest.GetResponse();
                System.IO.StreamReader reader = new System.IO.StreamReader(WebResonse.GetResponseStream());
                WebResponseString = reader.ReadToEnd();
                WebResonse.Close();
                Response.Write(WebResponseString);
            }
            catch (Exception ex)
            {
                WebResponseString = "Request Timeout";
               Response.Write(WebResponseString);
            } /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */

            return WebResponseString;
        }
        // return

        public string ConvertToUnicode(string str) /* TODO ERROR: Skipped SkippedTokensTrivia *//* TODO ERROR: Skipped SkippedTokensTrivia */
        {
            byte[] ArrayOFBytes = System.Text.Encoding.Unicode.GetBytes(str);
            string UnicodeString = "";
            int v;
            for (v = 0; v <= ArrayOFBytes.Length - 1; v++)
            {
                if (v % 2 == 0)
                {
                    byte t = ArrayOFBytes[v];

                    ArrayOFBytes[v] = ArrayOFBytes[v + 1];
                    ArrayOFBytes[v + 1] = t;
                }
            }

            //string c = Hex(ArrayOFBytes(v));
            string c = String.Format("{0:x4}", ArrayOFBytes[v]);
         
            if (c.Length == 1)
                c = "0" + c;
            return UnicodeString;

    }

    }
}
