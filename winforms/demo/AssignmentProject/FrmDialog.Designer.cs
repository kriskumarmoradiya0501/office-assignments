namespace AssignmentProject;

partial class FrmDialog
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Button btnColor;
    private System.Windows.Forms.Button btnFont;
    private System.Windows.Forms.Button btnOpenFile;
    private System.Windows.Forms.Button btnSaveFile;
    private System.Windows.Forms.Button btnFolder;
    private System.Windows.Forms.TextBox textBoxResult;

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
        this.btnColor = new System.Windows.Forms.Button();
        this.btnFont = new System.Windows.Forms.Button();
        this.btnOpenFile = new System.Windows.Forms.Button();
        this.btnSaveFile = new System.Windows.Forms.Button();
        this.btnFolder = new System.Windows.Forms.Button();
        this.textBoxResult = new System.Windows.Forms.TextBox();
        this.SuspendLayout();

        this.btnColor.Location = new System.Drawing.Point(20, 20);
        this.btnColor.Name = "btnColor";
        this.btnColor.Size = new System.Drawing.Size(150, 30);
        this.btnColor.TabIndex = 0;
        this.btnColor.Text = "Open color Dialog";
        this.btnColor.UseVisualStyleBackColor = true;
        this.btnColor.Click += new System.EventHandler(this.btnColor_Click);

        this.btnFont.Location = new System.Drawing.Point(20, 60);
        this.btnFont.Name = "btnFont";
        this.btnFont.Size = new System.Drawing.Size(150, 30);
        this.btnFont.TabIndex = 1;
        this.btnFont.Text = "Open Font Dialog";
        this.btnFont.UseVisualStyleBackColor = true;
        this.btnFont.Click += new System.EventHandler(this.btnFont_Click);

        this.btnOpenFile.Location = new System.Drawing.Point(20, 100);
        this.btnOpenFile.Name = "btnOpenFile";
        this.btnOpenFile.Size = new System.Drawing.Size(150, 30);
        this.btnOpenFile.TabIndex = 2;
        this.btnOpenFile.Text = "Open File Dialog";
        this.btnOpenFile.UseVisualStyleBackColor = true;
        this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);

        this.btnSaveFile.Location = new System.Drawing.Point(20, 140);
        this.btnSaveFile.Name = "btnSaveFile";
        this.btnSaveFile.Size = new System.Drawing.Size(150, 30);
        this.btnSaveFile.TabIndex = 3;
        this.btnSaveFile.Text = "Save File Dialog";
        this.btnSaveFile.UseVisualStyleBackColor = true;
        this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);

        this.btnFolder.Location = new System.Drawing.Point(20, 180);
        this.btnFolder.Name = "btnFolder";
        this.btnFolder.Size = new System.Drawing.Size(150, 30);
        this.btnFolder.TabIndex = 4;
        this.btnFolder.Text = "Open Folder Dialog";
        this.btnFolder.UseVisualStyleBackColor = true;
        this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);

        this.textBoxResult.Location = new System.Drawing.Point(20, 230);
        this.textBoxResult.Multiline = true;
        this.textBoxResult.Name = "textBoxResult";
        this.textBoxResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.textBoxResult.Size = new System.Drawing.Size(350, 150);
        this.textBoxResult.TabIndex = 5;

        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 400);
        this.Controls.Add(this.textBoxResult);
        this.Controls.Add(this.btnFolder);
        this.Controls.Add(this.btnSaveFile);
        this.Controls.Add(this.btnOpenFile);
        this.Controls.Add(this.btnFont);
        this.Controls.Add(this.btnColor);
        this.Name = "FrmDialog";
        this.Text = "Dialog Demonstration";
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
