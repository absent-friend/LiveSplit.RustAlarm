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
            System.Windows.Forms.TableLayoutPanel tableLayoutSettings;
            System.Windows.Forms.TableLayoutPanel tableLayoutBackground;
            System.Windows.Forms.Label lblBackgroundColor;
            System.Windows.Forms.GroupBox groupThresholdColors;
            System.Windows.Forms.TableLayoutPanel tableLayoutThresholds;
            System.Windows.Forms.Label lblWarningColor;
            System.Windows.Forms.Label lblThresholdColor1;
            System.Windows.Forms.GroupBox groupBoxHeading;
            System.Windows.Forms.TableLayoutPanel tableLayoutHeading;
            System.Windows.Forms.GroupBox groupCount;
            System.Windows.Forms.TableLayoutPanel tableLayoutCount;
            System.Windows.Forms.GroupBox groupTitle;
            System.Windows.Forms.TableLayoutPanel tableLayoutTitle;
            System.Windows.Forms.GroupBox groupSegments;
            System.Windows.Forms.TableLayoutPanel tableLayoutSegments;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cmbGradientType = new System.Windows.Forms.ComboBox();
            this.btnBackgroundColor2 = new System.Windows.Forms.Button();
            this.btnBackgroundColor1 = new System.Windows.Forms.Button();
            this.btnWarningColor = new System.Windows.Forms.Button();
            this.btnDangerColor = new System.Windows.Forms.Button();
            this.chkCountFont = new System.Windows.Forms.CheckBox();
            this.chkCountColor = new System.Windows.Forms.CheckBox();
            this.lblCountFont = new System.Windows.Forms.Label();
            this.btnCountFont = new System.Windows.Forms.Button();
            this.btnCountColor = new System.Windows.Forms.Button();
            this.chkTitleFont = new System.Windows.Forms.CheckBox();
            this.chkTitleColor = new System.Windows.Forms.CheckBox();
            this.lblTitleFont = new System.Windows.Forms.Label();
            this.btnTitleFont = new System.Windows.Forms.Button();
            this.btnTitleColor = new System.Windows.Forms.Button();
            this.btnSegmentsColor = new System.Windows.Forms.Button();
            this.chkSegmentsColor = new System.Windows.Forms.CheckBox();
            this.btnSegmentsFont = new System.Windows.Forms.Button();
            this.lblSegmentsFont = new System.Windows.Forms.Label();
            this.chkSegmentsFont = new System.Windows.Forms.CheckBox();
            this.dataGridSegments = new System.Windows.Forms.DataGridView();
            this.dataGridSegments_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSegments_FailRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSegments_WarningThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSegments_DangerThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSegments_MaxTimeLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tableLayoutSettings = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutBackground = new System.Windows.Forms.TableLayoutPanel();
            lblBackgroundColor = new System.Windows.Forms.Label();
            groupThresholdColors = new System.Windows.Forms.GroupBox();
            tableLayoutThresholds = new System.Windows.Forms.TableLayoutPanel();
            lblWarningColor = new System.Windows.Forms.Label();
            lblThresholdColor1 = new System.Windows.Forms.Label();
            groupBoxHeading = new System.Windows.Forms.GroupBox();
            tableLayoutHeading = new System.Windows.Forms.TableLayoutPanel();
            groupCount = new System.Windows.Forms.GroupBox();
            tableLayoutCount = new System.Windows.Forms.TableLayoutPanel();
            groupTitle = new System.Windows.Forms.GroupBox();
            tableLayoutTitle = new System.Windows.Forms.TableLayoutPanel();
            groupSegments = new System.Windows.Forms.GroupBox();
            tableLayoutSegments = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutSettings.SuspendLayout();
            tableLayoutBackground.SuspendLayout();
            groupThresholdColors.SuspendLayout();
            tableLayoutThresholds.SuspendLayout();
            groupBoxHeading.SuspendLayout();
            tableLayoutHeading.SuspendLayout();
            groupCount.SuspendLayout();
            tableLayoutCount.SuspendLayout();
            groupTitle.SuspendLayout();
            tableLayoutTitle.SuspendLayout();
            groupSegments.SuspendLayout();
            tableLayoutSegments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSegments)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutSettings
            // 
            tableLayoutSettings.ColumnCount = 1;
            tableLayoutSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutSettings.Controls.Add(tableLayoutBackground, 0, 3);
            tableLayoutSettings.Controls.Add(groupThresholdColors, 0, 1);
            tableLayoutSettings.Controls.Add(groupBoxHeading, 0, 2);
            tableLayoutSettings.Controls.Add(groupSegments, 0, 0);
            tableLayoutSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutSettings.Location = new System.Drawing.Point(0, 0);
            tableLayoutSettings.Name = "tableLayoutSettings";
            tableLayoutSettings.RowCount = 4;
            tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutSettings.Size = new System.Drawing.Size(476, 544);
            tableLayoutSettings.TabIndex = 0;
            // 
            // tableLayoutBackground
            // 
            tableLayoutBackground.AutoSize = true;
            tableLayoutBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutBackground.ColumnCount = 4;
            tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            tableLayoutBackground.Controls.Add(this.cmbGradientType, 3, 0);
            tableLayoutBackground.Controls.Add(this.btnBackgroundColor2, 1, 0);
            tableLayoutBackground.Controls.Add(this.btnBackgroundColor1, 2, 0);
            tableLayoutBackground.Controls.Add(lblBackgroundColor, 0, 0);
            tableLayoutBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutBackground.Location = new System.Drawing.Point(3, 513);
            tableLayoutBackground.Name = "tableLayoutBackground";
            tableLayoutBackground.RowCount = 1;
            tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutBackground.Size = new System.Drawing.Size(470, 29);
            tableLayoutBackground.TabIndex = 0;
            // 
            // cmbGradientType
            // 
            this.cmbGradientType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradientType.FormattingEnabled = true;
            this.cmbGradientType.Location = new System.Drawing.Point(220, 4);
            this.cmbGradientType.Name = "cmbGradientType";
            this.cmbGradientType.Size = new System.Drawing.Size(247, 21);
            this.cmbGradientType.TabIndex = 0;
            // 
            // btnBackgroundColor2
            // 
            this.btnBackgroundColor2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBackgroundColor2.BackColor = System.Drawing.Color.Transparent;
            this.btnBackgroundColor2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackgroundColor2.Location = new System.Drawing.Point(162, 3);
            this.btnBackgroundColor2.Name = "btnBackgroundColor2";
            this.btnBackgroundColor2.Size = new System.Drawing.Size(23, 23);
            this.btnBackgroundColor2.TabIndex = 1;
            this.btnBackgroundColor2.UseVisualStyleBackColor = false;
            this.btnBackgroundColor2.Visible = false;
            // 
            // btnBackgroundColor1
            // 
            this.btnBackgroundColor1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBackgroundColor1.BackColor = System.Drawing.Color.Transparent;
            this.btnBackgroundColor1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBackgroundColor1.Location = new System.Drawing.Point(191, 3);
            this.btnBackgroundColor1.Name = "btnBackgroundColor1";
            this.btnBackgroundColor1.Size = new System.Drawing.Size(23, 23);
            this.btnBackgroundColor1.TabIndex = 2;
            this.btnBackgroundColor1.UseVisualStyleBackColor = false;
            // 
            // lblBackgroundColor
            // 
            lblBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblBackgroundColor.AutoSize = true;
            lblBackgroundColor.Location = new System.Drawing.Point(3, 8);
            lblBackgroundColor.Name = "lblBackgroundColor";
            lblBackgroundColor.Size = new System.Drawing.Size(153, 13);
            lblBackgroundColor.TabIndex = 3;
            lblBackgroundColor.Text = "Background Color:";
            // 
            // groupThresholdColors
            // 
            groupThresholdColors.Controls.Add(tableLayoutThresholds);
            groupThresholdColors.Location = new System.Drawing.Point(3, 267);
            groupThresholdColors.Name = "groupThresholdColors";
            groupThresholdColors.Size = new System.Drawing.Size(470, 48);
            groupThresholdColors.TabIndex = 2;
            groupThresholdColors.TabStop = false;
            groupThresholdColors.Text = "Threshold Colors";
            // 
            // tableLayoutThresholds
            // 
            tableLayoutThresholds.AutoSize = true;
            tableLayoutThresholds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutThresholds.ColumnCount = 4;
            tableLayoutThresholds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            tableLayoutThresholds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            tableLayoutThresholds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutThresholds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 325F));
            tableLayoutThresholds.Controls.Add(this.btnWarningColor, 1, 0);
            tableLayoutThresholds.Controls.Add(lblWarningColor, 0, 0);
            tableLayoutThresholds.Controls.Add(lblThresholdColor1, 2, 0);
            tableLayoutThresholds.Controls.Add(this.btnDangerColor, 3, 0);
            tableLayoutThresholds.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutThresholds.Location = new System.Drawing.Point(3, 16);
            tableLayoutThresholds.Name = "tableLayoutThresholds";
            tableLayoutThresholds.RowCount = 1;
            tableLayoutThresholds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutThresholds.Size = new System.Drawing.Size(464, 29);
            tableLayoutThresholds.TabIndex = 0;
            // 
            // btnWarningColor
            // 
            this.btnWarningColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWarningColor.BackColor = System.Drawing.Color.Yellow;
            this.btnWarningColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWarningColor.Location = new System.Drawing.Point(62, 3);
            this.btnWarningColor.Name = "btnWarningColor";
            this.btnWarningColor.Size = new System.Drawing.Size(23, 23);
            this.btnWarningColor.TabIndex = 7;
            this.btnWarningColor.UseVisualStyleBackColor = false;
            // 
            // lblWarningColor
            // 
            lblWarningColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblWarningColor.AutoSize = true;
            lblWarningColor.Location = new System.Drawing.Point(3, 8);
            lblWarningColor.Name = "lblWarningColor";
            lblWarningColor.Size = new System.Drawing.Size(53, 13);
            lblWarningColor.TabIndex = 0;
            lblWarningColor.Text = "Warning:";
            // 
            // lblThresholdColor1
            // 
            lblThresholdColor1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            lblThresholdColor1.AutoSize = true;
            lblThresholdColor1.Location = new System.Drawing.Point(91, 8);
            lblThresholdColor1.Name = "lblThresholdColor1";
            lblThresholdColor1.Size = new System.Drawing.Size(45, 13);
            lblThresholdColor1.TabIndex = 2;
            lblThresholdColor1.Text = "Danger:";
            // 
            // btnDangerColor
            // 
            this.btnDangerColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDangerColor.BackColor = System.Drawing.Color.Red;
            this.btnDangerColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangerColor.Location = new System.Drawing.Point(142, 3);
            this.btnDangerColor.Name = "btnDangerColor";
            this.btnDangerColor.Size = new System.Drawing.Size(23, 23);
            this.btnDangerColor.TabIndex = 6;
            this.btnDangerColor.UseVisualStyleBackColor = false;
            // 
            // groupBoxHeading
            // 
            groupBoxHeading.Controls.Add(tableLayoutHeading);
            groupBoxHeading.Location = new System.Drawing.Point(3, 321);
            groupBoxHeading.Name = "groupBoxHeading";
            groupBoxHeading.Size = new System.Drawing.Size(470, 186);
            groupBoxHeading.TabIndex = 1;
            groupBoxHeading.TabStop = false;
            groupBoxHeading.Text = "Heading";
            // 
            // tableLayoutHeading
            // 
            tableLayoutHeading.AutoSize = true;
            tableLayoutHeading.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutHeading.ColumnCount = 1;
            tableLayoutHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutHeading.Controls.Add(groupCount, 0, 1);
            tableLayoutHeading.Controls.Add(groupTitle, 0, 0);
            tableLayoutHeading.Location = new System.Drawing.Point(3, 16);
            tableLayoutHeading.Name = "tableLayoutHeading";
            tableLayoutHeading.RowCount = 2;
            tableLayoutHeading.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutHeading.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutHeading.Size = new System.Drawing.Size(464, 165);
            tableLayoutHeading.TabIndex = 0;
            // 
            // groupCount
            // 
            groupCount.Controls.Add(tableLayoutCount);
            groupCount.Location = new System.Drawing.Point(3, 85);
            groupCount.Name = "groupCount";
            groupCount.Size = new System.Drawing.Size(458, 77);
            groupCount.TabIndex = 1;
            groupCount.TabStop = false;
            groupCount.Text = "Count";
            // 
            // tableLayoutCount
            // 
            tableLayoutCount.AutoSize = true;
            tableLayoutCount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutCount.ColumnCount = 3;
            tableLayoutCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            tableLayoutCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            tableLayoutCount.Controls.Add(this.chkCountFont, 0, 0);
            tableLayoutCount.Controls.Add(this.chkCountColor, 0, 1);
            tableLayoutCount.Controls.Add(this.lblCountFont, 1, 0);
            tableLayoutCount.Controls.Add(this.btnCountFont, 2, 0);
            tableLayoutCount.Controls.Add(this.btnCountColor, 1, 1);
            tableLayoutCount.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutCount.Location = new System.Drawing.Point(3, 16);
            tableLayoutCount.Name = "tableLayoutCount";
            tableLayoutCount.RowCount = 2;
            tableLayoutCount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutCount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutCount.Size = new System.Drawing.Size(452, 58);
            tableLayoutCount.TabIndex = 0;
            // 
            // chkCountFont
            // 
            this.chkCountFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCountFont.AutoSize = true;
            this.chkCountFont.Location = new System.Drawing.Point(3, 6);
            this.chkCountFont.Name = "chkCountFont";
            this.chkCountFont.Size = new System.Drawing.Size(50, 17);
            this.chkCountFont.TabIndex = 0;
            this.chkCountFont.Text = "Font:";
            this.chkCountFont.UseVisualStyleBackColor = true;
            // 
            // chkCountColor
            // 
            this.chkCountColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkCountColor.AutoSize = true;
            this.chkCountColor.Location = new System.Drawing.Point(3, 35);
            this.chkCountColor.Name = "chkCountColor";
            this.chkCountColor.Size = new System.Drawing.Size(53, 17);
            this.chkCountColor.TabIndex = 1;
            this.chkCountColor.Text = "Color:";
            this.chkCountColor.UseVisualStyleBackColor = true;
            // 
            // lblCountFont
            // 
            this.lblCountFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCountFont.AutoSize = true;
            this.lblCountFont.Location = new System.Drawing.Point(62, 8);
            this.lblCountFont.Name = "lblCountFont";
            this.lblCountFont.Size = new System.Drawing.Size(297, 13);
            this.lblCountFont.TabIndex = 3;
            // 
            // btnCountFont
            // 
            this.btnCountFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCountFont.Enabled = false;
            this.btnCountFont.Location = new System.Drawing.Point(365, 3);
            this.btnCountFont.Name = "btnCountFont";
            this.btnCountFont.Size = new System.Drawing.Size(84, 23);
            this.btnCountFont.TabIndex = 4;
            this.btnCountFont.Text = "Choose...";
            this.btnCountFont.UseVisualStyleBackColor = true;
            // 
            // btnCountColor
            // 
            this.btnCountColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCountColor.BackColor = System.Drawing.Color.White;
            this.btnCountColor.Enabled = false;
            this.btnCountColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCountColor.Location = new System.Drawing.Point(62, 32);
            this.btnCountColor.Name = "btnCountColor";
            this.btnCountColor.Size = new System.Drawing.Size(23, 23);
            this.btnCountColor.TabIndex = 5;
            this.btnCountColor.UseVisualStyleBackColor = false;
            // 
            // groupTitle
            // 
            groupTitle.Controls.Add(tableLayoutTitle);
            groupTitle.Location = new System.Drawing.Point(3, 3);
            groupTitle.Name = "groupTitle";
            groupTitle.Size = new System.Drawing.Size(458, 76);
            groupTitle.TabIndex = 0;
            groupTitle.TabStop = false;
            groupTitle.Text = "Title";
            // 
            // tableLayoutTitle
            // 
            tableLayoutTitle.AutoSize = true;
            tableLayoutTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            tableLayoutTitle.ColumnCount = 3;
            tableLayoutTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            tableLayoutTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            tableLayoutTitle.Controls.Add(this.chkTitleFont, 0, 0);
            tableLayoutTitle.Controls.Add(this.chkTitleColor, 0, 1);
            tableLayoutTitle.Controls.Add(this.lblTitleFont, 1, 0);
            tableLayoutTitle.Controls.Add(this.btnTitleFont, 2, 0);
            tableLayoutTitle.Controls.Add(this.btnTitleColor, 1, 1);
            tableLayoutTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutTitle.Location = new System.Drawing.Point(3, 16);
            tableLayoutTitle.Name = "tableLayoutTitle";
            tableLayoutTitle.RowCount = 2;
            tableLayoutTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutTitle.Size = new System.Drawing.Size(452, 57);
            tableLayoutTitle.TabIndex = 0;
            // 
            // chkTitleFont
            // 
            this.chkTitleFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkTitleFont.AutoSize = true;
            this.chkTitleFont.Location = new System.Drawing.Point(3, 6);
            this.chkTitleFont.Name = "chkTitleFont";
            this.chkTitleFont.Size = new System.Drawing.Size(50, 17);
            this.chkTitleFont.TabIndex = 0;
            this.chkTitleFont.Text = "Font:";
            this.chkTitleFont.UseVisualStyleBackColor = true;
            // 
            // chkTitleColor
            // 
            this.chkTitleColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkTitleColor.AutoSize = true;
            this.chkTitleColor.Location = new System.Drawing.Point(3, 35);
            this.chkTitleColor.Name = "chkTitleColor";
            this.chkTitleColor.Size = new System.Drawing.Size(53, 17);
            this.chkTitleColor.TabIndex = 1;
            this.chkTitleColor.Text = "Color:";
            this.chkTitleColor.UseVisualStyleBackColor = true;
            // 
            // lblTitleFont
            // 
            this.lblTitleFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleFont.AutoSize = true;
            this.lblTitleFont.Location = new System.Drawing.Point(62, 8);
            this.lblTitleFont.Name = "lblTitleFont";
            this.lblTitleFont.Size = new System.Drawing.Size(297, 13);
            this.lblTitleFont.TabIndex = 3;
            // 
            // btnTitleFont
            // 
            this.btnTitleFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTitleFont.Enabled = false;
            this.btnTitleFont.Location = new System.Drawing.Point(365, 3);
            this.btnTitleFont.Name = "btnTitleFont";
            this.btnTitleFont.Size = new System.Drawing.Size(84, 23);
            this.btnTitleFont.TabIndex = 4;
            this.btnTitleFont.Text = "Choose...";
            this.btnTitleFont.UseVisualStyleBackColor = true;
            // 
            // btnTitleColor
            // 
            this.btnTitleColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnTitleColor.BackColor = System.Drawing.Color.White;
            this.btnTitleColor.Enabled = false;
            this.btnTitleColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTitleColor.Location = new System.Drawing.Point(62, 32);
            this.btnTitleColor.Name = "btnTitleColor";
            this.btnTitleColor.Size = new System.Drawing.Size(23, 23);
            this.btnTitleColor.TabIndex = 5;
            this.btnTitleColor.UseVisualStyleBackColor = false;
            // 
            // groupSegments
            // 
            groupSegments.Controls.Add(tableLayoutSegments);
            groupSegments.Location = new System.Drawing.Point(3, 3);
            groupSegments.Name = "groupSegments";
            groupSegments.Size = new System.Drawing.Size(470, 258);
            groupSegments.TabIndex = 3;
            groupSegments.TabStop = false;
            groupSegments.Text = "Segments";
            // 
            // tableLayoutSegments
            // 
            tableLayoutSegments.ColumnCount = 3;
            tableLayoutSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            tableLayoutSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            tableLayoutSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            tableLayoutSegments.Controls.Add(this.btnSegmentsColor, 1, 2);
            tableLayoutSegments.Controls.Add(this.chkSegmentsColor, 0, 2);
            tableLayoutSegments.Controls.Add(this.btnSegmentsFont, 2, 1);
            tableLayoutSegments.Controls.Add(this.lblSegmentsFont, 1, 1);
            tableLayoutSegments.Controls.Add(this.chkSegmentsFont, 0, 1);
            tableLayoutSegments.Controls.Add(this.dataGridSegments, 0, 0);
            tableLayoutSegments.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutSegments.Location = new System.Drawing.Point(3, 16);
            tableLayoutSegments.Name = "tableLayoutSegments";
            tableLayoutSegments.RowCount = 3;
            tableLayoutSegments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutSegments.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutSegments.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutSegments.Size = new System.Drawing.Size(464, 239);
            tableLayoutSegments.TabIndex = 0;
            // 
            // btnSegmentsColor
            // 
            this.btnSegmentsColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSegmentsColor.BackColor = System.Drawing.Color.White;
            this.btnSegmentsColor.Enabled = false;
            this.btnSegmentsColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSegmentsColor.Location = new System.Drawing.Point(62, 213);
            this.btnSegmentsColor.Name = "btnSegmentsColor";
            this.btnSegmentsColor.Size = new System.Drawing.Size(23, 23);
            this.btnSegmentsColor.TabIndex = 7;
            this.btnSegmentsColor.UseVisualStyleBackColor = false;
            // 
            // chkSegmentsColor
            // 
            this.chkSegmentsColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkSegmentsColor.AutoSize = true;
            this.chkSegmentsColor.Location = new System.Drawing.Point(3, 216);
            this.chkSegmentsColor.Name = "chkSegmentsColor";
            this.chkSegmentsColor.Size = new System.Drawing.Size(53, 17);
            this.chkSegmentsColor.TabIndex = 6;
            this.chkSegmentsColor.Text = "Color:";
            this.chkSegmentsColor.UseVisualStyleBackColor = true;
            // 
            // btnSegmentsFont
            // 
            this.btnSegmentsFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSegmentsFont.Enabled = false;
            this.btnSegmentsFont.Location = new System.Drawing.Point(376, 184);
            this.btnSegmentsFont.Name = "btnSegmentsFont";
            this.btnSegmentsFont.Size = new System.Drawing.Size(85, 23);
            this.btnSegmentsFont.TabIndex = 5;
            this.btnSegmentsFont.Text = "Choose...";
            this.btnSegmentsFont.UseVisualStyleBackColor = true;
            // 
            // lblSegmentsFont
            // 
            this.lblSegmentsFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSegmentsFont.AutoSize = true;
            this.lblSegmentsFont.Location = new System.Drawing.Point(62, 189);
            this.lblSegmentsFont.Name = "lblSegmentsFont";
            this.lblSegmentsFont.Size = new System.Drawing.Size(308, 13);
            this.lblSegmentsFont.TabIndex = 4;
            // 
            // chkSegmentsFont
            // 
            this.chkSegmentsFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkSegmentsFont.AutoSize = true;
            this.chkSegmentsFont.Location = new System.Drawing.Point(3, 187);
            this.chkSegmentsFont.Name = "chkSegmentsFont";
            this.chkSegmentsFont.Size = new System.Drawing.Size(50, 17);
            this.chkSegmentsFont.TabIndex = 1;
            this.chkSegmentsFont.Text = "Font:";
            this.chkSegmentsFont.UseVisualStyleBackColor = true;
            // 
            // dataGridSegments
            // 
            this.dataGridSegments.AllowUserToAddRows = false;
            this.dataGridSegments.AllowUserToDeleteRows = false;
            this.dataGridSegments.AllowUserToResizeRows = false;
            this.dataGridSegments.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridSegments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSegments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridSegments_Name,
            this.dataGridSegments_FailRate,
            this.dataGridSegments_WarningThreshold,
            this.dataGridSegments_DangerThreshold,
            this.dataGridSegments_MaxTimeLoss});
            tableLayoutSegments.SetColumnSpan(this.dataGridSegments, 3);
            this.dataGridSegments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSegments.Location = new System.Drawing.Point(3, 3);
            this.dataGridSegments.MultiSelect = false;
            this.dataGridSegments.Name = "dataGridSegments";
            this.dataGridSegments.RowHeadersVisible = false;
            this.dataGridSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridSegments.Size = new System.Drawing.Size(458, 175);
            this.dataGridSegments.TabIndex = 8;
            // 
            // dataGridSegments_Name
            // 
            this.dataGridSegments_Name.Frozen = true;
            this.dataGridSegments_Name.HeaderText = "Segment";
            this.dataGridSegments_Name.Name = "dataGridSegments_Name";
            this.dataGridSegments_Name.ReadOnly = true;
            this.dataGridSegments_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_Name.Width = 194;
            // 
            // dataGridSegments_FailRate
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridSegments_FailRate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridSegments_FailRate.HeaderText = "Fail %";
            this.dataGridSegments_FailRate.Name = "dataGridSegments_FailRate";
            this.dataGridSegments_FailRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_FailRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_FailRate.ToolTipText = "How often do you expect to fail this segment?";
            this.dataGridSegments_FailRate.Width = 40;
            // 
            // dataGridSegments_WarningThreshold
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridSegments_WarningThreshold.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridSegments_WarningThreshold.HeaderText = "Warning #";
            this.dataGridSegments_WarningThreshold.Name = "dataGridSegments_WarningThreshold";
            this.dataGridSegments_WarningThreshold.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_WarningThreshold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_WarningThreshold.ToolTipText = "The number of back-to-back failures required to flag this segment at the \"Warning" +
    "\" level.";
            this.dataGridSegments_WarningThreshold.Width = 63;
            // 
            // dataGridSegments_DangerThreshold
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridSegments_DangerThreshold.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridSegments_DangerThreshold.HeaderText = "Danger #";
            this.dataGridSegments_DangerThreshold.Name = "dataGridSegments_DangerThreshold";
            this.dataGridSegments_DangerThreshold.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_DangerThreshold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_DangerThreshold.ToolTipText = "The number of back-to-back failures required to flag this segment at the \"Danger\"" +
    " level.";
            this.dataGridSegments_DangerThreshold.Width = 58;
            // 
            // dataGridSegments_MaxTimeLoss
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridSegments_MaxTimeLoss.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridSegments_MaxTimeLoss.HeaderText = "Max Time Loss";
            this.dataGridSegments_MaxTimeLoss.Name = "dataGridSegments_MaxTimeLoss";
            this.dataGridSegments_MaxTimeLoss.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_MaxTimeLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_MaxTimeLoss.ToolTipText = "How much time are you willing to lose on this segment? Splits that lose more than" +
    " this will be counted as failures. If left blank, only resets will count.";
            this.dataGridSegments_MaxTimeLoss.Width = 84;
            // 
            // RustAlarmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(tableLayoutSettings);
            this.Name = "RustAlarmSettings";
            this.Size = new System.Drawing.Size(476, 544);
            tableLayoutSettings.ResumeLayout(false);
            tableLayoutSettings.PerformLayout();
            tableLayoutBackground.ResumeLayout(false);
            tableLayoutBackground.PerformLayout();
            groupThresholdColors.ResumeLayout(false);
            groupThresholdColors.PerformLayout();
            tableLayoutThresholds.ResumeLayout(false);
            tableLayoutThresholds.PerformLayout();
            groupBoxHeading.ResumeLayout(false);
            groupBoxHeading.PerformLayout();
            tableLayoutHeading.ResumeLayout(false);
            groupCount.ResumeLayout(false);
            groupCount.PerformLayout();
            tableLayoutCount.ResumeLayout(false);
            tableLayoutCount.PerformLayout();
            groupTitle.ResumeLayout(false);
            groupTitle.PerformLayout();
            tableLayoutTitle.ResumeLayout(false);
            tableLayoutTitle.PerformLayout();
            groupSegments.ResumeLayout(false);
            tableLayoutSegments.ResumeLayout(false);
            tableLayoutSegments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSegments)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    private System.Windows.Forms.ComboBox cmbGradientType;
    private System.Windows.Forms.Button btnBackgroundColor2;
    private System.Windows.Forms.Button btnBackgroundColor1;
    private System.Windows.Forms.CheckBox chkTitleFont;
    private System.Windows.Forms.CheckBox chkTitleColor;
    private System.Windows.Forms.Label lblTitleFont;
    private System.Windows.Forms.Button btnTitleFont;
    private System.Windows.Forms.Button btnTitleColor;
    private System.Windows.Forms.CheckBox chkCountFont;
    private System.Windows.Forms.CheckBox chkCountColor;
    private System.Windows.Forms.Label lblCountFont;
    private System.Windows.Forms.Button btnCountFont;
    private System.Windows.Forms.Button btnCountColor;
    private System.Windows.Forms.Button btnDangerColor;
    private System.Windows.Forms.Button btnWarningColor;
    private System.Windows.Forms.Label lblSegmentsFont;
    private System.Windows.Forms.CheckBox chkSegmentsFont;
    private System.Windows.Forms.Button btnSegmentsColor;
    private System.Windows.Forms.CheckBox chkSegmentsColor;
    private System.Windows.Forms.Button btnSegmentsFont;
    private System.Windows.Forms.DataGridView dataGridSegments;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_Name;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_FailRate;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_WarningThreshold;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_DangerThreshold;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_MaxTimeLoss;
}
