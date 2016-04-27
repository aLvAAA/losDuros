namespace AerolineaFrba.Consulta_Millas
{
    partial class ConsultaMillas
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
            this.dniBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.encomiendasLink = new System.Windows.Forms.LinkLabel();
            this.viajesLink = new System.Windows.Forms.LinkLabel();
            this.canjesLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.millas = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dniBox
            // 
            this.dniBox.Location = new System.Drawing.Point(151, 26);
            this.dniBox.Name = "dniBox";
            this.dniBox.Size = new System.Drawing.Size(100, 20);
            this.dniBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI";
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(185, 87);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 4;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(42, 87);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(75, 23);
            this.limpiar.TabIndex = 5;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // encomiendasLink
            // 
            this.encomiendasLink.AutoSize = true;
            this.encomiendasLink.Location = new System.Drawing.Point(9, 136);
            this.encomiendasLink.Name = "encomiendasLink";
            this.encomiendasLink.Size = new System.Drawing.Size(99, 13);
            this.encomiendasLink.TabIndex = 6;
            this.encomiendasLink.TabStop = true;
            this.encomiendasLink.Text = "Ver Encomiendas...";
            this.encomiendasLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.encomiendasLink_LinkClicked);
            // 
            // viajesLink
            // 
            this.viajesLink.AutoSize = true;
            this.viajesLink.Location = new System.Drawing.Point(130, 136);
            this.viajesLink.Name = "viajesLink";
            this.viajesLink.Size = new System.Drawing.Size(63, 13);
            this.viajesLink.TabIndex = 7;
            this.viajesLink.TabStop = true;
            this.viajesLink.Text = "Ver Viajes...";
            this.viajesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.viajesLink_LinkClicked);
            // 
            // canjesLink
            // 
            this.canjesLink.AutoSize = true;
            this.canjesLink.Location = new System.Drawing.Point(220, 136);
            this.canjesLink.Name = "canjesLink";
            this.canjesLink.Size = new System.Drawing.Size(67, 13);
            this.canjesLink.TabIndex = 8;
            this.canjesLink.TabStop = true;
            this.canjesLink.Text = "Ver Canjes...";
            this.canjesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.canjesLink_LinkClicked);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 0;
            // 
            // millas
            // 
            this.millas.AutoSize = true;
            this.millas.Location = new System.Drawing.Point(148, 58);
            this.millas.Name = "millas";
            this.millas.Size = new System.Drawing.Size(26, 13);
            this.millas.TabIndex = 9;
            this.millas.Text = "DNI";
            this.millas.Visible = false;
            // 
            // ConsultaMillas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 168);
            this.Controls.Add(this.millas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.canjesLink);
            this.Controls.Add(this.viajesLink);
            this.Controls.Add(this.encomiendasLink);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dniBox);
            this.Name = "ConsultaMillas";
            this.Text = "Consulta Millas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dniBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.LinkLabel encomiendasLink;
        private System.Windows.Forms.LinkLabel viajesLink;
        private System.Windows.Forms.LinkLabel canjesLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label millas;
    }
}