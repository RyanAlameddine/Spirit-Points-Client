namespace SpiritPointsClient
{
    partial class Password
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
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.Submit = new System.Windows.Forms.Button();
            this.ip = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(12, 83);
            this.PasswordBox.MaxLength = 64;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '•';
            this.PasswordBox.Size = new System.Drawing.Size(387, 20);
            this.PasswordBox.TabIndex = 0;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.Location = new System.Drawing.Point(25, 9);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(352, 48);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Please enter the password to access the \r\nSpirit Point Collection Manager";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.PasswordLabel.Click += new System.EventHandler(this.PasswordLabel_Click);
            // 
            // Submit
            // 
            this.Submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Submit.Location = new System.Drawing.Point(12, 109);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(387, 27);
            this.Submit.TabIndex = 2;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // ip
            // 
            this.ip.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ip.Location = new System.Drawing.Point(12, 142);
            this.ip.MaxLength = 64;
            this.ip.Name = "ip";
            this.ip.Size = new System.Drawing.Size(387, 20);
            this.ip.TabIndex = 3;
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 168);
            this.Controls.Add(this.ip);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PasswordBox);
            this.Name = "Password";
            this.Text = "Password";
            this.Load += new System.EventHandler(this.Password_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.TextBox ip;
    }
}