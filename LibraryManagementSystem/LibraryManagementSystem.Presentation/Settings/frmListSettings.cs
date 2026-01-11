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
    public partial class frmListSettings : Form
    {
        private static DataTable _Setting;

        public frmListSettings()
        {
            InitializeComponent();
        }

        private void _ConfigureSettingsGrid()
        {
            // Header
            dgvSettings.EnableHeadersVisualStyles = false;
            dgvSettings.ColumnHeadersHeight = 36;
            dgvSettings.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgvSettings.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvSettings.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);
            dgvSettings.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);
            dgvSettings.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            // Cells
            dgvSettings.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvSettings.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvSettings.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Behavior
            dgvSettings.AllowUserToAddRows = false;
            dgvSettings.ReadOnly = true;
            dgvSettings.MultiSelect = false;
            dgvSettings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Layout
            dgvSettings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSettings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvSettings.ScrollBars = ScrollBars.Vertical;

            dgvSettings.RowHeadersVisible = false;
            dgvSettings.BackgroundColor = Color.White;
            dgvSettings.BorderStyle = BorderStyle.FixedSingle;
        }

        private void frmListSettings_Load(object sender, EventArgs e)
        {
            _Setting = clsSettings.GetSettings();
            dgvSettings.DataSource = _Setting;

            _ConfigureSettingsGrid();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditSettings frm = new frmEditSettings();
            frm.ShowDialog();

            frmListSettings_Load(null, null);
        }

        private void frmListSettings_Shown(object sender, EventArgs e)
        {
            dgvSettings.ClearSelection();
            dgvSettings.CurrentCell = null;
        }
    }
}
