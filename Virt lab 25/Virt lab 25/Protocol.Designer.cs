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
            this.exportProtocol.Location = new System.Drawing.Point(53, 462);
            this.exportProtocol.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.exportProtocol.Name = "exportProtocol";
            this.exportProtocol.Size = new System.Drawing.Size(992, 78);
            this.exportProtocol.TabIndex = 0;
            this.exportProtocol.Text = "Экспортировать протокол";
            this.exportProtocol.UseVisualStyleBackColor = true;
            this.exportProtocol.Click += new System.EventHandler(this.exportProtocol_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(53, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(992, 406);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Protocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exportProtocol);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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