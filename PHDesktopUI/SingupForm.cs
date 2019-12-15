using HubLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHDesktopUI
{
    public partial class SingupForm : Form
    {
        public SingupForm()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private void buttonSingup_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
        }

        private void textBoxCnfPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxCnfPassword.PasswordChar = '*';
        }

        private void textBoxName_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Name")
            {
                textBoxName.Clear();
            }
        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "Email")
            {
                textBoxEmail.Clear();
            }
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            if (textBoxPassword.Text == "Password")
            {
                textBoxPassword.Clear();
            }
        }

        private void textBoxCnfPassword_Click(object sender, EventArgs e)
        {
            if (textBoxCnfPassword.Text == "Confirm Password")
            {
                textBoxCnfPassword.Clear();
            }
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                textBoxName.Text = "Name";
            }
        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                textBoxName.Text = "Email";
            }
        }
        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                textBoxName.Text = "Password";
            }
        }
        private void textBoxCnfPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxCnfPassword.Text))
            {
                textBoxCnfPassword.Text = "Confirm Password";
            }
        }

        private void buttonSingup_Click_1(object sender, EventArgs e)
        {
            object data = new
            {
                name = textBoxName.Text,
                email = textBoxEmail.Text,
                password = textBoxPassword.Text
            };

            SingupAsync(data);
        }

        private async Task SingupAsync(object data)
        {
            string token = await LoginHelper.Login(data);

            if (!string.IsNullOrWhiteSpace(token))
            {
                ApiHelper.InitializeClient(token);
                Properties.Settings.Default.accessToken = token;
                Properties.Settings.Default.Save();

                (new PrintHubForm()).Show();
                //var t = new Thread(() => Application.Run(new PrintHubForm()));
                //t.Start();
                //this.Hide();
                this.Close();
            }
            else
            {
                Properties.Settings.Default.accessToken = "";
                Properties.Settings.Default.Save();
            }
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            (new LoginForm()).Show();
            this.Close();
        }
    }
}
