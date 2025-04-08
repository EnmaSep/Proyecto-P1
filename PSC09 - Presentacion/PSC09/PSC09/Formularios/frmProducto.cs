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
using iTextSharp.text.pdf;

namespace PSC09


{

    public partial class frmProducto : Form
    {
        public frmProducto()
        {
            InitializeComponent();
            EstiloDataGridViewAlm();
            EstiloDataGridViewInv();
        }

        Boolean ExisteData;
        string var1;


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ConsultaInventarioArticulo(txtCodigoProducto.Text);
        }

        private void MostrarCodigoBarras()
        {
            long nHeight = long.Parse(txtAltura.Text);
            string sTexto = Convert.ToString(txtProducto.Text);

            picBarcode.SizeMode = PictureBoxSizeMode.CenterImage;
            picBarcode.BackColor = Color.White;
            picBarcode.Image = Code128(sTexto, PrintTextInCode: true, Height: nHeight);
        }

        public enum Code128SubTypes
        {
            CODE128 = iTextSharp.text.pdf.Barcode.CODE128,
            CODE128_RAW = iTextSharp.text.pdf.Barcode.CODE128_RAW,
            CODE128_UCC = iTextSharp.text.pdf.Barcode.CODE128_UCC,
        }

        public static Bitmap Code128(string _code, Code128SubTypes codeType = Code128SubTypes.CODE128, bool PrintTextInCode = false,
                             float Height = 0, bool GenerateChecksum = true, bool ChecksumText = true)
        {
            if (_code.Trim() == "")
            {
                return null;
            }
            else
            {
                Barcode128 barcode = new Barcode128();

                barcode.CodeType = (int)codeType;
                barcode.StartStopText = true;
                barcode.GenerateChecksum = GenerateChecksum;
                barcode.ChecksumText = ChecksumText;
                if (Height != 0) barcode.BarHeight = Height;
                barcode.Code = _code;
                try
                {
                    System.Drawing.Bitmap bm = new System.Drawing.Bitmap(barcode.CreateDrawingImage
                        (System.Drawing.Color.Black, System.Drawing.Color.White));
                    if (PrintTextInCode == false)
                    {
                        return bm;
                    }
                    else
                    {
                        Bitmap bmT;
                        bmT = new Bitmap(bm.Width, bm.Height + 14);
                        Graphics g = Graphics.FromImage(bmT);
                        g.FillRectangle(new SolidBrush(Color.White), 0, 0, bm.Width, bm.Height + 14);

                        Font drawFont = new Font("Arial", 8);
                        SolidBrush drawBrush = new SolidBrush(Color.Black);

                        SizeF stringSize = new SizeF();
                        stringSize = g.MeasureString(_code, drawFont);
                        float xCenter = (bm.Width - stringSize.Width) / 2;
                        float x = xCenter;
                        float y = bm.Height;

                        StringFormat drawFormat = new StringFormat();
                        drawFormat.FormatFlags = StringFormatFlags.NoWrap;

                        g.DrawImage(bm, 0, 0);
                        g.DrawString(_code, drawFont, drawBrush, x, y, drawFormat);

                        return bmT;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Codigo De Barra Code128. Desc:" + ex.Message);
                }
            }
        }

        private void frmProducto_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // activa las teclas de funciones
            this.Text = "Maestro de Productos";

            txtAltura.Text = "400";

            txtProducto.Text = Busco.BuscaUltimoNumero("4");

            MostrarCodigoBarras();

            ExisteData = false;
        }


