namespace SecureConnection
{
    partial class Form1
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
            this.GetNormalButton = new System.Windows.Forms.Button();
            this.SecureStringButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GetNormalButton
            // 
            this.GetNormalButton.Location = new System.Drawing.Point(15, 31);
            this.GetNormalButton.Name = "GetNormalButton";
            this.GetNormalButton.Size = new System.Drawing.Size(173, 23);
            this.GetNormalButton.TabIndex = 0;
            this.GetNormalButton.Text = "Get Normal";
            this.GetNormalButton.UseVisualStyleBackColor = true;
            this.GetNormalButton.Click += new System.EventHandler(this.GetNormalButton_Click);
            // 
            // SecureStringButton
            // 
            this.SecureStringButton.Location = new System.Drawing.Point(15, 60);
            this.SecureStringButton.Name = "SecureStringButton";
            this.SecureStringButton.Size = new System.Drawing.Size(173, 23);
            this.SecureStringButton.TabIndex = 1;
            this.SecureStringButton.Text = "Secure string";
            this.SecureStringButton.UseVisualStyleBackColor = true;
            this.SecureStringButton.Click += new System.EventHandler(this.SecureStringButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 130);
            this.Controls.Add(this.SecureStringButton);
            this.Controls.Add(this.GetNormalButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raw demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button GetNormalButton;
        private System.Windows.Forms.Button SecureStringButton;
    }
}

