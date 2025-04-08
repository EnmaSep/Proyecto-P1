using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web;
using System.Diagnostics.Contracts;

//Login

namespace PSC09
{


    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        string password;



        private void Login_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Text = "Login";
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() != string.Empty)
            {
                if (txtPassword.Text.Trim() != string.Empty)
                {
                    if (txtPassword.Text.Trim() == password)
                    {
                        frmMenu frn = new frmMenu();
                        frn.Show();

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña o usuario incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                        txtPassword.Text = "";
                    }
                }
            }  

        } 


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void txtUser_Leave(object sender, EventArgs e)
        {

            if (txtUser.Text.Trim() != string.Empty)
            {
                BuscarUsuario(txtUser.Text);
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtUser.Text.Trim() != string.Empty)
                {
                    txtPassword.Focus();
                }
            }
        }




        private void txtPassword_Leave(object sender, EventArgs e)
        {

            if (txtPassword.Text.Trim() != string.Empty)
            {
                btnEnter.PerformClick();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtPassword.Text.Trim() != string.Empty)
                {
                    btnEnter.Focus();
                }
            }

        }


        private void BuscarUsuario(string cualUsuario)
        {
            string miQuery = "SELECT CLAVE " +
                "  FROM USUARIO " +
                " WHERE NOMBRECORTO = '" + cualUsuario + "'";

            SqlConnection cnxn = new SqlConnection(cnn.db);
            cnxn.Open();

            SqlCommand cmnd = new SqlCommand(miQuery, cnxn);
            SqlDataReader rdc = cmnd.ExecuteReader();

            if (rdc.Read())
            {
                password = rdc["CLAVE"].ToString();
            }

        }

     
    }
}
