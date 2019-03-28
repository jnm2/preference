namespace Preference
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
            this.leftWebBrowser = new System.Windows.Forms.WebBrowser();
            this.rightWebBrowser = new System.Windows.Forms.WebBrowser();
            this.leftButton = new Preference.CommandLink();
            this.rightButton = new Preference.CommandLink();
            this.choicePanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.resultsPanel = new System.Windows.Forms.Panel();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.choicePanel.SuspendLayout();
            this.resultsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftWebBrowser
            // 
            this.leftWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftWebBrowser.Location = new System.Drawing.Point(20, 113);
            this.leftWebBrowser.Margin = new System.Windows.Forms.Padding(20);
            this.leftWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.leftWebBrowser.Name = "leftWebBrowser";
            this.leftWebBrowser.Size = new System.Drawing.Size(631, 648);
            this.leftWebBrowser.TabIndex = 0;
            // 
            // rightWebBrowser
            // 
            this.rightWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightWebBrowser.Location = new System.Drawing.Point(691, 113);
            this.rightWebBrowser.Margin = new System.Windows.Forms.Padding(20);
            this.rightWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.rightWebBrowser.Name = "rightWebBrowser";
            this.rightWebBrowser.Size = new System.Drawing.Size(632, 648);
            this.rightWebBrowser.TabIndex = 0;
            // 
            // leftButton
            // 
            this.leftButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.leftButton.Location = new System.Drawing.Point(235, 50);
            this.leftButton.Margin = new System.Windows.Forms.Padding(0);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(200, 43);
            this.leftButton.TabIndex = 1;
            this.leftButton.Text = "Left option";
            this.leftButton.Click += new System.EventHandler(this.LeftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rightButton.Location = new System.Drawing.Point(907, 50);
            this.rightButton.Margin = new System.Windows.Forms.Padding(0);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(200, 43);
            this.rightButton.TabIndex = 1;
            this.rightButton.Text = "Right option";
            this.rightButton.Click += new System.EventHandler(this.RightButton_Click);
            // 
            // choicePanel
            // 
            this.choicePanel.ColumnCount = 2;
            this.choicePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.choicePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.choicePanel.Controls.Add(this.rightWebBrowser, 1, 2);
            this.choicePanel.Controls.Add(this.rightButton, 1, 1);
            this.choicePanel.Controls.Add(this.leftWebBrowser, 0, 2);
            this.choicePanel.Controls.Add(this.leftButton, 0, 1);
            this.choicePanel.Controls.Add(this.label1, 0, 0);
            this.choicePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.choicePanel.Location = new System.Drawing.Point(0, 0);
            this.choicePanel.Name = "choicePanel";
            this.choicePanel.RowCount = 3;
            this.choicePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.choicePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.choicePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.choicePanel.Size = new System.Drawing.Size(1343, 781);
            this.choicePanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.choicePanel.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.Location = new System.Drawing.Point(501, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Of the following two options, which would you prefer?";
            // 
            // resultsPanel
            // 
            this.resultsPanel.Controls.Add(this.resultsTextBox);
            this.resultsPanel.Controls.Add(this.label2);
            this.resultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultsPanel.Location = new System.Drawing.Point(0, 0);
            this.resultsPanel.Name = "resultsPanel";
            this.resultsPanel.Size = new System.Drawing.Size(1343, 781);
            this.resultsPanel.TabIndex = 3;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.resultsTextBox.Location = new System.Drawing.Point(433, 113);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ReadOnly = true;
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBox.Size = new System.Drawing.Size(474, 612);
            this.resultsTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(429, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(485, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Here is the totally-ordered list of your preferences (most preferred at the top):" +
    "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 781);
            this.Controls.Add(this.resultsPanel);
            this.Controls.Add(this.choicePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Preference";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.choicePanel.ResumeLayout(false);
            this.choicePanel.PerformLayout();
            this.resultsPanel.ResumeLayout(false);
            this.resultsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser leftWebBrowser;
        private System.Windows.Forms.WebBrowser rightWebBrowser;
        private CommandLink leftButton;
        private CommandLink rightButton;
        private System.Windows.Forms.TableLayoutPanel choicePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel resultsPanel;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.Label label2;
    }
}

