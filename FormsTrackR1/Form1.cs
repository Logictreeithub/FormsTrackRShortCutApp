using Google.Protobuf.Compiler;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace FormsTrackR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        StagingFormsTrackRDBEntities trackRDBEntities = new StagingFormsTrackRDBEntities();
        private async void button1_Click(object sender, EventArgs e)
        {
            var userName = txtUserName.Text;
            var passWord = txtPassword.Text;
            string URI = "https://stagingmservices.formstrackr.com/api/Account/Login";
            var result = await GetFileInformation(URI, userName, passWord);
            if (result != null)
            {
                dynamic userDetails = JsonConvert.DeserializeObject(result);
                //var user = trackRDBEntities.AspNetUsers.FirstOrDefault(i => i.UserName == userName);
                string userId = EncryptDecrypt.DESEncrypt(userDetails.Result.UserId.ToString());

                //string Password = EncryptDecrypt.DESDecrypt(userDetails.Result.Password);
                if (userDetails.Result.Username.ToString() == userName/* && Password == passWord*/)
                {
                    if (chkRemember.Checked == true)
                    {
                        Properties.Settings.Default.UserName = userName;
                        Properties.Settings.Default.Password = passWord;
                        Properties.Settings.Default.UserId = userDetails.Result.UserId;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.UserName = userName;
                        Properties.Settings.Default.Password = "";
                        Properties.Settings.Default.UserId = userDetails.Result.UserId;
                        Properties.Settings.Default.Save();
                    }
                    string url = "https://staging.formstrackr.com/Account/Impersination" + "?Id=" + userId;
                    OpenUrlInDefaultBrowser(url);
                    this.Close();
                }
                else
                {
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    chkRemember.Checked = false;
                    MessageBox.Show("Invalid Login Attempt");
                }

            }
            else
            {

                txtUserName.Text = "";
                txtPassword.Text = "";
                chkRemember.Checked = false;
                MessageBox.Show("Invalid Login Attempt");
            }



        }

        static void OpenUrlInDefaultBrowser(string url)
        {
            Process.Start(url);
        }

        public class EncryptDecrypt
        {
            const string DesKey = "AQWSEDRF";
            const string Desiv = "HGFEDCBA";
            public static string DESDecrypt(string stringToDecrypt)//Decrypt the content
            {
                stringToDecrypt = stringToDecrypt.Replace(" ", "+");
                string sEncryptionKey = "01234567890123456789";
                byte[] key = { };
                byte[] iV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] inputByteArray = new byte[stringToDecrypt.Length];
                try
                {
                    key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    inputByteArray = Convert.FromBase64String(stringToDecrypt);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, iV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    return encoding.GetString(ms.ToArray());
                }
                catch (System.Exception /*ex*/)
                {
                    return (string.Empty);
                }
            }

            public static string DESEncrypt(string stringToEncrypt)// Encrypt the content
            {
                string sEncryptionKey = "01234567890123456789";
                byte[] key = { };
                byte[] iV = { 10, 20, 30, 40, 50, 60, 70, 80 };
                byte[] inputByteArray; //Convert.ToByte(stringToEncrypt.Length) 

                try
                {
                    key = Encoding.UTF8.GetBytes(sEncryptionKey.Substring(0, 8));
                    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                    inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                    MemoryStream ms = new MemoryStream();
                    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, iV), CryptoStreamMode.Write);
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    return Convert.ToBase64String(ms.ToArray());
                }
                catch
                {
                    return (string.Empty);
                }
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            if (btnCloseEye.Text == "true")
            {
                btnCloseEye.Text = "";
                btnCloseEye.BringToFront();
                txtPassword.PasswordChar = '*';
            }
            if (btnOpenEye.Text == "true")
            {
                btnOpenEye.Text = "";
                btnOpenEye.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            txtUserName.Text = Properties.Settings.Default.UserName;
            txtPassword.Text = Properties.Settings.Default.Password;
            int userId = Properties.Settings.Default.UserId;
            var trackresult =await GetTrackingDetailsById(userId);            
            if (trackresult != null)
            {
                string value = "";
                //dynamic trackDetails = JsonConvert.DeserializeObject(trackresult);
                //dynamic jsonObject = JObject.Parse(trackresult);
                
                //var logoutDateTime = jsonObject["Result"]["LogoutDateTime"].ToString();

                JObject j = JObject.Parse(trackresult);
                JToken nestedToken = j["Result"];
                if (nestedToken is JObject nestedObject)
                {
                     value = nestedObject["LogoutDateTime"].ToString();
                    // Now you can safely access the nested value
                }

                if (value == null && value == "")
                {
                    OpenUrlByFormLoad(txtUserName.Text, txtPassword.Text,userId);
                }
                else
                {
                    if (txtUserName.Text != "" && txtPassword.Text != "")
                    {
                        chkRemember.Checked = true;
                    }
                    else
                    {
                        txtUserName.Text = "";
                        txtPassword.Text = "";
                        chkRemember.Checked = false;
                    }

                }
            }
            else
            {
                txtUserName.Text = "";
                txtPassword.Text = "";
                chkRemember.Checked = false;
            }

        }
        private async void OpenUrlByFormLoad(string userName, string password,int Id)
        {
            var userResult = await GetUserDetailsById(Id);
            if(userResult != null)
            {
                dynamic userData = JsonConvert.DeserializeObject(userResult);
                //var user = trackRDBEntities.AspNetUsers.FirstOrDefault(i => i.UserName == userName);
                string userId = EncryptDecrypt.DESEncrypt(userData.Result.UserId.ToString());
                if (userData != null)
                {
                    if (password != "")
                    {
                        string a = userData.Result.UserPassword;
                        string Password = EncryptDecrypt.DESDecrypt(a);
                        if (userData.Result.UserName == userName && Password == password)
                        {
                            string url = "https://staging.formstrackr.com/Account/Impersination" + "?Id=" + userId;
                            OpenUrlInDefaultBrowser(url);
                            this.Close();
                        }
                    }
                    else
                    {
                        if (userData.Result.UserName == userName)
                        {
                            string url = "https://staging.formstrackr.com/Account/Impersination" + "?Id=" + userId;
                            OpenUrlInDefaultBrowser(url);
                            this.Close();
                        }
                    }

                }
            }

            //if (password != "" && password != null)
            //{
            //    string userId = EncryptDecrypt.DESEncrypt(Id.ToString());
                
            //        string url = "https://staging.formstrackr.com/Account/Impersination" + "?Id=" + userId;
            //        OpenUrlInDefaultBrowser(url);
            //        this.Close();
                
            //}
            //else
            //{
            //    if (userName != null && userName != "")
            //    {
            //        string userId = EncryptDecrypt.DESEncrypt(Id.ToString());
            //        string url = "https://staging.formstrackr.com/Account/Impersination" + "?Id=" + userId;
            //        OpenUrlInDefaultBrowser(url);
            //        this.Close();
            //    }
            //}

        }

        //private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        //{
        //    if(ChkShowPassword.Checked == true)
        //    {  
        //        txtPassword.PasswordChar = '\0';               
        //    }
        //    else
        //    {
        //        txtPassword.PasswordChar = '*';
        //    }
        //}

        private void btnOpenEye_Click(object sender, EventArgs e)
        {
            btnOpenEye.Text = "false";
            btnCloseEye.Text = "true";

            if (txtPassword.PasswordChar == '*')
            {
                btnOpenEye.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
            if (txtPassword.PasswordChar == '\0')
            {
                btnCloseEye.BringToFront();
                txtPassword.PasswordChar = '*';
            }

        }

        private void btnCloseEye_Click(object sender, EventArgs e)
        {

            btnCloseEye.Text = "false";
            btnOpenEye.Text = "true";

            if (txtPassword.PasswordChar == '\0')
            {
                btnCloseEye.BringToFront();
                txtPassword.PasswordChar = '*';
            }
            if (txtPassword.PasswordChar == '*')
            {
                btnOpenEye.BringToFront();
                txtPassword.PasswordChar = '\0';

            }

        }

        public async Task<string> GetFileInformation(string url, string email, string password)
        {
            string responseData = null;
            using (var client = new HttpClient())
            {
                var parameters = new Dictionary<string, string>
                {
                    { "DeviceType","iphone"},
                    { "UniqueDeviceID","B07D817B-8267-4196-9C36-366593E9ECCC" },
                    { "IpAddress","192.168.1.37" },
                    { "DeviceInfo","Device Model - iPhone Device Name - iPhone SE (3rd generation) OS Name - iOS OS Version - 17.0.1 Unique Device ID - B07D817B-8267-4196-9C36-366593E9ECCC" },
                    { "OSVersion","17.0.1"},
                    { "Password",password },
                    { "PushTokenID","808715C05FB098BA1D4CF9037DDF3AA6B9EC92980719B7E91C18E6EF2D485AA28D692B087F94D6ED9133DC2602DA3E013A8F56F1E417E12E64B480C4DDAD66C56F249A30AE97893063AD0EE88FB8E806" },
                    {"Email",email}
                };

                dynamic json = JsonConvert.SerializeObject(parameters);

                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    responseData = await response.Content.ReadAsStringAsync();
                    //Data data = JsonConvert.DeserializeObject(responseData[1]);
                    return responseData;
                }

            }
            return responseData;
        }

        public async Task<string> GetTrackingDetailsById(int id)
        {
            string data = null;
            using (HttpClient client = new HttpClient())
            {
                // Replace the URL with the actual API endpoint and parameters
                string apiUrl = "https://stagingmservices.formstrackr.com/api/Account/GetUserLoginTrackingData?UserId=" + id;

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                    return data;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            return data;
        }


        public async Task<string> GetUserDetailsById(int id)
        {
            string data = null;
            using (HttpClient client = new HttpClient())
            {
                // Replace the URL with the actual API endpoint and parameters
                string apiUrl = "https://stagingmservices.formstrackr.com/api/Account/GetUserLoginData?UserId=" + id;

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                    return data;
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            return data;
        }

        class Data
        {
            public string DeviceType { get; set; }
            public string UniqueDeviceID { get; set; }
            public string IpAddress { get; set; }
            public string DeviceInfo { get; set; }
            public string OSVersion { get; set; }
            public string Password { get; set; }
            public string PushTokenID { get; set; }
            public string Email { get; set; }
        }
    }
}
