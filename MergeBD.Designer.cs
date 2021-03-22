
namespace Archivage
{
    partial class MergeBD
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
            this.txtPathBD1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPathBD2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearchFileBD2 = new System.Windows.Forms.Button();
            this.btnSearchFileBD1 = new System.Windows.Forms.Button();
            this.btn_ = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtPathBD1
            // 
            this.txtPathBD1.Location = new System.Drawing.Point(12, 40);
            this.txtPathBD1.Name = "txtPathBD1";
            this.txtPathBD1.Size = new System.Drawing.Size(543, 20);
            this.txtPathBD1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base de données principale";
            // 
            // txtPathBD2
            // 
            this.txtPathBD2.Location = new System.Drawing.Point(12, 95);
            this.txtPathBD2.Name = "txtPathBD2";
            this.txtPathBD2.Size = new System.Drawing.Size(543, 20);
            this.txtPathBD2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Deuxième base de données";
            // 
            // btnSearchFileBD2
            // 
            this.btnSearchFileBD2.Location = new System.Drawing.Point(581, 87);
            this.btnSearchFileBD2.Name = "btnSearchFileBD2";
            this.btnSearchFileBD2.Size = new System.Drawing.Size(116, 34);
            this.btnSearchFileBD2.TabIndex = 2;
            this.btnSearchFileBD2.Text = "Chercher le fichier";
            this.btnSearchFileBD2.UseVisualStyleBackColor = true;
            this.btnSearchFileBD2.Click += new System.EventHandler(this.btnSearchFileBD2_Click);
            // 
            // btnSearchFileBD1
            // 
            this.btnSearchFileBD1.Location = new System.Drawing.Point(581, 32);
            this.btnSearchFileBD1.Name = "btnSearchFileBD1";
            this.btnSearchFileBD1.Size = new System.Drawing.Size(116, 34);
            this.btnSearchFileBD1.TabIndex = 2;
            this.btnSearchFileBD1.Text = "Chercher le fichier";
            this.btnSearchFileBD1.UseVisualStyleBackColor = true;
            this.btnSearchFileBD1.Click += new System.EventHandler(this.btnSearchFileBD1_Click);
            // 
            // btn_
            // 
            this.btn_.Location = new System.Drawing.Point(605, 207);
            this.btn_.Name = "btn_";
            this.btn_.Size = new System.Drawing.Size(92, 29);
            this.btn_.TabIndex = 2;
            this.btn_.Text = "Commencer";
            this.btn_.UseVisualStyleBackColor = true;
            this.btn_.Click += new System.EventHandler(this.btn__Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(507, 207);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(92, 29);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Annuler";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // MergeBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 248);
            this.Controls.Add(this.btnSearchFileBD1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_);
            this.Controls.Add(this.btnSearchFileBD2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPathBD2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPathBD1);
            this.Name = "MergeBD";
            this.Text = "MergeBD";
            this.Load += new System.EventHandler(this.MergeBD_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPathBD1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathBD2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchFileBD2;
        private System.Windows.Forms.Button btnSearchFileBD1;
        private System.Windows.Forms.Button btn_;
        private System.Windows.Forms.Button btn_Cancel;
    }
}