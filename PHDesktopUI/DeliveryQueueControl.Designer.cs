namespace PHDesktopUI
{
    partial class DeliveryQueueControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryQueueControl));
            this.labelDeliveryQueue = new System.Windows.Forms.Label();
            this.tableLayoutDeliveryQueue = new System.Windows.Forms.TableLayoutPanel();
            this.labelTokenId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonRefreshDeliveryJob = new System.Windows.Forms.Button();
            this.panelTitleBG = new System.Windows.Forms.Panel();
            this.tableLayoutDeliveryQueue.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDeliveryQueue
            // 
            this.labelDeliveryQueue.AutoSize = true;
            this.labelDeliveryQueue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(75)))));
            this.labelDeliveryQueue.Font = new System.Drawing.Font("Century Gothic", 16F);
            this.labelDeliveryQueue.ForeColor = System.Drawing.Color.White;
            this.labelDeliveryQueue.Location = new System.Drawing.Point(3, 9);
            this.labelDeliveryQueue.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelDeliveryQueue.Name = "labelDeliveryQueue";
            this.labelDeliveryQueue.Size = new System.Drawing.Size(178, 25);
            this.labelDeliveryQueue.TabIndex = 1;
            this.labelDeliveryQueue.Text = "Delivery Queue";
            // 
            // tableLayoutDeliveryQueue
            // 
            this.tableLayoutDeliveryQueue.AutoSize = true;
            this.tableLayoutDeliveryQueue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutDeliveryQueue.ColumnCount = 5;
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutDeliveryQueue.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutDeliveryQueue.Controls.Add(this.labelTokenId, 0, 0);
            this.tableLayoutDeliveryQueue.Controls.Add(this.label1, 1, 0);
            this.tableLayoutDeliveryQueue.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutDeliveryQueue.Location = new System.Drawing.Point(10, 70);
            this.tableLayoutDeliveryQueue.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutDeliveryQueue.Name = "tableLayoutDeliveryQueue";
            this.tableLayoutDeliveryQueue.RowCount = 1;
            this.tableLayoutDeliveryQueue.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutDeliveryQueue.Size = new System.Drawing.Size(130, 33);
            this.tableLayoutDeliveryQueue.TabIndex = 2;
            // 
            // labelTokenId
            // 
            this.labelTokenId.AutoSize = true;
            this.labelTokenId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTokenId.Location = new System.Drawing.Point(5, 0);
            this.labelTokenId.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelTokenId.Name = "labelTokenId";
            this.labelTokenId.Size = new System.Drawing.Size(62, 33);
            this.labelTokenId.TabIndex = 2;
            this.labelTokenId.Text = "Token ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // buttonRefreshDeliveryJob
            // 
            this.buttonRefreshDeliveryJob.AutoSize = true;
            this.buttonRefreshDeliveryJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.buttonRefreshDeliveryJob.FlatAppearance.BorderSize = 0;
            this.buttonRefreshDeliveryJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefreshDeliveryJob.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.buttonRefreshDeliveryJob.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefreshDeliveryJob.Image")));
            this.buttonRefreshDeliveryJob.Location = new System.Drawing.Point(554, 16);
            this.buttonRefreshDeliveryJob.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRefreshDeliveryJob.Name = "buttonRefreshDeliveryJob";
            this.buttonRefreshDeliveryJob.Padding = new System.Windows.Forms.Padding(8);
            this.buttonRefreshDeliveryJob.Size = new System.Drawing.Size(46, 46);
            this.buttonRefreshDeliveryJob.TabIndex = 4;
            this.buttonRefreshDeliveryJob.UseVisualStyleBackColor = false;
            this.buttonRefreshDeliveryJob.Click += new System.EventHandler(this.buttonRefreshDeliveryJob_Click);
            // 
            // panelTitleBG
            // 
            this.panelTitleBG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(75)))));
            this.panelTitleBG.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBG.Name = "panelTitleBG";
            this.panelTitleBG.Size = new System.Drawing.Size(614, 48);
            this.panelTitleBG.TabIndex = 5;
            // 
            // DeliveryQueueControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.buttonRefreshDeliveryJob);
            this.Controls.Add(this.tableLayoutDeliveryQueue);
            this.Controls.Add(this.labelDeliveryQueue);
            this.Controls.Add(this.panelTitleBG);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "DeliveryQueueControl";
            this.Size = new System.Drawing.Size(614, 486);
            this.tableLayoutDeliveryQueue.ResumeLayout(false);
            this.tableLayoutDeliveryQueue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDeliveryQueue;
        private System.Windows.Forms.TableLayoutPanel tableLayoutDeliveryQueue;
        private System.Windows.Forms.Label labelTokenId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonRefreshDeliveryJob;
        private System.Windows.Forms.Panel panelTitleBG;
    }
}
