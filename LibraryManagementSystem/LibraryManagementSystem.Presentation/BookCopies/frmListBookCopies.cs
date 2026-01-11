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
    public partial class frmListBookCopies : Form
    {
        private static DataTable _AllBookCopies;
        private int _UserID;

        public frmListBookCopies()
        {
            InitializeComponent();
        }

        public frmListBookCopies(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListBookCopies_Load(object sender, EventArgs e)
        {
            _AllBookCopies = clsBookCopy.GetAllBookCopies();
            dgvBookCopies.DataSource = _AllBookCopies;

            cbFilterBy.SelectedIndex = 0;

            _ConfigureBookCopiesGrid();


            lblRecordsCount.Text = _AllBookCopies.Rows.Count.ToString();
        }

        private void _ConfigureBookCopiesGrid()
        {
            // Header
            dgvBookCopies.EnableHeadersVisualStyles = false;
            dgvBookCopies.ColumnHeadersHeight = 36;
            dgvBookCopies.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvBookCopies.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvBookCopies.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBookCopies.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);
            dgvBookCopies.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Cells
            dgvBookCopies.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvBookCopies.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvBookCopies.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Behavior
            dgvBookCopies.AllowUserToAddRows = false;
            dgvBookCopies.ReadOnly = true;
            dgvBookCopies.MultiSelect = false;
            dgvBookCopies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Layout
            dgvBookCopies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookCopies.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvBookCopies.ScrollBars = ScrollBars.Vertical;

            dgvBookCopies.RowHeadersVisible = false;
            dgvBookCopies.BackgroundColor = Color.White;
            dgvBookCopies.BorderStyle = BorderStyle.FixedSingle;
        }

        private void frmListBookCopies_Shown(object sender, EventArgs e)
        {
            dgvBookCopies.ClearSelection();
            dgvBookCopies.CurrentCell = null;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBookCopies.CurrentRow == null)
                return;

            int CopyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete this copy?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (clsBookCopy.DeleteBookCopy(CopyID))
                {
                    MessageBox.Show("Copy has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmListBookCopies_Load(null, null);
                }
                else
                    MessageBox.Show("Copy is not deleted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CopyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value;

            frmCopyDetails frm = new frmCopyDetails(CopyID);
            frm.ShowDialog();

            frmListBookCopies_Load(null, null);
        }

        private void editStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CopyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value;

            frmEditBookCopy frm = new frmEditBookCopy(CopyID);
            frm.ShowDialog();

            frmListBookCopies_Load(null, null);
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
                case "CopyID":
                    FilterColumn = "CopyID";
                    break;
                case "BookID":
                    FilterColumn = "BookID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllBookCopies.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _AllBookCopies.Rows.Count.ToString();
                return;
            }

            _AllBookCopies.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _AllBookCopies.Rows.Count.ToString();
        }

        private void btnAddCopy_Click(object sender, EventArgs e)
        {
            frmListBooks frm = new frmListBooks();
            frm.ShowDialog();

            frmListBookCopies_Load(null, null);
        }

        private void borrowThisBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CopyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to borrow this copy?", "Confirm Borrowing", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {

                if (clsBorrowingRecord.BorrowBook(_UserID, CopyID))
                {
                    MessageBox.Show("Copy has been borrowed successfully", "Borrowed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmListBookCopies_Load(null, null);
                }
                else
                    MessageBox.Show("Copy is not borrowed.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int rowIndex = dgvBookCopies.CurrentCell.RowIndex;

            bool isChecked = (bool)dgvBookCopies.Rows[rowIndex].Cells["AvailabilityStatus"].Value;

            borrowThisBookToolStripMenuItem.Enabled = isChecked;

            reserveThisCopyToolStripMenuItem.Enabled = !isChecked;
        }

        private void reserveThisCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CopyID = (int)dgvBookCopies.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("This copy is currently unavailable.\nDo you want to reserve it?", "Confirm Reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) 
            {
                return;
            }

            bool reserved = clsReservation.AddNewReservation(_UserID, CopyID);

            if (reserved)
            {
                MessageBox.Show("Copy reserved successfully.\nYou will be notified when it becomes available.", "Reservation Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmListBookCopies_Load(null, null);
            }
            else
            {
                MessageBox.Show("This copy is already reserved by another user.", "Reservation Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
