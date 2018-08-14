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
            this.bwFilterCodes = new System.ComponentModel.BackgroundWorker();
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
            this.buttonSortTreeAZ = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDeleteHierarchyNode = new System.Windows.Forms.Button();
            this.buttonEditHierarchyNode = new System.Windows.Forms.Button();
            this.labelCodeHierarchy = new System.Windows.Forms.Label();
            this.buttonAddHierarchyNode = new System.Windows.Forms.Button();
            this.panelHierarchyFind = new System.Windows.Forms.Panel();
            this.splitterMiddleRight = new System.Windows.Forms.Splitter();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSidebarBottom = new System.Windows.Forms.Panel();
            this.listViewRef = new System.Windows.Forms.ListView();
            this.columnTextorCodes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCodesorFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFileorNone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelReferenceTextToolbar = new System.Windows.Forms.Panel();
            this.buttonCopyRef = new System.Windows.Forms.Button();
            this.labelRef = new System.Windows.Forms.Label();
            this.panelSidebarTop = new System.Windows.Forms.Panel();
            this.textCode = new System.Windows.Forms.TextBox();
            this.panelCodeTextToolbar = new System.Windows.Forms.Panel();
            this.labelCode = new System.Windows.Forms.Label();
            this.buttonCopyComment = new System.Windows.Forms.Button();
            this.imageListRef = new System.Windows.Forms.ImageList(this.components);
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.textWorkingDir = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelWD = new System.Windows.Forms.Label();
            this.checkRTL = new System.Windows.Forms.CheckBox();
            this.labelCulture = new System.Windows.Forms.Label();
            this.textCulture = new System.Windows.Forms.TextBox();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelWorkingDirBrowseAnalyze = new System.Windows.Forms.Panel();
            this.radioMiniCodelist = new System.Windows.Forms.RadioButton();
            this.labelView = new System.Windows.Forms.Label();
            this.radioThreePanels = new System.Windows.Forms.RadioButton();
            this.timerAutoSaveHierarchy = new System.Windows.Forms.Timer(this.components);
            this.bwAnalyze = new System.ComponentModel.BackgroundWorker();
            this.hierarchyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemMoveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.panelParent.SuspendLayout();
            this.panelNode.SuspendLayout();
            this.panelNodeTop.SuspendLayout();
            this.panelMiddle.SuspendLayout();
            this.panelMiddleToolbar.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSidebarBottom.SuspendLayout();
            this.panelReferenceTextToolbar.SuspendLayout();
            this.panelSidebarTop.SuspendLayout();
            this.panelCodeTextToolbar.SuspendLayout();
            this.panelSeparator.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panelWorkingDirBrowseAnalyze.SuspendLayout();
            this.hierarchyContextMenu.SuspendLayout();
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
            // bwFilterCodes
            // 
            this.bwFilterCodes.WorkerSupportsCancellation = true;
            this.bwFilterCodes.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFilterCodes_DoWork);
            this.bwFilterCodes.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFilterCodes_RunWorkerCompleted);
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
            this.panelParent.Location = new System.Drawing.Point(0, 110);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(1008, 538);
            this.panelParent.TabIndex = 16;
            // 
            // panelNode
            // 
            this.panelNode.Controls.Add(this.listViewCodes);
            this.panelNode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNode.Location = new System.Drawing.Point(0, 59);
            this.panelNode.Name = "panelNode";
            this.panelNode.Size = new System.Drawing.Size(313, 479);
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
            this.listViewCodes.Size = new System.Drawing.Size(313, 479);
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
            this.labelFilter.Size = new System.Drawing.Size(60, 13);
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
            this.splitterLeftMiddle.Size = new System.Drawing.Size(4, 538);
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
            this.panelMiddle.Size = new System.Drawing.Size(367, 538);
            this.panelMiddle.TabIndex = 12;
            // 
            // treeViewHierarchy
            // 
            this.treeViewHierarchy.AllowDrop = true;
            this.treeViewHierarchy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewHierarchy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewHierarchy.HideSelection = false;
            this.treeViewHierarchy.Location = new System.Drawing.Point(0, 83);
            this.treeViewHierarchy.Margin = new System.Windows.Forms.Padding(15);
            this.treeViewHierarchy.Name = "treeViewHierarchy";
            this.treeViewHierarchy.Size = new System.Drawing.Size(367, 455);
            this.treeViewHierarchy.TabIndex = 7;
            this.treeViewHierarchy.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewHierarchy_BeforeLabelEdit);
            this.treeViewHierarchy.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeViewHierarchy_AfterLabelEdit);
            this.treeViewHierarchy.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeViewHierarchy_ItemDrag);
            this.treeViewHierarchy.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewHierarchy_AfterSelect);
            this.treeViewHierarchy.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeViewHierarchy_DragDrop);
            this.treeViewHierarchy.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeViewHierarchy_DragEnter);
            this.treeViewHierarchy.DragOver += new System.Windows.Forms.DragEventHandler(this.treeViewHierarchy_DragOver);
            this.treeViewHierarchy.KeyUp += new System.Windows.Forms.KeyEventHandler(this.treeViewHierarchy_KeyUp);
            this.treeViewHierarchy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.treeViewHierarchy_MouseClick);
            this.treeViewHierarchy.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeViewHierarchy_MouseUp);
            // 
            // panelMiddleToolbar
            // 
            this.panelMiddleToolbar.Controls.Add(this.buttonSortTreeAZ);
            this.panelMiddleToolbar.Controls.Add(this.buttonSave);
            this.panelMiddleToolbar.Controls.Add(this.buttonDeleteHierarchyNode);
            this.panelMiddleToolbar.Controls.Add(this.buttonEditHierarchyNode);
            this.panelMiddleToolbar.Controls.Add(this.labelCodeHierarchy);
            this.panelMiddleToolbar.Controls.Add(this.buttonAddHierarchyNode);
            this.panelMiddleToolbar.Controls.Add(this.panelHierarchyFind);
            this.panelMiddleToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMiddleToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelMiddleToolbar.Name = "panelMiddleToolbar";
            this.panelMiddleToolbar.Size = new System.Drawing.Size(367, 83);
            this.panelMiddleToolbar.TabIndex = 16;
            this.panelMiddleToolbar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMiddleToolbar_Paint);
            // 
            // buttonSortTreeAZ
            // 
            this.buttonSortTreeAZ.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSortTreeAZ.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_sort_alpha_asc32;
            this.buttonSortTreeAZ.Location = new System.Drawing.Point(187, 0);
            this.buttonSortTreeAZ.Name = "buttonSortTreeAZ";
            this.buttonSortTreeAZ.Size = new System.Drawing.Size(36, 36);
            this.buttonSortTreeAZ.TabIndex = 19;
            this.buttonSortTreeAZ.Tag = "Save hierarchy";
            this.buttonSortTreeAZ.UseVisualStyleBackColor = true;
            this.buttonSortTreeAZ.Click += new System.EventHandler(this.buttonSortTreeAZ_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonSave.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_save_32;
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
            this.buttonDeleteHierarchyNode.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_trash_32;
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
            this.buttonEditHierarchyNode.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_edit_32;
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
            this.labelCodeHierarchy.Size = new System.Drawing.Size(102, 13);
            this.labelCodeHierarchy.TabIndex = 16;
            this.labelCodeHierarchy.Text = "Code Hierarchy (0):";
            // 
            // buttonAddHierarchyNode
            // 
            this.buttonAddHierarchyNode.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonAddHierarchyNode.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_add_32;
            this.buttonAddHierarchyNode.Location = new System.Drawing.Point(331, 0);
            this.buttonAddHierarchyNode.Name = "buttonAddHierarchyNode";
            this.buttonAddHierarchyNode.Size = new System.Drawing.Size(36, 36);
            this.buttonAddHierarchyNode.TabIndex = 14;
            this.buttonAddHierarchyNode.Tag = "Add node";
            this.buttonAddHierarchyNode.UseVisualStyleBackColor = true;
            this.buttonAddHierarchyNode.Click += new System.EventHandler(this.buttonAddHierarchyNode_Click);
            // 
            // panelHierarchyFind
            // 
            this.panelHierarchyFind.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHierarchyFind.Location = new System.Drawing.Point(0, 36);
            this.panelHierarchyFind.Name = "panelHierarchyFind";
            this.panelHierarchyFind.Size = new System.Drawing.Size(367, 47);
            this.panelHierarchyFind.TabIndex = 20;
            // 
            // splitterMiddleRight
            // 
            this.splitterMiddleRight.BackColor = System.Drawing.Color.DodgerBlue;
            this.splitterMiddleRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterMiddleRight.Location = new System.Drawing.Point(684, 0);
            this.splitterMiddleRight.Name = "splitterMiddleRight";
            this.splitterMiddleRight.Size = new System.Drawing.Size(4, 538);
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
            this.panelSidebar.Size = new System.Drawing.Size(320, 538);
            this.panelSidebar.TabIndex = 9;
            // 
            // panelSidebarBottom
            // 
            this.panelSidebarBottom.Controls.Add(this.listViewRef);
            this.panelSidebarBottom.Controls.Add(this.panelReferenceTextToolbar);
            this.panelSidebarBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSidebarBottom.Location = new System.Drawing.Point(0, 93);
            this.panelSidebarBottom.Name = "panelSidebarBottom";
            this.panelSidebarBottom.Size = new System.Drawing.Size(320, 445);
            this.panelSidebarBottom.TabIndex = 17;
            // 
            // listViewRef
            // 
            this.listViewRef.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnTextorCodes,
            this.columnCodesorFile,
            this.columnFileorNone});
            this.listViewRef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewRef.GridLines = true;
            this.listViewRef.Location = new System.Drawing.Point(0, 36);
            this.listViewRef.Name = "listViewRef";
            this.listViewRef.Size = new System.Drawing.Size(320, 409);
            this.listViewRef.TabIndex = 17;
            this.listViewRef.TileSize = new System.Drawing.Size(300, 60);
            this.listViewRef.UseCompatibleStateImageBehavior = false;
            this.listViewRef.View = System.Windows.Forms.View.Tile;
            this.listViewRef.SelectedIndexChanged += new System.EventHandler(this.listViewRef_SelectedIndexChanged);
            // 
            // columnTextorCodes
            // 
            this.columnTextorCodes.Text = "Text";
            this.columnTextorCodes.Width = 200;
            // 
            // columnCodesorFile
            // 
            this.columnCodesorFile.Text = "File Name";
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
            this.buttonCopyRef.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_copy_32;
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
            this.labelRef.Size = new System.Drawing.Size(100, 13);
            this.labelRef.TabIndex = 11;
            this.labelRef.Text = "Reference texts ():";
            // 
            // panelSidebarTop
            // 
            this.panelSidebarTop.Controls.Add(this.textCode);
            this.panelSidebarTop.Controls.Add(this.panelCodeTextToolbar);
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
            // panelCodeTextToolbar
            // 
            this.panelCodeTextToolbar.Controls.Add(this.labelCode);
            this.panelCodeTextToolbar.Controls.Add(this.buttonCopyComment);
            this.panelCodeTextToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCodeTextToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelCodeTextToolbar.Name = "panelCodeTextToolbar";
            this.panelCodeTextToolbar.Size = new System.Drawing.Size(320, 36);
            this.panelCodeTextToolbar.TabIndex = 15;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(14, 9);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(36, 13);
            this.labelCode.TabIndex = 12;
            this.labelCode.Text = "Code:";
            // 
            // buttonCopyComment
            // 
            this.buttonCopyComment.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonCopyComment.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_copy_32;
            this.buttonCopyComment.Location = new System.Drawing.Point(284, 0);
            this.buttonCopyComment.Name = "buttonCopyComment";
            this.buttonCopyComment.Size = new System.Drawing.Size(36, 36);
            this.buttonCopyComment.TabIndex = 14;
            this.buttonCopyComment.Tag = "Copy to clipboard";
            this.buttonCopyComment.UseVisualStyleBackColor = true;
            this.buttonCopyComment.Click += new System.EventHandler(this.buttonCopyComment_Click);
            // 
            // imageListRef
            // 
            this.imageListRef.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListRef.ImageStream")));
            this.imageListRef.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListRef.Images.SetKeyName(0, "WIN_20171108_121108.JPG");
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelSeparator.Controls.Add(this.progressBar1);
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Location = new System.Drawing.Point(0, 107);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(1008, 3);
            this.panelSeparator.TabIndex = 17;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1008, 3);
            this.progressBar1.TabIndex = 0;
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(526, 0);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(120, 36);
            this.buttonAnalyze.TabIndex = 4;
            this.buttonAnalyze.Text = "Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // textWorkingDir
            // 
            this.textWorkingDir.Location = new System.Drawing.Point(115, 7);
            this.textWorkingDir.Name = "textWorkingDir";
            this.textWorkingDir.ReadOnly = true;
            this.textWorkingDir.Size = new System.Drawing.Size(269, 21);
            this.textWorkingDir.TabIndex = 1;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(400, 0);
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
            this.labelWD.Location = new System.Drawing.Point(12, 10);
            this.labelWD.Name = "labelWD";
            this.labelWD.Size = new System.Drawing.Size(97, 13);
            this.labelWD.TabIndex = 2;
            this.labelWD.Text = "Working Directory:";
            // 
            // checkRTL
            // 
            this.checkRTL.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkRTL.AutoSize = true;
            this.checkRTL.Location = new System.Drawing.Point(12, 78);
            this.checkRTL.Name = "checkRTL";
            this.checkRTL.Size = new System.Drawing.Size(77, 23);
            this.checkRTL.TabIndex = 3;
            this.checkRTL.Text = "Right to Left";
            this.checkRTL.UseVisualStyleBackColor = true;
            this.checkRTL.CheckedChanged += new System.EventHandler(this.checkRTL_CheckedChanged);
            // 
            // labelCulture
            // 
            this.labelCulture.AutoSize = true;
            this.labelCulture.Location = new System.Drawing.Point(95, 83);
            this.labelCulture.Name = "labelCulture";
            this.labelCulture.Size = new System.Drawing.Size(46, 13);
            this.labelCulture.TabIndex = 5;
            this.labelCulture.Text = "Culture:";
            // 
            // textCulture
            // 
            this.textCulture.Location = new System.Drawing.Point(147, 80);
            this.textCulture.Name = "textCulture";
            this.textCulture.Size = new System.Drawing.Size(49, 21);
            this.textCulture.TabIndex = 6;
            this.textCulture.Text = "en-US";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.White;
            this.panelTop.Controls.Add(this.panelWorkingDirBrowseAnalyze);
            this.panelTop.Controls.Add(this.radioMiniCodelist);
            this.panelTop.Controls.Add(this.labelView);
            this.panelTop.Controls.Add(this.radioThreePanels);
            this.panelTop.Controls.Add(this.textCulture);
            this.panelTop.Controls.Add(this.labelCulture);
            this.panelTop.Controls.Add(this.checkRTL);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1008, 107);
            this.panelTop.TabIndex = 8;
            this.panelTop.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // panelWorkingDirBrowseAnalyze
            // 
            this.panelWorkingDirBrowseAnalyze.Controls.Add(this.labelWD);
            this.panelWorkingDirBrowseAnalyze.Controls.Add(this.textWorkingDir);
            this.panelWorkingDirBrowseAnalyze.Controls.Add(this.buttonBrowse);
            this.panelWorkingDirBrowseAnalyze.Controls.Add(this.buttonAnalyze);
            this.panelWorkingDirBrowseAnalyze.Location = new System.Drawing.Point(0, 40);
            this.panelWorkingDirBrowseAnalyze.Name = "panelWorkingDirBrowseAnalyze";
            this.panelWorkingDirBrowseAnalyze.Size = new System.Drawing.Size(697, 35);
            this.panelWorkingDirBrowseAnalyze.TabIndex = 11;
            // 
            // radioMiniCodelist
            // 
            this.radioMiniCodelist.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioMiniCodelist.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.radioMiniCodelist.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.radioMiniCodelist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioMiniCodelist.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_view_one_column_modified_24;
            this.radioMiniCodelist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioMiniCodelist.Location = new System.Drawing.Point(169, 12);
            this.radioMiniCodelist.Name = "radioMiniCodelist";
            this.radioMiniCodelist.Size = new System.Drawing.Size(94, 28);
            this.radioMiniCodelist.TabIndex = 10;
            this.radioMiniCodelist.Text = "Mini code list";
            this.radioMiniCodelist.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioMiniCodelist.UseVisualStyleBackColor = true;
            this.radioMiniCodelist.CheckedChanged += new System.EventHandler(this.View_Changed);
            // 
            // labelView
            // 
            this.labelView.AutoSize = true;
            this.labelView.Location = new System.Drawing.Point(12, 20);
            this.labelView.Name = "labelView";
            this.labelView.Size = new System.Drawing.Size(33, 13);
            this.labelView.TabIndex = 9;
            this.labelView.Text = "View:";
            // 
            // radioThreePanels
            // 
            this.radioThreePanels.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioThreePanels.Checked = true;
            this.radioThreePanels.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.radioThreePanels.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.radioThreePanels.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioThreePanels.Image = global::WordCommentsAnalyzer.Properties.Resources.libre_gui_view_column_24;
            this.radioThreePanels.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioThreePanels.Location = new System.Drawing.Point(51, 12);
            this.radioThreePanels.Name = "radioThreePanels";
            this.radioThreePanels.Size = new System.Drawing.Size(107, 28);
            this.radioThreePanels.TabIndex = 8;
            this.radioThreePanels.TabStop = true;
            this.radioThreePanels.Text = "Three panels";
            this.radioThreePanels.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioThreePanels.UseVisualStyleBackColor = true;
            this.radioThreePanels.CheckedChanged += new System.EventHandler(this.View_Changed);
            // 
            // timerAutoSaveHierarchy
            // 
            this.timerAutoSaveHierarchy.Enabled = true;
            this.timerAutoSaveHierarchy.Interval = 60000;
            this.timerAutoSaveHierarchy.Tick += new System.EventHandler(this.timerAutoSaveHierarchy_Tick);
            // 
            // bwAnalyze
            // 
            this.bwAnalyze.WorkerReportsProgress = true;
            this.bwAnalyze.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwAnalyze_DoWork);
            this.bwAnalyze.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwAnalyze_ProgressChanged);
            this.bwAnalyze.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwAnalyze_RunWorkerCompleted);
            // 
            // hierarchyContextMenu
            // 
            this.hierarchyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMoveTo});
            this.hierarchyContextMenu.Name = "codehierarchyContextMenu";
            this.hierarchyContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.hierarchyContextMenu.Size = new System.Drawing.Size(122, 26);
            // 
            // menuItemMoveTo
            // 
            this.menuItemMoveTo.Name = "menuItemMoveTo";
            this.menuItemMoveTo.Size = new System.Drawing.Size(121, 22);
            this.menuItemMoveTo.Text = "Move To";
            this.menuItemMoveTo.Click += new System.EventHandler(this.menuItemMoveTo_Click);
            this.menuItemMoveTo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.menuItemMoveTo_MouseUp);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panelParent);
            this.Controls.Add(this.panelSeparator);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.textLog);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Main";
            this.Text = "Word Comments Analyzer []";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
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
            this.panelCodeTextToolbar.ResumeLayout(false);
            this.panelCodeTextToolbar.PerformLayout();
            this.panelSeparator.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelWorkingDirBrowseAnalyze.ResumeLayout(false);
            this.panelWorkingDirBrowseAnalyze.PerformLayout();
            this.hierarchyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textLog;
        private System.ComponentModel.BackgroundWorker bwFilterCodes;
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
        private System.Windows.Forms.Panel panelCodeTextToolbar;
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
        private System.Windows.Forms.ColumnHeader columnTextorCodes;
        private System.Windows.Forms.ColumnHeader columnCodesorFile;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.TextBox textWorkingDir;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelWD;
        private System.Windows.Forms.CheckBox checkRTL;
        private System.Windows.Forms.Label labelCulture;
        private System.Windows.Forms.TextBox textCulture;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelCodeHierarchy;
        private System.Windows.Forms.Timer timerAutoSaveHierarchy;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonEditHierarchyNode;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker bwAnalyze;
        private System.Windows.Forms.ImageList imageListRef;
        private System.Windows.Forms.ColumnHeader columnFileorNone;
        private System.Windows.Forms.Label labelView;
        private System.Windows.Forms.RadioButton radioThreePanels;
        private System.Windows.Forms.RadioButton radioMiniCodelist;
        private System.Windows.Forms.Panel panelWorkingDirBrowseAnalyze;
        private System.Windows.Forms.Button buttonSortTreeAZ;
        private System.Windows.Forms.Panel panelHierarchyFind;
        private System.Windows.Forms.ContextMenuStrip hierarchyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemMoveTo;
    }
}

