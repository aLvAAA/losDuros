namespace PagoElectronico.ABM_Cliente
{
    partial class DesvinculacionTarjeta
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
            this.textBox_tarjeta = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_buscar = new System.Windows.Forms.Button();
            this.button_desvincular = new System.Windows.Forms.Button();
            this.errorProvider_tarjeta = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_tarjeta)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_tarjeta
            // 
            this.textBox_tarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_tarjeta.Location = new System.Drawing.Point(178, 22);
            this.textBox_tarjeta.Name = "textBox_tarjeta";
            this.textBox_tarjeta.ReadOnly = true;
            this.textBox_tarjeta.Size = new System.Drawing.Size(145, 24);
            this.textBox_tarjeta.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tarjeta de crédito:";
            // 
            // button_buscar
            // 
            this.button_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_buscar.Location = new System.Drawing.Point(351, 20);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(75, 29);
            this.button_buscar.TabIndex = 2;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // button_desvincular
            // 
            this.button_desvincular.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_desvincular.Location = new System.Drawing.Point(329, 66);
            this.button_desvincular.Name = "button_desvincular";
            this.button_desvincular.Size = new System.Drawing.Size(112, 29);
            this.button_desvincular.TabIndex = 3;
            this.button_desvincular.Text = "Desvincular";
            this.button_desvincular.UseVisualStyleBackColor = true;
            this.button_desvincular.Click += new System.EventHandler(this.button_desvincular_Click);
            // 
            // errorProvider_tarjeta
            // 
            this.errorProvider_tarjeta.ContainerControl = this;
            // 
            // DesvinculacionTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 111);
            this.Controls.Add(this.button_desvincular);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_tarjeta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DesvinculacionTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Desvinculacion de Tarjeta";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_tarjeta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_tarjeta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Button button_desvincular;
        private System.Windows.Forms.ErrorProvider errorProvider_tarjeta;
    }
}