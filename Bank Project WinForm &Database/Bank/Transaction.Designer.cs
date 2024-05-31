namespace Bank
{
    partial class Deposite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Deposite));
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSendAmount = new System.Windows.Forms.Button();
            this.lbAmount = new System.Windows.Forms.Label();
            this.txtAmont = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(83, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 53);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSendAmount);
            this.panel1.Controls.Add(this.lbAmount);
            this.panel1.Controls.Add(this.txtAmont);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Location = new System.Drawing.Point(24, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(502, 432);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnSendAmount
            // 
            this.btnSendAmount.Location = new System.Drawing.Point(303, 304);
            this.btnSendAmount.Name = "btnSendAmount";
            this.btnSendAmount.Size = new System.Drawing.Size(120, 53);
            this.btnSendAmount.TabIndex = 8;
            this.btnSendAmount.Text = "Send";
            this.btnSendAmount.UseVisualStyleBackColor = true;
            this.btnSendAmount.Click += new System.EventHandler(this.btnSendAmount_Click);
            // 
            // lbAmount
            // 
            this.lbAmount.AutoSize = true;
            this.lbAmount.Font = new System.Drawing.Font("Tahoma", 18F);
            this.lbAmount.Location = new System.Drawing.Point(44, 156);
            this.lbAmount.Name = "lbAmount";
            this.lbAmount.Size = new System.Drawing.Size(118, 36);
            this.lbAmount.TabIndex = 7;
            this.lbAmount.Text = "Amount";
            // 
            // txtAmont
            // 
            this.txtAmont.Location = new System.Drawing.Point(178, 168);
            this.txtAmont.Name = "txtAmont";
            this.txtAmont.Size = new System.Drawing.Size(234, 24);
            this.txtAmont.TabIndex = 0;
            // 
            // Deposite
            // 
            this.AcceptButton = this.btnSendAmount;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(546, 456);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Deposite";
            this.Text = "Transaction";
            this.Load += new System.EventHandler(this.Deposite_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbAmount;
        private System.Windows.Forms.TextBox txtAmont;
        private System.Windows.Forms.Button btnSendAmount;
    }
}