namespace LiveSplit.RustAlarm.UI;

partial class RustAlarmSettings
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
            this.tableLayoutSegments = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tableLayoutSegments
            // 
            this.tableLayoutSegments.AutoSize = true;
            this.tableLayoutSegments.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutSegments.ColumnCount = 1;
            this.tableLayoutSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSegments.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutSegments.Name = "tableLayoutSegments";
            this.tableLayoutSegments.RowCount = 1;
            this.tableLayoutSegments.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSegments.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutSegments.TabIndex = 0;
            // 
            // RustAlarmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutSegments);
            this.Name = "RustAlarmSettings";
            this.Size = new System.Drawing.Size(476, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutSegments;
}
