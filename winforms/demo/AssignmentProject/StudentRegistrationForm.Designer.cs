namespace AssignmentProject;

partial class StudentRegistrationForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblCourse;
    private System.Windows.Forms.TextBox txtCourse;
    private System.Windows.Forms.Button btnSubmit;

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
        this.lblTitle = new System.Windows.Forms.Label();
        this.lblName = new System.Windows.Forms.Label();
        this.txtName = new System.Windows.Forms.TextBox();
        this.lblCourse = new System.Windows.Forms.Label();
        this.txtCourse = new System.Windows.Forms.TextBox();
        this.btnSubmit = new System.Windows.Forms.Button();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(50, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(227, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Student Registration";

        // lblName
        this.lblName.AutoSize = true;
        this.lblName.Location = new System.Drawing.Point(50, 80);
        this.lblName.Name = "lblName";
        this.lblName.Size = new System.Drawing.Size(42, 15);
        this.lblName.TabIndex = 1;
        this.lblName.Text = "Name:";

        // txtName
        this.txtName.Location = new System.Drawing.Point(120, 77);
        this.txtName.Name = "txtName";
        this.txtName.Size = new System.Drawing.Size(150, 23);
        this.txtName.TabIndex = 2;

        // lblCourse
        this.lblCourse.AutoSize = true;
        this.lblCourse.Location = new System.Drawing.Point(50, 120);
        this.lblCourse.Name = "lblCourse";
        this.lblCourse.Size = new System.Drawing.Size(47, 15);
        this.lblCourse.TabIndex = 3;
        this.lblCourse.Text = "Course:";

        // txtCourse
        this.txtCourse.Location = new System.Drawing.Point(120, 117);
        this.txtCourse.Name = "txtCourse";
        this.txtCourse.Size = new System.Drawing.Size(150, 23);
        this.txtCourse.TabIndex = 4;

        // btnSubmit
        this.btnSubmit.Location = new System.Drawing.Point(120, 160);
        this.btnSubmit.Name = "btnSubmit";
        this.btnSubmit.Size = new System.Drawing.Size(75, 23);
        this.btnSubmit.TabIndex = 5;
        this.btnSubmit.Text = "Submit";
        this.btnSubmit.UseVisualStyleBackColor = true;
        this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);

        // StudentRegistrationForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 250);
        this.Controls.Add(this.btnSubmit);
        this.Controls.Add(this.txtCourse);
        this.Controls.Add(this.lblCourse);
        this.Controls.Add(this.txtName);
        this.Controls.Add(this.lblName);
        this.Controls.Add(this.lblTitle);
        this.Name = "StudentRegistrationForm";
        this.Text = "Student Registration";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
