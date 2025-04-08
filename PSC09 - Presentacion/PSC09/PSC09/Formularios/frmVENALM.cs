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
    public partial class frmVENALM : Form
    {
        public frmVENALM()
        {
            InitializeComponent();
            EstiloDataGridView();
        }

        public Boolean Edata;
        public string var1;
        public string var2;

        private void frmVENALM_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true; // activa las teclas de funciones
            this.Text = "Consulta";

            Edata = false;
        }

        private void frmVENALM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            BuscarDatos(txtBuscar.Text);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount > 0)
            {
                Edata = true;
                var1 = dgv.CurrentRow.Cells[0].Value.ToString();
                var1 = dgv.CurrentRow.Cells[1].Value.ToString();

                this.Close();
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            Edata = false;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtBuscar.Text.Trim() != string.Empty)
                {
                    btnBuscar.Focus();
                }
            }
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            BuscarDatos(txtBuscar.Text);

        }

        private void BuscarDatos(string buscar)
        {


            this.dgv.Rows.Clear();
            this.dgv.Refresh();
            Edata = false;

            string miQuery = "      SELECT T1.IDPRODUCTO, " +
                             "             T1.IDALMACEN, " +
                             "             T3.DESCRIPCION, " +
                             "             T1.STOCK, " +
                             "             T1.REORDEN, " +
                             "             T2.NOMBREALMACEN " +                             
                             "      FROM  ALMACENSTOCK T1 " +
                             "  INNER JOIN ALMACENES T2 ON T1.IDALMACEN = T2.IDALMACEN " +
                             "  INNER JOIN PRODUCTOS T3 ON T1.IDPRODUCTO = T3.IDPRODUCTO " +
                             "       WHERE T2.NOMBREALMACEN LIKE '%" + buscar + "%' ORDER BY NOMBREALMACEN ASC";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgv.Rows.Add(); // agregamos una linea al contador
                int xrows = dgv.Rows.Count - 1; // le restamos uno al contador de linea 

                dgv[0, xrows].Value = dr["IDAMLACEN"].ToString();
                dgv[1, xrows].Value = dr["NOMBREALMACEN"].ToString();
                dgv[2, xrows].Value = dr["IDPRODUCTO"].ToString();
                dgv[3, xrows].Value = dr["DESCRIPCION"].ToString();
                dgv[4, xrows].Value = dr["STOCK"].ToString(); // existencia por almacne
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

            this.dgv.Columns.Add("Col00", "ALMACEN");
            this.dgv.Columns.Add("Col01", "NOMBRE ALMACEN");
            this.dgv.Columns.Add("Col02", "ARTICULO");
            this.dgv.Columns.Add("Col03", "Nombre Articulo");
            this.dgv.Columns.Add("Col04", "STOCK");

            DataGridViewColumn
            column = dgv.Columns[00]; column.Width = 100;
            column = dgv.Columns[01]; column.Width = 200;
            column = dgv.Columns[02]; column.Width = 100;
            column = dgv.Columns[01]; column.Width = 200;
            column = dgv.Columns[02]; column.Width = 100;

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

        private void frmVENALM_Load_1(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            BuscarDatos(txtBuscar.Text);
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            if (dgv.Rows.Count > 0)
            {
                var1 = dgv.CurrentRow.Cells[0].Value.ToString();
                var2 = dgv.CurrentRow.Cells[2].Value.ToString();
                Edata = true;
                this.Close();
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