            private void btnGuardar_Click(object sender, EventArgs e)
            {
            if (txtProducto.Text.Trim() != string.Empty)
            {
                if (txtNombreProducto.Text.Trim() != string.Empty)
                {
                    if (txtExistencia.Text.Trim() != string.Empty)
                    {
                        if (txtCosto.Text.Trim() != string.Empty)
                        {
                            if (txtPrecio.Text.Trim() != string.Empty)
                            {
                                if (txtImpuesto.Text.Trim() != string.Empty)
                                {
                                    if (txtBarCode.Text.Trim() != string.Empty)
                                    {
                                        if (ExisteData == false)
                                        {
                                            InsertarData();
                                            GuardarInventario(txtProducto.Text);    
                                            ActualizaSecuencia("4", txtProducto.Text); // actualiza la secuencia

                                            LimpiarFormulario();
                                            txtProducto.Text = Busco.BuscaUltimoNumero("4");
                                            txtProducto.Focus();
                                        }
                                        else
                                        {
                                            ActualizaData();
                                            GuardarInventario(txtProducto.Text);

                                            LimpiarFormulario();
                                            txtProducto.Text = Busco.BuscaUltimoNumero("4");
                                            txtProducto.Focus();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("FALTAIMPUESTO", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("FALTA CODIGO DE BARRA", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("FALTA LA EXISTENCIA", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("FALTA PRECIO", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("FALTA COSTO", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("FALTA NOMBRE", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("FALTACODIGO", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
             


        

        private void picBarcode_Click(object sender, EventArgs e)
        {
            if (txtCodigoProducto.Text.Trim() != string.Empty)
            {

            }
  
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            this.dgvAlm.Rows.Clear();
            this.dgvAlm.Refresh();

            txtProducto.Clear();
            txtNombreProducto.Clear();
            txtExistencia.Clear();
            txtCosto.Clear();
            txtPrecio.Clear();
            txtImpuesto.Clear();
            txtBarCode.Clear();
            txtAltura.Clear();
            txtCopia.Clear();
            txtCodigoProducto.Clear();

            picBarcode.Image = null;

        }

        private void BuscarProducto(string producto)
        {
            ExisteData = false;

            LimpiarFormulario();

            string miQuery = "SELECT IDPRODUCTO, DESCRIPCION, COSTO, " +
                            " PRECIO, IMPUESTO, STOCK, BARCODE " +
                            " FROM PRODUCTOS" +
                            " WHERE IDPRODUCTO = @A1 and ESTATUS = 1";
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);
            cmd.Parameters.AddWithValue("@A1", producto);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ExisteData = true;

                txtNombreProducto.Text = dr["DESCRIPCION"].ToString();
                txtCosto.Text = dr["COSTO"].ToString();
                txtPrecio.Text = dr["PRECIO"].ToString();
                txtImpuesto.Text = dr["IMPUESTO"].ToString();
                txtExistencia.Text = dr["STOCK"].ToString();
                txtBarCode.Text = dr["BARCODE"].ToString();

                try
                {
                    picProducto.Image = ConvertImage.ByteArrayToImage((byte[])dr["FOTO"]);
                }
                catch
                {

                }

                ConsultaInventario2(txtProducto.Text);
            }

        }

        private void ConsultaInventarioArticulo(string producto)
        {
            this.dgvInv.Rows.Clear();
            this.dgvInv.Refresh();

            string miQuery = "SELECT * FROM PRODUCTOS WHERE DESCRIPCION LIKE '%" + producto + "%' ORDER BY DESCRIPCION ASC";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvInv.Rows.Add();
                int xrows = dgvInv.Rows.Count - 1;

                dgvInv[0, xrows].Value = dr["IDPRODUCTO"].ToString();
                dgvInv[1, xrows].Value = dr["DESCRIPCION"].ToString();
                dgvInv[2, xrows].Value = dr["STOCK"].ToString();

            }

            cmd.Dispose();
            cxn.Close();
        }

        private void ConsultaInventario2(string producto)
        {
            {
                this.dgvAlm.Rows.Clear();
                this.dgvAlm.Refresh();

                string miQuery = "    SELECT T1.IDPRODUCTO, " +
                                 "           T1.STOCK, " +
                                 "           T1.REORDEN, " +
                                 "           T2.NOMBREALMACEN " +
                                 "      FROM ALMACENSTOCK T1 INNER JOIN ALMACENES T2 ON T1.IDALMACEN = T2.IDALMACEN " +
                                 "     WHERE T1.IDPRODUCTO ='" + producto +
                                 "' ORDER BY NOMBREALMACEN ASC";

                SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
                SqlCommand cmd = new SqlCommand(miQuery, cxn);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvAlm.Rows.Add();
                    int xrows = dgvAlm.Rows.Count - 1;

                    dgvAlm[0, xrows].Value = dr["IDALMACEN"].ToString();
                    dgvAlm[1, xrows].Value = dr["NOMBREALMACEN"].ToString();
                    dgvAlm[2, xrows].Value = dr["STOCK"].ToString();
                }

                cmd.Dispose();
                cxn.Close();
            }
        }

        private void BorrarProducto(string producto)
        {
            string tQuery = "UPDATE PRODUCTOS " +
                           " SET ESTATUS = 0 " +
                           " WHERE IDPRODUCTO = @A01";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);
            cmd.Parameters.AddWithValue("@A02", producto);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
           
        }

        private void InsertarData()
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(picProducto.Image);

            string tQuery = "INSERT INTO PRODUCTOS (IDPRODUCTO, DESCRIPCION, COSTO, PRECIO, IMPUESTO, STOCK, BARCODE, ESTATUS, FOTO) " +
                "                   VALUES (@A01, @A02, @A03, @A04, @A05, @A06, @A07, @A08, @A09)";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);


            cmd.Parameters.AddWithValue("@A01", txtProducto.Text);
            cmd.Parameters.AddWithValue("@A02", txtNombreProducto.Text);
            cmd.Parameters.AddWithValue("@A03", txtCosto.Text);
            cmd.Parameters.AddWithValue("@A04", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@A05", txtImpuesto.Text);
            cmd.Parameters.AddWithValue("@A06", txtExistencia.Text);
            cmd.Parameters.AddWithValue("@A07", txtBarCode.Text);
            cmd.Parameters.AddWithValue("@A08", "1");
            cmd.Parameters.AddWithValue("@A09", byteArrayImagen);


            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }

        private void ActualizarData()
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(picProducto.Image);

            string tQuery = "UPDATE CLIENTES " +
                           " SET DESCRIPCION = @A01, " +
                           " COSTO = @A02," +
                           " PRECIO = @A03," +
                           " IMPUESTO = @A04," +
                           " STOCK = @A05," +
                           " BARCODE = @A06," +
                           " FOTO = @A07," +
                           " CORREO = @A08," +
                           " FROM PRODUCTOS " +
                           " WHERE IDPRODUCTO = @A08";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);

            cmd.Parameters.AddWithValue("@A01", txtNombreProducto.Text);
            cmd.Parameters.AddWithValue("@A02", txtCosto.Text);
            cmd.Parameters.AddWithValue("@A03", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@A04", txtImpuesto.Text);
            cmd.Parameters.AddWithValue("@A05", txtExistencia.Text);
            cmd.Parameters.AddWithValue("@A06", txtBarCode.Text);
            cmd.Parameters.AddWithValue("@A07", byteArrayImagen);
            cmd.Parameters.AddWithValue("@A08", txtCodigoProducto.Text);

           

            
        }

        private void AgregarLinea()   
        {
            dgvAlm.Rows.Add();
            int xRows = dgvAlm.Rows.Count - 1;

            dgvAlm[00, xRows].Value = txtNombreSucursal.Text;
            dgvAlm[01, xRows].Value = lblNombreSucursal.Text;
            dgvAlm[02, xRows].Value = txtStock.Text;

            txtNombreSucursal.Clear();
            lblNombreSucursal.Text = "";
            txtStock.Clear();
            txtNombreSucursal.Focus();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtNombreSucursal.Text.Trim() != string.Empty)
            {
                if (txtStock.Text.Trim() != string.Empty)
                {
                    AgregarLinea();
                }
            }
        }

        private void GuardarInventario(string numProd)
        {
            string stQueri = "";
            string _IdStorage;
            string _Quantity;

            SqlConnection cxd = new SqlConnection(cnn.db); cxd.Open(); 
            SqlCommand dmm = new SqlCommand("DELETE FROM ALMACENSTOCK WHERE IDPRODUCTO ='" + txtProducto.Text + "'", cxd);
            dmm.ExecuteNonQuery();  
            cxd.Close();

            foreach (DataGridViewRow xrow in dgvAlm.Rows)
            {
                _IdStorage = "@A01";
                _Quantity = "@";

                if ((xrow.Cells[0].Value ?? "").ToString() != "") // ?? valida que la celda no este vacia
                {
                    _IdStorage = xrow.Cells[0].Value.ToString();
                }
                
                if ((xrow.Cells[2].Value ?? "").ToString() != "")
                {
                    _Quantity = xrow.Cells[2].Value.ToString();
                }

                stQueri = "INSERT INTO ALMACENSTOCK (IDPRODUCTO, IDALMACEN, STOCK, REORDEN) VALUES (@A00, @A01, @A02, @A03)";
                SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
                SqlCommand cmm = new SqlCommand(stQueri, cxn);

                cmm.Parameters.AddWithValue("@A00", txtProducto.Text);
                cmm.Parameters.AddWithValue("@A01", _IdStorage);
                cmm.Parameters.AddWithValue("@A02", _Quantity);
                cmm.Parameters.AddWithValue("@A03", "5");

            }
        }

        private void txtSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled =  true;
                if (txtStock.Text.Trim() != string.Empty)
                {
                    if (!(char.IsNumber(e.KeyChar)))
                    {
                        btnInsert.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Digite Solo numeros", "DLab",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                        e.Handled = true;
                        return;
                    }
                }
            }
        }

        private void txtSucursal_Leave(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSucursal.Text, out _))
            {
                MessageBox.Show("Por favor, ingrese solo numeros.", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSucursal.Text = ""; // Limpia el contenido no valido
            }
            else
            {
                int h = Convert.ToInt32(txtSucursal.Text);
                txtSucursal.Text = Convert.ToString(h.ToString("D03")); // formatea en tres posiciones el valor digitado

                txtSucursal.Text = Busco.BuscaNombreAlmacen(txtSucursal.Text); // busca el nombre de la sucursal
            }
        }

        private void EstiloDataGridViewInv()
        {
            this.dgvInv.EnableHeadersVisualStyles = false;
            this.dgvInv.AllowUserToAddRows = false;
            this.dgvInv.AllowUserToDeleteRows = false;
            this.dgvInv.ColumnHeadersVisible = true;
            this.dgvInv.RowHeadersVisible = false;

            this.dgvInv.Columns.Add("Col00", "Descripcion");
            this.dgvInv.Columns.Add("Col01", "Nombre");
            this.dgvInv.Columns.Add("Col02", "Cantidad");

            DataGridViewColumn
            column = dgvInv.Columns[00]; column.Width = 100;
            column = dgvInv.Columns[01]; column.Width = 300;
            column = dgvInv.Columns[02]; column.Width = 100;

            this.dgvInv.BorderStyle = BorderStyle.FixedSingle;
            this.dgvInv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.dgvInv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvInv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.dgvInv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.dgvInv.BackgroundColor = Color.LightGray;

            this.dgvInv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvInv.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            this.dgvInv.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            this.dgvInv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }


        private void EstiloDataGridViewAlm()
        {
            this.dgvAlm.EnableHeadersVisualStyles = false;
            this.dgvAlm.AllowUserToAddRows = false;
            this.dgvAlm.AllowUserToDeleteRows = false;
            this.dgvAlm.ColumnHeadersVisible = true;
            this.dgvAlm.RowHeadersVisible = false;

            this.dgvAlm.Columns.Add("Col00", "Almacen");
            this.dgvAlm.Columns.Add("Col01", "Nombre del Almacen");
            this.dgvAlm.Columns.Add("Col02", "Cantidades");

            DataGridViewColumn
            column = dgvAlm.Columns[00]; column.Width = 200;
            column = dgvAlm.Columns[01]; column.Width = 100;
            column = dgvAlm.Columns[02]; column.Width = 100;

            this.dgvAlm.BorderStyle = BorderStyle.FixedSingle;
            this.dgvAlm.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            this.dgvAlm.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAlm.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            this.dgvAlm.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            this.dgvAlm.BackgroundColor = Color.LightGray;

            this.dgvAlm.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.dgvAlm.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 6, 0, 6);
            this.dgvAlm.ColumnHeadersDefaultCellStyle.BackColor = Color.CornflowerBlue;
            this.dgvAlm.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void ActualizarSecuencia(string numId, string numsec)
        {
            string tQuery = "UPDATE SECUENCIAS" +
                           " SET SECUENCIA = @A01," +
                           " FROM SECUENCIAS " +
                           " WHERE ID = @A02";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);

            cmd.Parameters.AddWithValue("@A01", numsec);
            cmd.Parameters.AddWithValue("@A02", numId);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }

        private void dgvAlm_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigoProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvInv.RowCount > 0)
            {
                var1 = dgvInv.CurrentRow.Cells[0].Value.ToString();

                txtProducto.Text = var1;

                BuscarProducto(txtProducto.Text);
                tabControl1.SelectedTab = tabPage2;
                
            }
        }

        private void dgvInv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSeleccionar.PerformClick();
        }

        private void txtProducto_Leave(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() != string.Empty)
            {
                BuscarProducto(txtProducto.Text);
            }


        }

