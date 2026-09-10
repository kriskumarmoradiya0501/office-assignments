namespace Practice
{
    public partial class Form1 : System.Windows.Forms.Form
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.btnForm2 = new System.Windows.Forms.Button();
            this.btnForm3 = new System.Windows.Forms.Button();
            this.lblDataSharingForm = new System.Windows.Forms.Button();
            this.btnStudetFrm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm2
            // 
            this.btnForm2.Location = new System.Drawing.Point(83, 62);
            this.btnForm2.Name = "btnForm2";
            this.btnForm2.Size = new System.Drawing.Size(75, 23);
            this.btnForm2.TabIndex = 0;
            this.btnForm2.Text = "Form 2";
            this.btnForm2.UseVisualStyleBackColor = true;
            this.btnForm2.Click += new System.EventHandler(this.BtnForm2_Click);
            // 
            // btnForm3
            // 
            this.btnForm3.Location = new System.Drawing.Point(83, 110);
            this.btnForm3.Name = "btnForm3";
            this.btnForm3.Size = new System.Drawing.Size(75, 23);
            this.btnForm3.TabIndex = 1;
            this.btnForm3.Text = "Form 3";
            this.btnForm3.UseVisualStyleBackColor = true;
            this.btnForm3.Click += new System.EventHandler(this.BtnForm3_Click);
            // 
            // lblDataSharingForm
            // 
            this.lblDataSharingForm.Location = new System.Drawing.Point(43, 167);
            this.lblDataSharingForm.Name = "lblDataSharingForm";
            this.lblDataSharingForm.Size = new System.Drawing.Size(195, 23);
            this.lblDataSharingForm.TabIndex = 2;
            this.lblDataSharingForm.Text = "Data Sharing Form Demo";
            this.lblDataSharingForm.UseVisualStyleBackColor = true;
            this.lblDataSharingForm.Click += new System.EventHandler(this.LblDataSharingForm_Click);
            // 
            // btnStudetFrm
            // 
            this.btnStudetFrm.Location = new System.Drawing.Point(59, 215);
            this.btnStudetFrm.Name = "btnStudetFrm";
            this.btnStudetFrm.Size = new System.Drawing.Size(121, 23);
            this.btnStudetFrm.TabIndex = 1;
            this.btnStudetFrm.Text = "Student Form";
            this.btnStudetFrm.UseVisualStyleBackColor = true;
            this.btnStudetFrm.Click += new System.EventHandler(this.BtnStudetFrm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblDataSharingForm);
            this.Controls.Add(this.btnStudetFrm);
            this.Controls.Add(this.btnForm3);
            this.Controls.Add(this.btnForm2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnForm2;
        private System.Windows.Forms.Button btnForm3;
        private System.Windows.Forms.Button lblDataSharingForm;
        private System.Windows.Forms.Button btnStudetFrm;
    }
}