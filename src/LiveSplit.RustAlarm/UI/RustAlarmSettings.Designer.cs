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
            this.tableLayoutSettings = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutBackground = new System.Windows.Forms.TableLayoutPanel();
            this.cmbGradientType = new System.Windows.Forms.ComboBox();
            this.btnBackgroundColor2 = new System.Windows.Forms.Button();
            this.btnBackgroundColor1 = new System.Windows.Forms.Button();
            this.lblBackgroundColor = new System.Windows.Forms.Label();
            this.groupBoxHeading = new System.Windows.Forms.GroupBox();
            this.tableLayoutHeading = new System.Windows.Forms.TableLayoutPanel();
            this.groupTitle = new System.Windows.Forms.GroupBox();
            this.tableLayoutTitle = new System.Windows.Forms.TableLayoutPanel();
            this.chkTitleFont = new System.Windows.Forms.CheckBox();
            this.chkTitleColor = new System.Windows.Forms.CheckBox();
            this.chkTitleText = new System.Windows.Forms.CheckBox();
            this.lblTitleFont = new System.Windows.Forms.Label();
            this.btnTitleFont = new System.Windows.Forms.Button();
            this.btnTitleColor = new System.Windows.Forms.Button();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.groupCount = new System.Windows.Forms.GroupBox();
            this.tableLayoutCount = new System.Windows.Forms.TableLayoutPanel();
            this.chkCountFont = new System.Windows.Forms.CheckBox();
            this.chkCountColor = new System.Windows.Forms.CheckBox();
            this.lblCountFont = new System.Windows.Forms.Label();
            this.btnCountFont = new System.Windows.Forms.Button();
            this.btnCountColor = new System.Windows.Forms.Button();
            this.groupThresholdColors = new System.Windows.Forms.GroupBox();
            this.tableLayoutThresholds = new System.Windows.Forms.TableLayoutPanel();
            this.lblWarningColor = new System.Windows.Forms.Label();
            this.lblThresholdColor1 = new System.Windows.Forms.Label();
            this.btnDangerColor = new System.Windows.Forms.Button();
            this.groupSegments = new System.Windows.Forms.GroupBox();
            this.tableLayoutSegments = new System.Windows.Forms.TableLayoutPanel();
            this.btnWarningColor = new System.Windows.Forms.Button();
            this.chkSegmentsFont = new System.Windows.Forms.CheckBox();
            this.lblSegmentsFont = new System.Windows.Forms.Label();
            this.btnSegmentsFont = new System.Windows.Forms.Button();
            this.chkSegmentsColor = new System.Windows.Forms.CheckBox();
            this.btnSegmentsColor = new System.Windows.Forms.Button();
            this.dataGridSegments = new System.Windows.Forms.DataGridView();
            this.dataGridSegments_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSegments_ExpectedSuccessRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSegments_MaxTimeLoss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSegments_WarningThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridSegments_DangerThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutSettings.SuspendLayout();
            this.tableLayoutBackground.SuspendLayout();
            this.groupBoxHeading.SuspendLayout();
            this.tableLayoutHeading.SuspendLayout();
            this.groupTitle.SuspendLayout();
            this.tableLayoutTitle.SuspendLayout();
            this.groupCount.SuspendLayout();
            this.tableLayoutCount.SuspendLayout();
            this.groupThresholdColors.SuspendLayout();
            this.tableLayoutThresholds.SuspendLayout();
            this.groupSegments.SuspendLayout();
            this.tableLayoutSegments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSegments)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutSettings
            // 
            this.tableLayoutSettings.ColumnCount = 1;
            this.tableLayoutSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSettings.Controls.Add(this.tableLayoutBackground, 0, 3);
            this.tableLayoutSettings.Controls.Add(this.groupThresholdColors, 0, 1);
            this.tableLayoutSettings.Controls.Add(this.groupBoxHeading, 0, 2);
            this.tableLayoutSettings.Controls.Add(this.groupSegments, 0, 0);
            this.tableLayoutSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSettings.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutSettings.Name = "tableLayoutSettings";
            this.tableLayoutSettings.RowCount = 4;
            this.tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutSettings.Size = new System.Drawing.Size(459, 769);
            this.tableLayoutSettings.TabIndex = 0;
            // 
            // tableLayoutBackground
            // 
            this.tableLayoutBackground.AutoSize = true;
            this.tableLayoutBackground.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutBackground.ColumnCount = 4;
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutBackground.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tableLayoutBackground.Controls.Add(this.cmbGradientType, 3, 0);
            this.tableLayoutBackground.Controls.Add(this.btnBackgroundColor2, 1, 0);
            this.tableLayoutBackground.Controls.Add(this.btnBackgroundColor1, 2, 0);
            this.tableLayoutBackground.Controls.Add(this.lblBackgroundColor, 0, 0);
            this.tableLayoutBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutBackground.Location = new System.Drawing.Point(3, 737);
            this.tableLayoutBackground.Name = "tableLayoutBackground";
            this.tableLayoutBackground.RowCount = 1;
            this.tableLayoutBackground.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutBackground.Size = new System.Drawing.Size(453, 29);
            this.tableLayoutBackground.TabIndex = 0;
            // 
            // cmbGradientType
            // 
            this.cmbGradientType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGradientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGradientType.FormattingEnabled = true;
            this.cmbGradientType.Location = new System.Drawing.Point(220, 4);
            this.cmbGradientType.Name = "cmbGradientType";
            this.cmbGradientType.Size = new System.Drawing.Size(230, 21);
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
            this.lblBackgroundColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBackgroundColor.AutoSize = true;
            this.lblBackgroundColor.Location = new System.Drawing.Point(3, 8);
            this.lblBackgroundColor.Name = "lblBackgroundColor";
            this.lblBackgroundColor.Size = new System.Drawing.Size(153, 13);
            this.lblBackgroundColor.TabIndex = 3;
            this.lblBackgroundColor.Text = "Background Color:";
            // 
            // groupBoxHeading
            // 
            this.groupBoxHeading.Controls.Add(this.tableLayoutHeading);
            this.groupBoxHeading.Location = new System.Drawing.Point(3, 514);
            this.groupBoxHeading.Name = "groupBoxHeading";
            this.groupBoxHeading.Size = new System.Drawing.Size(453, 217);
            this.groupBoxHeading.TabIndex = 1;
            this.groupBoxHeading.TabStop = false;
            this.groupBoxHeading.Text = "Heading";
            // 
            // tableLayoutHeading
            // 
            this.tableLayoutHeading.AutoSize = true;
            this.tableLayoutHeading.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutHeading.ColumnCount = 1;
            this.tableLayoutHeading.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutHeading.Controls.Add(this.groupCount, 0, 1);
            this.tableLayoutHeading.Controls.Add(this.groupTitle, 0, 0);
            this.tableLayoutHeading.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutHeading.Name = "tableLayoutHeading";
            this.tableLayoutHeading.RowCount = 2;
            this.tableLayoutHeading.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutHeading.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutHeading.Size = new System.Drawing.Size(448, 198);
            this.tableLayoutHeading.TabIndex = 0;
            // 
            // groupTitle
            // 
            this.groupTitle.Controls.Add(this.tableLayoutTitle);
            this.groupTitle.Location = new System.Drawing.Point(3, 3);
            this.groupTitle.Name = "groupTitle";
            this.groupTitle.Size = new System.Drawing.Size(442, 109);
            this.groupTitle.TabIndex = 0;
            this.groupTitle.TabStop = false;
            this.groupTitle.Text = "Title";
            // 
            // tableLayoutTitle
            // 
            this.tableLayoutTitle.AutoSize = true;
            this.tableLayoutTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutTitle.ColumnCount = 3;
            this.tableLayoutTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            this.tableLayoutTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutTitle.Controls.Add(this.chkTitleFont, 0, 0);
            this.tableLayoutTitle.Controls.Add(this.chkTitleColor, 0, 1);
            this.tableLayoutTitle.Controls.Add(this.chkTitleText, 0, 2);
            this.tableLayoutTitle.Controls.Add(this.lblTitleFont, 1, 0);
            this.tableLayoutTitle.Controls.Add(this.btnTitleFont, 2, 0);
            this.tableLayoutTitle.Controls.Add(this.btnTitleColor, 1, 1);
            this.tableLayoutTitle.Controls.Add(this.txtTitle, 1, 2);
            this.tableLayoutTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutTitle.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutTitle.Name = "tableLayoutTitle";
            this.tableLayoutTitle.RowCount = 3;
            this.tableLayoutTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutTitle.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutTitle.Size = new System.Drawing.Size(436, 90);
            this.tableLayoutTitle.TabIndex = 0;
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
            // chkTitleText
            // 
            this.chkTitleText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkTitleText.AutoSize = true;
            this.chkTitleText.Location = new System.Drawing.Point(3, 65);
            this.chkTitleText.Name = "chkTitleText";
            this.chkTitleText.Size = new System.Drawing.Size(50, 17);
            this.chkTitleText.TabIndex = 2;
            this.chkTitleText.Text = "Text:";
            this.chkTitleText.UseVisualStyleBackColor = true;
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
            this.btnTitleFont.Size = new System.Drawing.Size(69, 23);
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
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutTitle.SetColumnSpan(this.txtTitle, 2);
            this.txtTitle.Enabled = false;
            this.txtTitle.Location = new System.Drawing.Point(62, 64);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(372, 20);
            this.txtTitle.TabIndex = 6;
            // 
            // groupCount
            // 
            this.groupCount.Controls.Add(this.tableLayoutCount);
            this.groupCount.Location = new System.Drawing.Point(3, 118);
            this.groupCount.Name = "groupCount";
            this.groupCount.Size = new System.Drawing.Size(442, 77);
            this.groupCount.TabIndex = 1;
            this.groupCount.TabStop = false;
            this.groupCount.Text = "Count";
            // 
            // tableLayoutCount
            // 
            this.tableLayoutCount.AutoSize = true;
            this.tableLayoutCount.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutCount.ColumnCount = 3;
            this.tableLayoutCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            this.tableLayoutCount.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutCount.Controls.Add(this.chkCountFont, 0, 0);
            this.tableLayoutCount.Controls.Add(this.chkCountColor, 0, 1);
            this.tableLayoutCount.Controls.Add(this.lblCountFont, 1, 0);
            this.tableLayoutCount.Controls.Add(this.btnCountFont, 2, 0);
            this.tableLayoutCount.Controls.Add(this.btnCountColor, 1, 1);
            this.tableLayoutCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutCount.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutCount.Name = "tableLayoutCount";
            this.tableLayoutCount.RowCount = 2;
            this.tableLayoutCount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutCount.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutCount.Size = new System.Drawing.Size(436, 58);
            this.tableLayoutCount.TabIndex = 0;
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
            this.btnCountFont.Size = new System.Drawing.Size(69, 23);
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
            // groupThresholdColors
            // 
            this.groupThresholdColors.Controls.Add(this.tableLayoutThresholds);
            this.groupThresholdColors.Location = new System.Drawing.Point(3, 430);
            this.groupThresholdColors.Name = "groupThresholdColors";
            this.groupThresholdColors.Size = new System.Drawing.Size(453, 78);
            this.groupThresholdColors.TabIndex = 2;
            this.groupThresholdColors.TabStop = false;
            this.groupThresholdColors.Text = "Threshold Colors";
            // 
            // tableLayoutThresholds
            // 
            this.tableLayoutThresholds.AutoSize = true;
            this.tableLayoutThresholds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutThresholds.ColumnCount = 2;
            this.tableLayoutThresholds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutThresholds.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tableLayoutThresholds.Controls.Add(this.btnWarningColor, 1, 0);
            this.tableLayoutThresholds.Controls.Add(this.lblWarningColor, 0, 0);
            this.tableLayoutThresholds.Controls.Add(this.lblThresholdColor1, 0, 1);
            this.tableLayoutThresholds.Controls.Add(this.btnDangerColor, 1, 1);
            this.tableLayoutThresholds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutThresholds.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutThresholds.Name = "tableLayoutThresholds";
            this.tableLayoutThresholds.RowCount = 2;
            this.tableLayoutThresholds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutThresholds.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutThresholds.Size = new System.Drawing.Size(447, 59);
            this.tableLayoutThresholds.TabIndex = 0;
            // 
            // lblWarningColor
            // 
            this.lblWarningColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarningColor.AutoSize = true;
            this.lblWarningColor.Location = new System.Drawing.Point(3, 8);
            this.lblWarningColor.Name = "lblWarningColor";
            this.lblWarningColor.Size = new System.Drawing.Size(50, 13);
            this.lblWarningColor.TabIndex = 0;
            this.lblWarningColor.Text = "Warning:";
            // 
            // lblThresholdColor1
            // 
            this.lblThresholdColor1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThresholdColor1.AutoSize = true;
            this.lblThresholdColor1.Location = new System.Drawing.Point(3, 37);
            this.lblThresholdColor1.Name = "lblThresholdColor1";
            this.lblThresholdColor1.Size = new System.Drawing.Size(50, 13);
            this.lblThresholdColor1.TabIndex = 2;
            this.lblThresholdColor1.Text = "Danger:";
            // 
            // btnDangerColor
            // 
            this.btnDangerColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDangerColor.BackColor = System.Drawing.Color.Red;
            this.btnDangerColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDangerColor.Location = new System.Drawing.Point(59, 32);
            this.btnDangerColor.Name = "btnDangerColor";
            this.btnDangerColor.Size = new System.Drawing.Size(23, 23);
            this.btnDangerColor.TabIndex = 6;
            this.btnDangerColor.UseVisualStyleBackColor = false;
            // 
            // groupSegments
            // 
            this.groupSegments.Controls.Add(this.tableLayoutSegments);
            this.groupSegments.Location = new System.Drawing.Point(3, 3);
            this.groupSegments.Name = "groupSegments";
            this.groupSegments.Size = new System.Drawing.Size(453, 421);
            this.groupSegments.TabIndex = 3;
            this.groupSegments.TabStop = false;
            this.groupSegments.Text = "Segments";
            // 
            // tableLayoutSegments
            // 
            this.tableLayoutSegments.ColumnCount = 3;
            this.tableLayoutSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 314F));
            this.tableLayoutSegments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutSegments.Controls.Add(this.btnSegmentsColor, 1, 2);
            this.tableLayoutSegments.Controls.Add(this.chkSegmentsColor, 0, 2);
            this.tableLayoutSegments.Controls.Add(this.btnSegmentsFont, 2, 1);
            this.tableLayoutSegments.Controls.Add(this.lblSegmentsFont, 1, 1);
            this.tableLayoutSegments.Controls.Add(this.chkSegmentsFont, 0, 1);
            this.tableLayoutSegments.Controls.Add(this.dataGridSegments, 0, 0);
            this.tableLayoutSegments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutSegments.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutSegments.Name = "tableLayoutSegments";
            this.tableLayoutSegments.RowCount = 3;
            this.tableLayoutSegments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutSegments.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSegments.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutSegments.Size = new System.Drawing.Size(447, 402);
            this.tableLayoutSegments.TabIndex = 0;
            // 
            // btnWarningColor
            // 
            this.btnWarningColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnWarningColor.BackColor = System.Drawing.Color.Yellow;
            this.btnWarningColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWarningColor.Location = new System.Drawing.Point(59, 3);
            this.btnWarningColor.Name = "btnWarningColor";
            this.btnWarningColor.Size = new System.Drawing.Size(23, 23);
            this.btnWarningColor.TabIndex = 7;
            this.btnWarningColor.UseVisualStyleBackColor = false;
            // 
            // chkSegmentsFont
            // 
            this.chkSegmentsFont.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkSegmentsFont.AutoSize = true;
            this.chkSegmentsFont.Location = new System.Drawing.Point(3, 350);
            this.chkSegmentsFont.Name = "chkSegmentsFont";
            this.chkSegmentsFont.Size = new System.Drawing.Size(50, 17);
            this.chkSegmentsFont.TabIndex = 1;
            this.chkSegmentsFont.Text = "Font:";
            this.chkSegmentsFont.UseVisualStyleBackColor = true;
            // 
            // lblSegmentsFont
            // 
            this.lblSegmentsFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSegmentsFont.AutoSize = true;
            this.lblSegmentsFont.Location = new System.Drawing.Point(62, 352);
            this.lblSegmentsFont.Name = "lblSegmentsFont";
            this.lblSegmentsFont.Size = new System.Drawing.Size(308, 13);
            this.lblSegmentsFont.TabIndex = 4;
            // 
            // btnSegmentsFont
            // 
            this.btnSegmentsFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSegmentsFont.Enabled = false;
            this.btnSegmentsFont.Location = new System.Drawing.Point(376, 347);
            this.btnSegmentsFont.Name = "btnSegmentsFont";
            this.btnSegmentsFont.Size = new System.Drawing.Size(69, 23);
            this.btnSegmentsFont.TabIndex = 5;
            this.btnSegmentsFont.Text = "Choose...";
            this.btnSegmentsFont.UseVisualStyleBackColor = true;
            // 
            // chkSegmentsColor
            // 
            this.chkSegmentsColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chkSegmentsColor.AutoSize = true;
            this.chkSegmentsColor.Location = new System.Drawing.Point(3, 379);
            this.chkSegmentsColor.Name = "chkSegmentsColor";
            this.chkSegmentsColor.Size = new System.Drawing.Size(53, 17);
            this.chkSegmentsColor.TabIndex = 6;
            this.chkSegmentsColor.Text = "Color:";
            this.chkSegmentsColor.UseVisualStyleBackColor = true;
            // 
            // btnSegmentsColor
            // 
            this.btnSegmentsColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSegmentsColor.BackColor = System.Drawing.Color.White;
            this.btnSegmentsColor.Enabled = false;
            this.btnSegmentsColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSegmentsColor.Location = new System.Drawing.Point(62, 376);
            this.btnSegmentsColor.Name = "btnSegmentsColor";
            this.btnSegmentsColor.Size = new System.Drawing.Size(23, 23);
            this.btnSegmentsColor.TabIndex = 7;
            this.btnSegmentsColor.UseVisualStyleBackColor = false;
            // 
            // dataGridSegments
            // 
            this.dataGridSegments.AllowUserToAddRows = false;
            this.dataGridSegments.AllowUserToDeleteRows = false;
            this.dataGridSegments.AllowUserToResizeRows = false;
            this.dataGridSegments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSegments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridSegments_Name,
            this.dataGridSegments_ExpectedSuccessRate,
            this.dataGridSegments_MaxTimeLoss,
            this.dataGridSegments_WarningThreshold,
            this.dataGridSegments_DangerThreshold});
            this.tableLayoutSegments.SetColumnSpan(this.dataGridSegments, 3);
            this.dataGridSegments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridSegments.Location = new System.Drawing.Point(3, 3);
            this.dataGridSegments.MultiSelect = false;
            this.dataGridSegments.Name = "dataGridSegments";
            this.dataGridSegments.RowHeadersVisible = false;
            this.dataGridSegments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridSegments.Size = new System.Drawing.Size(442, 338);
            this.dataGridSegments.TabIndex = 8;
            // 
            // dataGridSegments_Name
            // 
            this.dataGridSegments_Name.Frozen = true;
            this.dataGridSegments_Name.HeaderText = "Segment";
            this.dataGridSegments_Name.Name = "dataGridSegments_Name";
            this.dataGridSegments_Name.ReadOnly = true;
            this.dataGridSegments_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_Name.Width = 114;
            // 
            // dataGridSegments_ExpectedSuccessRate
            // 
            this.dataGridSegments_ExpectedSuccessRate.HeaderText = "Success %";
            this.dataGridSegments_ExpectedSuccessRate.Name = "dataGridSegments_ExpectedSuccessRate";
            this.dataGridSegments_ExpectedSuccessRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_ExpectedSuccessRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_ExpectedSuccessRate.ToolTipText = "How often do you expect to succeed in this segment?";
            this.dataGridSegments_ExpectedSuccessRate.Width = 85;
            // 
            // dataGridSegments_MaxTimeLoss
            // 
            this.dataGridSegments_MaxTimeLoss.HeaderText = "Max Time Loss";
            this.dataGridSegments_MaxTimeLoss.Name = "dataGridSegments_MaxTimeLoss";
            this.dataGridSegments_MaxTimeLoss.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_MaxTimeLoss.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_MaxTimeLoss.ToolTipText = "How much time loss are you willing to accept in this segment?";
            this.dataGridSegments_MaxTimeLoss.Width = 80;
            // 
            // dataGridSegments_WarningThreshold
            // 
            this.dataGridSegments_WarningThreshold.HeaderText = "Warning Threshold";
            this.dataGridSegments_WarningThreshold.Name = "dataGridSegments_WarningThreshold";
            this.dataGridSegments_WarningThreshold.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_WarningThreshold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_WarningThreshold.ToolTipText = "The number of back-to-back failures required to flag this segment at the \"Warning" +
    "\" level.";
            this.dataGridSegments_WarningThreshold.Width = 80;
            // 
            // dataGridSegments_DangerThreshold
            // 
            this.dataGridSegments_DangerThreshold.HeaderText = "Danger Threshold";
            this.dataGridSegments_DangerThreshold.Name = "dataGridSegments_DangerThreshold";
            this.dataGridSegments_DangerThreshold.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridSegments_DangerThreshold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridSegments_DangerThreshold.ToolTipText = "The number of back-to-back failures required to flag this segment at the \"Danger\"" +
    " level.";
            this.dataGridSegments_DangerThreshold.Width = 80;
            // 
            // RustAlarmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutSettings);
            this.Name = "RustAlarmSettings";
            this.Size = new System.Drawing.Size(459, 769);
            this.tableLayoutSettings.ResumeLayout(false);
            this.tableLayoutSettings.PerformLayout();
            this.tableLayoutBackground.ResumeLayout(false);
            this.tableLayoutBackground.PerformLayout();
            this.groupBoxHeading.ResumeLayout(false);
            this.groupBoxHeading.PerformLayout();
            this.tableLayoutHeading.ResumeLayout(false);
            this.groupTitle.ResumeLayout(false);
            this.groupTitle.PerformLayout();
            this.tableLayoutTitle.ResumeLayout(false);
            this.tableLayoutTitle.PerformLayout();
            this.groupCount.ResumeLayout(false);
            this.groupCount.PerformLayout();
            this.tableLayoutCount.ResumeLayout(false);
            this.tableLayoutCount.PerformLayout();
            this.groupThresholdColors.ResumeLayout(false);
            this.groupThresholdColors.PerformLayout();
            this.tableLayoutThresholds.ResumeLayout(false);
            this.tableLayoutThresholds.PerformLayout();
            this.groupSegments.ResumeLayout(false);
            this.tableLayoutSegments.ResumeLayout(false);
            this.tableLayoutSegments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSegments)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutSettings;
    private System.Windows.Forms.TableLayoutPanel tableLayoutBackground;
    private System.Windows.Forms.ComboBox cmbGradientType;
    private System.Windows.Forms.Button btnBackgroundColor2;
    private System.Windows.Forms.Button btnBackgroundColor1;
    private System.Windows.Forms.Label lblBackgroundColor;
    private System.Windows.Forms.GroupBox groupBoxHeading;
    private System.Windows.Forms.TableLayoutPanel tableLayoutHeading;
    private System.Windows.Forms.GroupBox groupTitle;
    private System.Windows.Forms.TableLayoutPanel tableLayoutTitle;
    private System.Windows.Forms.CheckBox chkTitleFont;
    private System.Windows.Forms.CheckBox chkTitleColor;
    private System.Windows.Forms.CheckBox chkTitleText;
    private System.Windows.Forms.Label lblTitleFont;
    private System.Windows.Forms.Button btnTitleFont;
    private System.Windows.Forms.Button btnTitleColor;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.GroupBox groupCount;
    private System.Windows.Forms.TableLayoutPanel tableLayoutCount;
    private System.Windows.Forms.CheckBox chkCountFont;
    private System.Windows.Forms.CheckBox chkCountColor;
    private System.Windows.Forms.Label lblCountFont;
    private System.Windows.Forms.Button btnCountFont;
    private System.Windows.Forms.Button btnCountColor;
    private System.Windows.Forms.GroupBox groupThresholdColors;
    private System.Windows.Forms.TableLayoutPanel tableLayoutThresholds;
    private System.Windows.Forms.Label lblWarningColor;
    private System.Windows.Forms.Button btnDangerColor;
    private System.Windows.Forms.Label lblThresholdColor1;
    private System.Windows.Forms.GroupBox groupSegments;
    private System.Windows.Forms.TableLayoutPanel tableLayoutSegments;
    private System.Windows.Forms.Button btnWarningColor;
    private System.Windows.Forms.Label lblSegmentsFont;
    private System.Windows.Forms.CheckBox chkSegmentsFont;
    private System.Windows.Forms.Button btnSegmentsColor;
    private System.Windows.Forms.CheckBox chkSegmentsColor;
    private System.Windows.Forms.Button btnSegmentsFont;
    private System.Windows.Forms.DataGridView dataGridSegments;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_Name;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_ExpectedSuccessRate;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_MaxTimeLoss;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_WarningThreshold;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridSegments_DangerThreshold;
}
