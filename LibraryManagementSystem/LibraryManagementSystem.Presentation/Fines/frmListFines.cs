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
    public partial class frmListFines : Form
    {
        private static DataTable _AllFines;
        private int _UserID = -1;


        public frmListFines()
        {
            InitializeComponent();
        }

        public frmListFines(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListFines_Load(object sender, EventArgs e)
        {
            if (_UserID == -1)
                _AllFines = clsFine.GetAllFines();
            else
            {
                _AllFines = clsFine.GetFinesByUserID(_UserID);
                cbFilterBy.Visible = false;
                txtFilterValue.Visible = false;
                lblFilterBy.Visible = false;
            }

            dgvFines.DataSource = _AllFines;

            cbFilterBy.SelectedIndex = 0;

            _ConfigureFinesGrid();


            lblRecordsCount.Text = _AllFines.Rows.Count.ToString();
        }

        private void _ConfigureFinesGrid()
        {
            // Header
            dgvFines.EnableHeadersVisualStyles = false;
            dgvFines.ColumnHeadersHeight = 36;
            dgvFines.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvFines.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvFines.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvFines.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);
            dgvFines.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Cells
            dgvFines.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvFines.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvFines.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Behavior
            dgvFines.AllowUserToAddRows = false;
            dgvFines.ReadOnly = true;
            dgvFines.MultiSelect = false;
            dgvFines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Layout
            dgvFines.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFines.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvFines.ScrollBars = ScrollBars.Vertical;

            dgvFines.RowHeadersVisible = false;
            dgvFines.BackgroundColor = Color.White;
            dgvFines.BorderStyle = BorderStyle.FixedSingle;
        }

        private void frmListFines_Shown(object sender, EventArgs e)
        {
            dgvFines.ClearSelection();
            dgvFines.CurrentCell = null;
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
                case "FineID":
                    FilterColumn = "FineID";
                    break;
                case "UserID":
                    FilterColumn = "UserID";
                    break;
                case "Name":
                    FilterColumn = "Name";
                    break;
                case "RecordID":
                    FilterColumn = "RecordID";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _AllFines.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _AllFines.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "Name")
                _AllFines.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _AllFines.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _AllFines.Rows.Count.ToString();
        }

        private void payFineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int FineID = (int)dgvFines.CurrentRow.Cells["FineID"].Value;

            clsFine fine = clsFine.Find(FineID);

            if (fine == null)
            {
                MessageBox.Show("Fine not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Are you sure you want to pay this fine?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (fine.PayFine())
                {
                    MessageBox.Show("Fine paid successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmListFines_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Payment failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int rowIndex = dgvFines.CurrentCell.RowIndex;

            bool isChecked = (bool)dgvFines.Rows[rowIndex].Cells["PaymentStatus"].Value;

            payFineToolStripMenuItem.Enabled = !isChecked;
        }
    }
}
