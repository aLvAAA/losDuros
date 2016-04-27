namespace PagoElectronico.ABM_Rol
{
    partial class Alta
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
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_guardar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_func = new System.Windows.Forms.ComboBox();
            this.button_eliminar = new System.Windows.Forms.Button();
            this.button_agregar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_funcionalidad = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_nombre_rol = new System.Windows.Forms.TextBox();
            this.errorProvider_Nombre = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider_listFunc = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Nombre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_listFunc)).BeginInit();
            this.SuspendLayout();
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(12, 288);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(75, 23);
            this.button_limpiar.TabIndex = 1;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(326, 288);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(75, 23);
            this.button_guardar.TabIndex = 2;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_func);
            this.groupBox1.Controls.Add(this.button_eliminar);
            this.groupBox1.Controls.Add(this.button_agregar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listBox_funcionalidad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_nombre_rol);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 270);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rol";
            // 
            // comboBox_func
            // 
            this.comboBox_func.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_func.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_func.FormattingEnabled = true;
            this.comboBox_func.Location = new System.Drawing.Point(115, 60);
            this.comboBox_func.Name = "comboBox_func";
            this.comboBox_func.Size = new System.Drawing.Size(167, 26);
            this.comboBox_func.TabIndex = 14;
            // 
            // button_eliminar
            // 
            this.button_eliminar.Enabled = false;
            this.button_eliminar.Location = new System.Drawing.Point(301, 106);
            this.button_eliminar.Name = "button_eliminar";
            this.button_eliminar.Size = new System.Drawing.Size(75, 23);
            this.button_eliminar.TabIndex = 13;
            this.button_eliminar.Text = "Eliminar";
            this.button_eliminar.UseVisualStyleBackColor = true;
            this.button_eliminar.Click += new System.EventHandler(this.button_eliminar_Click);
            // 
            // button_agregar
            // 
            this.button_agregar.Location = new System.Drawing.Point(301, 62);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(75, 23);
            this.button_agregar.TabIndex = 12;
            this.button_agregar.Text = "Agregar";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Funcionalidad:";
            // 
            // listBox_funcionalidad
            // 
            this.listBox_funcionalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_funcionalidad.FormattingEnabled = true;
            this.listBox_funcionalidad.ItemHeight = 18;
            this.listBox_funcionalidad.Location = new System.Drawing.Point(115, 106);
            this.listBox_funcionalidad.Name = "listBox_funcionalidad";
            this.listBox_funcionalidad.Size = new System.Drawing.Size(167, 148);
            this.listBox_funcionalidad.TabIndex = 10;
            this.listBox_funcionalidad.Click += new System.EventHandler(this.listBox_funcionalidad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nombre:";
            // 
            // textBox_nombre_rol
            // 
            this.textBox_nombre_rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_nombre_rol.Location = new System.Drawing.Point(115, 19);
            this.textBox_nombre_rol.Name = "textBox_nombre_rol";
            this.textBox_nombre_rol.Size = new System.Drawing.Size(167, 24);
            this.textBox_nombre_rol.TabIndex = 8;
            this.textBox_nombre_rol.TextChanged += new System.EventHandler(this.textBox_nombre_rol_TextChanged);
            // 
            // errorProvider_Nombre
            // 
            this.errorProvider_Nombre.ContainerControl = this;
            // 
            // errorProvider_listFunc
            // 
            this.errorProvider_listFunc.ContainerControl = this;
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 321);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.button_limpiar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Alta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alta de Rol";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_Nombre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider_listFunc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_func;
        private System.Windows.Forms.Button button_eliminar;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_funcionalidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nombre_rol;
        private System.Windows.Forms.ErrorProvider errorProvider_Nombre;
        private System.Windows.Forms.ErrorProvider errorProvider_listFunc;
    }
}