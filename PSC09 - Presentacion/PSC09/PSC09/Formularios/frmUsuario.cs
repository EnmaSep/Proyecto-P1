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

namespace PSC09.Formularios
{

    
    public partial class frmUsuario : Form
    {
        public frmUsuario()
        {
            InitializeComponent();
        }

        bool ExisteData;

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            
            this.KeyPreview = true;
            this.Text = "Usuario";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void frmUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                frmconusr frm = new frmconusr { };
                frm.Show();
            }
        }



        ////////////////////
        // KEY PRESS (ENTER PARA IR A SIGUIENTE TXT)
        ////////////////////

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtUsuario.Text.Trim() != string.Empty)
                {
                    txtNombre.Focus();
                }
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtNombre.Text.Trim() != string.Empty)
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
                    txtPassword.Focus();
                }
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPassword.Text.Trim() != string.Empty)
                {
                    txtPuesto.Focus();
                }
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)
            {
                BuscarUsuario(txtUsuario.Text);
            }
            
        }

        

        

       

        private void txtPuesto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                frmconpos frm = new frmconpos { };
                frm.Show();
            }
        }

        private void txtPuesto_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPuesto_Leave(object sender, EventArgs e)
        {

        }

        private void txtFecha_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)
            {
                if (txtNombre.Text.Trim() != string.Empty)
                {
                    if (txtCorreo.Text.Trim() != string.Empty)
                    {
                        if (txtPassword.Text.Trim() != string.Empty)
                        {
                            if (txtPuesto.Text.Trim() != string.Empty)
                            {
                                InsertarData();
                                LimpiarFormulario();
                                this.Close();

                                frmLogin frm = new frmLogin();
                                frm.Show();
    
                            }
                            else
                            {
                                MessageBox.Show("Ingrese el puesto del usuario");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese la contraseña del usuario");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese el correo del usuario");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el nombre completo del usuario");
                }
            }
            else
            {
                MessageBox.Show("Ingrese el nombre corto del usuario");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConusr_Click(object sender, EventArgs e)
        {
            BuscarUsuario(txtUsuario.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void InsertarData()
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image);

            string tQuery = "INSERT INTO USUARIO (NOMBRECORTO, NOMBRECOMPLETO, CORREO, CLAVE, POSICION, FOTO, ACTIVO) " +
                "                   VALUES (@A01, @A02, @A03, @A04, @A05, @A06, @A07)";

            SqlConnection cxn = new SqlConnection(cnn.db); cxn.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cxn);

            cmd.Parameters.AddWithValue("@A01", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@A02", txtNombre.Text);
            cmd.Parameters.AddWithValue("@A03", txtCorreo.Text);
            cmd.Parameters.AddWithValue("@A04", txtPassword.Text);
            cmd.Parameters.AddWithValue("@A05", txtPuesto.Text);
            cmd.Parameters.AddWithValue("@A06", byteArrayImagen);
            cmd.Parameters.AddWithValue("@A07", 1);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cxn.Close();
        }

        private void BuscarUsuario(string nomUsuario)
        {
            ExisteData = false;

            SqlConnection cnx = new SqlConnection(cnn.db);
            cnx.Open();

            string stQuery = " SELECT NOMBRECORTO, NOMBRECOMPLETO, CORREO, CLAVE, POSICION, FOTO " +
                             "   FROM USUARIO " +
                             "  WHERE ACTIVO =  " + 1 + // aca decia 'True' en vez de 1 pero me daba error porque nada convierte el true en el int 1 por lo que daba error la base de datos.
                             "    AND NOMBRECORTO = @A1";

            SqlCommand CMD = new SqlCommand(stQuery, cnx);
            CMD.Parameters.AddWithValue("@A1", nomUsuario);
            SqlDataReader rcd = CMD.ExecuteReader();

            if (rcd.Read())
            {
                ExisteData = true;

                txtUsuario.Text = rcd["NOMBRECORTO"].ToString();
                txtNombre.Text = rcd["NOMBRECOMPLETO"].ToString();
                txtCorreo.Text = rcd["CORREO"].ToString();
                txtPassword.Text = rcd["CLAVE"].ToString();
                txtPuesto.Text = rcd["POSICION"].ToString();

                if (rcd.Read())
                {
                    try
                    {
                        pictureBox1.Image = ConvertImage.ByteArrayToImage((byte[])rcd["FOTO"]);
                    }
                    catch
                    {

                    }
                }
            }
        }

        private int CalcularEdad(string data)
        {
            // DDMMYYYY
            // 10062024   --> fecha
            // 01234567   --> posiciones

            int _day = Convert.ToInt32(data.Substring(0, 2));
            int _month = Convert.ToInt32(data.Substring(2, 2));
            int _year = Convert.ToInt32(data.Substring(4, 4));

            int edad = DateTime.Today.Year - _year;

            if (DateTime.Today.Month < _month)  // verifica que el mes actual es menor al de nacimiento
            {
                --edad;  // le resta 1 a la edad
            }
            else if (DateTime.Today.Month == _month && DateTime.Today.Day < _day) // verifica que el dia actual es menor al de nacimiento
            {
                --edad;  // le resta 1 a la edad
            }

            return edad; // devuelve la edad a lblEdad.Text
        }

        private void LimpiarFormulario()
        {
            txtUsuario.Clear();
            txtNombre.Clear();
            txtCorreo.Clear();
            txtPassword.Clear();
            txtPuesto.Clear();

            pictureBox1.Image = null;

          //  lblEdad.Text = "";
          //  lblPuesto.Text = "";
        }

        private void txtFecha_Leave(object sender, EventArgs e)
        {

        }

        private void txtFecha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    