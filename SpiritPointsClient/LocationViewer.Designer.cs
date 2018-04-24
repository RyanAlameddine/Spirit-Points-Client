namespace SpiritPointsClient
{
    partial class LocationViewer
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
            this.LocationBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // LocationBrowser
            // 
            this.LocationBrowser.AllowNavigation = false;
            this.LocationBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationBrowser.Location = new System.Drawing.Point(0, 0);
            this.LocationBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.LocationBrowser.Name = "LocationBrowser";
            this.LocationBrowser.Size = new System.Drawing.Size(1199, 674);
            this.LocationBrowser.TabIndex = 0;
            // 
            // LocationViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 674);
            this.Controls.Add(this.LocationBrowser);
            this.Name = "LocationViewer";
            this.Text = "LocationViewer";
            this.Load += new System.EventHandler(this.LocationViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser LocationBrowser;
    }
}