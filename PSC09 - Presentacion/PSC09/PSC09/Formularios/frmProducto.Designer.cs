namespace PSC09
{
    partial class frmProducto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducto));
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvInv = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnBorrarLn = new System.Windows.Forms.Button();
            this.btnLimpiarDgv = new System.Windows.Forms.Button();
            this.btnAlmacen = new System.Windows.Forms.Button();
            this.txtNombreSucursal = new System.Windows.Forms.TextBox();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblNombreSucursal = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.picProducto = new System.Windows.Forms.PictureBox();
            this.dgvAlm = new System.Windows.Forms.DataGridView();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lblExistencia = new System.Windows.Forms.Label();
            this.lblCodigoBarras = new System.Windows.Forms.Label();
            this.txtExistencia = new System.Windows.Forms.TextBox();
            this.lblImpuesto = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.lblCodigoProducto = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.txtCopia = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtCopias = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlm)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Font = new System.Drawing.Font("Arial", 20F);
            this.label5.Location = new System.Drawing.Point(-1, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(402, 76);
            this.label5.TabIndex = 63;
            this.label5.Text = "Maestro de Producto";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(5, 88);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1022, 568);
            this.tabControl1.TabIndex = 64;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.dgvInv);
            this.tabPage1.Controls.Add(this.btnSeleccionar);
            this.tabPage1.Controls.Add(this.txtCodigoProducto);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1014, 542);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consulta Inventario";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(516, 33);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(92, 51);
            this.btnBuscar.TabIndex = 65;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvInv
            // 
            this.dgvInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInv.Location = new System.Drawing.Point(6, 97);
            this.dgvInv.Name = "dgvInv";
            this.dgvInv.Size = new System.Drawing.Size(778, 317);
            this.dgvInv.TabIndex = 69;
            this.dgvInv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInv_CellDoubleClick);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(614, 33);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 51);
            this.btnSeleccionar.TabIndex = 68;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.Location = new System.Drawing.Point(6, 60);
            this.txtCodigoProducto.Multiline = true;
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(187, 24);
            this.txtCodigoProducto.TabIndex = 67;
            this.txtCodigoProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoProducto.TextChanged += new System.EventHandler(this.txtCodigoProducto_TextChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(199, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 24);
            this.label2.TabIndex = 66;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 24);
            this.label1.TabIndex = 65;
            this.label1.Text = "Codigo del Producto / Inventario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnBorrarLn);
            this.tabPage2.Controls.Add(this.btnLimpiarDgv);
            this.tabPage2.Controls.Add(this.btnAlmacen);
            this.tabPage2.Controls.Add(this.txtNombreSucursal);
            this.tabPage2.Controls.Add(this.txtSucursal);
            this.tabPage2.Controls.Add(this.txtStock);
            this.tabPage2.Controls.Add(this.lblNombreSucursal);
            this.tabPage2.Controls.Add(this.lblStock);
            this.tabPage2.Controls.Add(this.lblSucursal);
            this.tabPage2.Controls.Add(this.btnInsert);
            this.tabPage2.Controls.Add(this.picProducto);
            this.tabPage2.Controls.Add(this.dgvAlm);
            this.tabPage2.Controls.Add(this.txtProducto);
            this.tabPage2.Controls.Add(this.txtNombreProducto);
            this.tabPage2.Controls.Add(this.txtImpuesto);
            this.tabPage2.Controls.Add(this.txtCosto);
            this.tabPage2.Controls.Add(this.txtPrecio);
            this.tabPage2.Controls.Add(this.txtBarCode);
            this.tabPage2.Controls.Add(this.lblExistencia);
            this.tabPage2.Controls.Add(this.lblCodigoBarras);
            this.tabPage2.Controls.Add(this.txtExistencia);
            this.tabPage2.Controls.Add(this.lblImpuesto);
            this.tabPage2.Controls.Add(this.lblPrecio);
            this.tabPage2.Controls.Add(this.lblCosto);
            this.tabPage2.Controls.Add(this.lblCantidad);
            this.tabPage2.Controls.Add(this.lblNombreProducto);
            this.tabPage2.Controls.Add(this.lblCodigoProducto);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1014, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Registro";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnBorrarLn
            // 
            this.btnBorrarLn.Location = new System.Drawing.Point(778, 452);
            this.btnBorrarLn.Name = "btnBorrarLn";
            this.btnBorrarLn.Size = new System.Drawing.Size(75, 59);
            this.btnBorrarLn.TabIndex = 152;
            this.btnBorrarLn.Text = "Borrar";
            this.btnBorrarLn.UseVisualStyleBackColor = true;
            this.btnBorrarLn.Click += new System.EventHandler(this.btnBorrarLn_Click);
            // 
            // btnLimpiarDgv
            // 
            this.btnLimpiarDgv.Location = new System.Drawing.Point(778, 322);
            this.btnLimpiarDgv.Name = "btnLimpiarDgv";
            this.btnLimpiarDgv.Size = new System.Drawing.Size(75, 59);
            this.btnLimpiarDgv.TabIndex = 151;
            this.btnLimpiarDgv.Text = "Limpiar";
            this.btnLimpiarDgv.UseVisualStyleBackColor = true;
            this.btnLimpiarDgv.Click += new System.EventHandler(this.btnLimpiarAlmacen_Click);
            // 
            // btnAlmacen
            // 
            this.btnAlmacen.Location = new System.Drawing.Point(603, 287);
            this.btnAlmacen.Name = "btnAlmacen";
            this.btnAlmacen.Size = new System.Drawing.Size(16, 23);
            this.btnAlmacen.TabIndex = 150;
            this.btnAlmacen.Text = "button1";
            this.btnAlmacen.UseVisualStyleBackColor = true;
            this.btnAlmacen.Click += new System.EventHandler(this.btnAlmacen_Click);
            // 
            // txtNombreSucursal
            // 
            this.txtNombreSucursal.Location = new System.Drawing.Point(388, 290);
            this.txtNombreSucursal.Name = "txtNombreSucursal";
            this.txtNombreSucursal.Size = new System.Drawing.Size(208, 20);
            this.txtNombreSucursal.TabIndex = 149;
            this.txtNombreSucursal.TextChanged += new System.EventHandler(this.txtNombreSucursal_TextChanged);
            // 
            // txtSucursal
            // 
            this.txtSucursal.Location = new System.Drawing.Point(229, 290);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(153, 20);
            this.txtSucursal.TabIndex = 148;
            this.txtSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSucursal_KeyPress);
            this.txtSucursal.Leave += new System.EventHandler(this.txtSucursal_Leave);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(625, 290);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(159, 20);
            this.txtStock.TabIndex = 147;
            // 
            // lblNombreSucursal
            // 
            this.lblNombreSucursal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNombreSucursal.Location = new System.Drawing.Point(388, 267);
            this.lblNombreSucursal.Name = "lblNombreSucursal";
            this.lblNombreSucursal.Size = new System.Drawing.Size(208, 20);
            this.lblNombreSucursal.TabIndex = 145;
            this.lblNombreSucursal.Text = "Nombre Sucursal";
            // 
            // lblStock
            // 
            this.lblStock.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblStock.Location = new System.Drawing.Point(625, 267);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(159, 20);
            this.lblStock.TabIndex = 144;
            this.lblStock.Text = "Cantidad";
            // 
            // lblSucursal
            // 
            this.lblSucursal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSucursal.Location = new System.Drawing.Point(229, 267);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(153, 20);
            this.lblSucursal.TabIndex = 143;
            this.lblSucursal.Text = "ID Sucursal";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(778, 387);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 59);
            this.btnInsert.TabIndex = 140;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // picProducto
            // 
            this.picProducto.Image = ((System.Drawing.Image)(resources.GetObject("picProducto.Image")));
            this.picProducto.Location = new System.Drawing.Point(25, 50);
            this.picProducto.Name = "picProducto";
            this.picProducto.Size = new System.Drawing.Size(198, 199);
            this.picProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProducto.TabIndex = 113;
            this.picProducto.TabStop = false;
            // 
            // dgvAlm
            // 
            this.dgvAlm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlm.Location = new System.Drawing.Point(229, 316);
            this.dgvAlm.Name = "dgvAlm";
            this.dgvAlm.Size = new System.Drawing.Size(532, 202);
            this.dgvAlm.TabIndex = 138;
            this.dgvAlm.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlm_CellContentClick);
            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = System.Drawing.Color.White;
            this.txtProducto.Location = new System.Drawing.Point(411, 47);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(118, 20);
            this.txtProducto.TabIndex = 137;
            this.txtProducto.TextChanged += new System.EventHandler(this.txtProducto_TextChanged);
            this.txtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducto_KeyPress);
            this.txtProducto.Leave += new System.EventHandler(this.txtProducto_Leave);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(411, 76);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(357, 20);
            this.txtNombreProducto.TabIndex = 136;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(411, 179);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.Size = new System.Drawing.Size(118, 20);
            this.txtImpuesto.TabIndex = 134;
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(411, 128);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(118, 20);
            this.txtCosto.TabIndex = 132;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(411, 154);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(118, 20);
            this.txtPrecio.TabIndex = 131;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(411, 204);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(238, 20);
            this.txtBarCode.TabIndex = 128;
            // 
            // lblExistencia
            // 
            this.lblExistencia.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblExistencia.Location = new System.Drawing.Point(229, 229);
            this.lblExistencia.Name = "lblExistencia";
            this.lblExistencia.Size = new System.Drawing.Size(539, 20);
            this.lblExistencia.TabIndex = 125;
            this.lblExistencia.Text = "Existencia en Almacenes";
            // 
            // lblCodigoBarras
            // 
            this.lblCodigoBarras.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCodigoBarras.Location = new System.Drawing.Point(229, 204);
            this.lblCodigoBarras.Name = "lblCodigoBarras";
            this.lblCodigoBarras.Size = new System.Drawing.Size(163, 20);
            this.lblCodigoBarras.TabIndex = 124;
            this.lblCodigoBarras.Text = "Codigo de Barra del Producto";
            // 
            // txtExistencia
            // 
            this.txtExistencia.Location = new System.Drawing.Point(411, 102);
            this.txtExistencia.Name = "txtExistencia";
            this.txtExistencia.Size = new System.Drawing.Size(118, 20);
            this.txtExistencia.TabIndex = 123;
            // 
            // lblImpuesto
            // 
            this.lblImpuesto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblImpuesto.Location = new System.Drawing.Point(229, 179);
            this.lblImpuesto.Name = "lblImpuesto";
            this.lblImpuesto.Size = new System.Drawing.Size(163, 20);
            this.lblImpuesto.TabIndex = 122;
            this.lblImpuesto.Text = "Impuestos IVA";
            // 
            // lblPrecio
            // 
            this.lblPrecio.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblPrecio.Location = new System.Drawing.Point(229, 154);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(163, 20);
            this.lblPrecio.TabIndex = 121;
            this.lblPrecio.Text = "Precio de Venta";
            // 
            // lblCosto
            // 
            this.lblCosto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCosto.Location = new System.Drawing.Point(229, 128);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(163, 20);
            this.lblCosto.TabIndex = 120;
            this.lblCosto.Text = "Costo del Producto";
            // 
            // lblCantidad
            // 
            this.lblCantidad.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCantidad.Location = new System.Drawing.Point(229, 102);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(163, 20);
            this.lblCantidad.TabIndex = 119;
            this.lblCantidad.Text = "Cantidad en Existencia";
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblNombreProducto.Location = new System.Drawing.Point(229, 76);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(163, 20);
            this.lblNombreProducto.TabIndex = 118;
            this.lblNombreProducto.Text = "Nombre del Producto";
            // 
            // lblCodigoProducto
            // 
            this.lblCodigoProducto.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblCodigoProducto.Location = new System.Drawing.Point(229, 50);
            this.lblCodigoProducto.Name = "lblCodigoProducto";
            this.lblCodigoProducto.Size = new System.Drawing.Size(163, 20);
            this.lblCodigoProducto.TabIndex = 117;
            this.lblCodigoProducto.Text = "Codigo Interno del Producto";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.txtCopia);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.txtAltura);
            this.tabPage3.Controls.Add(this.txtCopias);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.picBarcode);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1014, 542);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "BarCode";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(200, 213);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 73);
            this.button3.TabIndex = 66;
            this.button3.Text = "Actualizar";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txtCopia
            // 
            this.txtCopia.Location = new System.Drawing.Point(266, 172);
            this.txtCopia.Multiline = true;
            this.txtCopia.Name = "txtCopia";
            this.txtCopia.Size = new System.Drawing.Size(52, 24);
            this.txtCopia.TabIndex = 122;
            this.txtCopia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(48, 213);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(129, 73);
            this.button4.TabIndex = 65;
            this.button4.Text = "Imprimir";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // txtAltura
            // 
            this.txtAltura.Location = new System.Drawing.Point(266, 138);
            this.txtAltura.Multiline = true;
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(52, 24);
            this.txtAltura.TabIndex = 121;
            this.txtAltura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCopias
            // 
            this.txtCopias.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtCopias.Location = new System.Drawing.Point(48, 172);
            this.txtCopias.Name = "txtCopias";
            this.txtCopias.Size = new System.Drawing.Size(212, 25);
            this.txtCopias.TabIndex = 120;
            this.txtCopias.Text = "Copias a Imprimir";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(48, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 25);
            this.label4.TabIndex = 119;
            this.label4.Text = "Codigo Interno del Producto";
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(48, 40);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(270, 83);
            this.picBarcode.TabIndex = 0;
            this.picBarcode.TabStop = false;
            this.picBarcode.Click += new System.EventHandler(this.picBarcode_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(701, 12);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 73);
            this.btnSalir.TabIndex = 62;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrar.Image")));
            this.btnBorrar.Location = new System.Drawing.Point(603, 12);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(92, 73);
            this.btnBorrar.TabIndex = 61;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.Location = new System.Drawing.Point(505, 12);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(92, 73);
            this.btnLimpiar.TabIndex = 60;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(407, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 73);
            this.btnGuardar.TabIndex = 59;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 697);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "frmProducto";
            this.Text = "frmProducto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInv)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlm)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dgvInv;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblExistencia;
        private System.Windows.Forms.Label lblCodigoBarras;
        private System.Windows.Forms.TextBox txtExistencia;
        private System.Windows.Forms.Label lblImpuesto;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label lblCodigoProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.PictureBox picProducto;
        private System.Windows.Forms.Label txtCopias;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtCopia;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lblNombreSucursal;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.DataGridView dgvAlm;
        private System.Windows.Forms.TextBox txtNombreSucursal;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Button btnAlmacen;
        private System.Windows.Forms.Button btnBorrarLn;
        private System.Windows.Forms.Button btnLimpiarDgv;
    }
}