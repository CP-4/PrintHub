using HubLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHDesktopUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            BringToFront();
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //textBoxEmail.Text = "user8@asdf.com";
            //textBoxPassword.Text = "asdf";

            object data = new
            {
                email = textBoxEmail.Text,
                password = textBoxPassword.Text
            };

            LoginAsync(data);
        }

        private async Task LoginAsync(object data)
        {
            string token = await LoginHelper.Login(data);

            if (!string.IsNullOrWhiteSpace(token))
            {
                ApiHelper.InitializeClient(token);
                Properties.Settings.Default.accessToken = token;
                Properties.Settings.Default.Save();
                //PrintHubForm printHubForm = new PrintHubForm();
                //printHubForm.Show();
                var t = new Thread(() => Application.Run(new PrintHubForm()));
                t.Start();
                //this.Hide();
                this.Close();
            }
            else
            {
                Properties.Settings.Default.accessToken = "";
                Properties.Settings.Default.Save();
            }
        }

        private void buttonSingup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please call 9512184367 to register to Preasy\n" +
                "or\n" +
                "send an email to writetopreasy@gmail.com");
        }

        
        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Email")
            {
                textBoxEmail.Clear();
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Clear();
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                textBoxEmail.Text = "Email";
            }
        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxPassword.Text = "Password";
            }
        }
        
    }
}
