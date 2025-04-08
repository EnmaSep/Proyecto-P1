using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC09
{
    public partial class frmVENCTE : Form
    {
        public frmVENCTE()
        {
            InitializeComponent();
            EstiloDataGridView();
        }

        public Boolean EData;
        public string var1;
        public string var2;

        private void frmVENCTE_Load(object sender, EventArgs e)
        {
            this.Text = "Consulta";
            this.KeyPreview = true;
            EData = false;
        }


        private void BuscarDatos(string buscar)
        {
            // Limpia el DataGridView
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            EData = false;

            string miQuery =
                    "   SELECT IDCLIENTE, NOMBRECLIENTE " +
                    "     FROM CLIENTES " +
                    "    WHERE NOMBRECLIENTE LIKE '%" + buscar + "%' " +
                    " ORDER BY NOMBRECLIENTE ASC";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgv.Rows.Add();  // agregamos una linea al contador
                int xrows = dgv.Rows.Count - 1;  // le restamo uno al contador de linea

                dgv[0, xrows].Value = dr["IDCLIENTE"].ToString();
                dgv[1, xrows].Value = dr["NOMBRECLIENTE"].ToString();
            }

            cmd.Dispose();
            cxn.Close();
        }

        private void EstiloDataGridView()
        {
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersVisible = true;
            this.dgv.RowHeadersVisible = false;

            this.dgv.Columns.Add("Col00", "IDCLIENTE");
            this.dgv.Columns.Add("Col01", "NOMBRECLIENTE");


            DataGridViewColumn
            column = dgv.Columns[00]; column.Width = 140;
            column = dgv.Columns[01]; column.Width = 300;

            this.dgv.BorderStyle = BorderStyle.FixedSingle;
            this.dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.dgv.BackgroundColor = Color.LightGray;

            this.dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            this.dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            this.dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos(txtBuscar.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                var1 = dgv.CurrentRow.Cells[0].Value.ToString();
                var2 = dgv.CurrentRow.Cells[1].Value.ToString();
                EData = true;
                this.Close();
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccionar.PerformClick(); 
        }
    }
}
