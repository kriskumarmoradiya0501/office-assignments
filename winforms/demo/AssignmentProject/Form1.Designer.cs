namespace AssignmentProject;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Button btnCalculator;
    private System.Windows.Forms.Button btnStudentRegistration;
    private System.Windows.Forms.Button btnControlDemo;
    private System.Windows.Forms.Button btnDialogDemo;
    private System.Windows.Forms.Button btnMdiDemo;
    private System.Windows.Forms.Button btnEmployee;
    private System.Windows.Forms.Button btnApiDemo;
    private System.Windows.Forms.Button btnEvents;
    private System.Windows.Forms.Button btnAbout;

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
        this.btnCalculator = new System.Windows.Forms.Button();
        this.btnStudentRegistration = new System.Windows.Forms.Button();
        this.btnControlDemo = new System.Windows.Forms.Button();
        this.btnDialogDemo = new System.Windows.Forms.Button();
        this.btnMdiDemo = new System.Windows.Forms.Button();
        this.btnEmployee = new System.Windows.Forms.Button();
        this.btnApiDemo = new System.Windows.Forms.Button();
        this.btnEvents = new System.Windows.Forms.Button();
        this.btnAbout = new System.Windows.Forms.Button();
        this.SuspendLayout();
        
        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(50, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(200, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "Main Dashboard";
        
        // btnCalculator
        this.btnCalculator.Location = new System.Drawing.Point(50, 70);
        this.btnCalculator.Name = "btnCalculator";
        this.btnCalculator.Size = new System.Drawing.Size(200, 40);
        this.btnCalculator.TabIndex = 1;
        this.btnCalculator.Text = "Calculator Form";
        this.btnCalculator.UseVisualStyleBackColor = true;
        this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
        
        // btnStudentRegistration
        this.btnStudentRegistration.Location = new System.Drawing.Point(50, 120);
        this.btnStudentRegistration.Name = "btnStudentRegistration";
        this.btnStudentRegistration.Size = new System.Drawing.Size(200, 40);
        this.btnStudentRegistration.TabIndex = 2;
        this.btnStudentRegistration.Text = "Student Registration Form";
        this.btnStudentRegistration.UseVisualStyleBackColor = true;
        this.btnStudentRegistration.Click += new System.EventHandler(this.btnStudentRegistration_Click);

        // btnControlDemo
        this.btnControlDemo.Location = new System.Drawing.Point(50, 170);
        this.btnControlDemo.Name = "btnControlDemo";
        this.btnControlDemo.Size = new System.Drawing.Size(200, 40);
        this.btnControlDemo.TabIndex = 3;
        this.btnControlDemo.Text = "Controls Demo Form";
        this.btnControlDemo.UseVisualStyleBackColor = true;
        this.btnControlDemo.Click += new System.EventHandler(this.btnControlDemo_Click);

        // btnDialogDemo
        this.btnDialogDemo.Location = new System.Drawing.Point(50, 220);
        this.btnDialogDemo.Name = "btnDialogDemo";
        this.btnDialogDemo.Size = new System.Drawing.Size(200, 40);
        this.btnDialogDemo.TabIndex = 4;
        this.btnDialogDemo.Text = "Dialogs Demo Form";
        this.btnDialogDemo.UseVisualStyleBackColor = true;
        this.btnDialogDemo.Click += new System.EventHandler(this.btnDialogDemo_Click);

        // btnMdiDemo
        this.btnMdiDemo.Location = new System.Drawing.Point(280, 70);
        this.btnMdiDemo.Name = "btnMdiDemo";
        this.btnMdiDemo.Size = new System.Drawing.Size(200, 40);
        this.btnMdiDemo.TabIndex = 5;
        this.btnMdiDemo.Text = "MDI/SDI Window Demo";
        this.btnMdiDemo.UseVisualStyleBackColor = true;
        this.btnMdiDemo.Click += new System.EventHandler(this.btnMdiDemo_Click);

        // btnEmployee
        this.btnEmployee.Location = new System.Drawing.Point(280, 120);
        this.btnEmployee.Name = "btnEmployee";
        this.btnEmployee.Size = new System.Drawing.Size(200, 40);
        this.btnEmployee.TabIndex = 6;
        this.btnEmployee.Text = "Employee DB Form";
        this.btnEmployee.UseVisualStyleBackColor = true;
        this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);

        // btnApiDemo
        this.btnApiDemo.Location = new System.Drawing.Point(280, 170);
        this.btnApiDemo.Name = "btnApiDemo";
        this.btnApiDemo.Size = new System.Drawing.Size(200, 40);
        this.btnApiDemo.TabIndex = 7;
        this.btnApiDemo.Text = "REST API Demo Form";
        this.btnApiDemo.UseVisualStyleBackColor = true;
        this.btnApiDemo.Click += new System.EventHandler(this.btnApiDemo_Click);

        // btnEvents
        this.btnEvents.Location = new System.Drawing.Point(280, 220);
        this.btnEvents.Name = "btnEvents";
        this.btnEvents.Size = new System.Drawing.Size(200, 40);
        this.btnEvents.TabIndex = 8;
        this.btnEvents.Text = "Events & Drawing Demo Form";
        this.btnEvents.UseVisualStyleBackColor = true;
        this.btnEvents.Click += new System.EventHandler(this.btnEvents_Click);

        // btnAbout
        this.btnAbout.Location = new System.Drawing.Point(165, 280);
        this.btnAbout.Name = "btnAbout";
        this.btnAbout.Size = new System.Drawing.Size(200, 40);
        this.btnAbout.TabIndex = 9;
        this.btnAbout.Text = "About Project";
        this.btnAbout.UseVisualStyleBackColor = true;
        this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
        
        // Form1
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(530, 350);
        this.Controls.Add(this.btnAbout);
        this.Controls.Add(this.btnEvents);
        this.Controls.Add(this.btnApiDemo);
        this.Controls.Add(this.btnEmployee);
        this.Controls.Add(this.btnMdiDemo);
        this.Controls.Add(this.btnDialogDemo);
        this.Controls.Add(this.btnControlDemo);
        this.Controls.Add(this.btnStudentRegistration);
        this.Controls.Add(this.btnCalculator);
        this.Controls.Add(this.lblTitle);
        this.Name = "Form1";
        this.Text = "Main Menu";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
