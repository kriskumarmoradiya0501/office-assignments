namespace StudentManagment
{
    public partial class Form2 : System.Windows.Forms.Form
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
            this.lblNum1 = new System.Windows.Forms.Label();
            this.lblNum2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtNum1 = new System.Windows.Forms.TextBox();
            this.txtNum2 = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnHello = new System.Windows.Forms.Button();
            this.btnHi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNum1
            // 
            this.lblNum1.AutoSize = true;
            this.lblNum1.Location = new System.Drawing.Point(36, 43);
            this.lblNum1.Name = "lblNum1";
            this.lblNum1.Size = new System.Drawing.Size(105, 16);
            this.lblNum1.TabIndex = 0;
            this.lblNum1.Text = "Enter Number 1 :";
            // this.lblNum1.Click += new System.EventHandler(this.LblNum1_Click);
            // 
            // lblNum2
            // 
            this.lblNum2.AutoSize = true;
            this.lblNum2.Location = new System.Drawing.Point(36, 83);
            this.lblNum2.Name = "lblNum2";
            this.lblNum2.Size = new System.Drawing.Size(105, 16);
            this.lblNum2.TabIndex = 1;
            this.lblNum2.Text = "Enter Number 2 :";
            // this.lblNum2.Click += new System.EventHandler(this.LblNum2_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(87, 119);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(54, 16);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "Result : ";
            // this.lblResult.Click += new System.EventHandler(this.LblResult_Click);
            // 
            // txtNum1
            // 
            this.txtNum1.Location = new System.Drawing.Point(147, 37);
            this.txtNum1.Name = "txtNum1";
            this.txtNum1.Size = new System.Drawing.Size(100, 22);
            this.txtNum1.TabIndex = 3;
            // this.txtNum1.TextChanged += new System.EventHandler(this.TxtNum1_TextChanged);
            this.txtNum1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNum1_KeyPress);
            // 
            // txtNum2
            // 
            this.txtNum2.Location = new System.Drawing.Point(147, 77);
            this.txtNum2.Name = "txtNum2";
            this.txtNum2.Size = new System.Drawing.Size(100, 22);
            this.txtNum2.TabIndex = 4;
            // this.txtNum2.TextChanged += new System.EventHandler(this.TxtNum2_TextChanged);
            this.txtNum2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtNum2_KeyPress);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(147, 116);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(100, 22);
            this.txtResult.TabIndex = 5;
            // this.txtResult.TextChanged += new System.EventHandler(this.TxtResult_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(36, 169);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnHello
            // 
            this.btnHello.Location = new System.Drawing.Point(147, 169);
            this.btnHello.Name = "btnHello";
            this.btnHello.Size = new System.Drawing.Size(75, 23);
            this.btnHello.TabIndex = 7;
            this.btnHello.Text = "Hello";
            this.btnHello.UseVisualStyleBackColor = true;
            this.btnHello.Click += new System.EventHandler(this.BtnHello_Click);
            // 
            // btnHi
            // 
            this.btnHi.Location = new System.Drawing.Point(254, 169);
            this.btnHi.Name = "btnHi";
            this.btnHi.Size = new System.Drawing.Size(75, 23);
            this.btnHi.TabIndex = 8;
            this.btnHi.Text = "Hi";
            this.btnHi.UseVisualStyleBackColor = true;
            this.btnHi.Click += new System.EventHandler(this.BtnHi_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHi);
            this.Controls.Add(this.btnHello);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtNum2);
            this.Controls.Add(this.txtNum1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblNum2);
            this.Controls.Add(this.lblNum1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblNum1;
        private System.Windows.Forms.Label lblNum2;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtNum1;
        private System.Windows.Forms.TextBox txtNum2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnHello;
        private System.Windows.Forms.Button btnHi;
    }
}