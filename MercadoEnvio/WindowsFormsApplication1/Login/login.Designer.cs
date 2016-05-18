namespace WindowsFormsApplication1.Login
{
    partial class frm_login
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
            this.buttonIngresar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_usr = new System.Windows.Forms.TextBox();
            this.textBox_psw = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonIngresar
            // 
            this.buttonIngresar.Location = new System.Drawing.Point(93, 169);
            this.buttonIngresar.Name = "buttonIngresar";
            this.buttonIngresar.Size = new System.Drawing.Size(84, 49);
            this.buttonIngresar.TabIndex = 1;
            this.buttonIngresar.Text = " Entrar";
            this.buttonIngresar.UseVisualStyleBackColor = true;
            this.buttonIngresar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Usuario";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox_usr
            // 
            this.textBox_usr.Location = new System.Drawing.Point(109, 51);
            this.textBox_usr.Name = "textBox_usr";
            this.textBox_usr.Size = new System.Drawing.Size(150, 20);
            this.textBox_usr.TabIndex = 3;
            this.textBox_usr.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_psw
            // 
            this.textBox_psw.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBox_psw.Location = new System.Drawing.Point(109, 113);
            this.textBox_psw.Name = "textBox_psw";
            this.textBox_psw.Size = new System.Drawing.Size(150, 20);
            this.textBox_psw.TabIndex = 4;
            this.textBox_psw.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_psw);
            this.Controls.Add(this.textBox_usr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonIngresar);
            this.Name = "frm_login";
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonIngresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_usr;
        private System.Windows.Forms.TextBox textBox_psw;
        private System.Windows.Forms.Label label2;
    }
}