﻿namespace SpiritPointsClient
{
    partial class SpiritPointsClient
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
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.Grade = new System.Windows.Forms.Label();
            this.SpiritPointValue = new System.Windows.Forms.TextBox();
            this.Worth = new System.Windows.Forms.Label();
            this.Accept = new System.Windows.Forms.Button();
            this.Deny = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            this.Version = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.BackColor = System.Drawing.Color.LightSeaGreen;
            this.PictureBox.Location = new System.Drawing.Point(434, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(568, 516);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(5, 4);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(348, 39);
            this.Title.TabIndex = 1;
            this.Title.Text = "Spirit Points Manager";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.name.Location = new System.Drawing.Point(15, 79);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(101, 31);
            this.name.TabIndex = 2;
            this.name.Text = "Name: ";
            // 
            // Grade
            // 
            this.Grade.AutoSize = true;
            this.Grade.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Grade.Location = new System.Drawing.Point(15, 124);
            this.Grade.Name = "Grade";
            this.Grade.Size = new System.Drawing.Size(97, 31);
            this.Grade.TabIndex = 3;
            this.Grade.Text = "Grade:";
            // 
            // SpiritPointValue
            // 
            this.SpiritPointValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SpiritPointValue.Location = new System.Drawing.Point(309, 171);
            this.SpiritPointValue.Name = "SpiritPointValue";
            this.SpiritPointValue.Size = new System.Drawing.Size(100, 62);
            this.SpiritPointValue.TabIndex = 4;
            this.SpiritPointValue.Text = "10";
            // 
            // Worth
            // 
            this.Worth.AutoSize = true;
            this.Worth.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Worth.Location = new System.Drawing.Point(15, 192);
            this.Worth.Name = "Worth";
            this.Worth.Size = new System.Drawing.Size(222, 31);
            this.Worth.TabIndex = 5;
            this.Worth.Text = "Spirit point value:";
            // 
            // Accept
            // 
            this.Accept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accept.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Accept.Location = new System.Drawing.Point(12, 407);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(119, 121);
            this.Accept.TabIndex = 6;
            this.Accept.Text = "Accept";
            this.Accept.UseVisualStyleBackColor = false;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // Deny
            // 
            this.Deny.BackColor = System.Drawing.Color.DarkRed;
            this.Deny.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Deny.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Deny.Location = new System.Drawing.Point(137, 407);
            this.Deny.Name = "Deny";
            this.Deny.Size = new System.Drawing.Size(119, 121);
            this.Deny.TabIndex = 7;
            this.Deny.Text = "Deny";
            this.Deny.UseVisualStyleBackColor = false;
            this.Deny.Click += new System.EventHandler(this.Deny_Click);
            // 
            // refresh
            // 
            this.refresh.BackColor = System.Drawing.Color.Navy;
            this.refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.refresh.Location = new System.Drawing.Point(309, 407);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(119, 121);
            this.refresh.TabIndex = 8;
            this.refresh.Text = "Load and Refresh";
            this.refresh.UseVisualStyleBackColor = false;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Version.Location = new System.Drawing.Point(351, 10);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(52, 31);
            this.Version.TabIndex = 9;
            this.Version.Text = "1.1";
            // 
            // SpiritPointsClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1014, 540);
            this.Controls.Add(this.Version);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.Deny);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.Worth);
            this.Controls.Add(this.SpiritPointValue);
            this.Controls.Add(this.Grade);
            this.Controls.Add(this.name);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.PictureBox);
            this.Name = "SpiritPointsClient";
            this.Text = "Spirit Point Client";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label Grade;
        private System.Windows.Forms.TextBox SpiritPointValue;
        private System.Windows.Forms.Label Worth;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Button Deny;
        private System.Windows.Forms.Button refresh;
        private System.Windows.Forms.Label Version;
    }
}

