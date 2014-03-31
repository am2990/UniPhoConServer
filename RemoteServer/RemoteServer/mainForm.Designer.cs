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
            this.serverStart_btn.Location = new System.Drawing.Point(13, 37);
            this.serverStart_btn.Margin = new System.Windows.Forms.Padding(4);
            this.serverStart_btn.Name = "serverStart_btn";
            this.serverStart_btn.Size = new System.Drawing.Size(365, 124);
            this.serverStart_btn.TabIndex = 0;
            this.serverStart_btn.Text = "Start Server";
            this.serverStart_btn.UseVisualStyleBackColor = true;
            this.serverStart_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipAddress_label
            // 
            this.ipAddress_label.AutoSize = true;
            this.ipAddress_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ipAddress_label.Location = new System.Drawing.Point(80, 180);
            this.ipAddress_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipAddress_label.Name = "ipAddress_label";
            this.ipAddress_label.Size = new System.Drawing.Size(114, 17);
            this.ipAddress_label.TabIndex = 1;
            this.ipAddress_label.Text = "Not Connected...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 236);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please close the app using the EXIT button:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 281);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ipAddress_label);
            this.Controls.Add(this.serverStart_btn);
            this.Margin = new System.Windows.Forms.Padding(4);
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

