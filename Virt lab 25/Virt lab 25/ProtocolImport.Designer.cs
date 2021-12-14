
namespace Virt_lab_25
{
    partial class ProtocolImport
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
            this.importProtocolButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // importProtocolButton
            // 
            this.importProtocolButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.importProtocolButton.Location = new System.Drawing.Point(12, 380);
            this.importProtocolButton.Name = "importProtocolButton";
            this.importProtocolButton.Size = new System.Drawing.Size(776, 58);
            this.importProtocolButton.TabIndex = 0;
            this.importProtocolButton.Text = "Импортировать протокол";
            this.importProtocolButton.UseVisualStyleBackColor = true;
            this.importProtocolButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 368);
            this.label1.TabIndex = 1;
            this.label1.Text = "Загрузите протокол";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ProtocolImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.importProtocolButton);
            this.Name = "ProtocolImport";
            this.Text = "Проверка протокола";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button importProtocolButton;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button button1;

        #endregion
    }
}