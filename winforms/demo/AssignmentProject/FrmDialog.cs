using System;
using System.Drawing;
using System.Windows.Forms;

namespace AssignmentProject;

public partial class FrmDialog : Form
{
    public FrmDialog()
    {
        InitializeComponent();
    }

    private void btnColor_Click(object sender, EventArgs e)
    {
        ColorDialog colorDialog = new ColorDialog();
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            this.textBoxResult.BackColor = colorDialog.Color;
        }
    }

    private void btnFont_Click(object sender, EventArgs e)
    {
        FontDialog fontDialog = new FontDialog();
        if (fontDialog.ShowDialog() == DialogResult.OK)
        {
            this.textBoxResult.Font = fontDialog.Font;
            this.textBoxResult.Text = "Selected Font: " + fontDialog.Font.Name + ", " + fontDialog.Font.Size.ToString();
        }
    }

    private void btnOpenFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.textBoxResult.Text = "Opened File: " + openFileDialog.FileName;
        }
    }

    private void btnSaveFile_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Text Files|*.txt|All Files|*.*";
        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            this.textBoxResult.Text = "File to Save: " + saveFileDialog.FileName;
        }
    }

    private void btnFolder_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog folderDialog = new FolderBrowserDialog();
        if (folderDialog.ShowDialog() == DialogResult.OK)
        {
            this.textBoxResult.Text = "Selected Folder: " + folderDialog.SelectedPath;
        }
    }
}
