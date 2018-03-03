namespace PathFind
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.findPathRadio = new System.Windows.Forms.RadioButton();
            this.createWallRadio = new System.Windows.Forms.RadioButton();
            this.pointLocation = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.diagonalCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 413);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.diagonalCheckBox);
            this.groupBox1.Controls.Add(this.findPathRadio);
            this.groupBox1.Controls.Add(this.createWallRadio);
            this.groupBox1.Location = new System.Drawing.Point(668, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 135);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // findPathRadio
            // 
            this.findPathRadio.AutoSize = true;
            this.findPathRadio.Location = new System.Drawing.Point(6, 42);
            this.findPathRadio.Name = "findPathRadio";
            this.findPathRadio.Size = new System.Drawing.Size(70, 17);
            this.findPathRadio.TabIndex = 1;
            this.findPathRadio.TabStop = true;
            this.findPathRadio.Text = "Find Path";
            this.findPathRadio.UseVisualStyleBackColor = true;
            // 
            // createWallRadio
            // 
            this.createWallRadio.AutoSize = true;
            this.createWallRadio.Location = new System.Drawing.Point(6, 19);
            this.createWallRadio.Name = "createWallRadio";
            this.createWallRadio.Size = new System.Drawing.Size(85, 17);
            this.createWallRadio.TabIndex = 0;
            this.createWallRadio.TabStop = true;
            this.createWallRadio.Text = "Create Walls";
            this.createWallRadio.UseVisualStyleBackColor = true;
            // 
            // pointLocation
            // 
            this.pointLocation.AutoSize = true;
            this.pointLocation.Location = new System.Drawing.Point(668, 174);
            this.pointLocation.Name = "pointLocation";
            this.pointLocation.Size = new System.Drawing.Size(72, 13);
            this.pointLocation.TabIndex = 2;
            this.pointLocation.Text = "X: 100  Y:100";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // diagonalCheckBox
            // 
            this.diagonalCheckBox.AutoSize = true;
            this.diagonalCheckBox.Location = new System.Drawing.Point(12, 74);
            this.diagonalCheckBox.Name = "diagonalCheckBox";
            this.diagonalCheckBox.Size = new System.Drawing.Size(104, 17);
            this.diagonalCheckBox.TabIndex = 2;
            this.diagonalCheckBox.Text = "Enable Diagonal";
            this.diagonalCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(853, 431);
            this.Controls.Add(this.pointLocation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Path Find";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton findPathRadio;
        private System.Windows.Forms.RadioButton createWallRadio;
        private System.Windows.Forms.Label pointLocation;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox diagonalCheckBox;
    }
}

