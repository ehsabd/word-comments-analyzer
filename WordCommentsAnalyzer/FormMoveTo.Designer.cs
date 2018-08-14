namespace WordCommentsAnalyzer
{
    partial class FormMoveTo
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
            this.textFilter = new System.Windows.Forms.TextBox();
            this.labelFilterText = new System.Windows.Forms.Label();
            this.treeViewMoveTo = new System.Windows.Forms.TreeView();
            this.buttonMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textFilter
            // 
            this.textFilter.Location = new System.Drawing.Point(12, 36);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(100, 21);
            this.textFilter.TabIndex = 0;
            this.textFilter.TextChanged += new System.EventHandler(this.textFilter_TextChanged);
            // 
            // labelFilterText
            // 
            this.labelFilterText.AutoSize = true;
            this.labelFilterText.Location = new System.Drawing.Point(12, 20);
            this.labelFilterText.Name = "labelFilterText";
            this.labelFilterText.Size = new System.Drawing.Size(58, 13);
            this.labelFilterText.TabIndex = 1;
            this.labelFilterText.Text = "Filter text:";
            // 
            // treeViewMoveTo
            // 
            this.treeViewMoveTo.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeViewMoveTo.Location = new System.Drawing.Point(12, 62);
            this.treeViewMoveTo.Name = "treeViewMoveTo";
            this.treeViewMoveTo.Size = new System.Drawing.Size(222, 187);
            this.treeViewMoveTo.TabIndex = 2;
            this.treeViewMoveTo.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeViewMoveTo_DrawNode);
            this.treeViewMoveTo.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewMoveTo_AfterSelect);
            // 
            // buttonMove
            // 
            this.buttonMove.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonMove.Location = new System.Drawing.Point(15, 261);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(75, 23);
            this.buttonMove.TabIndex = 3;
            this.buttonMove.Text = "Move";
            this.buttonMove.UseVisualStyleBackColor = true;
            // 
            // FormMoveTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 296);
            this.Controls.Add(this.buttonMove);
            this.Controls.Add(this.treeViewMoveTo);
            this.Controls.Add(this.labelFilterText);
            this.Controls.Add(this.textFilter);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMoveTo";
            this.Text = " Move To:";
            this.Load += new System.EventHandler(this.FormMoveTo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textFilter;
        private System.Windows.Forms.Label labelFilterText;
        private System.Windows.Forms.TreeView treeViewMoveTo;
        private System.Windows.Forms.Button buttonMove;
    }
}