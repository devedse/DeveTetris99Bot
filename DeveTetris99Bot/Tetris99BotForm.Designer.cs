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
            this.buttonB = new System.Windows.Forms.Button();
            this.buttonDH = new System.Windows.Forms.Button();
            this.buttonRH = new System.Windows.Forms.Button();
            this.buttonUH = new System.Windows.Forms.Button();
            this.buttonLH = new System.Windows.Forms.Button();
            this.textboxDebug = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panelSimulatorBlocks = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDanger = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonUR = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.labelDanger = new System.Windows.Forms.Label();
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
            this.panel1.Location = new System.Drawing.Point(1300, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 400);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(1506, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(80, 400);
            this.panel2.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSerialArduinoRefresh);
            this.groupBox1.Controls.Add(this.comboBoxComConnections);
            this.groupBox1.Controls.Add(this.buttonSerialArduinoConnectDisconnect);
            this.groupBox1.Location = new System.Drawing.Point(1360, 433);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(322, 84);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Connection";
            // 
            // buttonSerialArduinoRefresh
            // 
            this.buttonSerialArduinoRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSerialArduinoRefresh.Location = new System.Drawing.Point(280, 20);
            this.buttonSerialArduinoRefresh.Margin = new System.Windows.Forms.Padding(2);
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
            this.comboBoxComConnections.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxComConnections.Name = "comboBoxComConnections";
            this.comboBoxComConnections.Size = new System.Drawing.Size(126, 21);
            this.comboBoxComConnections.TabIndex = 1;
            // 
            // buttonSerialArduinoConnectDisconnect
            // 
            this.buttonSerialArduinoConnectDisconnect.Location = new System.Drawing.Point(28, 29);
            this.buttonSerialArduinoConnectDisconnect.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSerialArduinoConnectDisconnect.Name = "buttonSerialArduinoConnectDisconnect";
            this.buttonSerialArduinoConnectDisconnect.Size = new System.Drawing.Size(88, 33);
            this.buttonSerialArduinoConnectDisconnect.TabIndex = 0;
            this.buttonSerialArduinoConnectDisconnect.Text = "Connect";
            this.buttonSerialArduinoConnectDisconnect.UseVisualStyleBackColor = true;
            this.buttonSerialArduinoConnectDisconnect.Click += new System.EventHandler(this.buttonSerialArduinoConnectDisconnect_Click);
            // 
            // buttonL
            // 
            this.buttonL.Location = new System.Drawing.Point(1350, 600);
            this.buttonL.Margin = new System.Windows.Forms.Padding(2);
            this.buttonL.Name = "buttonL";
            this.buttonL.Size = new System.Drawing.Size(50, 50);
            this.buttonL.TabIndex = 4;
            this.buttonL.Text = "L";
            this.buttonL.UseVisualStyleBackColor = true;
            this.buttonL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonU
            // 
            this.buttonU.Location = new System.Drawing.Point(1400, 550);
            this.buttonU.Margin = new System.Windows.Forms.Padding(2);
            this.buttonU.Name = "buttonU";
            this.buttonU.Size = new System.Drawing.Size(50, 50);
            this.buttonU.TabIndex = 5;
            this.buttonU.Text = "U";
            this.buttonU.UseVisualStyleBackColor = true;
            this.buttonU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonR
            // 
            this.buttonR.Location = new System.Drawing.Point(1450, 600);
            this.buttonR.Margin = new System.Windows.Forms.Padding(2);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(50, 50);
            this.buttonR.TabIndex = 6;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(1400, 650);
            this.buttonD.Margin = new System.Windows.Forms.Padding(2);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(50, 50);
            this.buttonD.TabIndex = 7;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(1800, 600);
            this.buttonA.Margin = new System.Windows.Forms.Padding(2);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(50, 52);
            this.buttonA.TabIndex = 8;
            this.buttonA.Text = "2 (A)";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // panelSimulator
            // 
            this.panelSimulator.Location = new System.Drawing.Point(1616, 12);
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
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(1750, 650);
            this.buttonB.Margin = new System.Windows.Forms.Padding(2);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(50, 52);
            this.buttonB.TabIndex = 11;
            this.buttonB.Text = "1 (B)";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonDH
            // 
            this.buttonDH.Location = new System.Drawing.Point(1400, 825);
            this.buttonDH.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDH.Name = "buttonDH";
            this.buttonDH.Size = new System.Drawing.Size(50, 50);
            this.buttonDH.TabIndex = 15;
            this.buttonDH.Text = "DH";
            this.buttonDH.UseVisualStyleBackColor = true;
            this.buttonDH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonDH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonRH
            // 
            this.buttonRH.Location = new System.Drawing.Point(1450, 775);
            this.buttonRH.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRH.Name = "buttonRH";
            this.buttonRH.Size = new System.Drawing.Size(50, 50);
            this.buttonRH.TabIndex = 14;
            this.buttonRH.Text = "RH";
            this.buttonRH.UseVisualStyleBackColor = true;
            this.buttonRH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonRH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonUH
            // 
            this.buttonUH.Location = new System.Drawing.Point(1400, 725);
            this.buttonUH.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUH.Name = "buttonUH";
            this.buttonUH.Size = new System.Drawing.Size(50, 50);
            this.buttonUH.TabIndex = 13;
            this.buttonUH.Text = "UH";
            this.buttonUH.UseVisualStyleBackColor = true;
            this.buttonUH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonUH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonLH
            // 
            this.buttonLH.Location = new System.Drawing.Point(1350, 775);
            this.buttonLH.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLH.Name = "buttonLH";
            this.buttonLH.Size = new System.Drawing.Size(50, 50);
            this.buttonLH.TabIndex = 12;
            this.buttonLH.Text = "LH";
            this.buttonLH.UseVisualStyleBackColor = true;
            this.buttonLH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonLH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // textboxDebug
            // 
            this.textboxDebug.Location = new System.Drawing.Point(1692, 417);
            this.textboxDebug.Margin = new System.Windows.Forms.Padding(2);
            this.textboxDebug.Multiline = true;
            this.textboxDebug.Name = "textboxDebug";
            this.textboxDebug.Size = new System.Drawing.Size(179, 172);
            this.textboxDebug.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1977, 633);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 57);
            this.button1.TabIndex = 17;
            this.button1.Text = "Go";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1850, 650);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 52);
            this.button5.TabIndex = 18;
            this.button5.Text = "7 (Store)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // panelSimulatorBlocks
            // 
            this.panelSimulatorBlocks.Location = new System.Drawing.Point(1822, 12);
            this.panelSimulatorBlocks.Name = "panelSimulatorBlocks";
            this.panelSimulatorBlocks.Size = new System.Drawing.Size(80, 400);
            this.panelSimulatorBlocks.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1931, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Danger mode:";
            // 
            // panelDanger
            // 
            this.panelDanger.Location = new System.Drawing.Point(1934, 38);
            this.panelDanger.Name = "panelDanger";
            this.panelDanger.Size = new System.Drawing.Size(80, 80);
            this.panelDanger.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1575, 650);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(50, 50);
            this.button2.TabIndex = 24;
            this.button2.Text = "DR";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1625, 600);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 50);
            this.button3.TabIndex = 23;
            this.button3.Text = "RR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonUR
            // 
            this.buttonUR.Location = new System.Drawing.Point(1575, 550);
            this.buttonUR.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUR.Name = "buttonUR";
            this.buttonUR.Size = new System.Drawing.Size(50, 50);
            this.buttonUR.TabIndex = 22;
            this.buttonUR.Text = "UR";
            this.buttonUR.UseVisualStyleBackColor = true;
            this.buttonUR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonUR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1525, 600);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 50);
            this.button6.TabIndex = 21;
            this.button6.Text = "LR";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.button6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // labelDanger
            // 
            this.labelDanger.AutoSize = true;
            this.labelDanger.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDanger.Location = new System.Drawing.Point(1937, 121);
            this.labelDanger.Name = "labelDanger";
            this.labelDanger.Size = new System.Drawing.Size(77, 90);
            this.labelDanger.TabIndex = 25;
            this.labelDanger.Text = "0";
            // 
            // Tetris99BotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2084, 891);
            this.Controls.Add(this.labelDanger);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonUR);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panelDanger);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelSimulatorBlocks);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textboxDebug);
            this.Controls.Add(this.buttonDH);
            this.Controls.Add(this.buttonRH);
            this.Controls.Add(this.buttonUH);
            this.Controls.Add(this.buttonLH);
            this.Controls.Add(this.buttonB);
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
        private System.Windows.Forms.Button buttonB;
        private System.Windows.Forms.Button buttonDH;
        private System.Windows.Forms.Button buttonRH;
        private System.Windows.Forms.Button buttonUH;
        private System.Windows.Forms.Button buttonLH;
        private System.Windows.Forms.TextBox textboxDebug;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panelSimulatorBlocks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDanger;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonUR;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label labelDanger;
    }
}

