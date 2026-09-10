namespace AssignmentProject;

partial class CalculatorForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox txtNum1;
    private System.Windows.Forms.TextBox txtNum2;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Label lblResult;
    private System.Windows.Forms.Label lblTitle;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.txtNum1 = new System.Windows.Forms.TextBox();
        this.txtNum2 = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.lblResult = new System.Windows.Forms.Label();
        this.lblTitle = new System.Windows.Forms.Label();
        this.SuspendLayout();
        
        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(50, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(155, 25);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Basic Calculator";

        // txtNum1
        this.txtNum1.Location = new System.Drawing.Point(50, 70);
        this.txtNum1.Name = "txtNum1";
        this.txtNum1.Size = new System.Drawing.Size(100, 23);
        this.txtNum1.TabIndex = 1;

        // txtNum2
        this.txtNum2.Location = new System.Drawing.Point(50, 110);
        this.txtNum2.Name = "txtNum2";
        this.txtNum2.Size = new System.Drawing.Size(100, 23);
        this.txtNum2.TabIndex = 2;

        // btnAdd
        this.btnAdd.Location = new System.Drawing.Point(50, 150);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(75, 23);
        this.btnAdd.TabIndex = 3;
        this.btnAdd.Text = "Add";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

        // lblResult
        this.lblResult.AutoSize = true;
        this.lblResult.Location = new System.Drawing.Point(50, 190);
        this.lblResult.Name = "lblResult";
        this.lblResult.Size = new System.Drawing.Size(42, 15);
        this.lblResult.TabIndex = 4;
        this.lblResult.Text = "Result:";

        // CalculatorForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(300, 250);
        this.Controls.Add(this.lblResult);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.txtNum2);
        this.Controls.Add(this.txtNum1);
        this.Controls.Add(this.lblTitle);
        this.Name = "CalculatorForm";
        this.Text = "Calculator Form";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
