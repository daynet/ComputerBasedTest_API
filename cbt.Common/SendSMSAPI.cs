﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace cbt.Common
{
   public class SendSMSAPI
    {
        private WebProxy objProxy1 = null;

        public string SendSMS(string User, string password, string Mobile_Number, string Message)
        {
            string stringpost = null;
            stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message;

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {

                string stringResult = null;

                objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.smscountry.com/SMSCwebservice.asp");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }


                // Use below code if you want to SETUP PROXY.
                //Parameters to pass: 1. ProxyAddress 2. Port
                //You can find both the parameters in Connection settings of your internet explorer.

                //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
                //myProxy.BypassProxyOnLocal = true;
                //wrGETURL.Proxy = myProxy;

                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                // commented tewrsting
                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();

                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();

                objStreamReader.Close();
                return stringResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }

        }

        public string SendSMS(string User, string password, string Mobile_Number, string Message, string Mtype)
        {

            System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&MType=" + Mtype;

            //string functionReturnValue = null;
            //functionReturnValue = "";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;

                objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.smscountry.com/SMSCwebservice.asp?");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }

                // Use below code if you want to SETUP PROXY.
                //Parameters to pass: 1. ProxyAddress 2. Port
                //You can find both the parameters in Connection settings of your internet explorer.

                //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
                //myProxy.BypassProxyOnLocal = true;
                //wrGETURL.Proxy = myProxy;

                objWebRequest.ContentType = "application/x-www-form-urlencoded";
                //commented for checking
                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();

                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();

                objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }

        public string SendSMS(string User, string password, string Mobile_Number, string Message, string Mtype, string DR)
        {

            System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&MType=" + Mtype + "&DR=" + DR;

            //string functionReturnValue = null;
            //functionReturnValue = "";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;

                objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.smscountry.com/SMSCwebservice.asp?");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }

                // Use below code if you want to SETUP PROXY.
                //Parameters to pass: 1. ProxyAddress 2. Port
                //You can find both the parameters in Connection settings of your internet explorer.

                //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
                //myProxy.BypassProxyOnLocal = true;
                //wrGETURL.Proxy = myProxy;
                //commented for checking
                objWebRequest.ContentType = "application/x-www-form-urlencoded";

                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();

                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();

                objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }

        public string SendSMS(string User, string password, string Mobile_Number, string Message, string Mtype, string DR, string SID)
        {

            System.Object stringpost = "User=" + User + "&passwd=" + password + "&mobilenumber=" + Mobile_Number + "&message=" + Message + "&MType=" + Mtype + "&DR=" + DR + "&SID=" + SID;

            //string functionReturnValue = null;
            //functionReturnValue = "";

            HttpWebRequest objWebRequest = null;
            HttpWebResponse objWebResponse = null;
            StreamWriter objStreamWriter = null;
            StreamReader objStreamReader = null;

            try
            {
                string stringResult = null;

                objWebRequest = (HttpWebRequest)WebRequest.Create("http://www.smscountry.com/SMSCwebservice.asp?");
                objWebRequest.Method = "POST";

                if ((objProxy1 != null))
                {
                    objWebRequest.Proxy = objProxy1;
                }

                // Use below code if you want to SETUP PROXY.
                //Parameters to pass: 1. ProxyAddress 2. Port
                //You can find both the parameters in Connection settings of your internet explorer.

                //WebProxy myProxy = new WebProxy("YOUR PROXY", PROXPORT);
                //myProxy.BypassProxyOnLocal = true;
                //wrGETURL.Proxy = myProxy;

                objWebRequest.ContentType = "application/x-www-form-urlencoded";

                objStreamWriter = new StreamWriter(objWebRequest.GetRequestStream());
                objStreamWriter.Write(stringpost);
                objStreamWriter.Flush();
                objStreamWriter.Close();

                objWebResponse = (HttpWebResponse)objWebRequest.GetResponse();
                objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                stringResult = objStreamReader.ReadToEnd();

                //objStreamReader.Close();
                return (stringResult);
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            finally
            {

                if ((objStreamWriter != null))
                {
                    objStreamWriter.Close();
                }
                if ((objStreamReader != null))
                {
                    objStreamReader.Close();
                }
                objWebRequest = null;
                objWebResponse = null;
                objProxy1 = null;
            }
        }

        //public string SendNewSMS(string destination, string message)
        //{
        //    var client = new RestClient("http://ngn.rmlconnect.net/bulksms/bulksms?username=sunadmin&password=sun%401234&type=0&dlr=1&destination=" + destination + "&source=SKYLINE-SUN&message=" + message + "");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("postman-token", "38a6e5d5-3a73-3637-b95e-65899e18dd3e");
        //    request.AddHeader("cache-control", "no-cache");
        //    IRestResponse response = client.Execute(request);
        //    return response.Content;
        //}


    }
}