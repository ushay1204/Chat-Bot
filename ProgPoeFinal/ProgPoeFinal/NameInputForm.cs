using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProgPoeFinal
{
    public partial class NameInputForm : Form
    {
        public string UserName { get; private set; }

        public NameInputForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Welcome to Ushay Cyber Secure"; // Set a more descriptive title
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Before we begin, what should I call you?";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(15, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(240, 26);
            this.txtName.TabIndex = 1;

            // Add KeyPress event to allow Enter key to submit
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(180, 80);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // NameInputForm
            //
            this.ClientSize = new System.Drawing.Size(420, 115);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NameInputForm";
            this.Text = "Welcome"; 
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label label1;
        private TextBox txtName;
        private Button btnOK;

        private void btnOK_Click(object sender, EventArgs e)
        {
            UserName = txtName.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Event handler for KeyPress on txtName
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Prevents the 'ding' sound
                btnOK_Click(sender, e); // Simulate a click on the OK button
            }
        }
    }
}