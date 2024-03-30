
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;


namespace CoreERP.Helpers
{
    public static class Utils
    {
        static string m_ConnectionString = null;
        static bool m_UpdateDashboard = false;
        static Dictionary<int, int> m_ColAsteriskClassnumber = new Dictionary<int, int>();
        static string _strOTP = string.Empty;
        static string _MachineName = string.Empty;
        public static bool CheckFileExists(string Url)
        {
            HttpWebResponse response = null;
            var request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "HEAD";

            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                return false;
            }
            finally
            {
                // Don't forget to close your response.
                if (response != null)
                {
                    response.Close();
                }
            }

            return true;
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            return new ObservableCollection<T>(source);
        }

        public static bool IsDecimal(string Amount)
        {
            decimal dRet = 0;
            return decimal.TryParse(Amount, out dRet);
        }

        public static string ConvertToProperCase(string text)
        {
            TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
            return myTI.ToTitleCase(text.ToLower());
        }

        public static Dictionary<int, string> m_dictLOV = new Dictionary<int, string>();

        public static string ConvertToCurrency(string strAmount)
        {
            CultureInfo cultureInfo = new CultureInfo("en-IN");
            NumberFormatInfo nfi = cultureInfo.NumberFormat;

            if (string.IsNullOrEmpty(strAmount))
                return null;
            //decimal devimalValue = GetDecimalFromString(strAmount, 0);
            return nfi.CurrencySymbol + " " + strAmount;// devimalValue.ToString("C");
        }

        public static bool GetDashboardUpdate()
        {
            return m_UpdateDashboard;
        }

        public static void SetDashboardUpdate(bool bState)
        {
            m_UpdateDashboard = bState;
        }

        public static int GetAsteriskClassnumber(int nClassnumber)
        {
            if (m_ColAsteriskClassnumber.Count <= 0)
            {
                int i;
                int j = 2;

                for (i = 1; i <= 23; i++)
                {
                    if (i > 20)
                    {
                        m_ColAsteriskClassnumber.Add(i, i - j);
                        j++;
                    }

                    else
                        m_ColAsteriskClassnumber.Add(i, i);

                    j++;
                }
            }

            int result = m_ColAsteriskClassnumber.FirstOrDefault(t => t.Key == nClassnumber).Value;

            return result;
        }

        public static bool IsOdd(int nNumber)
        {
            if (nNumber % 2 == 0)
                return false;
            else
                return true;
        }

        public static string NetworkErrorMessage()
        {
            return "Network Error, Please try again or contact Asterisk Co-ordinator";
        }

        public static bool IsDatabaseAvailable()
        {
            using (var l_oConnection = new SqlConnection(ConnectionString))
            {
                try
                {
                    l_oConnection.Open();
                    l_oConnection.Close();
                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                }
            }
        }

        public static string ConvertToStringCommas(string strAmount)
        {
            string strDecimalValue = string.Empty;
            if (strAmount != null)
            {
                int nPos = strAmount.IndexOf('.');

                if (nPos > 0)
                {
                    strDecimalValue = strAmount.Substring(nPos + 1);
                    strAmount = strAmount.Substring(0, nPos);
                }
            }
            if (!IsNumeric(strAmount))
                return strAmount;

            int nLength = strAmount.Length;
            if (nLength < 4)
                return strAmount;

            bool bIsOdd = IsOdd(nLength);

            string strCurrency, strTemp;

            if (bIsOdd)
            {
                strCurrency = strAmount.Substring(0, 2);
                strAmount = strAmount.Remove(0, 2);
            }
            else
            {
                strCurrency = strAmount.Substring(0, 1);
                strAmount = strAmount.Remove(0, 1);
            }

            while (strAmount.Length > 3)
            {
                strCurrency += ",";
                strTemp = strAmount.Substring(0, 2);
                strCurrency += strTemp;
                strAmount = strAmount.Remove(0, 2);
            }

            if (strAmount.Length == 3)
            {
                strCurrency += ",";
                strCurrency += strAmount;
            }

            if (!string.IsNullOrWhiteSpace(strDecimalValue))
                strCurrency = strCurrency + "." + strDecimalValue;

            return strCurrency;
        }

        public static bool IsNumeric(string strText)
        {
            int nOut = 0;
            return Int32.TryParse(strText, out nOut);
        }


