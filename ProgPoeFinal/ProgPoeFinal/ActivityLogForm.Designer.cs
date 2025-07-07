namespace ProgPoeFinal
{
    partial class ActivityLogForm
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
            this.rtbActivityLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            //
            // rtbActivityLog
            //
            this.rtbActivityLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbActivityLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbActivityLog.BackColor = System.Drawing.Color.Black;
            this.rtbActivityLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.rtbActivityLog.Location = new System.Drawing.Point(0, 0);
            this.rtbActivityLog.Name = "rtbActivityLog";
            this.rtbActivityLog.ReadOnly = true;
            this.rtbActivityLog.Size = new System.Drawing.Size(600, 400); // Adjust size as needed
            this.rtbActivityLog.TabIndex = 0;
            this.rtbActivityLog.Text = "";
            //
            // ActivityLogForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400); // Adjust size as needed
            this.Controls.Add(this.rtbActivityLog);
            this.Name = "ActivityLogForm";
            this.Text = "ActivityLogForm"; // This will be overwritten by ActivityLogForm.cs
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbActivityLog;
    }
}