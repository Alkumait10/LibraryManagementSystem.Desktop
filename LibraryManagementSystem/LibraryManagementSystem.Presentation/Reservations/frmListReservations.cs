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
    public partial class frmListReservations : Form
    {
        private static DataTable _AllReservations;
        private int _UserID = -1;

        public frmListReservations()
        {
            InitializeComponent();
        }

        public frmListReservations(int UserID)
        {
            InitializeComponent();

            _UserID = UserID;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListReservations_Load(object sender, EventArgs e)
        {
            if (_UserID == -1)
                _AllReservations = clsReservation.GetAllReservations();
            else
            {
                _AllReservations = clsReservation.GetReservationsByUserID(_UserID);
                lblFilterBy.Visible = false;
                txtFilterValue.Visible = false;
                cbFilterBy.Visible = false;
            }

            dgvReservations.DataSource = _AllReservations;

            cbFilterBy.SelectedIndex = 0;

            _ConfigureReservationsGrid();


            lblRecordsCount.Text = _AllReservations.Rows.Count.ToString();
        }

        private void _ConfigureReservationsGrid()
        {
            // Header
            dgvReservations.EnableHeadersVisualStyles = false;
            dgvReservations.ColumnHeadersHeight = 36;
            dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvReservations.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvReservations.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReservations.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);
            dgvReservations.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Cells
            dgvReservations.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvReservations.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvReservations.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Behavior
            dgvReservations.AllowUserToAddRows = false;
            dgvReservations.ReadOnly = true;
            dgvReservations.MultiSelect = false;
            dgvReservations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Layout
            dgvReservations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReservations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvReservations.ScrollBars = ScrollBars.Vertical;

            dgvReservations.RowHeadersVisible = false;
            dgvReservations.BackgroundColor = Color.White;
            dgvReservations.BorderStyle = BorderStyle.FixedSingle;
        }

        private void frmListReservations_Shown(object sender, EventArgs e)
        {
            dgvReservations.ClearSelection();
            dgvReservations.CurrentCell = null;
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
                case "ReservationID":
                    FilterColumn = "ReservationID";
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
                _AllReservations.DefaultView.RowFilter = "";
                lblRecordsCount.Text = _AllReservations.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "Name" && FilterColumn != "Title")
                _AllReservations.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                _AllReservations.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lblRecordsCount.Text = _AllReservations.Rows.Count.ToString();
        }
    }
}
