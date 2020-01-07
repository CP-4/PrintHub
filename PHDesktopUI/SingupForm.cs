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
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            BringToFront();
            ApiHelper.InitializeClient();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
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

        private void textBoxPhone_Click(object sender, EventArgs e)
        {
            if (textBoxPhone.Text == "Phone number")
            {
                textBoxPhone.Clear();
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

        private void textBoxPhone_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                textBoxPhone.Text = "Phone number";
            }
        }

        private void buttonSingup_Click(object sender, EventArgs e)
        {
            //textBoxName.Text = "Shop8";
            //textBoxPhone.Text = "0123456879";
            //textBoxEmail.Text = "shop8@asdf.com";
            //textBoxPassword.Text = "asdf";

            object data = new
            {
                student_name = textBoxName.Text,
                phone = textBoxPhone.Text,
                email = textBoxEmail.Text,
                password = textBoxPassword.Text
            };

            SingupAsync(data);
        }

        private async Task SingupAsync(object data)
        {
            string token = await LoginHelper.Singup(data);

            if (!string.IsNullOrWhiteSpace(token))
            {
                ApiHelper.InitializeClient(token);
                Properties.Settings.Default.accessToken = token;
                Properties.Settings.Default.Save();

                var t = new Thread(() => Application.Run(new PrintHubForm()));
                t.Start();
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
            var t = new Thread(() => Application.Run(new LoginForm()));
            t.Start();
            this.Close();
        }
    }
}
