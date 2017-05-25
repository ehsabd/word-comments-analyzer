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
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.textLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkRTL = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonCopyRef = new System.Windows.Forms.Button();
            this.buttonCopyComment = new System.Windows.Forms.Button();
            this.textComment = new System.Windows.Forms.TextBox();
            this.labelComment = new System.Windows.Forms.Label();
            this.labelRef = new System.Windows.Forms.Label();
            this.textReference = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.textFilter = new System.Windows.Forms.TextBox();
            this.labelFilter = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.labelNumberOfNodes = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(0, 107);
            this.treeView1.Margin = new System.Windows.Forms.Padding(15);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(447, 267);
            this.treeView1.TabIndex = 3;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(23, 16);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(120, 39);
            this.buttonAnalyze.TabIndex = 4;
            this.buttonAnalyze.Text = "Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // textLog
            // 
            this.textLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textLog.Location = new System.Drawing.Point(0, 374);
            this.textLog.Margin = new System.Windows.Forms.Padding(5);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(623, 81);
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
            this.panel1.Size = new System.Drawing.Size(623, 107);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonCopyRef);
            this.panel2.Controls.Add(this.buttonCopyComment);
            this.panel2.Controls.Add(this.textComment);
            this.panel2.Controls.Add(this.labelComment);
            this.panel2.Controls.Add(this.labelRef);
            this.panel2.Controls.Add(this.textReference);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.textFilter);
            this.panel2.Controls.Add(this.labelFilter);
            this.panel2.Controls.Add(this.buttonAnalyze);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(447, 107);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 267);
            this.panel2.TabIndex = 9;
            // 
            // buttonCopyRef
            // 
            this.buttonCopyRef.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyRef.Image")));
            this.buttonCopyRef.Location = new System.Drawing.Point(142, 165);
            this.buttonCopyRef.Name = "buttonCopyRef";
            this.buttonCopyRef.Size = new System.Drawing.Size(25, 23);
            this.buttonCopyRef.TabIndex = 15;
            this.buttonCopyRef.Tag = "Copy to clipboard";
            this.buttonCopyRef.UseVisualStyleBackColor = true;
            this.buttonCopyRef.Click += new System.EventHandler(this.buttonCopyRef_Click);
            // 
            // buttonCopyComment
            // 
            this.buttonCopyComment.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyComment.Image")));
            this.buttonCopyComment.Location = new System.Drawing.Point(142, 92);
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
            this.textComment.Location = new System.Drawing.Point(15, 117);
            this.textComment.Multiline = true;
            this.textComment.Name = "textComment";
            this.textComment.ReadOnly = true;
            this.textComment.Size = new System.Drawing.Size(149, 42);
            this.textComment.TabIndex = 13;
            // 
            // labelComment
            // 
            this.labelComment.AutoSize = true;
            this.labelComment.Location = new System.Drawing.Point(11, 102);
            this.labelComment.Name = "labelComment";
            this.labelComment.Size = new System.Drawing.Size(125, 13);
            this.labelComment.TabIndex = 12;
            this.labelComment.Text = "Comment (Subcomment):";
            // 
            // labelRef
            // 
            this.labelRef.AutoSize = true;
            this.labelRef.Location = new System.Drawing.Point(12, 175);
            this.labelRef.Name = "labelRef";
            this.labelRef.Size = new System.Drawing.Size(80, 13);
            this.labelRef.TabIndex = 11;
            this.labelRef.Text = "Reference text:";
            // 
            // textReference
            // 
            this.textReference.BackColor = System.Drawing.Color.White;
            this.textReference.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.textReference.Location = new System.Drawing.Point(14, 191);
            this.textReference.Multiline = true;
            this.textReference.Name = "textReference";
            this.textReference.ReadOnly = true;
            this.textReference.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textReference.Size = new System.Drawing.Size(150, 87);
            this.textReference.TabIndex = 10;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 267);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // textFilter
            // 
            this.textFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFilter.Location = new System.Drawing.Point(80, 67);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(59, 21);
            this.textFilter.TabIndex = 6;
            this.textFilter.TextChanged += new System.EventHandler(this.textFilter_TextChanged);
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(18, 70);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(56, 13);
            this.labelFilter.TabIndex = 5;
            this.labelFilter.Text = "Filter Text:";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // labelNumberOfNodes
            // 
            this.labelNumberOfNodes.AutoSize = true;
            this.labelNumberOfNodes.Location = new System.Drawing.Point(12, 88);
            this.labelNumberOfNodes.Name = "labelNumberOfNodes";
            this.labelNumberOfNodes.Size = new System.Drawing.Size(0, 13);
            this.labelNumberOfNodes.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 455);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textLog);
            this.Name = "Main";
            this.Text = "Word Comments Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textWorkingDir;
        private System.Windows.Forms.Label labelWD;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textFilter;
        private System.Windows.Forms.Label labelFilter;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckBox checkRTL;
        private System.Windows.Forms.TextBox textComment;
        private System.Windows.Forms.Label labelComment;
        private System.Windows.Forms.Label labelRef;
        private System.Windows.Forms.TextBox textReference;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button buttonCopyComment;
        private System.Windows.Forms.Button buttonCopyRef;
        private System.Windows.Forms.Label labelNumberOfNodes;
    }
}

