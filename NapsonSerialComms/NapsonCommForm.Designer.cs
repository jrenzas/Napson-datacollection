namespace NapsonExpanded
{
    partial class MenuForm
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
            this.buttonNoData = new System.Windows.Forms.Button();
            this.labelReading = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.groupBoxDOE = new System.Windows.Forms.GroupBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.buttonStartDOE = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.textBoxDOE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxMeasurements = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonEndDOE = new System.Windows.Forms.Button();
            this.buttonNewSample = new System.Windows.Forms.Button();
            this.buttonFake = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBoxDOE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNoData
            // 
            this.buttonNoData.Enabled = false;
            this.buttonNoData.Location = new System.Drawing.Point(52, 48);
            this.buttonNoData.Name = "buttonNoData";
            this.buttonNoData.Size = new System.Drawing.Size(75, 23);
            this.buttonNoData.TabIndex = 2;
            this.buttonNoData.Text = "No Data";
            this.buttonNoData.UseVisualStyleBackColor = true;
            this.buttonNoData.Click += new System.EventHandler(this.buttonNoData_Click);
            // 
            // labelReading
            // 
            this.labelReading.AutoSize = true;
            this.labelReading.Location = new System.Drawing.Point(20, 74);
            this.labelReading.Name = "labelReading";
            this.labelReading.Size = new System.Drawing.Size(76, 13);
            this.labelReading.TabIndex = 4;
            this.labelReading.Text = "Last Reading: ";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(44, 547);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(31, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.portChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 550);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Port:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sample ID:";
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(71, 22);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(100, 20);
            this.txtBoxID.TabIndex = 8;
            this.txtBoxID.Text = "Sample Number";
            // 
            // groupBoxDOE
            // 
            this.groupBoxDOE.Controls.Add(this.openFileButton);
            this.groupBoxDOE.Controls.Add(this.buttonStartDOE);
            this.groupBoxDOE.Controls.Add(this.label5);
            this.groupBoxDOE.Controls.Add(this.label4);
            this.groupBoxDOE.Controls.Add(this.numericUpDownY);
            this.groupBoxDOE.Controls.Add(this.numericUpDownX);
            this.groupBoxDOE.Controls.Add(this.textBoxDOE);
            this.groupBoxDOE.Controls.Add(this.label3);
            this.groupBoxDOE.Location = new System.Drawing.Point(13, 12);
            this.groupBoxDOE.Name = "groupBoxDOE";
            this.groupBoxDOE.Size = new System.Drawing.Size(187, 124);
            this.groupBoxDOE.TabIndex = 9;
            this.groupBoxDOE.TabStop = false;
            this.groupBoxDOE.Text = "Setup DOE";
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(91, 95);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(85, 23);
            this.openFileButton.TabIndex = 14;
            this.openFileButton.Text = "Open File";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // buttonStartDOE
            // 
            this.buttonStartDOE.Location = new System.Drawing.Point(8, 95);
            this.buttonStartDOE.Name = "buttonStartDOE";
            this.buttonStartDOE.Size = new System.Drawing.Size(76, 23);
            this.buttonStartDOE.TabIndex = 6;
            this.buttonStartDOE.Text = "New DOE";
            this.buttonStartDOE.UseVisualStyleBackColor = true;
            this.buttonStartDOE.Click += new System.EventHandler(this.buttonStartDOE_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Columns:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rows:";
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(76, 45);
            this.numericUpDownY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownY.TabIndex = 3;
            this.numericUpDownY.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(76, 71);
            this.numericUpDownX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownX.TabIndex = 2;
            this.numericUpDownX.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // textBoxDOE
            // 
            this.textBoxDOE.Location = new System.Drawing.Point(76, 19);
            this.textBoxDOE.Name = "textBoxDOE";
            this.textBoxDOE.Size = new System.Drawing.Size(100, 20);
            this.textBoxDOE.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "DOE Name:";
            // 
            // groupBoxMeasurements
            // 
            this.groupBoxMeasurements.Location = new System.Drawing.Point(206, 12);
            this.groupBoxMeasurements.Name = "groupBoxMeasurements";
            this.groupBoxMeasurements.Size = new System.Drawing.Size(854, 551);
            this.groupBoxMeasurements.TabIndex = 10;
            this.groupBoxMeasurements.TabStop = false;
            this.groupBoxMeasurements.Text = "Measurements";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBoxID);
            this.groupBox1.Controls.Add(this.buttonNoData);
            this.groupBox1.Controls.Add(this.labelReading);
            this.groupBox1.Location = new System.Drawing.Point(12, 142);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample";
            // 
            // buttonEndDOE
            // 
            this.buttonEndDOE.Enabled = false;
            this.buttonEndDOE.Location = new System.Drawing.Point(35, 490);
            this.buttonEndDOE.Name = "buttonEndDOE";
            this.buttonEndDOE.Size = new System.Drawing.Size(139, 33);
            this.buttonEndDOE.TabIndex = 9;
            this.buttonEndDOE.Text = "Save/Close DOE";
            this.buttonEndDOE.UseVisualStyleBackColor = true;
            this.buttonEndDOE.Click += new System.EventHandler(this.buttonEndDOE_Click);
            // 
            // buttonNewSample
            // 
            this.buttonNewSample.Enabled = false;
            this.buttonNewSample.Location = new System.Drawing.Point(35, 248);
            this.buttonNewSample.Name = "buttonNewSample";
            this.buttonNewSample.Size = new System.Drawing.Size(139, 34);
            this.buttonNewSample.TabIndex = 12;
            this.buttonNewSample.Text = "New Sample";
            this.buttonNewSample.UseVisualStyleBackColor = true;
            this.buttonNewSample.Click += new System.EventHandler(this.buttonNewSample_Click);
            // 
            // buttonFake
            // 
            this.buttonFake.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFake.Location = new System.Drawing.Point(63, 414);
            this.buttonFake.Name = "buttonFake";
            this.buttonFake.Size = new System.Drawing.Size(95, 23);
            this.buttonFake.TabIndex = 13;
            this.buttonFake.Text = "Gen. Fake Point";
            this.buttonFake.UseVisualStyleBackColor = true;
            this.buttonFake.Visible = false;
            this.buttonFake.Click += new System.EventHandler(this.buttonFake_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(18, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 86);
            this.label6.TabIndex = 14;
            this.label6.Text = "Software written by Russ Renzas. Software only works with Napson EC-80P Noncontac" +
    "t Resistance Probe. ";
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 575);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonFake);
            this.Controls.Add(this.buttonNewSample);
            this.Controls.Add(this.buttonEndDOE);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxMeasurements);
            this.Controls.Add(this.groupBoxDOE);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.Text = "Napson EC-80P Expanded Data Collection System - Russ Renzas, January 2014 (versio" +
    "n 3.0, March 2015)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBoxDOE.ResumeLayout(false);
            this.groupBoxDOE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNoData;
        private System.Windows.Forms.Label labelReading;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.GroupBox groupBoxDOE;
        private System.Windows.Forms.Button buttonStartDOE;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.TextBox textBoxDOE;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxMeasurements;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonEndDOE;
        private System.Windows.Forms.Button buttonNewSample;
        private System.Windows.Forms.Button buttonFake;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Label label6;
    }
}