        public static bool IsDouble(string strText)
        {
            double dOut = 0.0;
            bool bRet = double.TryParse(strText, out dOut);
            return bRet;
        }

        public static decimal CalculateInterest(decimal Amount, DateTime FromDate, DateTime ToDate, decimal RateofInterest, int round)
        {
            return Convert.ToDecimal(CalculateInterest(Convert.ToDouble(Amount), FromDate, ToDate, Convert.ToDouble(RateofInterest), round));
        }

        public static decimal CalculateInterest(decimal Amount, DateTime FromDate, DateTime ToDate, double RateofInterest, int round)
        {
            return Convert.ToDecimal(CalculateInterest(Convert.ToDouble(Amount), FromDate, ToDate, RateofInterest, round));
        }

        public static double CalculateInterest(double Amount, DateTime FromDate, DateTime ToDate, double RateofInterest, int round)
        {

            DateTime StartDate = FromDate.Date;
            DateTime EndDate = ToDate.Date;
            TimeSpan diff = EndDate.Subtract(StartDate);

            if (diff.TotalDays <= 0)
                return 0;

            return Math.Round(((Amount * RateofInterest / 100 / 12 / 30) * diff.TotalDays), round);

        }

        public static double CalculateLatePaymentCharges(double Amount, DateTime FromDate, DateTime ToDate, double penaltyfactor, int round)
        {

            DateTime StartDate = FromDate.Date;
            DateTime EndDate = ToDate.Date;
            TimeSpan diff = EndDate.Subtract(StartDate);

            if (diff.TotalDays <= 0)
                return 0;

            return Math.Round(((Amount * penaltyfactor / 100) * diff.TotalDays), round);
        }

        public static decimal CalculateLatePaymentCharges(decimal Amount, DateTime FromDate, DateTime ToDate, decimal penaltyfactor, int round)
        {

            DateTime StartDate = FromDate.Date;
            DateTime EndDate = ToDate.Date;
            TimeSpan diff = EndDate.Subtract(StartDate);

            if (diff.TotalDays <= 0)
                return 0;

            return Decimal.Round(((Amount * penaltyfactor / 100) * diff.Days), round);
        }

        public static void GetStartEndDatesbyWeek(int year, int weekNum, CalendarWeekRule rule, ref DateTime startDate, ref DateTime endDate)
        {
            DateTime jan1 = new DateTime(year, 1, 1);

            int daysOffset = DayOfWeek.Monday - jan1.DayOfWeek;
            DateTime firstMonday = jan1.AddDays(daysOffset);

            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(jan1, rule, DayOfWeek.Monday);

            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            startDate = firstMonday.AddDays(weekNum * 7);
            endDate = startDate.AddDays(6);
        }

