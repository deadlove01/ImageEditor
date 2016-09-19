using CafepressUploader.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafepressUploader.Forms
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            tbEmail.Text = Settings.Default.CAFEPRESS_EMAIL;
            tbPass.Text = Settings.Default.CAFEPRESS_PASS;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string pass = tbPass.Text.Trim();
            if(email.Length == 0)
            {
                MessageBox.Show("Email is required!");
                return;
            }

            if (pass.Length == 0)
            {
                MessageBox.Show("Password is required!");
                return;
            }

            Settings.Default.CAFEPRESS_PASS = pass;
            Settings.Default.CAFEPRESS_EMAIL = email;
            Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.DialogResult = DialogResult.Cancel;
        }
    }
}
