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
    public partial class frmListBorrowingRecords : Form
    {
        private static DataTable _AllBorrowingRecords;
        private int _UserID = -1;

        public frmListBorrowingRecords()
        {
            InitializeComponent();
        }

        public frmListBorrowingRecords(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListBorrowingRecords_Load(object sender, EventArgs e)
        {
            if (_UserID == -1)
                _AllBorrowingRecords = clsBorrowingRecord.GetAllBorrowingRecords();
            else
            {
                _AllBorrowingRecords = clsBorrowingRecord.GetAllBorrowingRecords(_UserID);
                lblFilterBy.Visible = false;
                cbFilterBy.Visible = false;
                txtFilterValue.Visible = false;
            }

            dgvBorrowingRecords.DataSource = _AllBorrowingRecords;

            cbFilterBy.SelectedIndex = 0;

            _ConfigureBorrowingRecordsGrid();


            lblRecordsCount.Text = _AllBorrowingRecords.Rows.Count.ToString();
        }

        private void _ConfigureBorrowingRecordsGrid()
        {
            // Header
            dgvBorrowingRecords.EnableHeadersVisualStyles = false;
            dgvBorrowingRecords.ColumnHeadersHeight = 36;
            dgvBorrowingRecords.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvBorrowingRecords.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvBorrowingRecords.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBorrowingRecords.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);
            dgvBorrowingRecords.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Cells
            dgvBorrowingRecords.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvBorrowingRecords.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvBorrowingRecords.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Behavior
            dgvBorrowingRecords.AllowUserToAddRows = false;
            dgvBorrowingRecords.ReadOnly = true;
            dgvBorrowingRecords.MultiSelect = false;
            dgvBorrowingRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Layout
            dgvBorrowingRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBorrowingRecords.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvBorrowingRecords.ScrollBars = ScrollBars.Vertical;

            dgvBorrowingRecords.RowHeadersVisible = false;
            dgvBorrowingRecords.BackgroundColor = Color.White;
            dgvBorrowingRecords.BorderStyle = BorderStyle.FixedSingle;
        }

        private void frmListBorrowingRecords_Shown(object sender, EventArgs e)
        {
            dgvBorrowingRecords.ClearSelection();
            dgvBorrowingRecords.CurrentCell = null;
        }

        private void showCopyDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CopyID = (int)dgvBorrowingRecords.CurrentRow.Cells[3].Value;

            frmCopyDetails frm = new frmCopyDetails(CopyID);
            frm.ShowDialog();

            frmListBorrowingRecords_Load(null, null);
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int borrowingRecordID = (int)dgvBorrowingRecords.CurrentRow.Cells["RecordID"].Value;

            clsBorrowingRecord record = clsBorrowingRecord.Find(borrowingRecordID);

            if (record != null)
            {
                if (MessageBox.Show("Are you sure you want to return this book?", "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (record.ReturnBook())
                    {
                        MessageBox.Show("Book returned successfully.");

                        frmListBorrowingRecords_Load(null, null);
                    }
                }
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int rowIndex = dgvBorrowingRecords.CurrentCell.RowIndex;

            var row = dgvBorrowingRecords.Rows[rowIndex];

            var dateValue = row.Cells["ReturnDate"].Value;

            bool hasDate = (dateValue != null && dateValue != DBNull.Value);

            returnBookToolStripMenuItem.Enabled = !hasDate;
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
                case "RecordID":
                    FilterColumn = "RecordID";
                    break;
                case "UserID":
                    FilterColumn = "UserID";
                    break;
                case "Name":
                    FilterColumn = "Name";
                    break;
                case "CopyID":
                    FilterColumn = "CopyID";
                    break;
                case "BookID":
                    FilterColumn = "BookID";
                    break;
                case "Title":
                    FilterColumn = "Title";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllBorrowingRecords.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _AllBorrowingRecords.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "Name" && FilterColumn != "Title")
                _AllBorrowingRecords.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _AllBorrowingRecords.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _AllBorrowingRecords.Rows.Count.ToString();
        }
    }
}
