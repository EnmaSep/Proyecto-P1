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
    public partial class frmCliente : Form
    {

        Boolean ExisteData;

        public frmCliente()
        {
            InitializeComponent();
        }
   

        private void frmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) // si la tecla que presionaste es igual a 27 entonces, cierra la aplicacion
            {
                this.Close(); // cerramos el formulario
            }
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblIdentifica_Click(object sender, EventArgs e)
        {

        }

        private void lblSector_Click(object sender, EventArgs e)
        {

        }

        private void lblCiudad_Click(object sender, EventArgs e)
        {

        }


        private void txtIdentificacion_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtIdentificacion.Text.Trim() != string.Empty)
                {
                    txtNombre.Focus();
                }
            }
        }

        private void txtIdentificacion_Leave(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text.Trim() != string.Empty)
            {
                BuscarCliente(txtIdentificacion.Text);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)
                {
                    txtDireccion.Focus();
                }
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtDireccion.Text.Trim() != string.Empty)
                {
                    txtSector.Focus();
                }
            }
        }

        private void txtSector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtSector.Text.Trim() != string.Empty)
                {
                    txtCiudad.Focus();
                }
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCiudad.Text.Trim() != string.Empty)
                {
                    txtTelefono.Focus();
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtTelefono.Text.Trim() != string.Empty)
                {
                    txtMovil.Focus();
                }
            }
        }

        private void txtMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtMovil.Text.Trim() != string.Empty)
                {
                    txtCorreo.Focus();
                }
            }
        }

        private void txtCorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCorreo.Text.Trim() != string.Empty)
                {
                    txtEnvio.Focus();
                }
            }
        }

        private void txtEnvio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtEnvio.Text.Trim() != string.Empty)
                {
                    txtNombre.Focus();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtIdentificacion.Text.Trim() != string.Empty)
            {
                if (txtNombre.Text.Trim() != string.Empty)
                {
                    if (txtDireccion.Text.Trim() != string.Empty)
                    {
                        if (txtSector.Text.Trim() != string.Empty)
                        {
                            if (txtCiudad.Text.Trim() != string.Empty)
                            {
                                if (txtTelefono.Text.Trim() != string.Empty)
                                {
                                    if (txtMovil.Text.Trim() != string.Empty)
                                    {
                                        if (txtCorreo.Text.Trim() != string.Empty)
                                        {
                                            if (txtEnvio.Text.Trim() != string.Empty)
                                            {
                                                if (cboPaga.Text.Trim() != string.Empty)
                                                {
                                                    if (ExisteData == false)
                                                    {
                                                        InsertarData();
                                                        LimpiarFormulario();
                                                        txtIdentificacion.Focus();
                                                    }
                                                    else
                                                    {
                                                        ActualizarData();
                                                        LimpiarFormulario();
                                                        txtIdentificacion.Focus();
                                                    }

                                                }
                                                else
                                                {
                                                    MessageBox.Show("FALTAIMPUESTO", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("FALTAENVIO", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("FALTACORREO", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("FALTAMOVIL", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("FALTATELEFONO", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("FALTACIUDAD", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("FALTASECTOR", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("FALTADIRECCION", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("FALTANOMBRE", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("FALTAIDENTIFICACION", "ITLA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string _imagen = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(_imagen);
            }
        }

        private void BuscarCliente(string numCTE)
        {
            ExisteData = false;

            SqlConnection cnx = new SqlConnection(cnn.db);
            cnx.Open();

            string miQuery = " SELECT IDCLIENTE, NOMBRECLIENTE, IDENTIFICACION, " +
                             " TIPOCLIENTE, DIRECCION, SECTOR, CIUDAD, TELEFONO, " +
                             " MOVIL, CORREO, BALANCEPENDIENTE, IMPUESTOPAGA, ENVIOSDIRECCION," +
                             " ESTATUS " +
                            " FROM CLIENTES " +
                           " WHERE IDENTIFICACION = @A01 " +
                            " AND ESTATUS = 1 ";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(miQuery, cxn);
            cmd.Parameters.AddWithValue("@A01", numCTE);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                ExisteData = true;

                lblIdentificacion.Text = dr["IDCLIENTE"].ToString();
                txtNombre.Text = dr["NOMBRECLIENTE"].ToString();
                txtIdentificacion.Text = dr["IDENTIFICACION"].ToString();
                cboTipo.Text = dr["TIPOCLIENTE"].ToString();
                txtDireccion.Text = dr["DIRECCION"].ToString();
                txtSector.Text = dr["SECTOR"].ToString();
                txtCiudad.Text = dr["CIUDAD"].ToString();
                txtTelefono.Text = dr["TELEFONO"].ToString();
                txtMovil.Text = dr["MOVIL"].ToString();
                txtDireccion.Text = dr["ENVIOSDIRECCION"].ToString();
                txtCorreo.Text = dr["CORREO"].ToString();

                if (dr.Read())
                {
                    try
                    {
                        pictureBox1.Image = ConvertImage.ByteArrayToImage((byte[])dr["FOTO"]);
                    }
                    catch
                    {

                    }
                }

            }



        }

        private void BorrarData(string usrName)
        {
            string tQuery = "UPDATE CLIENTES " +
                "SET ESTATUS = 0 " +
                "WHERE IDENTIFICACION = @A2";
            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);
            cmd.Parameters.AddWithValue("@A2", usrName);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (ExisteData == true)
            {
                BorrarData(txtIdentificacion.Text);
                LimpiarFormulario();
                txtIdentificacion.Focus();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InsertarData()
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image);

            string tQuery = "INSERT INTO CLIENTES (NOMBRECLIENTE, IDENTIFICACION, TIPOCLIENTE, DIRECCION, SECTOR, CIUDAD, TELEFONO, " +
                "MOVIL, CORREO, ENVIOSDIRECCION, BALANCEPENDIENTE, IMPUESTOPAGA, ESTATUS, FOTO) " +
                "                   VALUES (@A01, @A02, @A03, @A04, @A05, @A06, @A07, @A08, @A09, @A10, @A11, @A12, @A13, @A14)";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);


            cmd.Parameters.AddWithValue("@A01", txtNombre.Text);
            cmd.Parameters.AddWithValue("@A02", txtIdentificacion.Text);
            cmd.Parameters.AddWithValue("@A03", cboTipo.Text);
            cmd.Parameters.AddWithValue("@A04", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@A05", txtSector.Text);
            cmd.Parameters.AddWithValue("@A06", txtCiudad.Text);
            cmd.Parameters.AddWithValue("@A07", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@A08", txtMovil.Text);
            cmd.Parameters.AddWithValue("@A09", txtCorreo.Text);
            cmd.Parameters.AddWithValue("@A10", txtEnvio.Text);
            cmd.Parameters.AddWithValue("@A11", lblBalance.Text);
            cmd.Parameters.AddWithValue("@A12", cboPaga.Text);

            cmd.Parameters.AddWithValue("@A13", "1");
            cmd.Parameters.AddWithValue("@A14", byteArrayImagen);


            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtIdentificacion.Clear();
            txtSector.Clear();
            txtCiudad.Clear();
            txtTelefono.Clear();
            txtMovil.Clear();
            txtDireccion.Clear();
            txtCorreo.Clear();
            txtCiudad.Clear();

            ExisteData = false;
            pictureBox1.Image = null;

        }

        private void ActualizarData()
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image);

            string tQuery = "UPDATE CLIENTES " +
                            "   SET NOMBRECLIENTE = @A01, " +
                            "       TIPOCLIENTE = @A03, " +
                            "       DIRECCION = @A04, " +
                            "       SECTOR = @A05, " +
                            "       CIUDAD = @A06, " +
                            "       TELEFONO = @A07, " +
                            "       MOVIL = @A08, " +
                            "       CORREO = @A09," +
                            "       ENVIOSDIRECCION = @A10, " +
                            "       BALANCEPENDIENTE = @A11, " +
                            "       IMPUESTOPAGA = @A12, " +
                            "       ESTATUS = @A13, " +
                            "       FOTO = , @A14, " +
                            " WHERE IDENTIFICACION = @A02";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);

            cmd.Parameters.AddWithValue("@A01", txtNombre.Text);
            cmd.Parameters.AddWithValue("@A03", cboTipo.Text);
            cmd.Parameters.AddWithValue("@A04", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@A05", txtSector.Text);
            cmd.Parameters.AddWithValue("@A06", txtCiudad.Text);
            cmd.Parameters.AddWithValue("@A07", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@A08", txtMovil.Text);
            cmd.Parameters.AddWithValue("@A09", txtCorreo.Text);
            cmd.Parameters.AddWithValue("@A10", txtEnvio.Text);
            cmd.Parameters.AddWithValue("@A11", lblBalance.Text);
            cmd.Parameters.AddWithValue("@A12", cboPaga.Text);
            cmd.Parameters.AddWithValue("@A13", "1");
            cmd.Parameters.AddWithValue("@A14", byteArrayImagen);

        }

        private void txtIdentificacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
                  
            this.KeyPreview = true;
            this.Text = "Maestro de Cliente";

            ExisteData = false;        
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
