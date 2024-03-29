using System;
using System.IO;
using System.Net;
using System.Text;

namespace CoreERP.Helpers
{
    public class SMSGateway
    {
        //private static StringBuilder sbGateWayURL = new StringBuilder("http://smsonline.co.in/sendsms.asp?user=@username&password=@password&sender=@sender&text=@message&PhoneNumber=@mobileno&track=1");
        public static string gatewayurl = "http://www.pointsms.in/API/sms.php?username=@username&password=@password&from=@sender&to=@mobileno&msg=@message&type=1&dnd_check=0";
        public static string username = "onecontrol";
        public static string password = "ubuTzc3x";
        public static string sender = "ONECTL";

        /// <summary>
        /// Sends SMS via gateway
        /// </summary>
        /// <param name="mobileno"> 10 digit mobile number prefixed with 91</param>
        /// <param name="message"> message to be sent</param>
        /// <returns></returns>
        public bool SendSMSviaGateway(string mobileno, string message)
        {
            //   return true;
            try
            {
                if (!Utils.HasConnection())
                    return false;

                StringBuilder sb = new StringBuilder();

                sb.Append(gatewayurl);
                sb.Replace("@username", username);
                sb.Replace("@password", password);
                sb.Replace("@sender", sender);
                sb.Replace("@mobileno", mobileno);
                sb.Replace("@message", message);

                HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create(sb.ToString());
                GETRequest.Method = "GET";
                HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
                Stream GETResponseStream = GETResponse.GetResponseStream();
                StreamReader sr = new StreamReader(GETResponseStream);
                string strResponseReceived = sr.ReadLine();

                //Your message is successfully sent to:918500210210

                if (null == strResponseReceived || string.Empty == strResponseReceived)
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