        public static string Encrypt(string toEncrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string key = "EternitecGangadhar";

            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString)
        {
            bool useHashing = true;
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            string key = "EternitecGangadhar";

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static int GetIntegerFromString(string str)
        {
            int number;
            bool result = Int32.TryParse(str, out number);
            if (result)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

        public static short GetShortFromString(string str)
        {
            short number;
            bool result = Int16.TryParse(str, out number);
            if (result)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

        public static Int64 GetBigIntegerFromString(string str)
        {
            Int64 number;
            bool result = Int64.TryParse(str, out number);
            if (result)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }

        public static DateTime GetDateFromObject(object obj)
        {
            DateTime dtValue = DateTime.MinValue;
            bool result = DateTime.TryParse(obj.ToString(), out dtValue);
            return dtValue;
        }

        public static Double GetDoubleFromString(string str, int roundtodecimals)
        {
            double dbValue;
            bool result = double.TryParse(str, out dbValue);
            if (result)
            {
                return Math.Round(dbValue, roundtodecimals);
            }
            else
            {
                return 0;
            }
        }

        public static Double GetDoubleFromString(string str)
        {
            double dbValue;
            bool result = double.TryParse(str, out dbValue);
            if (result)
            {
                return Math.Round(dbValue, 2);
            }
            else
            {
                return 0;
            }
        }

        public static Decimal GetDecimalFromString(string str, int roundtodecimals)
        {
            decimal decValue;
            bool result = decimal.TryParse(str, out decValue);
            if (result)
            {
                return decimal.Round(decValue, roundtodecimals);
            }
            else
            {
                return 0;
            }
        }

        public static Decimal GetDecimalFromString(string str)
        {
            decimal decValue;
            bool result = decimal.TryParse(str, out decValue);
            if (result)
            {
                return decimal.Round(decValue, 2);
            }
            else
            {
                return 0;
            }
        }

        public static string GetStringFromDecimalForInsert(decimal str, int roundtodecimals)
        {
            return decimal.Round(str, roundtodecimals).ToString();
        }

        public static string GetTitleCase(string strValue)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(strValue);
        }

        public static string GetStringFromDecimalForInsert(decimal str)
        {
            return decimal.Round(str, 2).ToString();
        }

        public static bool CheckForImagesFolder()
        {
            bool result;
            result = System.IO.File.Exists(ImagePath);
            if (!result)
            {
                System.IO.Directory.CreateDirectory(ImagePath);
            }
            result = true;
            return result;
        }

        public static bool CheckForMDBFile()
        {
            //return true;
            return System.IO.File.Exists(MDBPath);
        }

        public static void CleanUpImages()
        {
            //string[] UsedImages = new FinPro.DL.CustomerDataAccess().GetCustomerAndVehicleImageFileNames();

            //DirectoryInfo dInfo = new DirectoryInfo(FinPro.DL.DataAccessBase.ImagePath);
            //FileInfo[] fInfo = dInfo.GetFiles();
            //foreach (FileInfo fi in fInfo)
            //{
            //    if (!UsedImages.Contains(fi.Name)) 
            //        fi.Delete();
            //}
        }

        public static void ErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                string sLogFormat = DateTime.Today.ToShortDateString().ToString() + " " + DateTime.Today.ToLongTimeString().ToString() + " ==> ";
                string sPathName = @"Logfiles\FinProErrorLog_";
                string sYear = DateTime.Today.Year.ToString();
                string sMonth = DateTime.Today.Month.ToString();
                string sDay = DateTime.Today.Day.ToString();
                string sErrorTime = sDay + "-" + sMonth + "-" + sYear;
                sw = new StreamWriter(sPathName + sErrorTime + ".txt", true);
                sw.WriteLine(sLogFormat + Message);
                sw.Flush();
            }
            catch (Exception)
            {
                // ErrorLog(ex.ToString());
            }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                    sw.Close();
                }
            }


        }

        public static bool CheckForWriteAccess()
        {
            StreamWriter sw = null;
            bool HasPermissions = false;
            try
            {
                if (File.Exists(@"testfile.txt"))
                    File.Delete(@"testfile.txt");

                string sPathName = @"testfile.txt";
                sw = new StreamWriter(sPathName, true);
                sw.Write("checking for permissions");
                sw.Flush();
                HasPermissions = true;
            }
            catch (Exception ex)
            {
                //ErrorLog(ex.ToString());
            }
            finally
            {

                if (sw != null)
                {
                    sw.Dispose();
                    sw.Close();
                }
            }
            return HasPermissions;
        }

        public static void RestoreDataBase()
        {
            // 1. check if any file exists in restore folder
            //string[] files = Directory.GetFiles(FinPro.DL.DataAccessBase.RestoreFolderPath);
            //foreach (string f in files)
            //{
            //    File.Copy(f, FinPro.DL.DataAccessBase.MDBPath,true);
            //    File.Delete(f);
            //}
        }

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(m_ConnectionString))
                    GetConnection();

                return m_ConnectionString;
                //string constr = "Data Source = GANGADHAR-PC;Initial Catalog = Asterisk;Persist Security Info=true;User ID=sa;Password=Admin@123";
                //string constr = "Data Source = GANGADHAR-HP;Initial Catalog = Asterisk;Persist Security Info=true;User ID=sa;Password=atg@123";
                //return constr;
            }
        }

        public static void GetConnection()
        {
            System.IO.StreamReader configFile = new System.IO.StreamReader("Config.txt");
            string strDataSource = configFile.ReadLine();
            m_ConnectionString = Decrypt(strDataSource);
            configFile.Close();
        }

        public static string MDBPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + GetDBFileName();
            }
        }

        public static string MDBExtension
        {
            get
            {
                return ".mdb";
            }
        }

        public static string ImagePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"FinProImages\";
            }
        }

        public static string BackUpFolderPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"BackUp\";
            }
        }

        public static string RestoreFolderPath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + @"Restore\";
            }
        }

        private static void CompressStringToFile(string fileName, string value)
        {
            // A.
            // Write string to temporary file.
            string temp = Path.GetTempFileName();
            File.WriteAllText(temp, value);

            // B.
            // Read file into byte array buffer.
            byte[] b;
            using (FileStream f = new FileStream(temp, FileMode.Open))
            {
                b = new byte[f.Length];
                f.Read(b, 0, (int)f.Length);
            }

            // C.
            // Use GZipStream to write compressed bytes to target file.
            using (FileStream f2 = new FileStream(fileName, FileMode.Create))
            using (GZipStream gz = new GZipStream(f2, CompressionMode.Compress, false))
            {
                gz.Write(b, 0, b.Length);
            }
        }

        public static string CompanyName { get; set; }

        public static string CompanyAddress { get; set; }

        public static string CompanyPhone { get; set; }

        public static void SetDBFileName(string DBFileName)
        {
            StreamWriter sw = null;
            string sPathName = @"DBName.txt";
            sw = new StreamWriter(sPathName, false);
            sw.WriteLine(DBFileName.Contains(".mdb") ? DBFileName : DBFileName + ".mdb");
            sw.Flush();

            if (sw != null)
            {
                sw.Dispose();
                sw.Close();
            }
        }

        public static void CreateNewCompany(string CompanyName)
        {
            string NewFileName = (CompanyName.Contains(".mdb") ? CompanyName : CompanyName + ".mdb");
            File.Copy(@"BlankDB.mdb", NewFileName);
            SetDBFileName(NewFileName);
        }

        public static string GetDBFileName()
        {
            if (!System.IO.File.Exists(@"DBName.txt"))
                return "Master.mdb";

            String line;
            string RetVal = string.Empty;
            using (StreamReader sr = new StreamReader(@"DBName.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    RetVal = line;
                }
            }

            if (!System.IO.File.Exists(RetVal))
                return "Master.mdb";

            return RetVal;

        }

        public static ObservableCollection<string> GetAvailableDBs()
        {

            string[] FilesList = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.mdb");

            ObservableCollection<string> lstFilesList = new ObservableCollection<string>();

            foreach (string FileName in FilesList)
            {
                FileInfo fi = new FileInfo(FileName);
                if (fi.Name != "BlankDB.mdb")
                    lstFilesList.Add(fi.Name.Replace(".mdb", ""));
            }

            return lstFilesList;
        }

        public static void AddRange<TItem, TElement>(this ICollection<TElement> collection, IEnumerable<TItem> items) where TItem : TElement
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (items == null) throw new ArgumentNullException("items");

            foreach (var item in items)
                collection.Add(item);
        }

        public static List<DateTime> GetDates(int nYear, int nMonth)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(nYear, nMonth))
                        .Select(day => new DateTime(nYear, nMonth, day))
                        .ToList();
        }

        public static int GetAttendanceDays(int nYear, int nMonth)
        {
            //Check if it is current month;
            if ((DateTime.Today.Year == nYear) && (DateTime.Today.Month == nMonth))
                return DateTime.Today.Day;
            else
                return DateTime.DaysInMonth(nYear, nMonth);
        }

        public static bool HasConnection()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDBAvailable()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("49.207.6.8");
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsLocalDBAvailable()
        {
            try
            {
                System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("192.168.1.7");
                return true;
            }
            catch
            {
                return false;
            }
        }

        static readonly Random _random = new Random();

        public static string[] RandomizeStrings(string[] arr)
        {
            List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
            // Add all strings from array
            // Add new random int each time
            foreach (string s in arr)
            {
                list.Add(new KeyValuePair<int, string>(_random.Next(), s));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            string[] result = new string[arr.Length];
            // Copy values to array
            int index = 0;
            foreach (KeyValuePair<int, string> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;
        }

        public static string GetFourDigitNumber(string Number)
        {
            switch (Number.Length)
            {
                case 1:
                    return "000" + Number;
                case 2:
                    return "00" + Number;
                case 3:
                    return "0" + Number;
                default:
                    return Number;
            }

        }

        public static ObservableCollection<Months> GetMonths(DateTime dtYearStartDate, DateTime dtYearEndDate)
        {
            ObservableCollection<Months> colMonths = new ObservableCollection<Months>();

            if ((null == dtYearStartDate) || (null == dtYearEndDate))
                return null;

            if (dtYearStartDate > dtYearEndDate)
                return null;


            int nMonths = (((dtYearEndDate.Year * 12) + dtYearEndDate.Month) - ((dtYearStartDate.Year * 12) + dtYearStartDate.Month)) + 1;

            int nCurrentYear = DateTime.Today.Year;
            int nCurrentMonth = DateTime.Today.Month;

            for (int i = 0; i < nMonths; i++)
            {
                DateTime dtTemp = dtYearStartDate.AddMonths(i);
                Months objMonths = new Months();

                int nYear = dtTemp.Year;
                int nMonth = dtTemp.Month;

                if (nYear > nCurrentYear)
                    break;

                if ((nCurrentYear == nYear) && (nMonth > nCurrentMonth))
                    break;

                objMonths.MonthName = dtTemp.Year.ToString() + " - " + dtTemp.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture);
                objMonths.MonthValue = dtTemp.Year.ToString() + "-" + dtTemp.Month.ToString();
                colMonths.Add(objMonths);
            }

            return colMonths;
        }

        public static List<string> GetFileFromFTP(string sPath, string sFileName, bool Startswith = false)
        {
            var requestObj = FtpWebRequest.Create(sPath) as FtpWebRequest;
            requestObj.Credentials = new NetworkCredential("amtpowertransm", "Zxan44*6");
            requestObj.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)requestObj.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());

            List<string> lstFiles = new List<string>();
            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                if (Startswith)
                {
                    if (line.StartsWith(sFileName))
                        lstFiles.Add(line);
                }
                else
                {
                    if (line.Contains(sFileName))
                        lstFiles.Add(line);
                }

                line = streamReader.ReadLine();
            }

            streamReader.Close();

            return lstFiles;
        }

        public static void SendEMail(string emailid, string subject, string body)
        {
            try
            {
                //MailMessage email = new MailMessage();
                //email.From = new MailAddress("mmp@amtpowertransmission.com", "AMT");
                //email.To.Add(new MailAddress(emailid, ""));
                //email.Subject = subject;
                //email.Body = body;
                //email.IsBodyHtml = true;

                //SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                ////client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //// Password changed by Naidu on 20-Feb-2017
                //client.Credentials = new System.Net.NetworkCredential("mmp@amtpowertransmission.com", "vbaamtpower@39");//password is changed 18-jan-2015
                //client.EnableSsl = true;

                ////System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                ////System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                ////System.Security.Cryptography.X509Certificates.X509Chain chain,
                ////System.Net.Security.SslPolicyErrors sslPolicyErrors)
                ////{
                ////    return true;
                ////};

                //client.Send(email);

                MailMessage email = new MailMessage();
                email.From = new MailAddress("sales@amtpowertransmission.com", "AMT");
                email.To.Add(new MailAddress("krishnaprasadg81@gmail.com"));

                //email.Bcc.Add(new MailAddress("mail id", "Email display"));


                email.Subject = subject;

                email.Body = body;
                email.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtpout.secureserver.net", 587);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;

                client.Credentials = new System.Net.NetworkCredential("sales@amtpowertransmission.com", "SALES@2020AMT");
                client.EnableSsl = true;
                client.Timeout = 20000;

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                System.Security.Cryptography.X509Certificates.X509Chain chain,
                System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                client.Send(email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static string GetDBByYear()
        {
            string year = DateTime.Now.Year.ToString();
             return year;
        }

        public static string GetMachineName()
        {
            return _MachineName;
        }

        private static string GenerateOTP()
        {
            string strOTP = string.Empty;

            Random rndm = new Random();
            strOTP = rndm.Next(1, 9).ToString() + rndm.Next(1, 9).ToString() + rndm.Next(1, 9).ToString() + rndm.Next(1, 9).ToString() + rndm.Next(1, 9).ToString() + rndm.Next(1, 9).ToString();

            return strOTP;
        }
    }

    public class Months
    {
        public string MonthName { get; set; }
        public string MonthValue { get; set; }
    }
}
