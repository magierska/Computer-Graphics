namespace PolygonEditor
{
    partial class PolygonEditorForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineLengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteVertexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawNewPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawingAgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.drawNewPolygonToolStripMenuItem,
            this.drawingAgorithmToolStripMenuItem});
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox, 0, 0);
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
            this.pictureBox.Size = new System.Drawing.Size(978, 581);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewVertexToolStripMenuItem,
            this.lineLengthToolStripMenuItem,
            this.verticalLineToolStripMenuItem,
            this.horizontalLineToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 92);
            // 
            // addNewVertexToolStripMenuItem
            // 
            this.addNewVertexToolStripMenuItem.Name = "addNewVertexToolStripMenuItem";
            this.addNewVertexToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.addNewVertexToolStripMenuItem.Text = "Add new vertex";
            // 
            // lineLengthToolStripMenuItem
            // 
            this.lineLengthToolStripMenuItem.Name = "lineLengthToolStripMenuItem";
            this.lineLengthToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.lineLengthToolStripMenuItem.Text = "Line length";
            // 
            // verticalLineToolStripMenuItem
            // 
            this.verticalLineToolStripMenuItem.Name = "verticalLineToolStripMenuItem";
            this.verticalLineToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.verticalLineToolStripMenuItem.Text = "Vertical line";
            // 
            // horizontalLineToolStripMenuItem
            // 
            this.horizontalLineToolStripMenuItem.Name = "horizontalLineToolStripMenuItem";
            this.horizontalLineToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.horizontalLineToolStripMenuItem.Text = "Horizontal line";
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
            // drawNewPolygonToolStripMenuItem
            // 
            this.drawNewPolygonToolStripMenuItem.Checked = true;
            this.drawNewPolygonToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawNewPolygonToolStripMenuItem.Name = "drawNewPolygonToolStripMenuItem";
            this.drawNewPolygonToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.drawNewPolygonToolStripMenuItem.Text = "Draw new polygon";
            this.drawNewPolygonToolStripMenuItem.Click += new System.EventHandler(this.drawNewPolygonToolStripMenuItem_Click);
            // 
            // drawingAgorithmToolStripMenuItem
            // 
            this.drawingAgorithmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bresenhamToolStripMenuItem,
            this.wuToolStripMenuItem});
            this.drawingAgorithmToolStripMenuItem.Name = "drawingAgorithmToolStripMenuItem";
            this.drawingAgorithmToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.drawingAgorithmToolStripMenuItem.Text = "Drawing agorithm";
            // 
            // bresenhamToolStripMenuItem
            // 
            this.bresenhamToolStripMenuItem.Checked = true;
            this.bresenhamToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bresenhamToolStripMenuItem.Name = "bresenhamToolStripMenuItem";
            this.bresenhamToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bresenhamToolStripMenuItem.Text = "Bresenham";
            this.bresenhamToolStripMenuItem.Click += new System.EventHandler(this.bresenhamToolStripMenuItem_Click);
            // 
            // wuToolStripMenuItem
            // 
            this.wuToolStripMenuItem.Name = "wuToolStripMenuItem";
            this.wuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wuToolStripMenuItem.Text = "Wu";
            this.wuToolStripMenuItem.Click += new System.EventHandler(this.wuToolStripMenuItem_Click);
            // 
            // PolygonEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PolygonEditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Polygon Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem verticalLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineLengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem horizontalLineToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem deleteVertexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawNewPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawingAgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wuToolStripMenuItem;
    }
}

