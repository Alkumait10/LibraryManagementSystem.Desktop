using LibraryManagementSystem.BusinessLogic;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace LibraryManagementSystem.Presentation
{
    public partial class frmListUsers : Form
    {
        private static DataTable _AllUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _AllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _AllUsers;

            cbFilterBy.SelectedIndex = 0;

            _ConfigureUsersGrid();


            lblRecordsCount.Text = _AllUsers.Rows.Count.ToString();

        }

        private void _ConfigureUsersGrid()
        {
            // Header
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.ColumnHeadersHeight = 36;
            dgvUsers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvUsers.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvUsers.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvUsers.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);
            dgvUsers.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Cells
            dgvUsers.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvUsers.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvUsers.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Behavior
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.ReadOnly = true;
            dgvUsers.MultiSelect = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Layout
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvUsers.ScrollBars = ScrollBars.Vertical;

            dgvUsers.RowHeadersVisible = false;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser();
            frm.ShowDialog();


            frmListUsers_Load(null, null);
        }

        private void frmListUsers_Shown(object sender, EventArgs e)
        {
            dgvUsers.ClearSelection();
            dgvUsers.CurrentCell = null;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
                return;

            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (clsUser.DeleteUser(UserID))
                {
                    MessageBox.Show("User has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmListUsers_Load(null, null);
                }
                else
                    MessageBox.Show("User is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmUserDetails frm = new frmUserDetails(UserID);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmAddEditUser frm = new frmAddEditUser(UserID);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (cbFilterBy.Text == "None")
                txtFilterValue.Enabled = false;
            else
                txtFilterValue.Enabled = true;

            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "UserID":
                    FilterColumn = "UserID";
                    break;
                case "Name":
                    FilterColumn = "Name";
                    break;
                case "ContactInformation":
                    FilterColumn = "ContactInformation";
                    break;
                case "LibraryCardNumber":
                    FilterColumn = "LibraryCardNumber";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "Name" && FilterColumn != "ContactInformation" && FilterColumn != "LibraryCardNumber")
                _AllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _AllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _AllUsers.Rows.Count.ToString();
        }

        private void borrowBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmListBookCopies frm = new frmListBookCopies(UserID);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void showFinesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmListFines frm = new frmListFines(UserID);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void showBorrowingRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmListBorrowingRecords frm = new frmListBorrowingRecords(UserID);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }

        private void showReservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

            frmListReservations frm = new frmListReservations(UserID);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }
    }
}
