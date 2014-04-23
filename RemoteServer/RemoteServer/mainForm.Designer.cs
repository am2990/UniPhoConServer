namespace RemoteServer
{
    partial class mainForm
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
            this.serverStart_btn = new System.Windows.Forms.Button();
            this.ipAddress_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serverStart_btn
            // 
            this.serverStart_btn.Location = new System.Drawing.Point(10, 30);
            this.serverStart_btn.Name = "serverStart_btn";
            this.serverStart_btn.Size = new System.Drawing.Size(274, 101);
            this.serverStart_btn.TabIndex = 0;
            this.serverStart_btn.Text = "Start Server";
            this.serverStart_btn.UseVisualStyleBackColor = true;
            this.serverStart_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipAddress_label
            // 
            this.ipAddress_label.AutoSize = true;
            this.ipAddress_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ipAddress_label.Location = new System.Drawing.Point(60, 146);
            this.ipAddress_label.Name = "ipAddress_label";
            this.ipAddress_label.Size = new System.Drawing.Size(88, 13);
            this.ipAddress_label.TabIndex = 1;
            this.ipAddress_label.Text = "Not Connected...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(223, 192);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 19);
            this.button1.TabIndex = 2;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 194);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please close the app using the EXIT button:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 228);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ipAddress_label);
            this.Controls.Add(this.serverStart_btn);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button serverStart_btn;
        private System.Windows.Forms.Label ipAddress_label;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

