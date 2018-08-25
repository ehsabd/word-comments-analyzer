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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.labelCodesB = new System.Windows.Forms.Label();
            this.listViewCodesB = new System.Windows.Forms.ListView();
            this.labelCodesA = new System.Windows.Forms.Label();
            this.listViewCodesA = new System.Windows.Forms.ListView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.radioCodeDocument = new System.Windows.Forms.RadioButton();
            this.radioCodeCoOccurrences = new System.Windows.Forms.RadioButton();
            this.panelLeftToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.panelLeftToolbar.Controls.Add(this.radioCodeDocument);
            this.panelLeftToolbar.Controls.Add(this.radioCodeCoOccurrences);
            this.panelLeftToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLeftToolbar.Location = new System.Drawing.Point(0, 0);
            this.panelLeftToolbar.Name = "panelLeftToolbar";
            this.panelLeftToolbar.Size = new System.Drawing.Size(898, 30);
            this.panelLeftToolbar.TabIndex = 22;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(898, 642);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 25;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listViewCodesA);
            this.splitContainer2.Panel1.Controls.Add(this.labelCodesA);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listViewCodesB);
            this.splitContainer2.Panel2.Controls.Add(this.labelCodesB);
            this.splitContainer2.Size = new System.Drawing.Size(299, 642);
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer2.TabIndex = 0;
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
            // listViewCodesB
            // 
            this.listViewCodesB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCodesB.Location = new System.Drawing.Point(0, 25);
            this.listViewCodesB.Name = "listViewCodesB";
            this.listViewCodesB.Size = new System.Drawing.Size(299, 313);
            this.listViewCodesB.TabIndex = 22;
            this.listViewCodesB.UseCompatibleStateImageBehavior = false;
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
            // listViewCodesA
            // 
            this.listViewCodesA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCodesA.Location = new System.Drawing.Point(0, 25);
            this.listViewCodesA.Name = "listViewCodesA";
            this.listViewCodesA.Size = new System.Drawing.Size(299, 275);
            this.listViewCodesA.TabIndex = 24;
            this.listViewCodesA.UseCompatibleStateImageBehavior = false;
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
            // radioCodeDocument
            // 
            this.radioCodeDocument.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioCodeDocument.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.radioCodeDocument.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.radioCodeDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioCodeDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioCodeDocument.Location = new System.Drawing.Point(169, 5);
            this.radioCodeDocument.Name = "radioCodeDocument";
            this.radioCodeDocument.Size = new System.Drawing.Size(130, 28);
            this.radioCodeDocument.TabIndex = 12;
            this.radioCodeDocument.Text = "Code Document Matrix";
            this.radioCodeDocument.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioCodeDocument.UseVisualStyleBackColor = true;
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
            this.radioCodeCoOccurrences.Text = "Code CoOccurrence Matrix";
            this.radioCodeCoOccurrences.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioCodeCoOccurrences.UseVisualStyleBackColor = true;
            // 
            // CodeDocumentMatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 672);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panelLeftToolbar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CodeDocumentMatrixForm";
            this.Text = "Visualize";
            this.Load += new System.EventHandler(this.CodeDocumentMatrixForm_Load);
            this.panelLeftToolbar.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bwFindCooccurrences;
        private System.Windows.Forms.Timer pseudoTimerStartUpdatingGrid;
        private System.Windows.Forms.Panel panelLeftToolbar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView listViewCodesA;
        private System.Windows.Forms.Label labelCodesA;
        private System.Windows.Forms.ListView listViewCodesB;
        private System.Windows.Forms.Label labelCodesB;
        public System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.RadioButton radioCodeDocument;
        private System.Windows.Forms.RadioButton radioCodeCoOccurrences;
    }
}