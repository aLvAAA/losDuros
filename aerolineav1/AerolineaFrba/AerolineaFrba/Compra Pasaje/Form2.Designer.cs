﻿namespace AerolineaFrba.Compra_Pasaje
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.previo = new System.Windows.Forms.Button();
            this.listado = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.pasajesBox = new System.Windows.Forms.TextBox();
            this.kilosBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.listado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Viajes";
            // 
            // previo
            // 
            this.previo.Location = new System.Drawing.Point(12, 347);
            this.previo.Name = "previo";
            this.previo.Size = new System.Drawing.Size(75, 23);
            this.previo.TabIndex = 5;
            this.previo.Text = "Previo";
            this.previo.UseVisualStyleBackColor = true;
            this.previo.Click += new System.EventHandler(this.previo_Click);
            // 
            // listado
            // 
            this.listado.AllowUserToAddRows = false;
            this.listado.AllowUserToDeleteRows = false;
            this.listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listado.Location = new System.Drawing.Point(12, 120);
            this.listado.Name = "listado";
            this.listado.ReadOnly = true;
            this.listado.Size = new System.Drawing.Size(643, 197);
            this.listado.TabIndex = 9;
            this.listado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listado_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cantidad de pasajes";
            // 
            // pasajesBox
            // 
            this.pasajesBox.Location = new System.Drawing.Point(143, 49);
            this.pasajesBox.Name = "pasajesBox";
            this.pasajesBox.Size = new System.Drawing.Size(35, 20);
            this.pasajesBox.TabIndex = 11;
            this.pasajesBox.TextChanged += new System.EventHandler(this.pasajesBox_TextChanged);
            // 
            // kilosBox
            // 
            this.kilosBox.Location = new System.Drawing.Point(436, 52);
            this.kilosBox.Name = "kilosBox";
            this.kilosBox.Size = new System.Drawing.Size(35, 20);
            this.kilosBox.TabIndex = 13;
            this.kilosBox.TextChanged += new System.EventHandler(this.encomiendaBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kilos de encomienda";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 382);
            this.Controls.Add(this.kilosBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pasajesBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listado);
            this.Controls.Add(this.previo);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Elegir viaje";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button previo;
        private System.Windows.Forms.DataGridView listado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pasajesBox;
        private System.Windows.Forms.TextBox kilosBox;
        private System.Windows.Forms.Label label3;
    }
}