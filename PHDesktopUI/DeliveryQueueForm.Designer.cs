namespace PHDesktopUI
{
    partial class PrintHubForm
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.tableLayoutDeliveryQueue = new System.Windows.Forms.TableLayoutPanel();
            this.labelTokenId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRefreshDeliveryJob = new System.Windows.Forms.Button();
            this.tableLayoutDeliveryQueue.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.Black;
            this.headerLabel.Location = new System.Drawing.Point(12, 9);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(129, 21);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Delivery Queue";
            // 
            // tableLayoutDeliveryQueue
            // 
            this.tableLayoutDeliveryQueue.AutoSize = true;
            this.tableLayoutDeliveryQueue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutDeliveryQueue.ColumnCount = 4;
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.07013F));
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.92987F));
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutDeliveryQueue.Controls.Add(this.labelTokenId, 0, 0);
            this.tableLayoutDeliveryQueue.Controls.Add(this.label1, 1, 0);
            this.tableLayoutDeliveryQueue.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutDeliveryQueue.Location = new System.Drawing.Point(12, 52);
            this.tableLayoutDeliveryQueue.Name = "tableLayoutDeliveryQueue";
            this.tableLayoutDeliveryQueue.RowCount = 1;
            this.tableLayoutDeliveryQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDeliveryQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDeliveryQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutDeliveryQueue.Size = new System.Drawing.Size(270, 20);
            this.tableLayoutDeliveryQueue.TabIndex = 1;
            this.tableLayoutDeliveryQueue.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // labelTokenId
            // 
            this.labelTokenId.AutoSize = true;
            this.labelTokenId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTokenId.Location = new System.Drawing.Point(3, 0);
            this.labelTokenId.Name = "labelTokenId";
            this.labelTokenId.Size = new System.Drawing.Size(62, 20);
            this.labelTokenId.TabIndex = 2;
            this.labelTokenId.Text = "Token ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // buttonRefreshDeliveryJob
            // 
            this.buttonRefreshDeliveryJob.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.buttonRefreshDeliveryJob.Location = new System.Drawing.Point(397, 13);
            this.buttonRefreshDeliveryJob.Name = "buttonRefreshDeliveryJob";
            this.buttonRefreshDeliveryJob.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshDeliveryJob.TabIndex = 3;
            this.buttonRefreshDeliveryJob.Text = "Refresh";
            this.buttonRefreshDeliveryJob.UseVisualStyleBackColor = true;
            this.buttonRefreshDeliveryJob.Click += new System.EventHandler(this.buttonRefreshDeliveryJob_Click);
            // 
            // PrintHubForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(488, 536);
            this.Controls.Add(this.buttonRefreshDeliveryJob);
            this.Controls.Add(this.tableLayoutDeliveryQueue);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PrintHubForm";
            this.Text = "Print Hub";
            this.Load += new System.EventHandler(this.PrintHub_Load);
            this.tableLayoutDeliveryQueue.ResumeLayout(false);
            this.tableLayoutDeliveryQueue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutDeliveryQueue;
        private System.Windows.Forms.Label labelTokenId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRefreshDeliveryJob;
    }
}

