﻿namespace RemoteServer
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
            this.SuspendLayout();
            // 
            // serverStart_btn
            // 
            this.serverStart_btn.Location = new System.Drawing.Point(13, 37);
            this.serverStart_btn.Margin = new System.Windows.Forms.Padding(4);
            this.serverStart_btn.Name = "serverStart_btn";
            this.serverStart_btn.Size = new System.Drawing.Size(346, 115);
            this.serverStart_btn.TabIndex = 0;
            this.serverStart_btn.Text = "Start Server";
            this.serverStart_btn.UseVisualStyleBackColor = true;
            this.serverStart_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // ipAddress_label
            // 
            this.ipAddress_label.AutoSize = true;
            this.ipAddress_label.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ipAddress_label.Location = new System.Drawing.Point(60, 176);
            this.ipAddress_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ipAddress_label.Name = "ipAddress_label";
            this.ipAddress_label.Size = new System.Drawing.Size(114, 17);
            this.ipAddress_label.TabIndex = 1;
            this.ipAddress_label.Text = "Not Connected...";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 216);
            this.Controls.Add(this.ipAddress_label);
            this.Controls.Add(this.serverStart_btn);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "joyPhone Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button serverStart_btn;
        private System.Windows.Forms.Label ipAddress_label;
    }
}

