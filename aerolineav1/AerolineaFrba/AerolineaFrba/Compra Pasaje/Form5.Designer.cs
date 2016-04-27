namespace AerolineaFrba.Compra_Pasaje
{
    partial class Form5
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
            this.cancelar = new System.Windows.Forms.Button();
            this.siguiente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numeroText = new System.Windows.Forms.TextBox();
            this.codigoText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.vencimientoPicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tipoCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cuotasText = new System.Windows.Forms.TextBox();
            this.efectivoLabel = new System.Windows.Forms.Label();
            this.efectivoCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(12, 310);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.TabIndex = 5;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // siguiente
            // 
            this.siguiente.Location = new System.Drawing.Point(276, 310);
            this.siguiente.Name = "siguiente";
            this.siguiente.Size = new System.Drawing.Size(75, 23);
            this.siguiente.TabIndex = 10;
            this.siguiente.Text = "Siguiente";
            this.siguiente.UseVisualStyleBackColor = true;
            this.siguiente.Click += new System.EventHandler(this.siguiente_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Por favor, complete con los datos de la tarjeta de credito";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Numero";
            // 
            // numeroText
            // 
            this.numeroText.Location = new System.Drawing.Point(185, 47);
            this.numeroText.Name = "numeroText";
            this.numeroText.Size = new System.Drawing.Size(100, 20);
            this.numeroText.TabIndex = 12;
            // 
            // codigoText
            // 
            this.codigoText.Location = new System.Drawing.Point(185, 91);
            this.codigoText.Name = "codigoText";
            this.codigoText.Size = new System.Drawing.Size(100, 20);
            this.codigoText.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Codigo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Fecha de vencimiento";
            // 
            // vencimientoPicker
            // 
            this.vencimientoPicker.Location = new System.Drawing.Point(185, 134);
            this.vencimientoPicker.Name = "vencimientoPicker";
            this.vencimientoPicker.Size = new System.Drawing.Size(100, 20);
            this.vencimientoPicker.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tipo de tarjeta";
            // 
            // tipoCombo
            // 
            this.tipoCombo.FormattingEnabled = true;
            this.tipoCombo.Location = new System.Drawing.Point(185, 176);
            this.tipoCombo.Name = "tipoCombo";
            this.tipoCombo.Size = new System.Drawing.Size(100, 21);
            this.tipoCombo.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Cuotas";
            // 
            // cuotasText
            // 
            this.cuotasText.Location = new System.Drawing.Point(185, 218);
            this.cuotasText.Name = "cuotasText";
            this.cuotasText.Size = new System.Drawing.Size(100, 20);
            this.cuotasText.TabIndex = 20;
            // 
            // efectivoLabel
            // 
            this.efectivoLabel.AutoSize = true;
            this.efectivoLabel.Location = new System.Drawing.Point(60, 266);
            this.efectivoLabel.Name = "efectivoLabel";
            this.efectivoLabel.Size = new System.Drawing.Size(46, 13);
            this.efectivoLabel.TabIndex = 21;
            this.efectivoLabel.Text = "Efectivo";
            this.efectivoLabel.Visible = false;
            // 
            // efectivoCheck
            // 
            this.efectivoCheck.AutoSize = true;
            this.efectivoCheck.Location = new System.Drawing.Point(185, 266);
            this.efectivoCheck.Name = "efectivoCheck";
            this.efectivoCheck.Size = new System.Drawing.Size(15, 14);
            this.efectivoCheck.TabIndex = 22;
            this.efectivoCheck.UseVisualStyleBackColor = true;
            this.efectivoCheck.Visible = false;
            this.efectivoCheck.CheckedChanged += new System.EventHandler(this.efectivoCheck_CheckedChanged);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(363, 345);
            this.Controls.Add(this.efectivoCheck);
            this.Controls.Add(this.efectivoLabel);
            this.Controls.Add(this.cuotasText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tipoCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.vencimientoPicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codigoText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numeroText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.siguiente);
            this.Controls.Add(this.cancelar);
            this.Controls.Add(this.label1);
            this.Name = "Form5";
            this.Text = "Pago";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.Button siguiente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numeroText;
        private System.Windows.Forms.TextBox codigoText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker vencimientoPicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox tipoCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cuotasText;
        private System.Windows.Forms.Label efectivoLabel;
        private System.Windows.Forms.CheckBox efectivoCheck;
    }
}