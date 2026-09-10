using System;
using System.Windows.Forms;

namespace AssignmentProject;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();
        this.IsMdiContainer = true;
    }

    private void sDIToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FrmChild child = new FrmChild();
        child.Text = "SDI Child";
        child.Show();
    }

    private void sDIDialogToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FrmChild child = new FrmChild();
        child.Text = "SDI Child Dialog";
        child.ShowDialog();
    }

    private void mDIToolStripMenuItem_Click(object sender, EventArgs e)
    {
        FrmChild child = new FrmChild();
        child.MdiParent = this;
        child.Text = "MDI Child";
        child.Show();
    }

    private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.LayoutMdi(MdiLayout.TileHorizontal);
    }

    private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.LayoutMdi(MdiLayout.TileVertical);
    }

    private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.LayoutMdi(MdiLayout.Cascade);
    }
}
