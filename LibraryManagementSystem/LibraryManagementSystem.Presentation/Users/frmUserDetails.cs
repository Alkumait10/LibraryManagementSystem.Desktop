using LibraryManagementSystem.BusinessLogic;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem.Presentation
{
    public partial class frmUserDetails : Form
    {
        private int _UserID;
        private clsUser _User;

        public frmUserDetails(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void frmUserDetails_Load(object sender, EventArgs e)
        {
            _User = clsUser.FindUserByID(_UserID);

            txtUserID.Text = _UserID.ToString();
            txtName.Text = _User.Name.ToString();
            txtContactInformation.Text = _User.ContactInformation.ToString();
            txtLibraryCardNumber.Text = _User.LibraryCardNumber.ToString();

            btnEdit.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int UserID = Convert.ToInt32(txtUserID.Text);

            frmAddEditUser frm = new frmAddEditUser(UserID);
            frm.ShowDialog();

            frmUserDetails_Load(null, null);

            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
