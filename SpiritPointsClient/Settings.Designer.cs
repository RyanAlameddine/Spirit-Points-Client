namespace SpiritPointsClient
{
    partial class Settings
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
            this.components = new System.ComponentModel.Container();
            this.reset = new System.Windows.Forms.Button();
            this.MainBox = new System.Windows.Forms.RichTextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.Info = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reset.Location = new System.Drawing.Point(12, 12);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(487, 62);
            this.reset.TabIndex = 0;
            this.reset.Text = "Generate New Year";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // MainBox
            // 
            this.MainBox.Location = new System.Drawing.Point(37, 90);
            this.MainBox.Name = "MainBox";
            this.MainBox.Size = new System.Drawing.Size(421, 232);
            this.MainBox.TabIndex = 2;
            this.MainBox.Text = "";
            this.MainBox.Visible = false;
            // 
            // NextButton
            // 
            this.NextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextButton.Location = new System.Drawing.Point(12, 327);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(487, 62);
            this.NextButton.TabIndex = 3;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Visible = false;
            this.NextButton.Click += new System.EventHandler(this.RequestNext);
            // 
            // Info
            // 
            this.Info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Info.Location = new System.Drawing.Point(12, 12);
            this.Info.Multiline = true;
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.Size = new System.Drawing.Size(487, 72);
            this.Info.TabIndex = 4;
            this.Info.TabStop = false;
            this.Info.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 401);
            this.Controls.Add(this.Info);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.MainBox);
            this.Controls.Add(this.reset);
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.RichTextBox MainBox;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.TextBox Info;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}