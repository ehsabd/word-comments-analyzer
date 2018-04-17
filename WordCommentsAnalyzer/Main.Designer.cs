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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textLog = new System.Windows.Forms.TextBox();
            this.labelNumberOfNodes = new System.Windows.Forms.Label();
            this.bgwFilterCodes = new System.ComponentModel.BackgroundWorker();
            this.panelParent = new System.Windows.Forms.Panel();
            this.panelNode = new System.Windows.Forms.Panel();
            this.listViewCodes = new System.Windows.Forms.ListView();
            this.columnCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFreq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelNodeTop = new System.Windows.Forms.Panel();
            this.labelFilter = new System.Windows.Forms.Label();
            this.textFilter = new System.Windows.Forms.TextBox();
            this.splitterLeftMiddle = new System.Windows.Forms.Splitter();
            this.panelMiddle = new System.Windows.Forms.Panel();
            this.treeViewHierarchy = new System.Windows.Forms.TreeView();
            this.panelMiddleToolbar = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDeleteHierarchyNode = new System.Windows.Forms.Button();
            this.buttonEditHierarchyNode = new System.Windows.Forms.Button();
            this.labelCodeHierarchy = new System.Windows.Forms.Label();
            this.buttonAddHierarchyNode = new System.Windows.Forms.Button();
            this.splitterMiddleRight = new System.Windows.Forms.Splitter();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSidebarBottom = new System.Windows.Forms.Panel();
            this.listViewRef = new System.Windows.Forms.ListView();
            this.columnText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelReferenceTextToolbar = new System.Windows.Forms.Panel();
            this.buttonCopyRef = new System.Windows.Forms.Button();
            this.labelRef = new System.Windows.Forms.Label();
            this.panelSidebarTop = new System.Windows.Forms.Panel();
            this.textCode = new System.Windows.Forms.TextBox();
            this.panelCommentTextToolbar = new System.Windows.Forms.Panel();
            this.labelCode = new System.Windows.Forms.Label();
            this.buttonCopyComment = new System.Windows.Forms.Button();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.textWorkingDir = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelWD = new System.Windows.Forms.Label();
            this.checkRTL = new System.Windows.Forms.CheckBox();
            this.labelCulture = new System.Windows.Forms.Label();
            this.textCulture = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timerAutoSaveHierarchy = new System.Windows.Forms.Timer(this.components);
            this.panelParent.SuspendLayout();
            this.panelNode.SuspendLayout();
            this.panelNodeTop.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelMiddleToolbar.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSidebarBottom.SuspendLayout();
            this.panelReferenceTextToolbar.SuspendLayout();
            this.panelSidebarTop.SuspendLayout();
            this.panelCommentTextToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textLog
            // 
            this.textLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textLog.Location = new System.Drawing.Point(0, 648);
            this.textLog.Margin = new System.Windows.Forms.Padding(5);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(1008, 81);
            this.textLog.TabIndex = 7;
            // 
            // labelNumberOfNodes
            // 
            this.labelNumberOfNodes.AutoSize = true;
            this.labelNumberOfNodes.Location = new System.Drawing.Point(12, 33);
            this.labelNumberOfNodes.Name = "labelNumberOfNodes";
            this.labelNumberOfNodes.Size = new System.Drawing.Size(61, 13);
            this.labelNumberOfNodes.TabIndex = 4;
            this.labelNumberOfNodes.Text = "_________";
            // 
            // bgwFilterCodes
            // 
            this.bgwFilterCodes.WorkerSupportsCancellation = true;
            this.bgwFilterCodes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwFilterCodes_DoWork);
            this.bgwFilterCodes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panelParent
            // 
            this.panelParent.Controls.Add(this.panelNode);
            this.panelParent.Controls.Add(this.panelNodeTop);
            this.panelParent.Controls.Add(this.splitterLeftMiddle);
            this.panelParent.Controls.Add(this.panelMiddle);
            this.panelParent.Controls.Add(this.splitterMiddleRight);
            this.panelParent.Controls.Add(this.panelSidebar);
            this.panelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParent.Location = new System.Drawing.Point(0, 111);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(1008, 537);
            this.panelParent.TabIndex = 16;
            // 
            // panelNode
            // 
            this.panelNode.Controls.Add(this.listViewCodes);
            this.panelNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNode.Location = new System.Drawing.Point(0, 59);
            this.panelNode.Name = "panelNode";
            this.panelNode.Size = new System.Drawing.Size(313, 478);
            this.panelNode.TabIndex = 7;
            // 
            // listViewCodes
            // 
            this.listViewCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnCode,
            this.columnFreq});
            this.listViewCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCodes.FullRowSelect = true;
            this.listViewCodes.Location = new System.Drawing.Point(0, 0);
            this.listViewCodes.Name = "listViewCodes";
            this.listViewCodes.Size = new System.Drawing.Size(313, 478);
            this.listViewCodes.TabIndex = 17;
            this.listViewCodes.UseCompatibleStateImageBehavior = false;
            this.listViewCodes.View = System.Windows.Forms.View.Details;
            this.listViewCodes.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewCodes_ItemDrag);
            this.listViewCodes.SelectedIndexChanged += new System.EventHandler(this.listViewCodes_SelectedIndexChanged);
            // 
            // columnCode
            // 
            this.columnCode.Text = "Code";
            this.columnCode.Width = 200;
            // 
            // columnFreq
            // 
            this.columnFreq.Text = "Frequency";
            this.columnFreq.Width = 100;
            // 
            // panelNodeTop
            // 
            this.panelNodeTop.Controls.Add(this.labelNumberOfNodes);
            this.panelNodeTop.Controls.Add(this.labelFilter);
            this.panelNodeTop.Controls.Add(this.textFilter);
            this.panelNodeTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNodeTop.Location = new System.Drawing.Point(0, 0);
            this.panelNodeTop.Margin = new System.Windows.Forms.Padding(5);
            this.panelNodeTop.Name = "panelNodeTop";
            this.panelNodeTop.Size = new System.Drawing.Size(313, 59);
            this.panelNodeTop.TabIndex = 10;
            // 
            // labelFilter
            // 
            this.labelFilter.AutoSize = true;
            this.labelFilter.Location = new System.Drawing.Point(12, 12);
            this.labelFilter.Name = "labelFilter";
            this.labelFilter.Size = new System.Drawing.Size(56, 13);
            this.labelFilter.TabIndex = 5;
            this.labelFilter.Text = "Filter Text:";
            // 
            // textFilter
            // 
            this.textFilter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFilter.Location = new System.Drawing.Point(74, 9);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(84, 21);
            this.textFilter.TabIndex = 6;
            this.textFilter.TextChanged += new System.EventHandler(this.textFilter_TextChanged);
            // 
            // splitterLeftMiddle
            // 
            this.splitterLeftMiddle.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.splitterLeftMiddle.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterLeftMiddle.Location = new System.Drawing.Point(313, 0);
            this.splitterLeftMiddle.Name = "splitterLeftMiddle";
            this.splitterLeftMiddle.Size = new System.Drawing.Size(4, 537);
            this.splitterLeftMiddle.TabIndex = 11;
            this.splitterLeftMiddle.TabStop = false;
            // 
            // panelMiddle
            // 
            this.panelMiddle.Controls.Add(this.treeViewHierarchy);
            this.panelMiddle.Controls.Add(this.panelMiddleToolbar);
            this.panelMiddle.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelMiddle.Enabled = false;
            this.panelMiddle.Location = new System.Drawing.Point(317, 0);
            this.panelMiddle.Name = "panelMiddle";
            this.panelMiddle.Size = new System.Drawing.Size(367, 537);
            this.panelMiddle.TabIndex = 12;
            // 
            // treeViewHierarchy
            // 
            this.treeViewHierarchy.AllowDrop = true;
            this.treeViewHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewHierarchy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewHierarchy.HideSelection = false;
            this.treeViewHierarchy.Location = new System.Drawing.Point(0, 36);
            this.treeViewHierarchy.Margin = new System.Windows.Forms.Padding(15);
            this.treeViewHierarchy.Name = "treeViewHierarchy";
            this.treeViewHierarchy.Size = new System.Drawing.Size(367, 501);
            this.treeViewHierarchy.TabIndex = 7;
            this.treeViewHierarchy.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewHierarchy_BeforeLabelEdit);
            this.treeViewHierarchy.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewHierarchy_AfterLabelEdit);
            this.treeViewHierarchy.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewHierarchy_ItemDrag);
            this.treeViewHierarchy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewHierarchy_AfterSelect);
            this.treeViewHierarchy.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewHierarchy_DragDrop);
            this.treeViewHierarchy.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewHierarchy_DragEnter);
            this.treeViewHierarchy.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewHierarchy_DragOver);
            this.treeViewHierarchy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeViewHierarchy_KeyUp);
            // 
            // panelMiddleToolbar
            // 
            this.panelMiddleToolbar.Controls.Add(this.buttonSave);
            this.panelMiddleToolbar.Controls.Add(this.buttonDeleteHierarchyNode);
            this.panelMiddleToolbar.Controls.Add(this.buttonEditHierarchyNode);
            this.panelMiddleToolbar.Controls.Add(this.labelCodeHierarchy);
            this.panelMiddleToolbar.Controls.Add(this.buttonAddHierarchyNode);
            this.panelMiddleToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddleToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelMiddleToolbar.Name = "panelMiddleToolbar";
            this.panelMiddleToolbar.Size = new System.Drawing.Size(367, 36);
            this.panelMiddleToolbar.TabIndex = 16;
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSave.Image = ((System.Drawing.Image)(resources.GetObject("buttonSave.Image")));
            this.buttonSave.Location = new System.Drawing.Point(223, 0);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(36, 36);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Tag = "Save hierarchy";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDeleteHierarchyNode
            // 
            this.buttonDeleteHierarchyNode.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonDeleteHierarchyNode.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeleteHierarchyNode.Image")));
            this.buttonDeleteHierarchyNode.Location = new System.Drawing.Point(259, 0);
            this.buttonDeleteHierarchyNode.Name = "buttonDeleteHierarchyNode";
            this.buttonDeleteHierarchyNode.Size = new System.Drawing.Size(36, 36);
            this.buttonDeleteHierarchyNode.TabIndex = 15;
            this.buttonDeleteHierarchyNode.Tag = "Delete node";
            this.buttonDeleteHierarchyNode.UseVisualStyleBackColor = true;
            this.buttonDeleteHierarchyNode.Click += new System.EventHandler(this.buttonDeleteHierarchyNode_Click);
            // 
            // buttonEditHierarchyNode
            // 
            this.buttonEditHierarchyNode.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonEditHierarchyNode.Image = ((System.Drawing.Image)(resources.GetObject("buttonEditHierarchyNode.Image")));
            this.buttonEditHierarchyNode.Location = new System.Drawing.Point(295, 0);
            this.buttonEditHierarchyNode.Name = "buttonEditHierarchyNode";
            this.buttonEditHierarchyNode.Size = new System.Drawing.Size(36, 36);
            this.buttonEditHierarchyNode.TabIndex = 18;
            this.buttonEditHierarchyNode.Tag = "Edit node";
            this.buttonEditHierarchyNode.UseVisualStyleBackColor = true;
            this.buttonEditHierarchyNode.Click += new System.EventHandler(this.buttonEditHierarchyNode_Click);
            // 
            // labelCodeHierarchy
            // 
            this.labelCodeHierarchy.AutoSize = true;
            this.labelCodeHierarchy.Location = new System.Drawing.Point(9, 12);
            this.labelCodeHierarchy.Name = "labelCodeHierarchy";
            this.labelCodeHierarchy.Size = new System.Drawing.Size(83, 13);
            this.labelCodeHierarchy.TabIndex = 16;
            this.labelCodeHierarchy.Text = "Code Hierarchy:";
            // 
            // buttonAddHierarchyNode
            // 
            this.buttonAddHierarchyNode.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddHierarchyNode.Image = ((System.Drawing.Image)(resources.GetObject("buttonAddHierarchyNode.Image")));
            this.buttonAddHierarchyNode.Location = new System.Drawing.Point(331, 0);
            this.buttonAddHierarchyNode.Name = "buttonAddHierarchyNode";
            this.buttonAddHierarchyNode.Size = new System.Drawing.Size(36, 36);
            this.buttonAddHierarchyNode.TabIndex = 14;
            this.buttonAddHierarchyNode.Tag = "Add node";
            this.buttonAddHierarchyNode.UseVisualStyleBackColor = true;
            this.buttonAddHierarchyNode.Click += new System.EventHandler(this.buttonAddHierarchyNode_Click);
            // 
            // splitterMiddleRight
            // 
            this.splitterMiddleRight.BackColor = System.Drawing.Color.DodgerBlue;
            this.splitterMiddleRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterMiddleRight.Location = new System.Drawing.Point(684, 0);
            this.splitterMiddleRight.Name = "splitterMiddleRight";
            this.splitterMiddleRight.Size = new System.Drawing.Size(4, 537);
            this.splitterMiddleRight.TabIndex = 4;
            this.splitterMiddleRight.TabStop = false;
            // 
            // panelSidebar
            // 
            this.panelSidebar.Controls.Add(this.panelSidebarBottom);
            this.panelSidebar.Controls.Add(this.panelSidebarTop);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSidebar.Location = new System.Drawing.Point(688, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(320, 537);
            this.panelSidebar.TabIndex = 9;
            // 
            // panelSidebarBottom
            // 
            this.panelSidebarBottom.Controls.Add(this.listViewRef);
            this.panelSidebarBottom.Controls.Add(this.panelReferenceTextToolbar);
            this.panelSidebarBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebarBottom.Location = new System.Drawing.Point(0, 93);
            this.panelSidebarBottom.Name = "panelSidebarBottom";
            this.panelSidebarBottom.Size = new System.Drawing.Size(320, 444);
            this.panelSidebarBottom.TabIndex = 17;
            // 
            // listViewRef
            // 
            this.listViewRef.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnText,
            this.columnFile});
            this.listViewRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRef.GridLines = true;
            this.listViewRef.Location = new System.Drawing.Point(0, 36);
            this.listViewRef.Name = "listViewRef";
            this.listViewRef.Size = new System.Drawing.Size(320, 408);
            this.listViewRef.TabIndex = 17;
            this.listViewRef.TileSize = new System.Drawing.Size(300, 60);
            this.listViewRef.UseCompatibleStateImageBehavior = false;
            this.listViewRef.View = System.Windows.Forms.View.Tile;
            // 
            // columnText
            // 
            this.columnText.Text = "Text";
            this.columnText.Width = 200;
            // 
            // columnFile
            // 
            this.columnFile.Text = "File Name";
            // 
            // panelReferenceTextToolbar
            // 
            this.panelReferenceTextToolbar.Controls.Add(this.buttonCopyRef);
            this.panelReferenceTextToolbar.Controls.Add(this.labelRef);
            this.panelReferenceTextToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelReferenceTextToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelReferenceTextToolbar.Name = "panelReferenceTextToolbar";
            this.panelReferenceTextToolbar.Size = new System.Drawing.Size(320, 36);
            this.panelReferenceTextToolbar.TabIndex = 16;
            // 
            // buttonCopyRef
            // 
            this.buttonCopyRef.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCopyRef.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyRef.Image")));
            this.buttonCopyRef.Location = new System.Drawing.Point(284, 0);
            this.buttonCopyRef.Name = "buttonCopyRef";
            this.buttonCopyRef.Size = new System.Drawing.Size(36, 36);
            this.buttonCopyRef.TabIndex = 15;
            this.buttonCopyRef.Tag = "Copy to clipboard";
            this.buttonCopyRef.UseVisualStyleBackColor = true;
            this.buttonCopyRef.Click += new System.EventHandler(this.buttonCopyRef_Click);
            // 
            // labelRef
            // 
            this.labelRef.AutoSize = true;
            this.labelRef.Location = new System.Drawing.Point(14, 11);
            this.labelRef.Name = "labelRef";
            this.labelRef.Size = new System.Drawing.Size(94, 13);
            this.labelRef.TabIndex = 11;
            this.labelRef.Text = "Reference texts ():";
            // 
            // panelSidebarTop
            // 
            this.panelSidebarTop.Controls.Add(this.textCode);
            this.panelSidebarTop.Controls.Add(this.panelCommentTextToolbar);
            this.panelSidebarTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidebarTop.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarTop.Name = "panelSidebarTop";
            this.panelSidebarTop.Size = new System.Drawing.Size(320, 93);
            this.panelSidebarTop.TabIndex = 16;
            // 
            // textCode
            // 
            this.textCode.BackColor = System.Drawing.Color.White;
            this.textCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCode.Location = new System.Drawing.Point(0, 36);
            this.textCode.Multiline = true;
            this.textCode.Name = "textCode";
            this.textCode.ReadOnly = true;
            this.textCode.Size = new System.Drawing.Size(320, 57);
            this.textCode.TabIndex = 13;
            this.textCode.TextChanged += new System.EventHandler(this.textComment_TextChanged);
            // 
            // panelCommentTextToolbar
            // 
            this.panelCommentTextToolbar.Controls.Add(this.labelCode);
            this.panelCommentTextToolbar.Controls.Add(this.buttonCopyComment);
            this.panelCommentTextToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommentTextToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelCommentTextToolbar.Name = "panelCommentTextToolbar";
            this.panelCommentTextToolbar.Size = new System.Drawing.Size(320, 36);
            this.panelCommentTextToolbar.TabIndex = 15;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(14, 9);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(35, 13);
            this.labelCode.TabIndex = 12;
            this.labelCode.Text = "Code:";
            // 
            // buttonCopyComment
            // 
            this.buttonCopyComment.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCopyComment.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopyComment.Image")));
            this.buttonCopyComment.Location = new System.Drawing.Point(284, 0);
            this.buttonCopyComment.Name = "buttonCopyComment";
            this.buttonCopyComment.Size = new System.Drawing.Size(36, 36);
            this.buttonCopyComment.TabIndex = 14;
            this.buttonCopyComment.Tag = "Copy to clipboard";
            this.buttonCopyComment.UseVisualStyleBackColor = true;
            this.buttonCopyComment.Click += new System.EventHandler(this.buttonCopyComment_Click);
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Location = new System.Drawing.Point(0, 107);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(1008, 4);
            this.panelSeparator.TabIndex = 17;
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(538, 23);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(120, 39);
            this.buttonAnalyze.TabIndex = 4;
            this.buttonAnalyze.Text = "Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // textWorkingDir
            // 
            this.textWorkingDir.Location = new System.Drawing.Point(113, 23);
            this.textWorkingDir.Name = "textWorkingDir";
            this.textWorkingDir.ReadOnly = true;
            this.textWorkingDir.Size = new System.Drawing.Size(269, 20);
            this.textWorkingDir.TabIndex = 1;
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
            // labelWD
            // 
            this.labelWD.AutoSize = true;
            this.labelWD.Location = new System.Drawing.Point(12, 23);
            this.labelWD.Name = "labelWD";
            this.labelWD.Size = new System.Drawing.Size(95, 13);
            this.labelWD.TabIndex = 2;
            this.labelWD.Text = "Working Directory:";
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
            // labelCulture
            // 
            this.labelCulture.AutoSize = true;
            this.labelCulture.Location = new System.Drawing.Point(12, 81);
            this.labelCulture.Name = "labelCulture";
            this.labelCulture.Size = new System.Drawing.Size(43, 13);
            this.labelCulture.TabIndex = 5;
            this.labelCulture.Text = "Culture:";
            // 
            // textCulture
            // 
            this.textCulture.Location = new System.Drawing.Point(58, 78);
            this.textCulture.Name = "textCulture";
            this.textCulture.Size = new System.Drawing.Size(49, 20);
            this.textCulture.TabIndex = 6;
            this.textCulture.Text = "en-US";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.textCulture);
            this.panel1.Controls.Add(this.labelCulture);
            this.panel1.Controls.Add(this.checkRTL);
            this.panel1.Controls.Add(this.labelWD);
            this.panel1.Controls.Add(this.buttonBrowse);
            this.panel1.Controls.Add(this.textWorkingDir);
            this.panel1.Controls.Add(this.buttonAnalyze);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 107);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // timerAutoSaveHierarchy
            // 
            this.timerAutoSaveHierarchy.Enabled = true;
            this.timerAutoSaveHierarchy.Interval = 60000;
            this.timerAutoSaveHierarchy.Tick += new System.EventHandler(this.timerAutoSaveHierarchy_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelParent);
            this.Controls.Add(this.panelSeparator);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textLog);
            this.Name = "Main";
            this.Text = "Word Comments Analyzer []";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelParent.ResumeLayout(false);
            this.panelNode.ResumeLayout(false);
            this.panelNodeTop.ResumeLayout(false);
            this.panelNodeTop.PerformLayout();
            this.panelMiddle.ResumeLayout(false);
            this.panelMiddleToolbar.ResumeLayout(false);
            this.panelMiddleToolbar.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebarBottom.ResumeLayout(false);
            this.panelReferenceTextToolbar.ResumeLayout(false);
            this.panelReferenceTextToolbar.PerformLayout();
            this.panelSidebarTop.ResumeLayout(false);
            this.panelSidebarTop.PerformLayout();
            this.panelCommentTextToolbar.ResumeLayout(false);
            this.panelCommentTextToolbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textLog;
        private System.ComponentModel.BackgroundWorker bgwFilterCodes;
        private System.Windows.Forms.Panel panelParent;
        private System.Windows.Forms.Splitter splitterMiddleRight;
        private System.Windows.Forms.Splitter splitterLeftMiddle;
        private System.Windows.Forms.Label labelFilter;
        private System.Windows.Forms.TextBox textFilter;
        private System.Windows.Forms.Label labelRef;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.TextBox textCode;
        private System.Windows.Forms.Button buttonCopyComment;
        private System.Windows.Forms.Button buttonCopyRef;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelSidebarTop;
        private System.Windows.Forms.Panel panelSidebarBottom;
        private System.Windows.Forms.Panel panelReferenceTextToolbar;
        private System.Windows.Forms.Label labelNumberOfNodes;
        private System.Windows.Forms.Panel panelNodeTop;
        private System.Windows.Forms.Panel panelCommentTextToolbar;
        private System.Windows.Forms.Panel panelNode;
        private System.Windows.Forms.Panel panelMiddle;
        private System.Windows.Forms.TreeView treeViewHierarchy;
        private System.Windows.Forms.Panel panelMiddleToolbar;
        private System.Windows.Forms.Button buttonAddHierarchyNode;
        private System.Windows.Forms.Button buttonDeleteHierarchyNode;
        private System.Windows.Forms.ListView listViewCodes;
        private System.Windows.Forms.ColumnHeader columnCode;
        private System.Windows.Forms.ColumnHeader columnFreq;
        private System.Windows.Forms.ListView listViewRef;
        private System.Windows.Forms.ColumnHeader columnText;
        private System.Windows.Forms.ColumnHeader columnFile;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.TextBox textWorkingDir;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelWD;
        private System.Windows.Forms.CheckBox checkRTL;
        private System.Windows.Forms.Label labelCulture;
        private System.Windows.Forms.TextBox textCulture;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCodeHierarchy;
        private System.Windows.Forms.Timer timerAutoSaveHierarchy;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEditHierarchyNode;
    }
}

