namespace AssignmentProject;

partial class AboutForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblInfo;
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
        this.lblInfo = new System.Windows.Forms.Label();
        this.lblTitle = new System.Windows.Forms.Label();
        this.SuspendLayout();

        // lblTitle
        this.lblTitle.AutoSize = true;
        this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.lblTitle.Location = new System.Drawing.Point(50, 20);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(161, 30);
        this.lblTitle.TabIndex = 0;
        this.lblTitle.Text = "About Project";

        // lblInfo
        this.lblInfo.AutoSize = true;
        this.lblInfo.Location = new System.Drawing.Point(50, 70);
        this.lblInfo.Name = "lblInfo";
        this.lblInfo.Size = new System.Drawing.Size(200, 45);
        this.lblInfo.TabIndex = 1;
        this.lblInfo.Text = "Assignment Project\nCreated in ASP.NET / WinForms\nSimple navigation between forms.";

        // AboutForm
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(300, 200);
        this.Controls.Add(this.lblInfo);
        this.Controls.Add(this.lblTitle);
        this.Name = "AboutForm";
        this.Text = "About Project";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
