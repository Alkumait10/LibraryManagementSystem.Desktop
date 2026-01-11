using System;
using System.IO;
using System.Windows.Forms;

namespace LibraryManagementSystem.Presentation
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string filePath = "admin.txt";

            if (!File.Exists(filePath))
            {
                MessageBox.Show("admin.txt file not found!");

                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            string fileUsername = lines[0];
            string filePassword = lines[1];

            if (txtUsername.Text == fileUsername && txtPassword.Text == filePassword)
            {
                frmMain main = new frmMain();
                main.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong username or password!");
            }
        }
    }
}
