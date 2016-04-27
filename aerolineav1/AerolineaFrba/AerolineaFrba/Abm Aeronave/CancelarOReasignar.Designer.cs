namespace AerolineaFrba.Abm_Aeronave
{
    partial class CancelarReasignarAeronave
    {
        /// <summary>
        /// Required designer variable.
        /// 
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
            this.radioReemplazar = new System.Windows.Forms.RadioButton();
            this.radioEliminar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.aceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cancelar
            // 
            this.cancelar.Location = new System.Drawing.Point(12, 198);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(93, 39);
            this.cancelar.TabIndex = 1;
            this.cancelar.Text = "Cancelar";
            this.cancelar.UseVisualStyleBackColor = true;
            // 
            // radioReemplazar
            // 
            this.radioReemplazar.AutoSize = true;
            this.radioReemplazar.Location = new System.Drawing.Point(110, 143);
            this.radioReemplazar.Name = "radioReemplazar";
            this.radioReemplazar.Size = new System.Drawing.Size(129, 17);
            this.radioReemplazar.TabIndex = 3;
            this.radioReemplazar.TabStop = true;
            this.radioReemplazar.Text = "Reemplazar aeronave";
            this.radioReemplazar.UseVisualStyleBackColor = true;
            // 
            // radioEliminar
            // 
            this.radioEliminar.AutoSize = true;
            this.radioEliminar.Location = new System.Drawing.Point(110, 111);
            this.radioEliminar.Name = "radioEliminar";
            this.radioEliminar.Size = new System.Drawing.Size(92, 17);
            this.radioEliminar.TabIndex = 2;
            this.radioEliminar.TabStop = true;
            this.radioEliminar.Text = "Eliminar Viajes";
            this.radioEliminar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "La aeronave estaba asignada a viajes futuros";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "¿Que desea hacer con ellos?";
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(252, 198);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(93, 39);
            this.aceptar.TabIndex = 6;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // CancelarReasignarAeronave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 249);
            this.Controls.Add(this.aceptar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioReemplazar);
            this.Controls.Add(this.radioEliminar);
            this.Controls.Add(this.cancelar);
            this.Name = "CancelarReasignarAeronave";
            this.Text = "Cancelar o reasignar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelar;
        private System.Windows.Forms.RadioButton radioReemplazar;
        private System.Windows.Forms.RadioButton radioEliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button aceptar;

    }
}