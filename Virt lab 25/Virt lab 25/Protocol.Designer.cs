using System.ComponentModel;

namespace Virt_lab_25
{
    partial class Protocol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.exportProtocol = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // exportProtocol
            // 
            this.exportProtocol.Location = new System.Drawing.Point(40, 375);
            this.exportProtocol.Name = "exportProtocol";
            this.exportProtocol.Size = new System.Drawing.Size(744, 63);
            this.exportProtocol.TabIndex = 0;
            this.exportProtocol.Text = "Экспортировать протокол";
            this.exportProtocol.UseVisualStyleBackColor = true;
            this.exportProtocol.Click += new System.EventHandler(this.exportProtocol_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.Location = new System.Drawing.Point(40, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(744, 330);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Protocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportProtocol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Protocol";
            this.Text = "Пртокол";
            this.Load += new System.EventHandler(this.Protocol_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button exportProtocol;

        #endregion
    }
}