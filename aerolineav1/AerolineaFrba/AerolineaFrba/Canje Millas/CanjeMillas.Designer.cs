namespace AerolineaFrba.Canje_Millas
{
    partial class CanjeMillas
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.dniBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.productosGrid = new System.Windows.Forms.DataGridView();
            this.productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gD2C2015DataSet = new AerolineaFrba.GD2C2015DataSet();
            this.productoTableAdapter = new AerolineaFrba.GD2C2015DataSetTableAdapters.ProductoTableAdapter();
            this.lblTotalMillas = new System.Windows.Forms.Label();
            this.buscarMillas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cantidadBox = new System.Windows.Forms.TextBox();
            this.limpiar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.productosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2015DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dni cliente:";
            // 
            // dniBox
            // 
            this.dniBox.Location = new System.Drawing.Point(115, 29);
            this.dniBox.Name = "dniBox";
            this.dniBox.Size = new System.Drawing.Size(89, 20);
            this.dniBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.productosGrid);
            this.groupBox1.Location = new System.Drawing.Point(12, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 200);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Productos";
            // 
            // productosGrid
            // 
            this.productosGrid.AllowUserToAddRows = false;
            this.productosGrid.AllowUserToDeleteRows = false;
            this.productosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productosGrid.Location = new System.Drawing.Point(8, 19);
            this.productosGrid.Name = "productosGrid";
            this.productosGrid.ReadOnly = true;
            this.productosGrid.Size = new System.Drawing.Size(499, 214);
            this.productosGrid.TabIndex = 0;
            this.productosGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productosGrid_CellContentClick);
            // 
            // productoBindingSource
            // 
            this.productoBindingSource.DataMember = "Producto";
            this.productoBindingSource.DataSource = this.gD2C2015DataSet;
            // 
            // gD2C2015DataSet
            // 
            this.gD2C2015DataSet.DataSetName = "GD2C2015DataSet";
            this.gD2C2015DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productoTableAdapter
            // 
            this.productoTableAdapter.ClearBeforeFill = true;
            // 
            // lblTotalMillas
            // 
            this.lblTotalMillas.AutoSize = true;
            this.lblTotalMillas.Location = new System.Drawing.Point(27, 92);
            this.lblTotalMillas.Name = "lblTotalMillas";
            this.lblTotalMillas.Size = new System.Drawing.Size(0, 13);
            this.lblTotalMillas.TabIndex = 3;
            // 
            // buscarMillas
            // 
            this.buscarMillas.Location = new System.Drawing.Point(254, 27);
            this.buscarMillas.Name = "buscarMillas";
            this.buscarMillas.Size = new System.Drawing.Size(95, 23);
            this.buscarMillas.TabIndex = 4;
            this.buscarMillas.Text = "Buscar Millas Disponibles";
            this.buscarMillas.UseVisualStyleBackColor = true;
            this.buscarMillas.Click += new System.EventHandler(this.buscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad:";
            // 
            // cantidadBox
            // 
            this.cantidadBox.Location = new System.Drawing.Point(115, 62);
            this.cantidadBox.Name = "cantidadBox";
            this.cantidadBox.Size = new System.Drawing.Size(89, 20);
            this.cantidadBox.TabIndex = 6;
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(254, 65);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(95, 23);
            this.limpiar.TabIndex = 8;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // CanjeMillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 353);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.cantidadBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buscarMillas);
            this.Controls.Add(this.lblTotalMillas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dniBox);
            this.Controls.Add(this.label1);
            this.Name = "CanjeMillas";
            this.Text = "Canje Millas";
            this.Load += new System.EventHandler(this.CanjeMillas_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.productosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gD2C2015DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dniBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private GD2C2015DataSet gD2C2015DataSet;
        private System.Windows.Forms.BindingSource productoBindingSource;
        private GD2C2015DataSetTableAdapters.ProductoTableAdapter productoTableAdapter;
        private System.Windows.Forms.Label lblTotalMillas;
        private System.Windows.Forms.DataGridView productosGrid;
        private System.Windows.Forms.Button buscarMillas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cantidadBox;
        private System.Windows.Forms.Button limpiar;
    }
}