namespace Practice
{
    public partial class FrmPassingDataOneToOther1 : System.Windows.Forms.Form
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.btnOpenForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 0;
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(133, 99);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(100, 22);
            this.txtAge.TabIndex = 1;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAge_KeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(75, 50);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name : ";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(75, 102);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(38, 16);
            this.lblAge.TabIndex = 3;
            this.lblAge.Text = "Age :";
            // 
            // btnOpenForm
            // 
            this.btnOpenForm.Location = new System.Drawing.Point(49, 149);
            this.btnOpenForm.Name = "btnOpenForm";
            this.btnOpenForm.Size = new System.Drawing.Size(244, 49);
            this.btnOpenForm.TabIndex = 4;
            this.btnOpenForm.Text = "Oprn Form and pass this values";
            this.btnOpenForm.UseVisualStyleBackColor = true;
            this.btnOpenForm.Click += new System.EventHandler(this.BtnOpenForm_Click);
            // 
            // FrmPassingDataOneToOther1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOpenForm);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtName);
            this.Name = "FrmPassingDataOneToOther1";
            this.Text = "FrmPassingDataOneToOther1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Button btnOpenForm;
    }
}