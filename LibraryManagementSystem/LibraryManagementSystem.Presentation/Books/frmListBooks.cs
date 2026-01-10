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
    public partial class frmListBooks : Form
    {
        private static DataTable _AllBooks;
        public frmListBooks()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListBooks_Load(object sender, EventArgs e)
        {
            _AllBooks = clsBook.GetAllBooks();
            dgvBooks.DataSource = _AllBooks;

            _ConfigureBooksGrid();


            lblRecordsCount.Text = _AllBooks.Rows.Count.ToString();
        }

        private void _ConfigureBooksGrid()
        {
            // Header
            dgvBooks.EnableHeadersVisualStyles = false;
            dgvBooks.ColumnHeadersHeight = 36;
            dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvBooks.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBooks.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);
            dgvBooks.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Cells
            dgvBooks.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvBooks.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvBooks.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Behavior
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.MultiSelect = false;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Layout
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvBooks.ScrollBars = ScrollBars.Vertical;

            dgvBooks.RowHeadersVisible = false;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.FixedSingle;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            frmAddEditBook frm = new frmAddEditBook();
            frm.ShowDialog();


            frmListBooks_Load(null, null);
        }

        private void frmListBooks_Shown(object sender, EventArgs e)
        {
            dgvBooks.ClearSelection();
            dgvBooks.CurrentCell = null;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
                return;

            int BookID = (int)dgvBooks.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want to delete this book?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                if (clsBook.DeleteBook(BookID))
                {
                    MessageBox.Show("Book has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmListBooks_Load(null, null);
                }
                else
                    MessageBox.Show("Book is not deleted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookID = (int)dgvBooks.CurrentRow.Cells[0].Value;

            frmBookDetails frm = new frmBookDetails(BookID);
            frm.ShowDialog();

            frmListBooks_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookID = (int)dgvBooks.CurrentRow.Cells[0].Value;

            frmAddEditBook frm = new frmAddEditBook(BookID);
            frm.ShowDialog();

            frmListBooks_Load(null, null);
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
                case "BookID":
                    FilterColumn = "BookID";
                    break;
                case "Title":
                    FilterColumn = "Title";
                    break;
                case "ISBN":
                    FilterColumn = "ISBN";
                    break;
                case "Genre":
                    FilterColumn = "Genre";
                    break;
                case "AdditionalDetails":
                    FilterColumn = "AdditionalDetails";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllBooks.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _AllBooks.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "Title" && FilterColumn != "ISBN" && FilterColumn != "Genre" && FilterColumn != "AdditionalDetails")
                _AllBooks.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _AllBooks.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _AllBooks.Rows.Count.ToString();
        }

        private void addCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
                return;

            int BookID = (int)dgvBooks.CurrentRow.Cells["BookID"].Value;

            if (clsBookCopy.AddNewCopy(BookID))
            {
                MessageBox.Show("Book copy added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add book copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
