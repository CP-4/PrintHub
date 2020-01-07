using HubLibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HubLibrary
{

    public class SettingsHelper
    {
        public static async Task<ShopModel> UpdateShopDetails(object data)
        {
            ShopModel shop = new ShopModel();

            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string url = GlobalConfig.ApiHost + "/file2/shop/register";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, byteContent))
            {
                //Debug.WriteLine(response.StatusCode);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //token = "Auth failed";
                    MessageBox.Show("Login again.\n" + response.ReasonPhrase);
                }
                else if (response.StatusCode == HttpStatusCode.Created)
                {
                    shop = await response.Content.ReadAsAsync<ShopModel>();
                }
                else
                {
                    MessageBox.Show("Exception occured.\n" + response.ReasonPhrase);
                }

                return shop;
            }
        }

        public static async Task<ShopModel> FetchShopDetailsAsync(string id)
        {
            ShopModel shop = new ShopModel();

            string url = GlobalConfig.ApiHost + "/file2/shops/" + id + "/";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //Debug.WriteLine(response.StatusCode);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //token = "Auth failed";
                    MessageBox.Show("Login again.\n" + response.ReasonPhrase);
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    shop = await response.Content.ReadAsAsync<ShopModel>();
                }
                else
                {
                    MessageBox.Show("Exception occured.\n" + response.ReasonPhrase);
                }

                return shop;
            }
        }

        public static async Task<ShopModel> FetchShopFromUserAsync()
        {
            ShopModel shop = new ShopModel();

            string url = GlobalConfig.ApiHost + "/file2/shops/getshopfromuser/";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //Debug.WriteLine(response.StatusCode);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //token = "Auth failed";
                    MessageBox.Show("Login again.\n" + response.ReasonPhrase);
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    shop = await response.Content.ReadAsAsync<ShopModel>();
                }
                else
                {
                    MessageBox.Show(response.ReasonPhrase);
                }

                return shop;
            }
        }
    }
}
