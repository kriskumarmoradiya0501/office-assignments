namespace AssignmentProject;

partial class FrmMain
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.MenuStrip menuStripMain;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sDIToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sDIDialogToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem mDIToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;

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
        this.menuStripMain = new System.Windows.Forms.MenuStrip();
        this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.sDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.sDIDialogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.mDIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        this.menuStripMain.SuspendLayout();
        this.SuspendLayout();
        // 
        // menuStripMain
        // 
        this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem});
        this.menuStripMain.Location = new System.Drawing.Point(0, 0);
        this.menuStripMain.Name = "menuStripMain";
        this.menuStripMain.Size = new System.Drawing.Size(800, 24);
        this.menuStripMain.TabIndex = 0;
        // 
        // fileToolStripMenuItem
        // 
        this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sDIToolStripMenuItem,
            this.sDIDialogToolStripMenuItem,
            this.mDIToolStripMenuItem});
        this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        this.fileToolStripMenuItem.Text = "File";
        // 
        // sDIToolStripMenuItem
        // 
        this.sDIToolStripMenuItem.Name = "sDIToolStripMenuItem";
        this.sDIToolStripMenuItem.Text = "SDI Child";
        this.sDIToolStripMenuItem.Click += new System.EventHandler(this.sDIToolStripMenuItem_Click);
        // 
        // sDIDialogToolStripMenuItem
        // 
        this.sDIDialogToolStripMenuItem.Name = "sDIDialogToolStripMenuItem";
        this.sDIDialogToolStripMenuItem.Text = "SDI Child Dialog";
        this.sDIDialogToolStripMenuItem.Click += new System.EventHandler(this.sDIDialogToolStripMenuItem_Click);
        // 
        // mDIToolStripMenuItem
        // 
        this.mDIToolStripMenuItem.Name = "mDIToolStripMenuItem";
        this.mDIToolStripMenuItem.Text = "MDI Child";
        this.mDIToolStripMenuItem.Click += new System.EventHandler(this.mDIToolStripMenuItem_Click);
        // 
        // windowToolStripMenuItem
        // 
        this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileHorizontalToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.cascadeToolStripMenuItem});
        this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
        this.windowToolStripMenuItem.Text = "Window";
        // 
        // tileHorizontalToolStripMenuItem
        // 
        this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
        this.tileHorizontalToolStripMenuItem.Text = "Tile Horizontal";
        this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontalToolStripMenuItem_Click);
        // 
        // tileVerticalToolStripMenuItem
        // 
        this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
        this.tileVerticalToolStripMenuItem.Text = "Tile Vertical";
        this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.tileVerticalToolStripMenuItem_Click);
        // 
        // cascadeToolStripMenuItem
        // 
        this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
        this.cascadeToolStripMenuItem.Text = "Cascade";
        this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
        // 
        // FrmMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Controls.Add(this.menuStripMain);
        this.MainMenuStrip = this.menuStripMain;
        this.IsMdiContainer = true;
        this.Name = "FrmMain";
        this.Text = "MDI / SDI Demo";
        this.menuStripMain.ResumeLayout(false);
        this.menuStripMain.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
