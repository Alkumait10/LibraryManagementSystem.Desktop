using LibraryManagementSystem.BusinessLogic;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.Presentation
{
    public partial class frmAddEditUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private int _UserID = -1;
        clsUser _user;

        public frmAddEditUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddEditUser(int UserID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _user = new clsUser();
            }
            else
            {
                lblTitle.Text = "Update User";
                this.Text = "Update User";
            }

            txtName.Text = "";
            txtContactInformation.Text = "";
            txtLibraryCardNumber.Text = "";
        }

        private void _LoadData()
        {
            _user = clsUser.FindUserByID(_UserID);


            if (_user == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.Close();

                return;
            }

            txtUserID.Text = _user.UserID.ToString();
            txtName.Text = _user.Name;
            txtContactInformation.Text = _user.ContactInformation;
            txtLibraryCardNumber.Text = _user.LibraryCardNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _user.Name = txtName.Text;
            _user.ContactInformation = txtContactInformation.Text;
            _user.LibraryCardNumber = txtLibraryCardNumber.Text;

            if (_user.Save())
            {
                txtUserID.Text = _user.UserID.ToString();
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void frmAddEditUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }
    }
}
