namespace AerolineaFrba.Listado_Estadistico
{
    partial class MostrarListado
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
            this.listadoGrid = new System.Windows.Forms.DataGridView();
            this.volver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listadoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // listadoGrid
            // 
            this.listadoGrid.AllowUserToAddRows = false;
            this.listadoGrid.AllowUserToDeleteRows = false;
            this.listadoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listadoGrid.Location = new System.Drawing.Point(12, 12);
            this.listadoGrid.Name = "listadoGrid";
            this.listadoGrid.ReadOnly = true;
            this.listadoGrid.Size = new System.Drawing.Size(648, 195);
            this.listadoGrid.TabIndex = 0;
            // 
            // volver
            // 
            this.volver.Location = new System.Drawing.Point(13, 223);
            this.volver.Name = "volver";
            this.volver.Size = new System.Drawing.Size(75, 23);
            this.volver.TabIndex = 1;
            this.volver.Text = "Volver";
            this.volver.UseVisualStyleBackColor = true;
            this.volver.Click += new System.EventHandler(this.volver_Click);
            // 
            // MostrarListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 258);
            this.Controls.Add(this.volver);
            this.Controls.Add(this.listadoGrid);
            this.Name = "MostrarListado";
            this.Text = "Mostar Listado";
            this.Load += new System.EventHandler(this.MostrarListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listadoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listadoGrid;
        private System.Windows.Forms.Button volver;

    }
}