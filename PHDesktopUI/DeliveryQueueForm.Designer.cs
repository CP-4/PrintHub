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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintHubForm));
            this.panelSelected = new System.Windows.Forms.Panel();
            this.buttonPrintPause = new System.Windows.Forms.Button();
            this.buttonPrintQueue = new System.Windows.Forms.Button();
            this.buttonDeliveryQueue = new System.Windows.Forms.Button();
            this.buttonPrintHistory = new System.Windows.Forms.Button();
            this.labelAppTitle = new System.Windows.Forms.Label();
            this.panelPrintPause = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.printQueueControl1 = new PHDesktopUI.PrintQueueControl();
            this.deliveryQueueControl1 = new PHDesktopUI.DeliveryQueueControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSelected
            // 
            this.panelSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(84)))));
            this.panelSelected.Location = new System.Drawing.Point(0, 90);
            this.panelSelected.Margin = new System.Windows.Forms.Padding(0);
            this.panelSelected.Name = "panelSelected";
            this.panelSelected.Size = new System.Drawing.Size(10, 75);
            this.panelSelected.TabIndex = 7;
            // 
            // buttonPrintPause
            // 
            this.buttonPrintPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
            this.buttonPrintPause.FlatAppearance.BorderSize = 0;
            this.buttonPrintPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrintPause.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrintPause.ForeColor = System.Drawing.Color.White;
            this.buttonPrintPause.Image = global::PHDesktopUI.Properties.Resources.play_7_24;
            this.buttonPrintPause.Location = new System.Drawing.Point(0, 450);
            this.buttonPrintPause.Name = "buttonPrintPause";
            this.buttonPrintPause.Padding = new System.Windows.Forms.Padding(12);
            this.buttonPrintPause.Size = new System.Drawing.Size(200, 75);
            this.buttonPrintPause.TabIndex = 4;
            this.buttonPrintPause.Text = "   Auto accept: OFF";
            this.buttonPrintPause.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrintPause.UseVisualStyleBackColor = false;
            this.buttonPrintPause.Click += new System.EventHandler(this.buttonPrintPause_Click);
            // 
            // buttonPrintQueue
            // 
            this.buttonPrintQueue.FlatAppearance.BorderSize = 0;
            this.buttonPrintQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrintQueue.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrintQueue.ForeColor = System.Drawing.Color.White;
            this.buttonPrintQueue.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrintQueue.Image")));
            this.buttonPrintQueue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrintQueue.Location = new System.Drawing.Point(0, 90);
            this.buttonPrintQueue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPrintQueue.Name = "buttonPrintQueue";
            this.buttonPrintQueue.Padding = new System.Windows.Forms.Padding(12);
            this.buttonPrintQueue.Size = new System.Drawing.Size(200, 75);
            this.buttonPrintQueue.TabIndex = 8;
            this.buttonPrintQueue.Text = "Print Queue";
            this.buttonPrintQueue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonPrintQueue.UseVisualStyleBackColor = true;
            this.buttonPrintQueue.Click += new System.EventHandler(this.buttonPrintQueue_Click);
            // 
            // buttonDeliveryQueue
            // 
            this.buttonDeliveryQueue.FlatAppearance.BorderSize = 0;
            this.buttonDeliveryQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeliveryQueue.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeliveryQueue.ForeColor = System.Drawing.Color.White;
            this.buttonDeliveryQueue.Image = ((System.Drawing.Image)(resources.GetObject("buttonDeliveryQueue.Image")));
            this.buttonDeliveryQueue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeliveryQueue.Location = new System.Drawing.Point(0, 165);
            this.buttonDeliveryQueue.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDeliveryQueue.Name = "buttonDeliveryQueue";
            this.buttonDeliveryQueue.Padding = new System.Windows.Forms.Padding(12);
            this.buttonDeliveryQueue.Size = new System.Drawing.Size(200, 75);
            this.buttonDeliveryQueue.TabIndex = 8;
            this.buttonDeliveryQueue.Text = "Delivery Queue";
            this.buttonDeliveryQueue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonDeliveryQueue.UseVisualStyleBackColor = true;
            this.buttonDeliveryQueue.Click += new System.EventHandler(this.buttonDeliveryQueue_Click);
            // 
            // buttonPrintHistory
            // 
            this.buttonPrintHistory.FlatAppearance.BorderSize = 0;
            this.buttonPrintHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrintHistory.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPrintHistory.ForeColor = System.Drawing.Color.White;
            this.buttonPrintHistory.Image = ((System.Drawing.Image)(resources.GetObject("buttonPrintHistory.Image")));
            this.buttonPrintHistory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPrintHistory.Location = new System.Drawing.Point(0, 240);
            this.buttonPrintHistory.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPrintHistory.Name = "buttonPrintHistory";
            this.buttonPrintHistory.Padding = new System.Windows.Forms.Padding(12);
            this.buttonPrintHistory.Size = new System.Drawing.Size(200, 75);
            this.buttonPrintHistory.TabIndex = 8;
            this.buttonPrintHistory.Text = "Print History";
            this.buttonPrintHistory.UseVisualStyleBackColor = true;
            // 
            // labelAppTitle
            // 
            this.labelAppTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(84)))));
            this.labelAppTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelAppTitle.Font = new System.Drawing.Font("Beyond The Mountains", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppTitle.ForeColor = System.Drawing.Color.White;
            this.labelAppTitle.Image = ((System.Drawing.Image)(resources.GetObject("labelAppTitle.Image")));
            this.labelAppTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelAppTitle.Location = new System.Drawing.Point(0, 7);
            this.labelAppTitle.Margin = new System.Windows.Forms.Padding(0);
            this.labelAppTitle.Name = "labelAppTitle";
            this.labelAppTitle.Size = new System.Drawing.Size(200, 75);
            this.labelAppTitle.TabIndex = 7;
            this.labelAppTitle.Text = "  Preasy";
            this.labelAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPrintPause
            // 
            this.panelPrintPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(84)))));
            this.panelPrintPause.Location = new System.Drawing.Point(0, 450);
            this.panelPrintPause.Margin = new System.Windows.Forms.Padding(0);
            this.panelPrintPause.Name = "panelPrintPause";
            this.panelPrintPause.Size = new System.Drawing.Size(10, 75);
            this.panelPrintPause.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.panelPrintPause);
            this.panel1.Controls.Add(this.labelAppTitle);
            this.panel1.Controls.Add(this.buttonPrintHistory);
            this.panel1.Controls.Add(this.buttonDeliveryQueue);
            this.panel1.Controls.Add(this.buttonPrintQueue);
            this.panel1.Controls.Add(this.buttonPrintPause);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 536);
            this.panel1.TabIndex = 6;
            // 
            // buttonClose
            // 
            this.buttonClose.AutoSize = true;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose.Image")));
            this.buttonClose.Location = new System.Drawing.Point(775, 6);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(30, 30);
            this.buttonClose.TabIndex = 10;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.AutoSize = true;
            this.buttonMinimize.FlatAppearance.BorderSize = 0;
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.Image")));
            this.buttonMinimize.Location = new System.Drawing.Point(739, 6);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(30, 30);
            this.buttonMinimize.TabIndex = 11;
            this.buttonMinimize.UseVisualStyleBackColor = true;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(529, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "https://preasy-53c43.appspot.com";
            // 
            // printQueueControl1
            // 
            this.printQueueControl1.BackColor = System.Drawing.Color.White;
            this.printQueueControl1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.printQueueControl1.Location = new System.Drawing.Point(200, 43);
            this.printQueueControl1.Margin = new System.Windows.Forms.Padding(5);
            this.printQueueControl1.Name = "printQueueControl1";
            this.printQueueControl1.Size = new System.Drawing.Size(614, 466);
            this.printQueueControl1.TabIndex = 8;
            // 
            // deliveryQueueControl1
            // 
            this.deliveryQueueControl1.BackColor = System.Drawing.Color.White;
            this.deliveryQueueControl1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deliveryQueueControl1.Location = new System.Drawing.Point(200, 43);
            this.deliveryQueueControl1.Margin = new System.Windows.Forms.Padding(5);
            this.deliveryQueueControl1.Name = "deliveryQueueControl1";
            this.deliveryQueueControl1.Size = new System.Drawing.Size(614, 466);
            this.deliveryQueueControl1.TabIndex = 9;
            // 
            // PrintHubForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(29)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(814, 536);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMinimize);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.deliveryQueueControl1);
            this.Controls.Add(this.printQueueControl1);
            this.Controls.Add(this.panelSelected);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintHubForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Print Hub";
            this.Load += new System.EventHandler(this.PrintHub_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PrintHubForm_MouseDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelSelected;
        private PrintQueueControl printQueueControl1;
        private System.Windows.Forms.Button buttonPrintPause;
        private System.Windows.Forms.Button buttonPrintQueue;
        private System.Windows.Forms.Button buttonDeliveryQueue;
        private System.Windows.Forms.Button buttonPrintHistory;
        private System.Windows.Forms.Label labelAppTitle;
        private System.Windows.Forms.Panel panelPrintPause;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.Label label1;
        private DeliveryQueueControl deliveryQueueControl1;
    }
}

