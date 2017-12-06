namespace PolygonEditor
{
    partial class FillAndCropPolygonForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawNewPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.lightSourceVectorGroupBox = new System.Windows.Forms.GroupBox();
            this.radiusLightSourceVectorTextBox = new System.Windows.Forms.TextBox();
            this.radiusLightSourceVectorRadioButton = new System.Windows.Forms.RadioButton();
            this.constantLightSourceVectorRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.disorderGroupBox = new System.Windows.Forms.GroupBox();
            this.textureDisoderPictureBox = new System.Windows.Forms.PictureBox();
            this.textureDisorderRadioButton = new System.Windows.Forms.RadioButton();
            this.noDisorderRadioButton = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.normalVectorGroupBox = new System.Windows.Forms.GroupBox();
            this.textureVectorPictureBox = new System.Windows.Forms.PictureBox();
            this.textureNormalVectorRadioButton = new System.Windows.Forms.RadioButton();
            this.constantNormalVectorRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lightSourceColorPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.objectColorGroupBox = new System.Windows.Forms.GroupBox();
            this.constantObjectColorPictureBox = new System.Windows.Forms.PictureBox();
            this.textureObjectPictureBox = new System.Windows.Forms.PictureBox();
            this.TextureObjectRadioButton = new System.Windows.Forms.RadioButton();
            this.ConstantObjectRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.fDisorderTextbox = new System.Windows.Forms.TextBox();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blueLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.lightSourceVectorGroupBox.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.disorderGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textureDisoderPictureBox)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            this.normalVectorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textureVectorPictureBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightSourceColorPictureBox)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.objectColorGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constantObjectColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureObjectPictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.drawNewPolygonToolStripMenuItem,
            this.lightToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // drawNewPolygonToolStripMenuItem
            // 
            this.drawNewPolygonToolStripMenuItem.Checked = true;
            this.drawNewPolygonToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawNewPolygonToolStripMenuItem.Name = "drawNewPolygonToolStripMenuItem";
            this.drawNewPolygonToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.drawNewPolygonToolStripMenuItem.Text = "Draw new polygon";
            this.drawNewPolygonToolStripMenuItem.Click += new System.EventHandler(this.drawNewPolygonToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 587);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(3, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(778, 581);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel7, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel6, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(787, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(194, 581);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel7.Controls.Add(this.lightSourceVectorGroupBox, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(4, 467);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(186, 110);
            this.tableLayoutPanel7.TabIndex = 4;
            // 
            // lightSourceVectorGroupBox
            // 
            this.lightSourceVectorGroupBox.Controls.Add(this.radiusLightSourceVectorTextBox);
            this.lightSourceVectorGroupBox.Controls.Add(this.radiusLightSourceVectorRadioButton);
            this.lightSourceVectorGroupBox.Controls.Add(this.constantLightSourceVectorRadioButton);
            this.lightSourceVectorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightSourceVectorGroupBox.Location = new System.Drawing.Point(3, 28);
            this.lightSourceVectorGroupBox.Name = "lightSourceVectorGroupBox";
            this.lightSourceVectorGroupBox.Size = new System.Drawing.Size(180, 79);
            this.lightSourceVectorGroupBox.TabIndex = 0;
            this.lightSourceVectorGroupBox.TabStop = false;
            // 
            // radiusLightSourceVectorTextBox
            // 
            this.radiusLightSourceVectorTextBox.Location = new System.Drawing.Point(112, 55);
            this.radiusLightSourceVectorTextBox.Name = "radiusLightSourceVectorTextBox";
            this.radiusLightSourceVectorTextBox.Size = new System.Drawing.Size(48, 20);
            this.radiusLightSourceVectorTextBox.TabIndex = 2;
            this.radiusLightSourceVectorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radiusLightSourceVectorRadioButton
            // 
            this.radiusLightSourceVectorRadioButton.AutoSize = true;
            this.radiusLightSourceVectorRadioButton.Location = new System.Drawing.Point(15, 32);
            this.radiusLightSourceVectorRadioButton.Name = "radiusLightSourceVectorRadioButton";
            this.radiusLightSourceVectorRadioButton.Size = new System.Drawing.Size(116, 43);
            this.radiusLightSourceVectorRadioButton.TabIndex = 1;
            this.radiusLightSourceVectorRadioButton.TabStop = true;
            this.radiusLightSourceVectorRadioButton.Text = "światło animowane\r\npo sferze\r\no promieniu R = ";
            this.radiusLightSourceVectorRadioButton.UseVisualStyleBackColor = true;
            // 
            // constantLightSourceVectorRadioButton
            // 
            this.constantLightSourceVectorRadioButton.AutoSize = true;
            this.constantLightSourceVectorRadioButton.Checked = true;
            this.constantLightSourceVectorRadioButton.Location = new System.Drawing.Point(15, 9);
            this.constantLightSourceVectorRadioButton.Name = "constantLightSourceVectorRadioButton";
            this.constantLightSourceVectorRadioButton.Size = new System.Drawing.Size(87, 17);
            this.constantLightSourceVectorRadioButton.TabIndex = 0;
            this.constantLightSourceVectorRadioButton.TabStop = true;
            this.constantLightSourceVectorRadioButton.Text = "stały [0; 0; 1]";
            this.constantLightSourceVectorRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Wektor do źródła światła:";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel6.Controls.Add(this.disorderGroupBox, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(4, 294);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(186, 166);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // disorderGroupBox
            // 
            this.disorderGroupBox.Controls.Add(this.fDisorderTextbox);
            this.disorderGroupBox.Controls.Add(this.label6);
            this.disorderGroupBox.Controls.Add(this.textureDisoderPictureBox);
            this.disorderGroupBox.Controls.Add(this.textureDisorderRadioButton);
            this.disorderGroupBox.Controls.Add(this.noDisorderRadioButton);
            this.disorderGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.disorderGroupBox.Location = new System.Drawing.Point(3, 28);
            this.disorderGroupBox.Name = "disorderGroupBox";
            this.disorderGroupBox.Size = new System.Drawing.Size(180, 135);
            this.disorderGroupBox.TabIndex = 0;
            this.disorderGroupBox.TabStop = false;
            // 
            // textureDisoderPictureBox
            // 
            this.textureDisoderPictureBox.BackColor = System.Drawing.Color.White;
            this.textureDisoderPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textureDisoderPictureBox.Location = new System.Drawing.Point(101, 32);
            this.textureDisoderPictureBox.Name = "textureDisoderPictureBox";
            this.textureDisoderPictureBox.Size = new System.Drawing.Size(59, 29);
            this.textureDisoderPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.textureDisoderPictureBox.TabIndex = 2;
            this.textureDisoderPictureBox.TabStop = false;
            // 
            // textureDisorderRadioButton
            // 
            this.textureDisorderRadioButton.AutoSize = true;
            this.textureDisorderRadioButton.Checked = true;
            this.textureDisorderRadioButton.Location = new System.Drawing.Point(15, 32);
            this.textureDisorderRadioButton.Name = "textureDisorderRadioButton";
            this.textureDisorderRadioButton.Size = new System.Drawing.Size(83, 30);
            this.textureDisorderRadioButton.TabIndex = 1;
            this.textureDisorderRadioButton.TabStop = true;
            this.textureDisorderRadioButton.Text = "z tekstury\r\n(HeightMap)";
            this.textureDisorderRadioButton.UseVisualStyleBackColor = true;
            // 
            // noDisorderRadioButton
            // 
            this.noDisorderRadioButton.AutoSize = true;
            this.noDisorderRadioButton.Location = new System.Drawing.Point(15, 9);
            this.noDisorderRadioButton.Name = "noDisorderRadioButton";
            this.noDisorderRadioButton.Size = new System.Drawing.Size(85, 17);
            this.noDisorderRadioButton.TabIndex = 0;
            this.noDisorderRadioButton.TabStop = true;
            this.noDisorderRadioButton.Text = "brak [0; 0; 0]";
            this.noDisorderRadioButton.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Zaburzenie:";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.Controls.Add(this.normalVectorGroupBox, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(4, 178);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(186, 109);
            this.tableLayoutPanel5.TabIndex = 2;
            // 
            // normalVectorGroupBox
            // 
            this.normalVectorGroupBox.Controls.Add(this.textureVectorPictureBox);
            this.normalVectorGroupBox.Controls.Add(this.textureNormalVectorRadioButton);
            this.normalVectorGroupBox.Controls.Add(this.constantNormalVectorRadioButton);
            this.normalVectorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.normalVectorGroupBox.Location = new System.Drawing.Point(3, 28);
            this.normalVectorGroupBox.Name = "normalVectorGroupBox";
            this.normalVectorGroupBox.Size = new System.Drawing.Size(180, 78);
            this.normalVectorGroupBox.TabIndex = 0;
            this.normalVectorGroupBox.TabStop = false;
            // 
            // textureVectorPictureBox
            // 
            this.textureVectorPictureBox.BackColor = System.Drawing.Color.White;
            this.textureVectorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textureVectorPictureBox.Location = new System.Drawing.Point(101, 32);
            this.textureVectorPictureBox.Name = "textureVectorPictureBox";
            this.textureVectorPictureBox.Size = new System.Drawing.Size(59, 29);
            this.textureVectorPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.textureVectorPictureBox.TabIndex = 2;
            this.textureVectorPictureBox.TabStop = false;
            // 
            // textureNormalVectorRadioButton
            // 
            this.textureNormalVectorRadioButton.AutoSize = true;
            this.textureNormalVectorRadioButton.Checked = true;
            this.textureNormalVectorRadioButton.Location = new System.Drawing.Point(15, 32);
            this.textureNormalVectorRadioButton.Name = "textureNormalVectorRadioButton";
            this.textureNormalVectorRadioButton.Size = new System.Drawing.Size(85, 30);
            this.textureNormalVectorRadioButton.TabIndex = 1;
            this.textureNormalVectorRadioButton.TabStop = true;
            this.textureNormalVectorRadioButton.Text = "z tekstury \r\n(NormalMap)";
            this.textureNormalVectorRadioButton.UseVisualStyleBackColor = true;
            // 
            // constantNormalVectorRadioButton
            // 
            this.constantNormalVectorRadioButton.AutoSize = true;
            this.constantNormalVectorRadioButton.Location = new System.Drawing.Point(15, 9);
            this.constantNormalVectorRadioButton.Name = "constantNormalVectorRadioButton";
            this.constantNormalVectorRadioButton.Size = new System.Drawing.Size(87, 17);
            this.constantNormalVectorRadioButton.TabIndex = 0;
            this.constantNormalVectorRadioButton.Text = "stały [0; 0; 1]";
            this.constantNormalVectorRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Wektor normalny:";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lightSourceColorPictureBox, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(186, 51);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kolor źródła swiatła:";
            // 
            // lightSourceColorPictureBox
            // 
            this.lightSourceColorPictureBox.BackColor = System.Drawing.Color.White;
            this.lightSourceColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightSourceColorPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightSourceColorPictureBox.Location = new System.Drawing.Point(3, 28);
            this.lightSourceColorPictureBox.Name = "lightSourceColorPictureBox";
            this.lightSourceColorPictureBox.Size = new System.Drawing.Size(180, 20);
            this.lightSourceColorPictureBox.TabIndex = 1;
            this.lightSourceColorPictureBox.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.objectColorGroupBox, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(4, 62);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(186, 109);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // objectColorGroupBox
            // 
            this.objectColorGroupBox.Controls.Add(this.constantObjectColorPictureBox);
            this.objectColorGroupBox.Controls.Add(this.textureObjectPictureBox);
            this.objectColorGroupBox.Controls.Add(this.TextureObjectRadioButton);
            this.objectColorGroupBox.Controls.Add(this.ConstantObjectRadioButton);
            this.objectColorGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectColorGroupBox.Location = new System.Drawing.Point(3, 28);
            this.objectColorGroupBox.Name = "objectColorGroupBox";
            this.objectColorGroupBox.Size = new System.Drawing.Size(180, 78);
            this.objectColorGroupBox.TabIndex = 0;
            this.objectColorGroupBox.TabStop = false;
            // 
            // constantObjectColorPictureBox
            // 
            this.constantObjectColorPictureBox.BackColor = System.Drawing.Color.White;
            this.constantObjectColorPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.constantObjectColorPictureBox.Location = new System.Drawing.Point(101, 9);
            this.constantObjectColorPictureBox.Name = "constantObjectColorPictureBox";
            this.constantObjectColorPictureBox.Size = new System.Drawing.Size(59, 29);
            this.constantObjectColorPictureBox.TabIndex = 3;
            this.constantObjectColorPictureBox.TabStop = false;
            // 
            // textureObjectPictureBox
            // 
            this.textureObjectPictureBox.BackColor = System.Drawing.Color.White;
            this.textureObjectPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textureObjectPictureBox.Location = new System.Drawing.Point(101, 43);
            this.textureObjectPictureBox.Name = "textureObjectPictureBox";
            this.textureObjectPictureBox.Size = new System.Drawing.Size(59, 29);
            this.textureObjectPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.textureObjectPictureBox.TabIndex = 2;
            this.textureObjectPictureBox.TabStop = false;
            // 
            // TextureObjectRadioButton
            // 
            this.TextureObjectRadioButton.AutoSize = true;
            this.TextureObjectRadioButton.Checked = true;
            this.TextureObjectRadioButton.Location = new System.Drawing.Point(15, 43);
            this.TextureObjectRadioButton.Name = "TextureObjectRadioButton";
            this.TextureObjectRadioButton.Size = new System.Drawing.Size(70, 17);
            this.TextureObjectRadioButton.TabIndex = 1;
            this.TextureObjectRadioButton.TabStop = true;
            this.TextureObjectRadioButton.Text = "z tekstury";
            this.TextureObjectRadioButton.UseVisualStyleBackColor = true;
            // 
            // ConstantObjectRadioButton
            // 
            this.ConstantObjectRadioButton.AutoSize = true;
            this.ConstantObjectRadioButton.Location = new System.Drawing.Point(15, 9);
            this.ConstantObjectRadioButton.Name = "ConstantObjectRadioButton";
            this.ConstantObjectRadioButton.Size = new System.Drawing.Size(48, 17);
            this.ConstantObjectRadioButton.TabIndex = 0;
            this.ConstantObjectRadioButton.Text = "stały";
            this.ConstantObjectRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kolor obiektu:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewVertexToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 26);
            // 
            // addNewVertexToolStripMenuItem
            // 
            this.addNewVertexToolStripMenuItem.Name = "addNewVertexToolStripMenuItem";
            this.addNewVertexToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addNewVertexToolStripMenuItem.Text = "Add new vertex";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteVertexToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(142, 26);
            // 
            // deleteVertexToolStripMenuItem
            // 
            this.deleteVertexToolStripMenuItem.Name = "deleteVertexToolStripMenuItem";
            this.deleteVertexToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.deleteVertexToolStripMenuItem.Text = "Delete vertex";
            this.deleteVertexToolStripMenuItem.Click += new System.EventHandler(this.deleteVertexToolStripMenuItem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Współczynnik zaburzenia f:";
            // 
            // fDisorderTextbox
            // 
            this.fDisorderTextbox.Location = new System.Drawing.Point(42, 97);
            this.fDisorderTextbox.Name = "fDisorderTextbox";
            this.fDisorderTextbox.Size = new System.Drawing.Size(79, 20);
            this.fDisorderTextbox.TabIndex = 4;
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.redLightToolStripMenuItem,
            this.greenLightToolStripMenuItem,
            this.blueLightToolStripMenuItem});
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.lightToolStripMenuItem.Text = "Light";
            // 
            // redLightToolStripMenuItem
            // 
            this.redLightToolStripMenuItem.Checked = true;
            this.redLightToolStripMenuItem.CheckOnClick = true;
            this.redLightToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.redLightToolStripMenuItem.Name = "redLightToolStripMenuItem";
            this.redLightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redLightToolStripMenuItem.Text = "Red light";
            // 
            // greenLightToolStripMenuItem
            // 
            this.greenLightToolStripMenuItem.Checked = true;
            this.greenLightToolStripMenuItem.CheckOnClick = true;
            this.greenLightToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.greenLightToolStripMenuItem.Name = "greenLightToolStripMenuItem";
            this.greenLightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.greenLightToolStripMenuItem.Text = "Green light";
            // 
            // blueLightToolStripMenuItem
            // 
            this.blueLightToolStripMenuItem.Checked = true;
            this.blueLightToolStripMenuItem.CheckOnClick = true;
            this.blueLightToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.blueLightToolStripMenuItem.Name = "blueLightToolStripMenuItem";
            this.blueLightToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blueLightToolStripMenuItem.Text = "Blue light";
            // 
            // FillAndClipPolygonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FillAndClipPolygonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polygon Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.lightSourceVectorGroupBox.ResumeLayout(false);
            this.lightSourceVectorGroupBox.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.disorderGroupBox.ResumeLayout(false);
            this.disorderGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textureDisoderPictureBox)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.normalVectorGroupBox.ResumeLayout(false);
            this.normalVectorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textureVectorPictureBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightSourceColorPictureBox)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.objectColorGroupBox.ResumeLayout(false);
            this.objectColorGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.constantObjectColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textureObjectPictureBox)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewVertexToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem deleteVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawNewPolygonToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.GroupBox disorderGroupBox;
        private System.Windows.Forms.PictureBox textureDisoderPictureBox;
        private System.Windows.Forms.RadioButton textureDisorderRadioButton;
        private System.Windows.Forms.RadioButton noDisorderRadioButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.GroupBox normalVectorGroupBox;
        private System.Windows.Forms.PictureBox textureVectorPictureBox;
        private System.Windows.Forms.RadioButton textureNormalVectorRadioButton;
        private System.Windows.Forms.RadioButton constantNormalVectorRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox lightSourceColorPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.GroupBox objectColorGroupBox;
        private System.Windows.Forms.PictureBox constantObjectColorPictureBox;
        private System.Windows.Forms.PictureBox textureObjectPictureBox;
        private System.Windows.Forms.RadioButton TextureObjectRadioButton;
        private System.Windows.Forms.RadioButton ConstantObjectRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.GroupBox lightSourceVectorGroupBox;
        private System.Windows.Forms.TextBox radiusLightSourceVectorTextBox;
        private System.Windows.Forms.RadioButton radiusLightSourceVectorRadioButton;
        private System.Windows.Forms.RadioButton constantLightSourceVectorRadioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fDisorderTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redLightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenLightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blueLightToolStripMenuItem;
    }
}

