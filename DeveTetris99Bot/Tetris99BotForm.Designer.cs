﻿namespace DeveTetris99Bot
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(2560, 1385);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2720, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 769);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(3176, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(644, 162);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Serial Connection";
            // 
            // buttonSerialArduinoRefresh
            // 
            this.buttonSerialArduinoRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSerialArduinoRefresh.Location = new System.Drawing.Point(560, 38);
            this.buttonSerialArduinoRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.comboBoxComConnections.Location = new System.Drawing.Point(280, 71);
            this.comboBoxComConnections.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxComConnections.Name = "comboBoxComConnections";
            this.comboBoxComConnections.Size = new System.Drawing.Size(248, 33);
            this.comboBoxComConnections.TabIndex = 1;
            // 
            // buttonSerialArduinoConnectDisconnect
            // 
            this.buttonSerialArduinoConnectDisconnect.Location = new System.Drawing.Point(56, 56);
            this.buttonSerialArduinoConnectDisconnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSerialArduinoConnectDisconnect.Name = "buttonSerialArduinoConnectDisconnect";
            this.buttonSerialArduinoConnectDisconnect.Size = new System.Drawing.Size(176, 63);
            this.buttonSerialArduinoConnectDisconnect.TabIndex = 0;
            this.buttonSerialArduinoConnectDisconnect.Text = "Connect";
            this.buttonSerialArduinoConnectDisconnect.UseVisualStyleBackColor = true;
            this.buttonSerialArduinoConnectDisconnect.Click += new System.EventHandler(this.buttonSerialArduinoConnectDisconnect_Click);
            // 
            // buttonL
            // 
            this.buttonL.Location = new System.Drawing.Point(2700, 1154);
            this.buttonL.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonL.Name = "buttonL";
            this.buttonL.Size = new System.Drawing.Size(100, 96);
            this.buttonL.TabIndex = 4;
            this.buttonL.Text = "L";
            this.buttonL.UseVisualStyleBackColor = true;
            this.buttonL.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonL.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonU
            // 
            this.buttonU.Location = new System.Drawing.Point(2800, 1058);
            this.buttonU.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonU.Name = "buttonU";
            this.buttonU.Size = new System.Drawing.Size(100, 96);
            this.buttonU.TabIndex = 5;
            this.buttonU.Text = "U";
            this.buttonU.UseVisualStyleBackColor = true;
            this.buttonU.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonU.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonR
            // 
            this.buttonR.Location = new System.Drawing.Point(2900, 1154);
            this.buttonR.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonR.Name = "buttonR";
            this.buttonR.Size = new System.Drawing.Size(100, 96);
            this.buttonR.TabIndex = 6;
            this.buttonR.Text = "R";
            this.buttonR.UseVisualStyleBackColor = true;
            this.buttonR.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonR.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(2800, 1250);
            this.buttonD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(100, 96);
            this.buttonD.TabIndex = 7;
            this.buttonD.Text = "D";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonD.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonA
            // 
            this.buttonA.Location = new System.Drawing.Point(3600, 1154);
            this.buttonA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonA.Name = "buttonA";
            this.buttonA.Size = new System.Drawing.Size(100, 100);
            this.buttonA.TabIndex = 8;
            this.buttonA.Text = "2 (A)";
            this.buttonA.UseVisualStyleBackColor = true;
            this.buttonA.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonA.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // panelSimulator
            // 
            this.panelSimulator.Location = new System.Drawing.Point(3752, 23);
            this.panelSimulator.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panelSimulator.Name = "panelSimulator";
            this.panelSimulator.Size = new System.Drawing.Size(400, 769);
            this.panelSimulator.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3746, 871);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Lines cleared:";
            // 
            // labelLinesCleared
            // 
            this.labelLinesCleared.AutoSize = true;
            this.labelLinesCleared.Location = new System.Drawing.Point(3906, 871);
            this.labelLinesCleared.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelLinesCleared.Name = "labelLinesCleared";
            this.labelLinesCleared.Size = new System.Drawing.Size(24, 25);
            this.labelLinesCleared.TabIndex = 10;
            this.labelLinesCleared.Text = "0";
            // 
            // buttonB
            // 
            this.buttonB.Location = new System.Drawing.Point(3500, 1250);
            this.buttonB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonB.Name = "buttonB";
            this.buttonB.Size = new System.Drawing.Size(100, 100);
            this.buttonB.TabIndex = 11;
            this.buttonB.Text = "1 (B)";
            this.buttonB.UseVisualStyleBackColor = true;
            this.buttonB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonB.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonDH
            // 
            this.buttonDH.Location = new System.Drawing.Point(3200, 1250);
            this.buttonDH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDH.Name = "buttonDH";
            this.buttonDH.Size = new System.Drawing.Size(100, 96);
            this.buttonDH.TabIndex = 15;
            this.buttonDH.Text = "DH";
            this.buttonDH.UseVisualStyleBackColor = true;
            this.buttonDH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonDH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonRH
            // 
            this.buttonRH.Location = new System.Drawing.Point(3300, 1154);
            this.buttonRH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRH.Name = "buttonRH";
            this.buttonRH.Size = new System.Drawing.Size(100, 96);
            this.buttonRH.TabIndex = 14;
            this.buttonRH.Text = "RH";
            this.buttonRH.UseVisualStyleBackColor = true;
            this.buttonRH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonRH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonUH
            // 
            this.buttonUH.Location = new System.Drawing.Point(3200, 1058);
            this.buttonUH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUH.Name = "buttonUH";
            this.buttonUH.Size = new System.Drawing.Size(100, 96);
            this.buttonUH.TabIndex = 13;
            this.buttonUH.Text = "UH";
            this.buttonUH.UseVisualStyleBackColor = true;
            this.buttonUH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonUH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // buttonLH
            // 
            this.buttonLH.Location = new System.Drawing.Point(3100, 1154);
            this.buttonLH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLH.Name = "buttonLH";
            this.buttonLH.Size = new System.Drawing.Size(100, 96);
            this.buttonLH.TabIndex = 12;
            this.buttonLH.Text = "LH";
            this.buttonLH.UseVisualStyleBackColor = true;
            this.buttonLH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Down);
            this.buttonLH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonArduinoAction_Up);
            // 
            // textboxDebug
            // 
            this.textboxDebug.Location = new System.Drawing.Point(3383, 801);
            this.textboxDebug.Multiline = true;
            this.textboxDebug.Name = "textboxDebug";
            this.textboxDebug.Size = new System.Drawing.Size(354, 327);
            this.textboxDebug.TabIndex = 16;
            // 
            // Tetris99BotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3844, 1421);
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
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
    }
}

