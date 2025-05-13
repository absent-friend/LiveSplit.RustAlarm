namespace LiveSplit.RustAlarm
{
    partial class RustAlarmSegmentSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tableLayoutThresholds;
            System.Windows.Forms.Label labelRustThreshold;
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.textRustThreshold = new System.Windows.Forms.TextBox();
            tableLayoutThresholds = new System.Windows.Forms.TableLayoutPanel();
            labelRustThreshold = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            tableLayoutThresholds.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(tableLayoutThresholds);
            this.groupBox.Location = new System.Drawing.Point(3, 3);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(368, 56);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Segment:";
            // 
            // tableLayoutThresholds
            // 
            tableLayoutThresholds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            tableLayoutThresholds.ColumnCount = 2;
            tableLayoutThresholds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            tableLayoutThresholds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutThresholds.Controls.Add(labelRustThreshold, 0, 0);
            tableLayoutThresholds.Controls.Add(this.textRustThreshold, 1, 0);
            tableLayoutThresholds.Location = new System.Drawing.Point(6, 19);
            tableLayoutThresholds.Name = "tableLayoutThresholds";
            tableLayoutThresholds.RowCount = 1;
            tableLayoutThresholds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutThresholds.Size = new System.Drawing.Size(356, 31);
            tableLayoutThresholds.TabIndex = 0;
            // 
            // labelRustThreshold
            // 
            labelRustThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            labelRustThreshold.AutoSize = true;
            labelRustThreshold.Location = new System.Drawing.Point(3, 9);
            labelRustThreshold.Name = "labelRustThreshold";
            labelRustThreshold.Size = new System.Drawing.Size(82, 13);
            labelRustThreshold.TabIndex = 0;
            labelRustThreshold.Text = "Rust Threshold:";
            // 
            // textRustThreshold
            // 
            this.textRustThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.textRustThreshold.Location = new System.Drawing.Point(91, 5);
            this.textRustThreshold.Name = "textRustThreshold";
            this.textRustThreshold.Size = new System.Drawing.Size(262, 20);
            this.textRustThreshold.TabIndex = 1;
            // 
            // RustAlarmSegmentSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox);
            this.Name = "RustAlarmSegmentSettings";
            this.Size = new System.Drawing.Size(374, 62);
            this.groupBox.ResumeLayout(false);
            tableLayoutThresholds.ResumeLayout(false);
            tableLayoutThresholds.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.TextBox textRustThreshold;
    }
}
