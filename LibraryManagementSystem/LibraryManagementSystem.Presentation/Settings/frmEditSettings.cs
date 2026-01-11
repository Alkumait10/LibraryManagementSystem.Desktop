using LibraryManagementSystem.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem.Presentation
{
    public partial class frmEditSettings : Form
    {
        private clsSettings _Settings;

        public enum enMode { Update = 1 };
        private enMode _Mode;

        public frmEditSettings()
        {
            InitializeComponent();

            _Mode = enMode.Update;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Settings.DefaultBorrowDays = Convert.ToInt32(txtDefaultBorrowDays.Text);
            _Settings.DefaultFinePerDay = Convert.ToInt32(txtDefaultFinePerDay.Text);

            if (_Settings.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmEditSettings_Load(object sender, EventArgs e)
        {
            _Settings = clsSettings.GetSetting();

            if (_Settings != null)
            {
                txtDefaultBorrowDays.Text = _Settings.DefaultBorrowDays.ToString();
                txtDefaultFinePerDay.Text = _Settings.DefaultFinePerDay.ToString();

                btnSave.Focus();
            }
        }
    }
}
