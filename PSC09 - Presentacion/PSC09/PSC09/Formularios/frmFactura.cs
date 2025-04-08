using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace PSC09

    
{


    public partial class frmFactura : Form
    {

        double zImpuesto;
        double zTotal;
        double zSubtotal;
        double lnImpuesto;
        double nmCant;
        double nmPrec;

        Boolean ExisteData;



        public frmFactura()
        {
            InitializeComponent();
            EstiloDataGridViewInv();
        }

        private void frmFactura_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // activa las teclas de funciones
            this.Text = "Facturacion";

            lblFactura.Text = Busco.BuscaUltimoNumero("1");

            lblFecha2.Text = DateTime.Now.ToString("ddMMyyyy");

            lblAlmacen.Text = "01";

            ExisteData = false;

        }


        private void frmFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close(); // Cerramos el formulario
            }
        }

        private void BorrarLinea()
        {
            int CuantasLineasTengo = Convert.ToInt32(dgv.RowCount);

            if (CuantasLineasTengo == 1)
            {
                dgv.Rows.RemoveAt(dgv.RowCount - 1); // se utiliza cuando te queda una sola linea
            }
            else
            {
                dgv.Rows.Remove(dgv.CurrentRow); // utilizada cuando tienes varias lineaas
            }
        }

        private void ActualizaUltimoSecuenciaFactura (string numSecuencia)
        {
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE SECUENCIAS " +
                                            "   SET CONTADOR ='" + numSecuencia + 
                                            "  FROM SECUENCIAS " +
                                            " WHERE ID = '1'", cxn);

            cmd.ExecuteNonQuery();
            cxn.Close();
        }
       

        private void InsertaLinea()
        {
            dgv.Rows.Add(); // Agregamos una linea a la grilla
            int xRows = dgv.Rows.Count - 1; // tenemos la linea correcta a escribir

            dgv[00, xRows].Value = txtArticulo.Text;
            dgv[01, xRows].Value = lblArticulo.Text;
            dgv[02, xRows].Value = txtCantidad.Text;
            dgv[03, xRows].Value = lblPrecio.Text;
            dgv[04, xRows].Value = lblImpuesto.Text;
            dgv[05, xRows].Value = lblTotalLn.Text;
        }

        private void LimpiarDetalle()
        {
            txtArticulo.Clear();
            lblArticulo.Text = "";
            txtCantidad.Clear();
            lblPrecio.Text = "";
            lblImpuestoLn.Text = "";
            lblTotalLn.Text = "";


        }

        private void LimpiarFormulario()
        {
            ExisteData = false;
            txtCliente.Clear();
            lblNombreCliente.Text = "";

            lblSubtotal.Text = "";
            lblImpuesto.Text = "";
            lblTotal.Text = "";

            LimpiarDetalle();

            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            lblFactura.Text = Busco.BuscaUltimoNumero("1");
            lblFecha2.Text = DateTime.Now.ToString("ddMMyyyy");
        }


        private void BuscarProducto(string producto)
        {
            string miQuery = " SELECT T1.DESCRIPCION, T1.PRECIO, T1.IMPUESTO, T1.STOCK, T2.STOCK AS EXISTENCIA " +
                             "   FROM PRODUCTOS T1 " +
                          "INNER JOIN ALMACENSTOCK T2 ON T1.IDPRODUCTO = T2.IDPRODUCCION" +
                               "WHERE T1.IDPRODCTO = @A1 " +
                               "  AND T1.ESTATUS = 1 " +
                               "  AND T2.IDALMACEN = '" + lblAlmacen.Text + "'";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);
            cmd.Parameters.AddWithValue("@A1", producto);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblArticulo.Text = dr["DESCRIPCION"].ToString();
                lblArticulo.Text = dr["PRECIO"].ToString();
                lblArticulo.Text = dr["IDALMACEN"].ToString();
                lblArticulo.Text = dr["IMPUESTO"].ToString();
            }           

        }

        private void TotalizarFactura()
        {
            zImpuesto = 0;
            zSubtotal = 0;
            zTotal = 0;

            lblSubtotal.Text = "";
            lblImpuesto.Text = "";
            lblTotal.Text = "";

            foreach(DataGridViewRow row in dgv.Rows) // recorre la grilla desde la linea 0 hasta la ultima 
            {
                double nImpuesto = Convert.ToDouble(row.Cells[4].Value.ToString() ?? "");
                double nSubtotal = Convert.ToDouble(row.Cells[5].Value.ToString() ?? "");
                double nTotal = nSubtotal + nImpuesto;

                zImpuesto = zImpuesto + nImpuesto;
                zSubtotal = zSubtotal + nSubtotal;
                zTotal = zTotal + nTotal;

                lblSubtotal.Text = zSubtotal.ToString();
                lblImpuesto.Text = zImpuesto.ToString();
                lblTotal.Text = zTotal.ToString();  

            }
        }

        private void EstiloDataGridViewInv()
        {
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersVisible = true;
            this.dgv.RowHeadersVisible = false;

            this.dgv.Columns.Add("Col00", "");
            this.dgv.Columns.Add("Col01", "");
            this.dgv.Columns.Add("Col02", "");
            this.dgv.Columns.Add("Col03", "");
            this.dgv.Columns.Add("Col04", "");
            this.dgv.Columns.Add("Col05", "");
            this.dgv.Columns.Add("Col06", ""); // Almacen

            DataGridViewColumn
            column = dgv.Columns[00]; column.Width = 100;
            column = dgv.Columns[01]; column.Width = 420;
            column = dgv.Columns[02]; column.Width = 100;
            column = dgv.Columns[03]; column.Width = 100;
            column = dgv.Columns[04]; column.Width = 100;
            column = dgv.Columns[05]; column.Width = 100;
            column = dgv.Columns[06]; column.Width = 0; // Almacen

            this.dgv.BorderStyle = BorderStyle.None;
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

        private void CalcularLineaDetalle()
        {
            nmCant = 0;
            nmPrec = 0;

            nmCant = Convert.ToDouble(txtCantidad.Text);
            nmCant = Convert.ToDouble(lblPrecio.Text);

            if (nmCant > 0)
            {
                if (nmPrec > 0)
                {
                    double total = nmPrec * nmCant;

                    lblImpuestoLn.Text = (total * lnImpuesto).ToString();
                    lblTotal.Text = total.ToString();
                }
            }
        }

        private void InsertarLinea()
        {
            dgv.Rows.Add();
            int xRows = dgv.Rows.Count - 1;

            dgv[00, xRows].Value = txtArticulo.Text;
            dgv[01, xRows].Value = lblArticulo.Text;
            dgv[02, xRows].Value = txtCantidad.Text;
            dgv[03, xRows].Value = lblPrecio.Text;
            dgv[04, xRows].Value = lblImpuestoLn.Text;
            dgv[05, xRows].Value = lblTotalLn.Text;

        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();

            this.Close();
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnVENCTE.PerformClick();
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {

        }

        private void txtArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                btnArticulo.PerformClick();
            }
        }

        private void txtArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtArticulo_Leave(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim() != string.Empty)
            {
                BuscarProducto(txtArticulo.Text);
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();

            txtArticulo.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            lblArticulo.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            txtCantidad.Text = dgv.CurrentRow.Cells[2].Value.ToString();
            lblPrecio.Text = dgv.CurrentRow.Cells[3].Value.ToString();
            lblImpuesto.Text = dgv.CurrentRow.Cells[4].Value.ToString();
            lblTotal.Text = dgv.CurrentRow.Cells[5].Value.ToString();

            BorrarLinea();
            TotalizarFactura();

            txtArticulo.Focus();
        }

        private void btnInsertarLn_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim() != string.Empty)
            {
                if (txtCantidad.Text.Trim() != string.Empty)
                {
                    InsertarLinea();
                    TotalizarFactura();
                    LimpiarDetalle();

                    txtArticulo.Focus();
                }
            }

        }


        private void btnBorrarLn_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text.Trim() != string.Empty)
            {
                if (ExisteData == true)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        string nmArt = row.Cells[0].Value.ToString() ?? "";
                        string nmCan = row.Cells[2].Value.ToString() ?? "";

                        AumentaInventario(nmArt, nmCan);
                    }

                    BorrarData(lblFactura.Text);
                }

            }

        }

        private void btnCONFACT_Click(object sender, EventArgs e)
        {
            frmVENFAT frm = new frmVENFAT();

            DialogResult res = frm.ShowDialog();

            if (frm.EData == true)
            {
                lblFactura.Text = frm.var1;
                BuscarFactura(lblFactura.Text);
            }

        }


        private void btnVENCTE_Click(object sender, EventArgs e)
        {
            frmVENCTE frm = new frmVENCTE();

            DialogResult res = frm.ShowDialog();

            if (frm.EData == true)
            {
                txtCliente.Text = frm.var1;
                lblNombreCliente.Text = frm.var2;
            }

        }

        private void btnLimpiarLn_Click(object sender, EventArgs e)
        {
            
            LimpiarDetalle();

            lblSubtotal.Text = "";
            lblImpuesto.Text = "";
            lblTotal.Text = "";

            this.dgv.Rows.Clear();
            this.dgv.Refresh();
            

        }

        private void AumentaInventario(string numProducto, string laCantidad)
        {

        }

        private void BorrarData(string numFactura)
        {
            if (ExisteData == true)
            {
                DialogResult dialogResult = MessageBox.Show("Desea Borrar?", "ITLA", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlConnection cns = new SqlConnection(cnn.db); cns.Open();
                    string ssQuery = "DELETE FROM HFACTURA WHERE FACTURA ='" + numFactura + "'";
                    SqlCommand cms = new SqlCommand(ssQuery, cns);
                    cms.ExecuteNonQuery();

                    SqlConnection cnx = new SqlConnection(cnn.db); ; cnx.Open();
                    string tsQuery = "DELETE FROM DFACTURA WHERE FACTURA ='" + numFactura + "'";
                    SqlCommand cmd = new SqlCommand(tsQuery, cnx);
                    cmd.ExecuteNonQuery();
                }


        }   }

        private void D(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.PerformClick();
        }

        private void BuscarFactura(string nmrFactura)
        {
            ExisteData = false;
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();  // abro la base de datos
            string tsQuery = "      SELECT A.FACTURA, " +
                             "             A.CLIENTE, " +
                             "             B.NOMBRE, " +
                             "             A.FECHA, " +
                             "             A.SUBTOTAL, " +
                             "             A.IMPUESTO, " +
                             "             A.MONTOFACTURADO " +
                             "      FROM HFACTURA A " +
                             "      INNER JOIN CLIENTES B ON A.CLIENTE = B.IDCLIENTE" +
                             "      WHERE A.FACTURA ='" + nmrFactura +
                             "'      AND A.ACTIVO ='1'";

            SqlCommand cmd = new SqlCommand(tsQuery, cnx);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read()) // pregunta si trajo data
            {
                ExisteData = true;

                lblFactura.Text = Convert.ToString(rdr["FACTURA"]);
                txtCliente.Text = Convert.ToString(rdr["CLIENTE"]);
                lblNombreCliente.Text = Convert.ToString(rdr["NOMBRE"]);
                lblFecha.Text = Convert.ToString(rdr["FECHA"]);
                lblSubtotal.Text = Convert.ToString(rdr["SUBTOTAL"]);
                lblImpuesto.Text = Convert.ToString(rdr["IMPUESTO"]);
                lblTotal.Text = Convert.ToString(rdr["MONTOFACTURADO"]);

                BuscarDetalle(nmrFactura); // METODO PARA LLENAR LA GRILLA
                TotalizarFactura();
            }

            cmd.Dispose();
            cnx.Close();
        }

        private void BuscarDetalle(string nmrFactura)
        {
          
            // Limpiar el dgv
            // --------------
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            string tsQuery = "      SELECT A.FACTURA, " +
                             "             A.SEC, " +
                             "             A.ARTICULO, " +
                             "             B.DESCRIPCION, " +
                             "             A.CANTIDAD, " +
                             "             A.PRECIODEVENTA, " +
                             "             A.IMPUESTO " +
                             "             A.MONTOPORLINEA" +
                             "      FROM DFACTURA A " +
                             "      INNER JOIN PRODUCTOS B ON A.ARTICULO = B.ITEM" +
                             "      WHERE A.FACTURA ='" + nmrFactura + "'";
                             

            SqlCommand cmd = new SqlCommand(tsQuery, cnx);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read()) // va a hacer un recorrido hasta el final del contenedor rdr
            {
                dgv.Rows.Add();
                int xRows = dgv.Rows.Count - 1;

                dgv[0, xRows].Value = Convert.ToString(rdr["ARTICULO"]);
                dgv[1, xRows].Value = Convert.ToString(rdr["DESCRIPCION"]);
                dgv[2, xRows].Value = Convert.ToString(rdr["CANTIDAD"]);
                dgv[3, xRows].Value = Convert.ToString(rdr["PRECIODEVENTA"]);
                dgv[4, xRows].Value = Convert.ToString(rdr["IMPUESTO"]);
                dgv[5, xRows].Value = Convert.ToString(rdr["MONTOPORLINEA"]);
              
            }

        }

        private void InsertarData()
        {
          if (dgv.Rows.Count > 0)
            {
                if (lblTotal.Text != string.Empty)
                {
                    string tQuery = "INSERT INTO HFACTURA (FACTURA, CLIENTE, FECHA, SUBTOTAL, IMPUESTO, MONTOFACTURADO, ACTIVO ) " +
                    "                   VALUES (@A1, @A2, @A3, @A4, @A5, @A6);";

                    SqlConnection cnt = new SqlConnection(cnn.db); cnt.Open();
                    SqlCommand cmd = new SqlCommand(tQuery, cnt);


                    cmd.Parameters.AddWithValue("@A1", lblFactura.Text);
                    cmd.Parameters.AddWithValue("@A2", txtCliente.Text);
                    cmd.Parameters.AddWithValue("@A3", lblFecha.Text);
                    cmd.Parameters.AddWithValue("@A4", lblSubtotal.Text);
                    cmd.Parameters.AddWithValue("@A5", lblImpuesto.Text);
                    cmd.Parameters.AddWithValue("@A6", lblTotal.Text);


                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    cnt.Close();

                    ActualizarBalanceDeCliente(txtCliente.Text);
                    InsertaDetalleFactura();

                }
            }          
        }

        private void InsertarMvto()
        {
            string tQuery = "INSERT INTO MVTOCTE (IDCLIENTE, FECHA, DOCUMENTO, APLICADO, ORIGEN, MONTO, BCEPENDIENTE, ACTIVO, CTACONTABIILIDAD, TIPDOC ) " +
                    "                   VALUES (@A0, @A2, @A3, @A4, @A5, @A6, @A7, @A8);";

            SqlConnection cnt = new SqlConnection(cnn.db); cnt.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cnt);


            cmd.Parameters.AddWithValue("@A1", txtCliente.Text);
            cmd.Parameters.AddWithValue("@A2", lblFecha.Text);
            cmd.Parameters.AddWithValue("@A3", lblFactura.Text);
            cmd.Parameters.AddWithValue("@A4", "FTW000000");
            cmd.Parameters.AddWithValue("@A5", lblTotal.Text);
            cmd.Parameters.AddWithValue("@A6", lblTotal.Text);
            cmd.Parameters.AddWithValue("@A7", "1");
            cmd.Parameters.AddWithValue("@A8", "FT");


            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cnt.Close();
        }

        private void InsertaDetalleFactura()
        {
           
            string stQueri = " INSERT INTO DFACTURA, " +
                             "           ( FACTURA, " +
                             "             ARTICULO, " +
                             "             CANTIDAD, " +
                             "             PRECIODEVENTA, " +
                             "             IMPUESTO, " +
                             "             MONTOPORLINEA, " +
                             "             CLIENTE, " +
                             "             FECHA, " +
                             "             ACTIVO  )" +
                             "      FROM HFACTURA " +
                             "    VALUES (@A0, @A1, @A2, @A3, @A4, @A5, @A6, @A7, A9)";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open(); 

            foreach (DataGridViewRow row in dgv.Rows)
            {
                string nmArt = row.Cells[0].Value.ToString() ?? "";
                string nmCan = row.Cells[2].Value.ToString() ?? "";
                string nmPre = row.Cells[3].Value.ToString() ?? "";
                string nmImp = row.Cells[4].Value.ToString() ?? "";
                string nmTot = row.Cells[5].Value.ToString() ?? "";
                string nmAlm = row.Cells[6].Value.ToString() ?? "";

                SqlCommand cmm = new SqlCommand(stQueri, cnx);
                cmm.Parameters.AddWithValue("@A0", lblFactura.Text);
                cmm.Parameters.AddWithValue("@A1", nmArt);
                cmm.Parameters.AddWithValue("@A2", nmCan);
                cmm.Parameters.AddWithValue("@A3", nmPre);
                cmm.Parameters.AddWithValue("@A4", nmImp);
                cmm.Parameters.AddWithValue("@A5", nmTot);
                cmm.Parameters.AddWithValue("@A6", txtCliente.Text);
                cmm.Parameters.AddWithValue("@A7", lblFecha.Text);
                cmm.Parameters.AddWithValue("@A9", "1");

                cmm.ExecuteNonQuery();
                cmm.Dispose();

                RebajaInventario(nmArt, nmCan, nmAlm);

            }
   
        }

        private void RebajaInventario(string numProducto, string laCantidad, string miAlmacen)
        {
            SqlConnection cns = new SqlConnection(cnn.db); cns.Open();
            string ssQuery = " UPDATE PRODUCTOS " +
                             " SET STOCK = STOCK - + " + laCantidad +
                             " FROM PRODUCTOS " +
                             " WHERE IDPRODUCTO = '" + numProducto + "'";

            SqlCommand cms = new SqlCommand(ssQuery, cns);
            cms.ExecuteNonQuery();

            SqlConnection xns = new SqlConnection(cnn.db); xns.Open();
            string sxQuery = " UPDATE ALMACENSTOCK " +
                             " SET STOCK = STOCK - + " + laCantidad +
                             " FROM ALMACENSTOCK " +
                             " WHERE IDPRODUCTO = '" + numProducto + "'" +
                             "'AND IDALMACEN = '" + miAlmacen + "'";
            
            SqlCommand cmx = new SqlCommand(sxQuery, xns);
            cms.ExecuteNonQuery();
        }
        
        private void AumentaInventario(string numProducto, string laCantidad, string miAlmacen)
        {
            SqlConnection cns = new SqlConnection(cnn.db); cns.Open();
            string ssQuery = " UPDATE PRODUCTOS " +
                             " SET STOCK = STOCK + " + laCantidad +
                             " FROM PRODUCTOS " +
                             " WHERE IDPRODUCTO = '" + numProducto + "'";
            SqlCommand cms = new SqlCommand(ssQuery, cns);
            cms.ExecuteNonQuery();


        }

        private void ActualizaBalanceCliente(string numCliente, string TotalFacturaCliente)

        {
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE CLIENTES " +
                                            "    SET BALANCEPENDIENTE = BALANCEPENDIENTE + " + TotalFacturaCliente +
                                            "' FROM CLIENTES " +
                                            " WHERE IDCLIENTE = '" + numCliente + "'", cxn);
            cmd.ExecuteNonQuery();
            cxn.Close();
        }

        private void ActualizarBalanceDeCliente(string nmrClientes)
        {
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE CLIENTES " +
                                            "    SET BALANCEPENDIENTE = BALANCEPENDIENTE + " + lblTotal.Text +
                                            "' FROM CLIENTES " +
                                            " WHERE IDCLIENTE = '" + nmrClientes + "'", cxn);
            cmd.ExecuteNonQuery();
            cxn.Close();
        }

        private void btnArticulo_Click(object sender, EventArgs e)
        {
            frmVENALM frm = new frmVENALM();
            frm.Show();

            if (frm.Edata == true);
            {
                txtArticulo.Text = frm.var2;
                lblAlmacen.Text = frm.var1;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text.Trim() != string.Empty)
            {
                BorrarData(lblFactura.Text);
                InsertarData();
                InsertarMvto();
                ActualizaUltimoSecuenciaFactura(lblFactura.Text);
                ActualizaBalanceCliente(txtCliente.Text, lblTotal.Text);

                LimpiarFormulario();
                txtCliente.Focus();
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtArticulo.Text.Trim() != string.Empty)
            {
                if (txtCantidad.Text.Trim() != string.Empty)
                {
                    CalcularLineaDetalle();
                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text.Trim() != string.Empty)
            {
                if (ExisteData == true)
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        string nmArt = row.Cells[0].Value.ToString() ?? "";
                        string nmCan = row.Cells[2].Value.ToString() ?? "";
                        AumentaInventario(nmArt, nmCan);
                        
                    }

                    BorrarData(lblFactura.Text);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
