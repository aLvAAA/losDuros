namespace AerolineaFrba
{
    partial class InicioCliente
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.compraPasajeencomiendaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaDeMillasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canjeDeMillasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compraPasajeencomiendaToolStripMenuItem,
            this.consultaDeMillasToolStripMenuItem,
            this.canjeDeMillasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(839, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(110, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(590, 41);
            this.label1.TabIndex = 5;
            this.label1.Text = "¡Bienvenido a nuestro aeropuerto!";
            // 
            // compraPasajeencomiendaToolStripMenuItem
            // 
            this.compraPasajeencomiendaToolStripMenuItem.Name = "compraPasajeencomiendaToolStripMenuItem";
            this.compraPasajeencomiendaToolStripMenuItem.Size = new System.Drawing.Size(169, 20);
            this.compraPasajeencomiendaToolStripMenuItem.Text = "Compra pasaje/encomienda";
            this.compraPasajeencomiendaToolStripMenuItem.Click += new System.EventHandler(this.compraPasajeencomiendaToolStripMenuItem_Click);
            // 
            // consultaDeMillasToolStripMenuItem
            // 
            this.consultaDeMillasToolStripMenuItem.Name = "consultaDeMillasToolStripMenuItem";
            this.consultaDeMillasToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.consultaDeMillasToolStripMenuItem.Text = "Consulta de Millas";
            this.consultaDeMillasToolStripMenuItem.Click += new System.EventHandler(this.consultaDeMillasToolStripMenuItem_Click);
            // 
            // canjeDeMillasToolStripMenuItem
            // 
            this.canjeDeMillasToolStripMenuItem.Name = "canjeDeMillasToolStripMenuItem";
            this.canjeDeMillasToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.canjeDeMillasToolStripMenuItem.Text = "Canje de Millas";
            this.canjeDeMillasToolStripMenuItem.Click += new System.EventHandler(this.canjeDeMillasToolStripMenuItem_Click);
            // 
            // InicioCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(839, 492);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "InicioCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aerolinea";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem compraPasajeencomiendaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaDeMillasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canjeDeMillasToolStripMenuItem;
        private System.Windows.Forms.Label label1;


    }
}
