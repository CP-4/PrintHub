namespace PHDesktopUI
{
    partial class PrintQueueControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPrintQueue = new System.Windows.Forms.Label();
            this.tableLayoutPrintQueue = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTitleBG = new System.Windows.Forms.Panel();
            this.tableLayoutPrintQueue.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPrintQueue
            // 
            this.labelPrintQueue.AutoSize = true;
            this.labelPrintQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(75)))));
            this.labelPrintQueue.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.labelPrintQueue.ForeColor = System.Drawing.Color.White;
            this.labelPrintQueue.Location = new System.Drawing.Point(3, 9);
            this.labelPrintQueue.Name = "labelPrintQueue";
            this.labelPrintQueue.Size = new System.Drawing.Size(136, 25);
            this.labelPrintQueue.TabIndex = 0;
            this.labelPrintQueue.Text = "Print Queue";
            // 
            // tableLayoutPrintQueue
            // 
            this.tableLayoutPrintQueue.AutoSize = true;
            this.tableLayoutPrintQueue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPrintQueue.ColumnCount = 5;
            this.tableLayoutPrintQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPrintQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPrintQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPrintQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPrintQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPrintQueue.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPrintQueue.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPrintQueue.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPrintQueue.Location = new System.Drawing.Point(10, 70);
            this.tableLayoutPrintQueue.Name = "tableLayoutPrintQueue";
            this.tableLayoutPrintQueue.RowCount = 1;
            this.tableLayoutPrintQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPrintQueue.Size = new System.Drawing.Size(122, 21);
            this.tableLayoutPrintQueue.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Token ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // panelTitleBG
            // 
            this.panelTitleBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(75)))));
            this.panelTitleBG.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBG.Name = "panelTitleBG";
            this.panelTitleBG.Size = new System.Drawing.Size(614, 48);
            this.panelTitleBG.TabIndex = 6;
            // 
            // PrintQueueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPrintQueue);
            this.Controls.Add(this.labelPrintQueue);
            this.Controls.Add(this.panelTitleBG);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PrintQueueControl";
            this.Size = new System.Drawing.Size(614, 486);
            this.tableLayoutPrintQueue.ResumeLayout(false);
            this.tableLayoutPrintQueue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPrintQueue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPrintQueue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelTitleBG;
    }
}