        private void txtNombreSucursal_TextChanged(object sender, EventArgs e)
        {

        }

        private void ActualizaData()
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(picProducto.Image);

            string tQuery = "UPTDATE CLIENTES " +
                " SET DESCRIPCION = @A01," +
                "      COSTO = @A02," +
                "      PRECIO = @A03," +
                "      IMPUESTO = @A04," +
                "      STOCK = @A05," +
                "      BARCODE = @A06," +
                "      FOTO = @A07," +
                "      CORREO = @A08," +
                " FROM PRODUCTOS    " +
                " WHERE IDPRODUCTO = @A08";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);

            cmd.Parameters.AddWithValue("@A01", txtNombreProducto.Text);
            cmd.Parameters.AddWithValue("@A02", txtCosto.Text);
            cmd.Parameters.AddWithValue("@A03", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@A04", txtImpuesto.Text);
            cmd.Parameters.AddWithValue("@A05", txtExistencia.Text);
            cmd.Parameters.AddWithValue("@A06", txtBarCode.Text);
            cmd.Parameters.AddWithValue("@A07", byteArrayImagen);
            cmd.Parameters.AddWithValue("@A08", txtProducto);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }

        private void ConsultaInventarioProducto(string producto)
        {
            this.dgvInv.Rows.Clear();
            this.dgvInv.Refresh();

            string miQuery = "SELECT * FROM PRODUCTOS WHERE DESCRIPCION LIKE '%" + producto + "%' ORDER BY DESCRIPCION ASC";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                dgvInv.Rows.Add();
                int xrows = dgvInv.Rows.Count - 1;

                dgvInv[0, xrows].Value = dr["IDPRODUCTO"].ToString();
                dgvInv[1, xrows].Value = dr["DESCRIPCION"].ToString();
                dgvInv[2, xrows].Value = dr["STOCK"].ToString();
            }

            cmd.Dispose();
            cxn.Close();
        }

        private void BorrarLinea()
        {
            int CuantasLineasTengo = Convert.ToInt32(dgvAlm.RowCount);

            if (CuantasLineasTengo == 1)
            {
                dgvAlm.Rows.RemoveAt(dgvAlm.RowCount - 1);

            }
            else
            {
                dgvAlm.Rows.Remove(dgvAlm.CurrentRow);
            }
        }


        private void ActualizaSecuencia(string numId, string numSec)
        {
            string tQuery = "UPDATE SECUENCIAS " +
                " SET CONTADOR = @A01 " +
                " FROM SECUENCIAS " +
                " WHERE ID = @A02 ";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);

            cmd.Parameters.AddWithValue("@A01", numSec);
            cmd.Parameters.AddWithValue("@A02", numId);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();

        }

        private void CalculosTotales()
        {
            double nInv;

            try
            {
                nInv = 0;

                txtExistencia.Text = "";

                foreach (DataGridViewRow row in dgvAlm.Rows)
                {
                    Double nCant = Convert.ToDouble(dgvAlm.CurrentRow.Cells[2].Value.ToString());
                    nInv = nInv + nCant;

                }
                txtExistencia.Text = nInv.ToString();

            }
            catch
            {
                //
            }
        }

        private void LimpiarDetalle()
        {
            this.dgvAlm.Rows.Clear();
            this.dgvAlm.Refresh();

            txtSucursal.Clear();
            lblNombreSucursal.Text = "";
            txtStock.Clear();

            txtSucursal.Focus();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtProducto.Text.Trim() != string.Empty)
                {
                    txtNombreProducto.Focus();
                }
            }

        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvAlm.RowCount > 0)
            {
                BorrarLinea();
                CalculosTotales();
                txtSucursal.Focus();    
            }   
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            frmVENALM frm = new frmVENALM();
            frm.Show();

        }

        private void btnLimpiarAlmacen_Click(object sender, EventArgs e)
        {
            LimpiarDetalle();

        }

        private void btnBorrarLn_Click(object sender, EventArgs e)
        {
            int CuantasLineasTengo = Convert.ToInt32(dgvAlm.RowCount);

            if (CuantasLineasTengo == 1)
            {
                dgvAlm.Rows.RemoveAt(dgvAlm.RowCount - 1);

            }
            else
            {
                dgvAlm.Rows.Remove(dgvAlm.CurrentRow);
            }

        }


    }
}
