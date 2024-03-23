using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace BillBook.Library
{
    public class FastSMSService
    {
       // CustomersDataAccess _daCustomers = new CustomersDataAccess();

        public void SendMessage(string MobileNumber, string Message)
        {
            //Your authentication key
            string authKey = "31762AiS5t3itCdC5ce55751";
            //Sender ID,While using route4 sender id should be 6 characters long.
            string senderId = "AMTHYD";
            //Your message to send, Add URL encoding here.
            string message = HttpUtility.UrlEncode(Message);

            //Prepare you post parameters
            StringBuilder sbPostData = new StringBuilder();
            sbPostData.AppendFormat("authkey={0}", authKey);
            sbPostData.AppendFormat("&mobiles={0}", MobileNumber + ",9963004836");
            sbPostData.AppendFormat("&message={0}", message);
            sbPostData.AppendFormat("&sender={0}", senderId);
            sbPostData.AppendFormat("&route={0}", "default");

            try
            {
                //Call Send SMS API
                string sendSMSUri = "http://sms.fastsmsindia.com/api/sendhttp.php";
                //Create HTTPWebrequest
                HttpWebRequest httpWReq = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                //Prepare and Add URL Encoded data
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(sbPostData.ToString());
                //Specify post method
                httpWReq.Method = "POST";
                httpWReq.ContentType = "application/x-www-form-urlencoded";
                httpWReq.ContentLength = data.Length;
                using (Stream stream = httpWReq.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                //Get the response
                HttpWebResponse response = (HttpWebResponse)httpWReq.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string responseString = reader.ReadToEnd();

                //Close the response
                reader.Close();
                response.Close();
            }
            catch (SystemException ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }

        public void SendMessage2(string MobileNumber, string Message)
        {
            //string message = HttpUtility.UrlEncode(Message);


            try
            {
                //Call Send SMS API
                string sendSMSUri = $"https://smslogin.co/v3/api.php?username=infinix&apikey=ed37311e18681771a5fa&senderid=INFNIX&mobile={MobileNumber}&message={Message}";

                HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create(sendSMSUri);
                GETRequest.Method = "GET";
                HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
                Stream GETResponseStream = GETResponse.GetResponseStream();
                StreamReader sr = new StreamReader(GETResponseStream);
                string strResponseReceived = sr.ReadLine();
            }
            catch (SystemException ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }

        public void SendNewOrderThanksMessage(int CustomerNumber, string OrderNumber)
        {
            //Customer objCustomer = _daCustomers.GetCustomersByNumber(CustomerNumber);
            //if (objCustomer == null)
            //    return;

            //if (objCustomer.Contact1.Length < 10)
            //    return;

            //string sMessage = string.Format("Dear Sir, We are thankful to {0} for choosing AMT. Your order is registered with number {1}. - AMT Power Transmission", objCustomer.CompanyName, OrderNumber);
            string sMessage = $"Dear Sir, We are thankful to {"CompanyName"} for choosing AMT. Your order is registered with number {OrderNumber}. - Infinix";

            SendMessage2("objCustomer.Contact1", sMessage);
        }

        public void SendNewInvoiceMessage(int CustomerNumber, string OrderNumber, string InvoiceNumber, double Amount)
        {
            //Customer objCustomer = _daCustomers.GetCustomersByNumber(CustomerNumber);
            //if (objCustomer == null)
            //    return;

            //if (objCustomer.Contact1.Length < 10)
            //    return;

            //string sMessage = string.Format("Dear Sir, delivered your order with number {0}. Invoice number : {1}, Invoice Amount : {2}. Thanks for choosing AMT. - AMT Power Transmission", OrderNumber, InvoiceNumber, Amount.ToString("#.00"));
            string sMessage = $"Dear Sir, delivered your order with number {"OrderNumber"}. Invoice number : {InvoiceNumber}, Invoice Amount : ₹{Amount}. Thanks for choosing AMT. -Infinix";

            SendMessage2("objCustomer.Contact1", sMessage);
        }
    }
}
