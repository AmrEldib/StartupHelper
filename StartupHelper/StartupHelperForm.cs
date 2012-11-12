using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace StartupHelper
{
    public partial class StartupHelperForm : Form
    {
        public int Countdown { get; set; }
        public Timer t { get; set; }

        public StartupHelperForm()
        {
            InitializeComponent();
            this.btnCancel.Click += btnCancel_Click;

            // Starting your applications in {0} seconds...
            this.Countdown = 10;
            t = new Timer();
            t.Interval = 1000;
            t.Tick += t_Tick;

            t.Enabled = true;
        }

        void t_Tick(object sender, EventArgs e)
        {
            this.lblStarting.Text = string.Format("Starting your applications in {0} seconds...", this.Countdown.ToString());
            this.Countdown -= 1;
            if (Countdown == -1)
            {
                // Stop timer
                t.Enabled = false;

                // Hide form
                this.Hide();

                // Start applications
                this.StartApplications();

                // Close this application once all applications started.
                Application.Exit();
            }
        }

        private void StartApplications()
        {
            // Read Applications.txt file
            string[] applications = File.ReadAllLines("Applications.txt");
            foreach (string application in applications)
            {
                // Make sure that the application file exist
                if (File.Exists(application))
                {
                    try
                    {
                        // Start application
                        Process.Start(application);
                    }
                    catch (Exception)
                    {
                        // Ignore error
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InitializeComponent()
        {
            this.lblStarting = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStarting
            // 
            this.lblStarting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStarting.AutoEllipsis = true;
            this.lblStarting.Location = new System.Drawing.Point(12, 19);
            this.lblStarting.Name = "lblStarting";
            this.lblStarting.Size = new System.Drawing.Size(257, 28);
            this.lblStarting.TabIndex = 0;
            this.lblStarting.Text = "Starting your applications in 10 seconds...";
            this.lblStarting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(99, 57);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // StartupHelperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 101);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblStarting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "StartupHelperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startup Helper";
            this.TopMost = true;
            this.ResumeLayout(false);

        }
    }
}
