using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HubLibrary;
using HubLibrary.Model;
using System.Diagnostics;

namespace PHDesktopUI
{
    public partial class SettingsControl : UserControl
    {
        string Id = Properties.Settings.Default.shopId;

        public SettingsControl()
        {
            InitializeComponent();

            //LoadSettingsFieldAsync();
        }

        public async Task LoadSettingsFieldAsync()
        {
            Id = Properties.Settings.Default.shopId;

            if (!string.IsNullOrWhiteSpace(Id))
            {
                ShopModel shop = await SettingsHelper.FetchShopDetailsAsync(Id);

                textBoxShopName.Text = shop.Name;
                textBoxMapLink.Text = shop.Gmap_Url;
                textBoxCity.Text = shop.City;
                textBoxState.Text = shop.State;
                textBoxAddress.Text = shop.Address;
                textBoxPriceSS.Text = shop.Price_SS.ToString();
                textBoxPriceDS.Text = shop.Price_DS.ToString();
            }
        }

        private void buttonCancelShopDetails_Click(object sender, EventArgs e)
        {
            //printQueueControl1.BringToFront();
            this.SendToBack();
        }

        

        private async Task UpdateShopDetailsAsync(object data)
        {
            ShopModel shop = await SettingsHelper.UpdateShopDetails(data);
            
            if (!string.IsNullOrWhiteSpace(shop.Id))
            {
                if (Id == shop.Id)
                {
                    MessageBox.Show("Shop Updated\n");
                }
                else
                {
                    MessageBox.Show("Shop Created\n");
                    Properties.Settings.Default.shopId = shop.Id;
                    Properties.Settings.Default.Save();
                    Id = Properties.Settings.Default.shopId;
                }

                this.SendToBack();
            }
            else
            {
                MessageBox.Show("Error occured while updating shop details.\nPlease contact Preasy customer support\n");
                
                textBoxShopName.Text = "";
                textBoxMapLink.Text = "";
                textBoxCity.Text = "";
                textBoxState.Text = "";
                textBoxAddress.Text = "";
                textBoxPriceSS.Text = "";
                textBoxPriceDS.Text = "";
            }
        }

        private void buttonSaveShopDetails_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Id))
            {
                object data = new
                {
                    id = Id,
                    name = textBoxShopName.Text,
                    gmap_url = textBoxMapLink.Text,
                    city = textBoxCity.Text,
                    state = textBoxState.Text,
                    address = textBoxAddress.Text,
                    price_ss = textBoxPriceSS.Text,
                    price_ds = textBoxPriceDS.Text
                };
                
                UpdateShopDetailsAsync(data);
            }
            else
            {
                object data = new
                {
                    name = textBoxShopName.Text,
                    gmap_url = textBoxMapLink.Text,
                    city = textBoxCity.Text,
                    state = textBoxState.Text,
                    address = textBoxAddress.Text,
                    price_ss = textBoxPriceSS.Text,
                    price_ds = textBoxPriceDS.Text
                };

                UpdateShopDetailsAsync(data);
            }


        }
    }
}
