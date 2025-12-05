namespace FBZapp
{
    partial class FantasyBzaarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FantasyBzaarForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pictureSearch = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.signInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.logInToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvComics = new System.Windows.Forms.DataGridView();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.cmbGroupBy = new System.Windows.Forms.ComboBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtAuthorFilter = new System.Windows.Forms.TextBox();
            this.pnlAdvancedSearch = new System.Windows.Forms.Panel();
            this.btnAdvanced = new System.Windows.Forms.Button();
            this.numYearTo = new System.Windows.Forms.NumericUpDown();
            this.numYearFrom = new System.Windows.Forms.NumericUpDown();
            this.txtPublisherFilter = new System.Windows.Forms.TextBox();
            this.btnApplyAdvancedSearch = new System.Windows.Forms.Button();
            this.btnSaved = new System.Windows.Forms.Button();
            this.pnlReports = new System.Windows.Forms.Panel();
            this.lblReportsTitle = new System.Windows.Forms.Label();
            this.lblTopQueries = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.lblTopResults = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.btnPopularComics = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.btnReports = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearch)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComics)).BeginInit();
            this.pnlAdvancedSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearFrom)).BeginInit();
            this.pnlReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.FloralWhite;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1090, 70);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightYellow;
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.pictureSearch);
            this.panel2.Location = new System.Drawing.Point(628, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(346, 38);
            this.panel2.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.ForeColor = System.Drawing.Color.Gray;
            this.txtSearch.Location = new System.Drawing.Point(3, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(293, 32);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Author | Year | Publisher\r\n";
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // pictureSearch
            // 
            this.pictureSearch.Image = ((System.Drawing.Image)(resources.GetObject("pictureSearch.Image")));
            this.pictureSearch.Location = new System.Drawing.Point(300, 2);
            this.pictureSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pictureSearch.Name = "pictureSearch";
            this.pictureSearch.Size = new System.Drawing.Size(44, 36);
            this.pictureSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSearch.TabIndex = 0;
            this.pictureSearch.TabStop = false;
            this.pictureSearch.Click += new System.EventHandler(this.pictureSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Uighur", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(272, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "\"Fantasy B\'zaar (FBZ)\"";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem,
            this.signInToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 68);
            // 
            // logInToolStripMenuItem
            // 
            this.logInToolStripMenuItem.Name = "logInToolStripMenuItem";
            this.logInToolStripMenuItem.Size = new System.Drawing.Size(138, 32);
            this.logInToolStripMenuItem.Text = "Log in";
            // 
            // signInToolStripMenuItem
            // 
            this.signInToolStripMenuItem.Name = "signInToolStripMenuItem";
            this.signInToolStripMenuItem.Size = new System.Drawing.Size(138, 32);
            this.signInToolStripMenuItem.Text = "Sign in";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem1,
            this.signInToolStripMenuItem1});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(137, 68);
            // 
            // logInToolStripMenuItem1
            // 
            this.logInToolStripMenuItem1.Name = "logInToolStripMenuItem1";
            this.logInToolStripMenuItem1.Size = new System.Drawing.Size(136, 32);
            this.logInToolStripMenuItem1.Text = "log in";
            // 
            // signInToolStripMenuItem1
            // 
            this.signInToolStripMenuItem1.Name = "signInToolStripMenuItem1";
            this.signInToolStripMenuItem1.Size = new System.Drawing.Size(136, 32);
            this.signInToolStripMenuItem1.Text = "sign in";
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip5
            // 
            this.contextMenuStrip5.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logInToolStripMenuItem2});
            this.contextMenuStrip5.Name = "contextMenuStrip5";
            this.contextMenuStrip5.Size = new System.Drawing.Size(130, 36);
            // 
            // logInToolStripMenuItem2
            // 
            this.logInToolStripMenuItem2.Name = "logInToolStripMenuItem2";
            this.logInToolStripMenuItem2.Size = new System.Drawing.Size(129, 32);
            this.logInToolStripMenuItem2.Text = "log in";
            // 
            // dgvComics
            // 
            this.dgvComics.AllowUserToAddRows = false;
            this.dgvComics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvComics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComics.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvComics.Location = new System.Drawing.Point(188, 300);
            this.dgvComics.MultiSelect = false;
            this.dgvComics.Name = "dgvComics";
            this.dgvComics.ReadOnly = true;
            this.dgvComics.RowHeadersWidth = 62;
            this.dgvComics.RowTemplate.Height = 28;
            this.dgvComics.Size = new System.Drawing.Size(600, 400);
            this.dgvComics.TabIndex = 5;
            this.dgvComics.Visible = false;
            this.dgvComics.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvComics_CellClick);
            // 
            // cmbGenre
            // 
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Items.AddRange(new object[] {
            "All",
            "Fantasy",
            "Horror",
            "Science Fiction"});
            this.cmbGenre.Location = new System.Drawing.Point(232, 83);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(140, 34);
            this.cmbGenre.TabIndex = 6;
            this.cmbGenre.SelectedIndexChanged += new System.EventHandler(this.cmbGroupBy_SelectedIndexChanged);
            // 
            // cmbGroupBy
            // 
            this.cmbGroupBy.FormattingEnabled = true;
            this.cmbGroupBy.Items.AddRange(new object[] {
            "None",
            "Author",
            "Year"});
            this.cmbGroupBy.Location = new System.Drawing.Point(232, 143);
            this.cmbGroupBy.Name = "cmbGroupBy";
            this.cmbGroupBy.Size = new System.Drawing.Size(140, 34);
            this.cmbGroupBy.TabIndex = 7;
            this.cmbGroupBy.SelectedIndexChanged += new System.EventHandler(this.cmbGroupBy_SelectedIndexChanged);
            // 
            // cmbSort
            // 
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "A-z",
            "Z-A"});
            this.cmbSort.Location = new System.Drawing.Point(232, 194);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(140, 34);
            this.cmbSort.TabIndex = 8;
            // 
            // btnClear
            // 
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(12, 336);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(140, 34);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtAuthorFilter
            // 
            this.txtAuthorFilter.Location = new System.Drawing.Point(12, 73);
            this.txtAuthorFilter.Name = "txtAuthorFilter";
            this.txtAuthorFilter.Size = new System.Drawing.Size(140, 32);
            this.txtAuthorFilter.TabIndex = 2;
            this.txtAuthorFilter.Text = "Author\r\n";
            this.txtAuthorFilter.Enter += new System.EventHandler(this.txtAuthorFilter_Enter);
            this.txtAuthorFilter.Leave += new System.EventHandler(this.txtAuthorFilter_Leave);
            // 
            // pnlAdvancedSearch
            // 
            this.pnlAdvancedSearch.BackColor = System.Drawing.Color.LightGray;
            this.pnlAdvancedSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdvancedSearch.Controls.Add(this.btnAdvanced);
            this.pnlAdvancedSearch.Controls.Add(this.numYearTo);
            this.pnlAdvancedSearch.Controls.Add(this.numYearFrom);
            this.pnlAdvancedSearch.Controls.Add(this.txtPublisherFilter);
            this.pnlAdvancedSearch.Controls.Add(this.txtAuthorFilter);
            this.pnlAdvancedSearch.Controls.Add(this.btnApplyAdvancedSearch);
            this.pnlAdvancedSearch.Controls.Add(this.btnClear);
            this.pnlAdvancedSearch.Location = new System.Drawing.Point(0, 70);
            this.pnlAdvancedSearch.Name = "pnlAdvancedSearch";
            this.pnlAdvancedSearch.Size = new System.Drawing.Size(180, 630);
            this.pnlAdvancedSearch.TabIndex = 10;
            this.pnlAdvancedSearch.Visible = false;
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAdvanced.FlatAppearance.BorderSize = 2;
            this.btnAdvanced.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnAdvanced.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvanced.ForeColor = System.Drawing.Color.Black;
            this.btnAdvanced.Location = new System.Drawing.Point(4, 6);
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(176, 41);
            this.btnAdvanced.TabIndex = 11;
            this.btnAdvanced.Text = "Advanced Search";
            this.btnAdvanced.UseVisualStyleBackColor = true;
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // numYearTo
            // 
            this.numYearTo.Location = new System.Drawing.Point(12, 221);
            this.numYearTo.Name = "numYearTo";
            this.numYearTo.Size = new System.Drawing.Size(140, 32);
            this.numYearTo.TabIndex = 11;
            // 
            // numYearFrom
            // 
            this.numYearFrom.Location = new System.Drawing.Point(12, 172);
            this.numYearFrom.Name = "numYearFrom";
            this.numYearFrom.Size = new System.Drawing.Size(140, 32);
            this.numYearFrom.TabIndex = 11;
            // 
            // txtPublisherFilter
            // 
            this.txtPublisherFilter.Location = new System.Drawing.Point(12, 124);
            this.txtPublisherFilter.Name = "txtPublisherFilter";
            this.txtPublisherFilter.Size = new System.Drawing.Size(140, 32);
            this.txtPublisherFilter.TabIndex = 11;
            this.txtPublisherFilter.Text = "Publisher\r\n\r\n";
            this.txtPublisherFilter.Enter += new System.EventHandler(this.txtPublisherFilter_Enter);
            this.txtPublisherFilter.Leave += new System.EventHandler(this.txtPublisherFilter_Leave);
            // 
            // btnApplyAdvancedSearch
            // 
            this.btnApplyAdvancedSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyAdvancedSearch.ForeColor = System.Drawing.Color.Black;
            this.btnApplyAdvancedSearch.Location = new System.Drawing.Point(12, 276);
            this.btnApplyAdvancedSearch.Name = "btnApplyAdvancedSearch";
            this.btnApplyAdvancedSearch.Size = new System.Drawing.Size(140, 34);
            this.btnApplyAdvancedSearch.TabIndex = 12;
            this.btnApplyAdvancedSearch.Text = "Search";
            this.btnApplyAdvancedSearch.UseVisualStyleBackColor = true;
            this.btnApplyAdvancedSearch.Click += new System.EventHandler(this.btnApplyAdvanced_Click);
            // 
            // btnSaved
            // 
            this.btnSaved.ForeColor = System.Drawing.Color.Black;
            this.btnSaved.Location = new System.Drawing.Point(424, 84);
            this.btnSaved.Name = "btnSaved";
            this.btnSaved.Size = new System.Drawing.Size(140, 34);
            this.btnSaved.TabIndex = 11;
            this.btnSaved.Text = "Saved";
            this.btnSaved.UseVisualStyleBackColor = true;
            this.btnSaved.Click += new System.EventHandler(this.btnSaved_Click);
            // 
            // pnlReports
            // 
            this.pnlReports.BackColor = System.Drawing.Color.LightGray;
            this.pnlReports.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReports.Controls.Add(this.lblReportsTitle);
            this.pnlReports.Controls.Add(this.lblTopQueries);
            this.pnlReports.Controls.Add(this.listBox1);
            this.pnlReports.Controls.Add(this.lblTopResults);
            this.pnlReports.Controls.Add(this.listBox2);
            this.pnlReports.Controls.Add(this.btnPopularComics);
            this.pnlReports.Controls.Add(this.listBox3);
            this.pnlReports.Location = new System.Drawing.Point(794, 70);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(290, 630);
            this.pnlReports.TabIndex = 12;
            // 
            // lblReportsTitle
            // 
            this.lblReportsTitle.AutoSize = true;
            this.lblReportsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportsTitle.ForeColor = System.Drawing.Color.Black;
            this.lblReportsTitle.Location = new System.Drawing.Point(98, 0);
            this.lblReportsTitle.Name = "lblReportsTitle";
            this.lblReportsTitle.Size = new System.Drawing.Size(86, 25);
            this.lblReportsTitle.TabIndex = 14;
            this.lblReportsTitle.Text = "Reports";
            this.lblReportsTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTopQueries
            // 
            this.lblTopQueries.AutoSize = true;
            this.lblTopQueries.Location = new System.Drawing.Point(3, 29);
            this.lblTopQueries.Name = "lblTopQueries";
            this.lblTopQueries.Size = new System.Drawing.Size(176, 26);
            this.lblTopQueries.TabIndex = 15;
            this.lblTopQueries.Text = "Top 10 Searches";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 26;
            this.listBox1.Location = new System.Drawing.Point(3, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(210, 134);
            this.listBox1.TabIndex = 16;
            // 
            // lblTopResults
            // 
            this.lblTopResults.AutoSize = true;
            this.lblTopResults.Location = new System.Drawing.Point(3, 195);
            this.lblTopResults.Name = "lblTopResults";
            this.lblTopResults.Size = new System.Drawing.Size(253, 26);
            this.lblTopResults.TabIndex = 17;
            this.lblTopResults.Text = "Top 10 Comics Returned";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 26;
            this.listBox2.Location = new System.Drawing.Point(3, 224);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(210, 134);
            this.listBox2.TabIndex = 18;
            // 
            // btnPopularComics
            // 
            this.btnPopularComics.Location = new System.Drawing.Point(3, 364);
            this.btnPopularComics.Name = "btnPopularComics";
            this.btnPopularComics.Size = new System.Drawing.Size(200, 35);
            this.btnPopularComics.TabIndex = 19;
            this.btnPopularComics.Text = "Popular Comics (100+)";
            this.btnPopularComics.UseVisualStyleBackColor = true;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 26;
            this.listBox3.Location = new System.Drawing.Point(3, 405);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(210, 134);
            this.listBox3.TabIndex = 20;
            // 
            // btnReports
            // 
            this.btnReports.ForeColor = System.Drawing.Color.Black;
            this.btnReports.Location = new System.Drawing.Point(424, 144);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(140, 34);
            this.btnReports.TabIndex = 21;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(801, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 0);
            this.panel3.TabIndex = 13;
            // 
            // FantasyBzaarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 705);
            this.Controls.Add(this.pnlReports);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnReports);
            this.Controls.Add(this.btnSaved);
            this.Controls.Add(this.pnlAdvancedSearch);
            this.Controls.Add(this.cmbSort);
            this.Controls.Add(this.cmbGroupBy);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.dgvComics);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FantasyBzaarForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FantasyBzaarForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSearch)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComics)).EndInit();
            this.pnlAdvancedSearch.ResumeLayout(false);
            this.pnlAdvancedSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numYearTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYearFrom)).EndInit();
            this.pnlReports.ResumeLayout(false);
            this.pnlReports.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem signInToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip5;
        private System.Windows.Forms.ToolStripMenuItem logInToolStripMenuItem2;
        private System.Windows.Forms.PictureBox pictureSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvComics;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.ComboBox cmbGroupBy;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtAuthorFilter;
        private System.Windows.Forms.Panel pnlAdvancedSearch;
        private System.Windows.Forms.TextBox txtPublisherFilter;
        private System.Windows.Forms.Button btnAdvanced;
        private System.Windows.Forms.NumericUpDown numYearTo;
        private System.Windows.Forms.NumericUpDown numYearFrom;
        private System.Windows.Forms.Button btnSaved;
        private System.Windows.Forms.Button btnApplyAdvancedSearch;
        private System.Windows.Forms.Panel pnlReports;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblReportsTitle;
        private System.Windows.Forms.Label lblTopQueries;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label lblTopResults;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button btnPopularComics;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button btnReports;
    }
}

