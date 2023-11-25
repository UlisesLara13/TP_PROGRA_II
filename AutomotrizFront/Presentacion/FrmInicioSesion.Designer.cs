namespace AutomotrizFront.Presentacion
{
    partial class FrmInicioSesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicioSesion));
            Usuario=new Label();
            label2=new Label();
            txtUsuario=new TextBox();
            txtContraseña=new TextBox();
            btnLogin=new Button();
            btnSalir=new Button();
            pictureBox1=new PictureBox();
            cbMostrar=new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Usuario
            // 
            Usuario.AutoSize=true;
            Usuario.Font=new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            Usuario.Location=new Point(57, 114);
            Usuario.Name="Usuario";
            Usuario.Size=new Size(66, 20);
            Usuario.TabIndex=0;
            Usuario.Text="Usuario:";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Font=new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location=new Point(33, 158);
            label2.Name="label2";
            label2.Size=new Size(90, 20);
            label2.TabIndex=1;
            label2.Text="Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location=new Point(123, 113);
            txtUsuario.Name="txtUsuario";
            txtUsuario.Size=new Size(131, 23);
            txtUsuario.TabIndex=0;
            // 
            // txtContraseña
            // 
            txtContraseña.Location=new Point(123, 157);
            txtContraseña.Name="txtContraseña";
            txtContraseña.Size=new Size(131, 23);
            txtContraseña.TabIndex=1;
            // 
            // btnLogin
            // 
            btnLogin.Location=new Point(89, 209);
            btnLogin.Name="btnLogin";
            btnLogin.Size=new Size(75, 23);
            btnLogin.TabIndex=2;
            btnLogin.Text="Ingresar";
            btnLogin.UseVisualStyleBackColor=true;
            btnLogin.Click+=btnLogin_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location=new Point(186, 209);
            btnSalir.Name="btnSalir";
            btnSalir.Size=new Size(75, 23);
            btnSalir.TabIndex=3;
            btnSalir.Text="Salir";
            btnSalir.UseVisualStyleBackColor=true;
            btnSalir.Click+=btnSalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image=Properties.Resources.loginmanager_10029;
            pictureBox1.Location=new Point(141, 23);
            pictureBox1.Name="pictureBox1";
            pictureBox1.Size=new Size(88, 84);
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex=0;
            pictureBox1.TabStop=false;
            // 
            // cbMostrar
            // 
            cbMostrar.AutoSize=true;
            cbMostrar.Font=new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            cbMostrar.Location=new Point(260, 162);
            cbMostrar.Name="cbMostrar";
            cbMostrar.Size=new Size(66, 17);
            cbMostrar.TabIndex=6;
            cbMostrar.Text="Mostrar";
            cbMostrar.UseVisualStyleBackColor=true;
            // 
            // FrmInicioSesion
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(334, 261);
            Controls.Add(cbMostrar);
            Controls.Add(pictureBox1);
            Controls.Add(btnSalir);
            Controls.Add(btnLogin);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(Usuario);
            FormBorderStyle=FormBorderStyle.FixedSingle;
            Icon=(Icon)resources.GetObject("$this.Icon");
            MaximizeBox=false;
            Name="FrmInicioSesion";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Inicio de Sesión";
            Load+=FrmInicioSesion_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Usuario;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnLogin;
        private Button btnSalir;
        private PictureBox pictureBox1;
        private CheckBox cbMostrar;
    }
}