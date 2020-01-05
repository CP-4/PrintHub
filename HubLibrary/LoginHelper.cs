using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HubLibrary
{
    public class Token
    {
        public string token { get; set; }
    }

    public static class LoginHelper
    {
        public static async Task<string> Login(object data)
        {

            string token = "";

            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = GlobalConfig.ApiHost + "/file2/auth/login/";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, byteContent))
            {
                //Debug.WriteLine(response.StatusCode);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //token = "Auth failed";
                    MessageBox.Show("Incorrect credentials.\n" + response.ReasonPhrase);
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    Token tok = JsonConvert.DeserializeObject<Token>(res);
                    token = tok.token;
                    Debug.WriteLine(tok);
                }
                else
                {
                    //token = "Exception occured";
                    MessageBox.Show("Exception occured.\n" + response.ReasonPhrase);
                    throw new Exception(response.ReasonPhrase);
                }

                return token;
            }
        }

        public static async Task<string> Singup(object data)
        {

            string token = "";

            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = GlobalConfig.ApiHost + "/file2/auth/register/";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, byteContent))
            {
                //Debug.WriteLine(response.StatusCode);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //token = "Auth failed";
                    MessageBox.Show("Incorrect credentials.\n" + response.ReasonPhrase);
                }
                else if (response.StatusCode == HttpStatusCode.Created)
                {
                    string res = await response.Content.ReadAsStringAsync();
                    Token tok = JsonConvert.DeserializeObject<Token>(res);
                    token = tok.token;
                    Debug.WriteLine(tok);
                }
                else
                {
                    //token = "Exception occured";
                    MessageBox.Show("Exception occured.\n" + response.ReasonPhrase);
                    throw new Exception(response.ReasonPhrase);
                }

                return token;
            }
        }

    }
}
