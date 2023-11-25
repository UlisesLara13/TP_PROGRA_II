namespace AutomotrizFront.Presentacion
{
    partial class FrmDesarrolladores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDesarrolladores));
            button1=new Button();
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label5=new Label();
            pictureBox1=new PictureBox();
            groupBox1=new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor=Color.Gainsboro;
            button1.Image=Properties.Resources.SALRR__1_;
            button1.Location=new Point(185, 265);
            button1.Name="button1";
            button1.Size=new Size(60, 23);
            button1.TabIndex=0;
            button1.UseVisualStyleBackColor=false;
            button1.Click+=button1_Click;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Font=new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location=new Point(21, 51);
            label1.Name="label1";
            label1.Size=new Size(149, 17);
            label1.TabIndex=0;
            label1.Text="● 404889 - Zunino Luca";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Font=new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location=new Point(21, 93);
            label2.Name="label2";
            label2.Size=new Size(138, 17);
            label2.TabIndex=1;
            label2.Text="● 406003 - Lara Ulises";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Font=new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location=new Point(21, 134);
            label3.Name="label3";
            label3.Size=new Size(159, 17);
            label3.TabIndex=2;
            label3.Text="● 405124 - Cifuentes Pilar";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Font=new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location=new Point(21, 178);
            label5.Name="label5";
            label5.Size=new Size(179, 17);
            label5.TabIndex=4;
            label5.Text="● 405132 - Mansilla Santiago";
            // 
            // pictureBox1
            // 
            pictureBox1.Image=Properties.Resources.c_;
            pictureBox1.Location=new Point(128, 0);
            pictureBox1.Name="pictureBox1";
            pictureBox1.Size=new Size(30, 26);
            pictureBox1.SizeMode=PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex=6;
            pictureBox1.TabStop=false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label3);
            groupBox1.Font=new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location=new Point(30, 19);
            groupBox1.Name="groupBox1";
            groupBox1.Size=new Size(215, 236);
            groupBox1.TabIndex=7;
            groupBox1.TabStop=false;
            groupBox1.Text="Desarrolladores";
            // 
            // FrmDesarrolladores
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            BackColor=Color.White;
            ClientSize=new Size(270, 309);
            Controls.Add(groupBox1);
            Controls.Add(button1);
            FormBorderStyle=FormBorderStyle.FixedSingle;
            Icon=(Icon)resources.GetObject("$this.Icon");
            MaximizeBox=false;
            Name="FrmDesarrolladores";
            StartPosition=FormStartPosition.CenterScreen;
            Text="Desarrolladores";
            Load+=FrmDesarrolladores_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private PictureBox pictureBox1;
        private GroupBox groupBox1;
    }
}