namespace EntityFrameworkCoreExamples
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
            this.IncludeStatementsUsingExtensionButton = new System.Windows.Forms.Button();
            this.IncludeStatementsConventionalButton = new System.Windows.Forms.Button();
            this.CustomerListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ContactTypeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CountryTextBox = new System.Windows.Forms.TextBox();
            this.LogConsoleCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IncludeStatementsUsingExtensionButton
            // 
            this.IncludeStatementsUsingExtensionButton.Enabled = false;
            this.IncludeStatementsUsingExtensionButton.Location = new System.Drawing.Point(499, 49);
            this.IncludeStatementsUsingExtensionButton.Name = "IncludeStatementsUsingExtensionButton";
            this.IncludeStatementsUsingExtensionButton.Size = new System.Drawing.Size(195, 23);
            this.IncludeStatementsUsingExtensionButton.TabIndex = 0;
            this.IncludeStatementsUsingExtensionButton.Text = "re-use include statements";
            this.IncludeStatementsUsingExtensionButton.UseVisualStyleBackColor = true;
            this.IncludeStatementsUsingExtensionButton.Click += new System.EventHandler(this.IncludeStatementsUsingExtensionButton_Click);
            // 
            // IncludeStatementsConventionalButton
            // 
            this.IncludeStatementsConventionalButton.Enabled = false;
            this.IncludeStatementsConventionalButton.Location = new System.Drawing.Point(499, 12);
            this.IncludeStatementsConventionalButton.Name = "IncludeStatementsConventionalButton";
            this.IncludeStatementsConventionalButton.Size = new System.Drawing.Size(195, 23);
            this.IncludeStatementsConventionalButton.TabIndex = 1;
            this.IncludeStatementsConventionalButton.Text = "conventional include statements";
            this.IncludeStatementsConventionalButton.UseVisualStyleBackColor = true;
            this.IncludeStatementsConventionalButton.Click += new System.EventHandler(this.IncludeStatementsConventionalButton_Click);
            // 
            // CustomerListBox
            // 
            this.CustomerListBox.FormattingEnabled = true;
            this.CustomerListBox.Location = new System.Drawing.Point(5, 4);
            this.CustomerListBox.Name = "CustomerListBox";
            this.CustomerListBox.Size = new System.Drawing.Size(240, 199);
            this.CustomerListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "First";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Last";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(48, 22);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(141, 20);
            this.FirstNameTextBox.TabIndex = 5;
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(48, 56);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(141, 20);
            this.LastNameTextBox.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ContactTypeTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.LastNameTextBox);
            this.groupBox1.Controls.Add(this.FirstNameTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(261, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 135);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contact";
            // 
            // ContactTypeTextBox
            // 
            this.ContactTypeTextBox.Location = new System.Drawing.Point(48, 87);
            this.ContactTypeTextBox.Name = "ContactTypeTextBox";
            this.ContactTypeTextBox.Size = new System.Drawing.Size(141, 20);
            this.ContactTypeTextBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Country";
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.Location = new System.Drawing.Point(309, 162);
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.Size = new System.Drawing.Size(141, 20);
            this.CountryTextBox.TabIndex = 9;
            // 
            // LogConsoleCheckBox
            // 
            this.LogConsoleCheckBox.AutoSize = true;
            this.LogConsoleCheckBox.Location = new System.Drawing.Point(716, 53);
            this.LogConsoleCheckBox.Name = "LogConsoleCheckBox";
            this.LogConsoleCheckBox.Size = new System.Drawing.Size(96, 17);
            this.LogConsoleCheckBox.TabIndex = 10;
            this.LogConsoleCheckBox.Text = "Log to console";
            this.LogConsoleCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 227);
            this.Controls.Add(this.LogConsoleCheckBox);
            this.Controls.Add(this.CountryTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CustomerListBox);
            this.Controls.Add(this.IncludeStatementsConventionalButton);
            this.Controls.Add(this.IncludeStatementsUsingExtensionButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entity Framework Core Tips";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button IncludeStatementsUsingExtensionButton;
        private System.Windows.Forms.Button IncludeStatementsConventionalButton;
        private System.Windows.Forms.ListBox CustomerListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox ContactTypeTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CountryTextBox;
        private System.Windows.Forms.CheckBox LogConsoleCheckBox;
    }
}

