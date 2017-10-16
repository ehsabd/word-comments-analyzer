namespace WordCommentsAnalyzer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textWorkingDir = new System.Windows.Forms.TextBox();
            this.labelWD = new System.Windows.Forms.Label();
            this.textLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkRTL = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelParent = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSidebarBottom = new System.Windows.Forms.Panel();
            this.textReference = new System.Windows.Forms.TextBox();
            this.panelToolbar1 = new System.Windows.Forms.Panel();
            this.buttonCopyRef = new System.Windows.Forms.Button();
            this.labelRef = new System.Windows.Forms.Label();
            this.panelSidebarTop = new System.Windows.Forms.Panel();
            this.buttonCopyComment = new System.Windows.Forms.Button();
            this.textComment = new System.Windows.Forms.TextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.textFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.labelNumberOfNodes = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelParent.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSidebarBottom.SuspendLayout();
            this.panelToolbar1.SuspendLayout();
            this.panelSidebarTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(399, 23);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(120, 36);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textWorkingDir
            // 
            this.textWorkingDir.Location = new System.Drawing.Point(113, 23);
            this.textWorkingDir.Name = "textWorkingDir";
            this.textWorkingDir.ReadOnly = true;
            this.textWorkingDir.Size = new System.Drawing.Size(269, 20);
            this.textWorkingDir.TabIndex = 1;
            // 
            // labelWD
            // 
            this.labelWD.AutoSize = true;
            this.labelWD.Location = new System.Drawing.Point(12, 23);
            this.labelWD.Name = "labelWD";
            this.labelWD.Size = new System.Drawing.Size(95, 13);
            this.labelWD.TabIndex = 2;
            this.labelWD.Text = "Working Directory:";
            // 
            // textLog
            // 
            this.textLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textLog.Location = new System.Drawing.Point(0, 404);
            this.textLog.Margin = new System.Windows.Forms.Padding(5);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(706, 81);
            this.textLog.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelNumberOfNodes);
            this.panel1.Controls.Add(this.checkRTL);
            this.panel1.Controls.Add(this.labelWD);
            this.panel1.Controls.Add(this.buttonBrowse);
            this.panel1.Controls.Add(this.textWorkingDir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 107);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkRTL
            // 
            this.checkRTL.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkRTL.AutoSize = true;
            this.checkRTL.Location = new System.Drawing.Point(15, 52);
            this.checkRTL.Name = "checkRTL";
            this.checkRTL.Size = new System.Drawing.Size(75, 23);
            this.checkRTL.TabIndex = 3;
            this.checkRTL.Text = "Right to Left";
            this.checkRTL.UseVisualStyleBackColor = true;
            this.checkRTL.CheckedChanged += new System.EventHandler(this.checkRTL_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panelParent
            // 
            this.panelParent.Controls.Add(this.treeView1);
            this.panelParent.Controls.Add(this.splitter1);
            this.panelParent.Controls.Add(this.panelSidebar);
            this.panelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParent.Location = new System.Drawing.Point(0, 107);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(706, 297);
            this.panelParent.TabIndex = 16;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(15);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(477, 297);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(477, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(10, 297);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.panelSidebarBottom);
            this.panelSidebar.Controls.Add(this.panelSidebarTop);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebar.Location = new System.Drawing.Point(487, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(219, 297);
            this.panelSidebar.TabIndex = 9;
            // 
            // panelSidebarBottom
            // 
            this.panelSidebarBottom.Controls.Add(this.textReference);
            this.panelSidebarBottom.Controls.Add(this.panelToolbar1);
            this.panelSidebarBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebarBottom.Location = new System.Drawing.Point(0, 153);
            this.panelSidebarBottom.Name = "panelSidebarBottom";
            this.panelSidebarBottom.Size = new System.Drawing.Size(219, 144);
            this.panelSidebarBottom.TabIndex = 17;
            // 
            // textReference
            // 
            this.textReference.BackColor = System.Drawing.Color.White;
            this.textReference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textReference.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textReference.Location = new System.Drawing.Point(0, 27);
            this.textReference.Multiline = true;
            this.textReference.Name = "textReference";
            this.textReference.ReadOnly = true;
            this.textReference.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textReference.Size = new System.Drawing.Size(219, 117);
            this.textReference.TabIndex = 10;
            // 
            // panelToolbar1
            // 
            this.panelToolbar1.Controls.Add(this.buttonCopyRef);
            this.panelToolbar1.Controls.Add(this.labelRef);
            this.panelToolbar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelToolbar1.Location = new System.Drawing.Point(0, 0);
            this.panelToolbar1.Name = "panelToolbar1";
            this.panelToolbar1.Padding = new System.Windows.Forms.Padding(2);
            this.panelToolbar1.Size = new System.Drawing.Size(219, 27);
            this.panelToolbar1.TabIndex = 16;
            // 
            // buttonCopyRef
            // 
            this.buttonCopyRef.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCopyRef.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyRef.Image")));
            this.buttonCopyRef.Location = new System.Drawing.Point(192, 2);
            this.buttonCopyRef.Name = "buttonCopyRef";
            this.buttonCopyRef.Size = new System.Drawing.Size(25, 23);
            this.buttonCopyRef.TabIndex = 15;
            this.buttonCopyRef.Tag = "Copy to clipboard";
            this.buttonCopyRef.UseVisualStyleBackColor = true;
            this.buttonCopyRef.Click += new System.EventHandler(this.buttonCopyRef_Click);
            // 
            // labelRef
            // 
            this.labelRef.AutoSize = true;
            this.labelRef.Location = new System.Drawing.Point(4, 7);
            this.labelRef.Name = "labelRef";
            this.labelRef.Size = new System.Drawing.Size(80, 13);
            this.labelRef.TabIndex = 11;
            this.labelRef.Text = "Reference text:";
            // 
            // panelSidebarTop
            // 
            this.panelSidebarTop.Controls.Add(this.buttonCopyComment);
            this.panelSidebarTop.Controls.Add(this.textComment);
            this.panelSidebarTop.Controls.Add(this.labelComment);
            this.panelSidebarTop.Controls.Add(this.textFilter);
            this.panelSidebarTop.Controls.Add(this.labelFilter);
            this.panelSidebarTop.Controls.Add(this.buttonAnalyze);
            this.panelSidebarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidebarTop.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarTop.Name = "panelSidebarTop";
            this.panelSidebarTop.Size = new System.Drawing.Size(219, 153);
            this.panelSidebarTop.TabIndex = 16;
            // 
            // buttonCopyComment
            // 
            this.buttonCopyComment.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyComment.Image")));
            this.buttonCopyComment.Location = new System.Drawing.Point(133, 80);
            this.buttonCopyComment.Name = "buttonCopyComment";
            this.buttonCopyComment.Size = new System.Drawing.Size(25, 23);
            this.buttonCopyComment.TabIndex = 14;
            this.buttonCopyComment.Tag = "Copy to clipboard";
            this.buttonCopyComment.UseVisualStyleBackColor = true;
            this.buttonCopyComment.Click += new System.EventHandler(this.buttonCopyComment_Click);
            // 
            // textComment
            // 
            this.textComment.BackColor = System.Drawing.Color.White;
            this.textComment.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textComment.Location = new System.Drawing.Point(6, 105);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.ReadOnly = true;
            this.textComment.Size = new System.Drawing.Size(149, 42);
            this.textComment.TabIndex = 13;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(2, 90);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(125, 13);
            this.labelComment.TabIndex = 12;
            this.labelComment.Text = "Comment (Subcomment):";
            // 
            // textFilter
            // 
            this.textFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFilter.Location = new System.Drawing.Point(71, 55);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(84, 21);
            this.textFilter.TabIndex = 6;
            this.textFilter.TextChanged += new System.EventHandler(this.textFilter_TextChanged);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(9, 58);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(56, 13);
            this.labelFilter.TabIndex = 5;
            this.labelFilter.Text = "Filter Text:";
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(14, 4);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(120, 39);
            this.buttonAnalyze.TabIndex = 4;
            this.buttonAnalyze.Text = "Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // labelNumberOfNodes
            // 
            this.labelNumberOfNodes.AutoSize = true;
            this.labelNumberOfNodes.Location = new System.Drawing.Point(12, 88);
            this.labelNumberOfNodes.Name = "labelNumberOfNodes";
            this.labelNumberOfNodes.Size = new System.Drawing.Size(61, 13);
            this.labelNumberOfNodes.TabIndex = 4;
            this.labelNumberOfNodes.Text = "_________";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 485);
            this.Controls.Add(this.panelParent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textLog);
            this.Name = "Main";
            this.Text = "Word Comments Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelParent.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebarBottom.ResumeLayout(false);
            this.panelSidebarBottom.PerformLayout();
            this.panelToolbar1.ResumeLayout(false);
            this.panelToolbar1.PerformLayout();
            this.panelSidebarTop.ResumeLayout(false);
            this.panelSidebarTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textWorkingDir;
        private System.Windows.Forms.Label labelWD;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkRTL;
        private System.Windows.Forms.Panel panelParent;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.TextBox textFilter;
        private System.Windows.Forms.TextBox textReference;
        private System.Windows.Forms.Label labelRef;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.TextBox textComment;
        private System.Windows.Forms.Button buttonCopyComment;
        private System.Windows.Forms.Button buttonCopyRef;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelSidebarTop;
        private System.Windows.Forms.Panel panelSidebarBottom;
        private System.Windows.Forms.Panel panelToolbar1;
        private System.Windows.Forms.Label labelNumberOfNodes;
    }
}

