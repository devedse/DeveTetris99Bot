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
            this.panelSimulator = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelLinesCleared = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1280, 720);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1360, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 400);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1588, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 400);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSerialArduinoRefresh);
            this.groupBox1.Controls.Add(this.comboBoxComConnections);
            this.groupBox1.Controls.Add(this.buttonSerialArduinoConnectDisconnect);
            this.groupBox1.Location = new System.Drawing.Point(1360, 433);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(322, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Connection";
            // 
            // buttonSerialArduinoRefresh
            // 
            this.buttonSerialArduinoRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSerialArduinoRefresh.Location = new System.Drawing.Point(280, 20);
            this.buttonSerialArduinoRefresh.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSerialArduinoRefresh.Name = "buttonSerialArduinoRefresh";
            this.buttonSerialArduinoRefresh.Size = new System.Drawing.Size(39, 52);
            this.buttonSerialArduinoRefresh.TabIndex = 2;
            this.buttonSerialArduinoRefresh.Text = "⟳";
            this.buttonSerialArduinoRefresh.UseVisualStyleBackColor = true;
            this.buttonSerialArduinoRefresh.Click += new System.EventHandler(this.buttonSerialArduinoRefresh_Click);
            // 
            // comboBoxComConnections
            // 
            this.comboBoxComConnections.FormattingEnabled = true;
            this.comboBoxComConnections.Location = new System.Drawing.Point(140, 37);
            this.comboBoxComConnections.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxComConnections.Name = "comboBoxComConnections";
            this.comboBoxComConnections.Size = new System.Drawing.Size(126, 21);
            this.comboBoxComConnections.TabIndex = 1;
            // 
            // buttonSerialArduinoConnectDisconnect
            // 
            this.buttonSerialArduinoConnectDisconnect.Location = new System.Drawing.Point(28, 29);
            this.buttonSerialArduinoConnectDisconnect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSerialArduinoConnectDisconnect.Name = "buttonSerialArduinoConnectDisconnect";
            this.buttonSerialArduinoConnectDisconnect.Size = new System.Drawing.Size(88, 33);
            this.buttonSerialArduinoConnectDisconnect.TabIndex = 0;
            this.buttonSerialArduinoConnectDisconnect.Text = "Connect";
            this.buttonSerialArduinoConnectDisconnect.UseVisualStyleBackColor = true;
            this.buttonSerialArduinoConnectDisconnect.Click += new System.EventHandler(this.buttonSerialArduinoConnectDisconnect_Click);
            // 
            // buttonL
            // 
            this.buttonL.Location = new System.Drawing.Point(1350, 624);
            this.buttonL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonL.Name = "buttonL";
            this.buttonL.Size = new System.Drawing.Size(50, 52);
            this.buttonL.TabIndex = 4;
            this.buttonL.Text = "L";
            this.buttonL.UseVisualStyleBackColor = true;
            this.buttonL.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // buttonU
            // 
            this.buttonU.Location = new System.Drawing.Point(1400, 572);
            this.buttonU.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonU.Name = "buttonU";
            this.buttonU.Size = new System.Drawing.Size(50, 52);
            this.buttonU.TabIndex = 5;
            this.buttonU.Text = "U";
            this.buttonU.UseVisualStyleBackColor = true;
            this.buttonU.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // buttonR
            // 
            this.buttonR.Location = new System.Drawing.Point(1450, 624);
            this.buttonR.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(50, 52);
            this.buttonR.TabIndex = 6;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(1400, 676);
            this.buttonD.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(50, 52);
            this.buttonD.TabIndex = 7;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(1550, 676);
            this.buttonA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(50, 52);
            this.buttonA.TabIndex = 8;
            this.buttonA.Text = "A";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.Click += new System.EventHandler(this.buttonArduinoAction_Click);
            // 
            // panelSimulator
            // 
            this.panelSimulator.Location = new System.Drawing.Point(1876, 12);
            this.panelSimulator.Name = "panelSimulator";
            this.panelSimulator.Size = new System.Drawing.Size(200, 400);
            this.panelSimulator.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1873, 453);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lines cleared:";
            // 
            // labelLinesCleared
            // 
            this.labelLinesCleared.AutoSize = true;
            this.labelLinesCleared.Location = new System.Drawing.Point(1953, 453);
            this.labelLinesCleared.Name = "labelLinesCleared";
            this.labelLinesCleared.Size = new System.Drawing.Size(13, 13);
            this.labelLinesCleared.TabIndex = 10;
            this.labelLinesCleared.Text = "0";
            // 
            // Tetris99BotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2239, 739);
            this.Controls.Add(this.labelLinesCleared);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelSimulator);
            this.Controls.Add(this.buttonA);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.buttonR);
            this.Controls.Add(this.buttonU);
            this.Controls.Add(this.buttonL);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Tetris99BotForm";
            this.Text = "Tetris 99 Bot Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panelSimulator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLinesCleared;
    }
}

