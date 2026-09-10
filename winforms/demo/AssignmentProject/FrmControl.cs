using System;
using System.Windows.Forms;

namespace AssignmentProject;

public partial class FrmControl : Form
{
    public FrmControl()
    {
        InitializeComponent();
    }

    private void FrmControl_Load(object sender, EventArgs e)
    {
        comboBoxExample.DropDownStyle = ComboBoxStyle.DropDownList;
        radioButtonMale.Checked = true;
        // Initialize ComboBox items
        comboBoxExample.Items.Add("Option 1");
        comboBoxExample.Items.Add("Option 2");
        comboBoxExample.Items.Add("Option 3");
        comboBoxExample.SelectedIndex = 0; // Default selection
    }

    private void btnShow_Click(object sender, EventArgs e)
    {
        string comboText = comboBoxExample.SelectedItem?.ToString() ?? "";
        decimal numericValue = numericUpDownExample.Value;
        string gender = radioButtonMale.Checked ? "Male" : radioButtonFemale.Checked ? "Female" : "Not selected";
        string terms = checkBoxExample.Checked ? "Agreed" : "Not Agreed";

        lblResult.Text = $"ComboBox: {comboText}\n" +
                          $"NumericUpDown: {numericValue}\n" +
                          $"Gender: {gender}\n" +
                          $"Terms: {terms}";
    }
}
