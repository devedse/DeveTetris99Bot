namespace DeveTetris99Bot
{
    partial class Tetris99BotForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSerialArduinoRefresh = new System.Windows.Forms.Button();
            this.comboBoxComConnections = new System.Windows.Forms.ComboBox();
            this.buttonSerialArduinoConnectDisconnect = new System.Windows.Forms.Button();
            this.buttonL = new System.Windows.Forms.Button();
            this.buttonU = new System.Windows.Forms.Button();
            this.buttonR = new System.Windows.Forms.Button();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2560, 1385);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2720, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 769);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3176, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 769);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSerialArduinoRefresh);
            this.groupBox1.Controls.Add(this.comboBoxComConnections);
            this.groupBox1.Controls.Add(this.buttonSerialArduinoConnectDisconnect);
            this.groupBox1.Location = new System.Drawing.Point(2720, 833);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 161);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Connection";
            // 
            // buttonSerialArduinoRefresh
            // 
            this.buttonSerialArduinoRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSerialArduinoRefresh.Location = new System.Drawing.Point(560, 39);
            this.buttonSerialArduinoRefresh.Name = "buttonSerialArduinoRefresh";
            this.buttonSerialArduinoRefresh.Size = new System.Drawing.Size(78, 100);
            this.buttonSerialArduinoRefresh.TabIndex = 2;
            this.buttonSerialArduinoRefresh.Text = "⟳";
            this.buttonSerialArduinoRefresh.UseVisualStyleBackColor = true;
            this.buttonSerialArduinoRefresh.Click += new System.EventHandler(this.buttonSerialArduinoRefresh_Click);
            // 
            // comboBoxComConnections
            // 
            this.comboBoxComConnections.FormattingEnabled = true;
            this.comboBoxComConnections.Location = new System.Drawing.Point(281, 72);
            this.comboBoxComConnections.Name = "comboBoxComConnections";
            this.comboBoxComConnections.Size = new System.Drawing.Size(247, 33);
            this.comboBoxComConnections.TabIndex = 1;
            // 
            // buttonSerialArduinoConnectDisconnect
            // 
            this.buttonSerialArduinoConnectDisconnect.Location = new System.Drawing.Point(57, 55);
            this.buttonSerialArduinoConnectDisconnect.Name = "buttonSerialArduinoConnectDisconnect";
            this.buttonSerialArduinoConnectDisconnect.Size = new System.Drawing.Size(176, 64);
            this.buttonSerialArduinoConnectDisconnect.TabIndex = 0;
            this.buttonSerialArduinoConnectDisconnect.Text = "Connect";
            this.buttonSerialArduinoConnectDisconnect.UseVisualStyleBackColor = true;
            this.buttonSerialArduinoConnectDisconnect.Click += new System.EventHandler(this.buttonSerialArduinoConnectDisconnect_Click);
            // 
            // buttonL
            // 
            this.buttonL.Location = new System.Drawing.Point(2700, 1200);
            this.buttonL.Name = "buttonL";
            this.buttonL.Size = new System.Drawing.Size(100, 100);
            this.buttonL.TabIndex = 4;
            this.buttonL.Text = "L";
            this.buttonL.UseVisualStyleBackColor = true;
            this.buttonL.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // buttonU
            // 
            this.buttonU.Location = new System.Drawing.Point(2800, 1100);
            this.buttonU.Name = "buttonU";
            this.buttonU.Size = new System.Drawing.Size(100, 100);
            this.buttonU.TabIndex = 5;
            this.buttonU.Text = "U";
            this.buttonU.UseVisualStyleBackColor = true;
            this.buttonU.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // buttonR
            // 
            this.buttonR.Location = new System.Drawing.Point(2900, 1200);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(100, 100);
            this.buttonR.TabIndex = 6;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(2800, 1300);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(100, 100);
            this.buttonD.TabIndex = 7;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(3100, 1300);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(100, 100);
            this.buttonA.TabIndex = 8;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // Tetris99BotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3844, 1687);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.buttonR);
            this.Controls.Add(this.buttonU);
            this.Controls.Add(this.buttonL);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Tetris99BotForm";
            this.Text = "Tetris 99 Bot Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxComConnections;
        private System.Windows.Forms.Button buttonSerialArduinoConnectDisconnect;
        private System.Windows.Forms.Button buttonSerialArduinoRefresh;
        private System.Windows.Forms.Button buttonL;
        private System.Windows.Forms.Button buttonU;
        private System.Windows.Forms.Button buttonR;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonA;
    }
}

