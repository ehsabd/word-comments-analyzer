using System.Runtime.InteropServices;

namespace WordCommentsAnalyzer
{
    [ComVisible(true)]
    partial class VisualizeForm
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
            this.bwFindCooccurrences = new System.ComponentModel.BackgroundWorker();
            this.pseudoTimerStartUpdatingGrid = new System.Windows.Forms.Timer(this.components);
            this.panelLeftToolbar = new System.Windows.Forms.Panel();
            this.radioCodeFile = new System.Windows.Forms.RadioButton();
            this.radioCodeCoOccurrences = new System.Windows.Forms.RadioButton();
            this.splitContainerParent = new System.Windows.Forms.SplitContainer();
            this.splitContainerLeft = new System.Windows.Forms.SplitContainer();
            this.listViewCodesA = new System.Windows.Forms.ListView();
            this.labelCodesA = new System.Windows.Forms.Label();
            this.labelFiles = new System.Windows.Forms.Label();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.listViewCodesB = new System.Windows.Forms.ListView();
            this.labelCodesB = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.bwCalculateFileCodeMatrix = new System.ComponentModel.BackgroundWorker();
            this.panelLeftToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerParent)).BeginInit();
            this.splitContainerParent.Panel1.SuspendLayout();
            this.splitContainerParent.Panel2.SuspendLayout();
            this.splitContainerParent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).BeginInit();
            this.splitContainerLeft.Panel1.SuspendLayout();
            this.splitContainerLeft.Panel2.SuspendLayout();
            this.splitContainerLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // bwFindCooccurrences
            // 
            this.bwFindCooccurrences.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFindCooccurrences_DoWork);
            this.bwFindCooccurrences.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFindCooccurrences_RunWorkerCompleted);
            // 
            // pseudoTimerStartUpdatingGrid
            // 
            this.pseudoTimerStartUpdatingGrid.Interval = 1000;
            this.pseudoTimerStartUpdatingGrid.Tick += new System.EventHandler(this.pseudoTimerStartUpdatingGrid_Tick);
            // 
            // panelLeftToolbar
            // 
            this.panelLeftToolbar.Controls.Add(this.radioCodeFile);
            this.panelLeftToolbar.Controls.Add(this.radioCodeCoOccurrences);
            this.panelLeftToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelLeftToolbar.Name = "panelLeftToolbar";
            this.panelLeftToolbar.Size = new System.Drawing.Size(898, 30);
            this.panelLeftToolbar.TabIndex = 22;
            // 
            // radioCodeFile
            // 
            this.radioCodeFile.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioCodeFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.radioCodeFile.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.radioCodeFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioCodeFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioCodeFile.Location = new System.Drawing.Point(169, 5);
            this.radioCodeFile.Name = "radioCodeFile";
            this.radioCodeFile.Size = new System.Drawing.Size(130, 28);
            this.radioCodeFile.TabIndex = 12;
            this.radioCodeFile.Text = "File Code Matrix";
            this.radioCodeFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radioCodeFile.UseVisualStyleBackColor = true;
            this.radioCodeFile.CheckedChanged += new System.EventHandler(this.radioItemCheckedChanged);
            // 
            // radioCodeCoOccurrences
            // 
            this.radioCodeCoOccurrences.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioCodeCoOccurrences.Checked = true;
            this.radioCodeCoOccurrences.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.radioCodeCoOccurrences.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.radioCodeCoOccurrences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioCodeCoOccurrences.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioCodeCoOccurrences.Location = new System.Drawing.Point(12, 5);
            this.radioCodeCoOccurrences.Name = "radioCodeCoOccurrences";
            this.radioCodeCoOccurrences.Size = new System.Drawing.Size(151, 28);
            this.radioCodeCoOccurrences.TabIndex = 11;
            this.radioCodeCoOccurrences.TabStop = true;
            this.radioCodeCoOccurrences.Text = "Code Co-Occurrence Matrix";
            this.radioCodeCoOccurrences.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioCodeCoOccurrences.UseVisualStyleBackColor = true;
            this.radioCodeCoOccurrences.CheckedChanged += new System.EventHandler(this.radioItemCheckedChanged);
            // 
            // splitContainerParent
            // 
            this.splitContainerParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerParent.Location = new System.Drawing.Point(0, 30);
            this.splitContainerParent.Name = "splitContainerParent";
            // 
            // splitContainerParent.Panel1
            // 
            this.splitContainerParent.Panel1.Controls.Add(this.splitContainerLeft);
            // 
            // splitContainerParent.Panel2
            // 
            this.splitContainerParent.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainerParent.Size = new System.Drawing.Size(898, 642);
            this.splitContainerParent.SplitterDistance = 299;
            this.splitContainerParent.TabIndex = 25;
            // 
            // splitContainerLeft
            // 
            this.splitContainerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerLeft.Name = "splitContainerLeft";
            this.splitContainerLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerLeft.Panel1
            // 
            this.splitContainerLeft.Panel1.Controls.Add(this.listViewCodesA);
            this.splitContainerLeft.Panel1.Controls.Add(this.labelCodesA);
            // 
            // splitContainerLeft.Panel2
            // 
            this.splitContainerLeft.Panel2.Controls.Add(this.labelFiles);
            this.splitContainerLeft.Panel2.Controls.Add(this.listViewFiles);
            this.splitContainerLeft.Panel2.Controls.Add(this.listViewCodesB);
            this.splitContainerLeft.Panel2.Controls.Add(this.labelCodesB);
            this.splitContainerLeft.Size = new System.Drawing.Size(299, 642);
            this.splitContainerLeft.SplitterDistance = 300;
            this.splitContainerLeft.TabIndex = 0;
            // 
            // listViewCodesA
            // 
            this.listViewCodesA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCodesA.Location = new System.Drawing.Point(0, 25);
            this.listViewCodesA.Name = "listViewCodesA";
            this.listViewCodesA.Size = new System.Drawing.Size(299, 275);
            this.listViewCodesA.TabIndex = 24;
            this.listViewCodesA.UseCompatibleStateImageBehavior = false;
            // 
            // labelCodesA
            // 
            this.labelCodesA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelCodesA.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCodesA.Location = new System.Drawing.Point(0, 0);
            this.labelCodesA.Name = "labelCodesA";
            this.labelCodesA.Size = new System.Drawing.Size(299, 25);
            this.labelCodesA.TabIndex = 25;
            this.labelCodesA.Text = "0 Codes";
            this.labelCodesA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFiles
            // 
            this.labelFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelFiles.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFiles.Location = new System.Drawing.Point(0, 25);
            this.labelFiles.Name = "labelFiles";
            this.labelFiles.Size = new System.Drawing.Size(299, 25);
            this.labelFiles.TabIndex = 25;
            this.labelFiles.Text = "0 Files";
            this.labelFiles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelFiles.Visible = false;
            // 
            // listViewFiles
            // 
            this.listViewFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFiles.FullRowSelect = true;
            this.listViewFiles.Location = new System.Drawing.Point(0, 25);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(299, 313);
            this.listViewFiles.TabIndex = 24;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.Visible = false;
            // 
            // listViewCodesB
            // 
            this.listViewCodesB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCodesB.Location = new System.Drawing.Point(0, 25);
            this.listViewCodesB.Name = "listViewCodesB";
            this.listViewCodesB.Size = new System.Drawing.Size(299, 313);
            this.listViewCodesB.TabIndex = 22;
            this.listViewCodesB.UseCompatibleStateImageBehavior = false;
            // 
            // labelCodesB
            // 
            this.labelCodesB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.labelCodesB.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCodesB.Location = new System.Drawing.Point(0, 0);
            this.labelCodesB.Name = "labelCodesB";
            this.labelCodesB.Size = new System.Drawing.Size(299, 25);
            this.labelCodesB.TabIndex = 23;
            this.labelCodesB.Text = "0 Codes";
            this.labelCodesB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(595, 642);
            this.webBrowser1.TabIndex = 11;
            // 
            // bwCalculateFileCodeMatrix
            // 
            this.bwCalculateFileCodeMatrix.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCalculateFileCodeMatrix_DoWork);
            this.bwCalculateFileCodeMatrix.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCalculateFileCodeMatrix_RunWorkerCompleted);
            // 
            // VisualizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 672);
            this.Controls.Add(this.splitContainerParent);
            this.Controls.Add(this.panelLeftToolbar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "VisualizeForm";
            this.Text = "Visualize";
            this.Load += new System.EventHandler(this.Form_Load);
            this.panelLeftToolbar.ResumeLayout(false);
            this.splitContainerParent.Panel1.ResumeLayout(false);
            this.splitContainerParent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerParent)).EndInit();
            this.splitContainerParent.ResumeLayout(false);
            this.splitContainerLeft.Panel1.ResumeLayout(false);
            this.splitContainerLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerLeft)).EndInit();
            this.splitContainerLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bwFindCooccurrences;
        private System.Windows.Forms.Timer pseudoTimerStartUpdatingGrid;
        private System.Windows.Forms.Panel panelLeftToolbar;
        private System.Windows.Forms.SplitContainer splitContainerParent;
        private System.Windows.Forms.SplitContainer splitContainerLeft;
        private System.Windows.Forms.ListView listViewCodesA;
        private System.Windows.Forms.Label labelCodesA;
        private System.Windows.Forms.ListView listViewCodesB;
        private System.Windows.Forms.Label labelCodesB;
        public System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.RadioButton radioCodeFile;
        private System.Windows.Forms.RadioButton radioCodeCoOccurrences;
        private System.Windows.Forms.Label labelFiles;
        private System.Windows.Forms.ListView listViewFiles;
        private System.ComponentModel.BackgroundWorker bwCalculateFileCodeMatrix;
    }
}