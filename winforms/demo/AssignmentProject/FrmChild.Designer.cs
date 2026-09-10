namespace AssignmentProject;

partial class FrmChild
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox textBoxChild;

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
        this.textBoxChild = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // textBoxChild
        // 
        this.textBoxChild.Location = new System.Drawing.Point(20, 20);
        this.textBoxChild.Multiline = true;
        this.textBoxChild.Name = "textBoxChild";
        this.textBoxChild.Size = new System.Drawing.Size(250, 150);
        this.textBoxChild.TabIndex = 0;
        // 
        // FrmChild
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(300, 200);
        this.Controls.Add(this.textBoxChild);
        this.Name = "FrmChild";
        this.Text = "Child Form";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
