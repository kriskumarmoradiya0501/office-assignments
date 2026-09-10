namespace AssignmentProject;

partial class FrmControl
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.ComboBox comboBoxExample;
    private System.Windows.Forms.NumericUpDown numericUpDownExample;
    private System.Windows.Forms.GroupBox groupBoxExample;
    private System.Windows.Forms.RadioButton radioButtonFemale;
    private System.Windows.Forms.RadioButton radioButtonMale;
    private System.Windows.Forms.CheckBox checkBoxExample;
    private System.Windows.Forms.Button btnShow;
    private System.Windows.Forms.Label lblResult;

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
        this.comboBoxExample = new System.Windows.Forms.ComboBox();
        this.numericUpDownExample = new System.Windows.Forms.NumericUpDown();
        this.groupBoxExample = new System.Windows.Forms.GroupBox();
        this.radioButtonFemale = new System.Windows.Forms.RadioButton();
        this.radioButtonMale = new System.Windows.Forms.RadioButton();
        this.checkBoxExample = new System.Windows.Forms.CheckBox();
        this.btnShow = new System.Windows.Forms.Button();
        this.lblResult = new System.Windows.Forms.Label();
        this.groupBoxExample.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExample)).BeginInit();
        this.SuspendLayout();
        // 
        // comboBoxExample
        // 
        this.comboBoxExample.FormattingEnabled = true;
        this.comboBoxExample.Location = new System.Drawing.Point(30, 30);
        this.comboBoxExample.Name = "comboBoxExample";
        this.comboBoxExample.Size = new System.Drawing.Size(150, 23);
        this.comboBoxExample.TabIndex = 0;
        // 
        // numericUpDownExample
        // 
        this.numericUpDownExample.Location = new System.Drawing.Point(30, 70);
        this.numericUpDownExample.Name = "numericUpDownExample";
        this.numericUpDownExample.Size = new System.Drawing.Size(150, 23);
        this.numericUpDownExample.TabIndex = 1;
        // 
        // groupBoxExample
        // 
        this.groupBoxExample.Controls.Add(this.radioButtonFemale);
        this.groupBoxExample.Controls.Add(this.radioButtonMale);
        this.groupBoxExample.Location = new System.Drawing.Point(30, 110);
        this.groupBoxExample.Name = "groupBoxExample";
        this.groupBoxExample.Size = new System.Drawing.Size(200, 70);
        this.groupBoxExample.TabIndex = 2;
        this.groupBoxExample.TabStop = false;
        this.groupBoxExample.Text = "Choose Gender";
        // 
        // radioButtonFemale
        // 
        this.radioButtonFemale.AutoSize = true;
        this.radioButtonFemale.Location = new System.Drawing.Point(100, 30);
        this.radioButtonFemale.Name = "radioButtonFemale";
        this.radioButtonFemale.Size = new System.Drawing.Size(63, 19);
        this.radioButtonFemale.TabIndex = 1;
        this.radioButtonFemale.TabStop = true;
        this.radioButtonFemale.Text = "Female";
        this.radioButtonFemale.UseVisualStyleBackColor = true;
        // 
        // radioButtonMale
        // 
        this.radioButtonMale.AutoSize = true;
        this.radioButtonMale.Location = new System.Drawing.Point(20, 30);
        this.radioButtonMale.Name = "radioButtonMale";
        this.radioButtonMale.Size = new System.Drawing.Size(51, 19);
        this.radioButtonMale.TabIndex = 0;
        this.radioButtonMale.TabStop = true;
        this.radioButtonMale.Text = "Male";
        this.radioButtonMale.UseVisualStyleBackColor = true;
        // 
        // checkBoxExample
        // 
        this.checkBoxExample.AutoSize = true;
        this.checkBoxExample.Location = new System.Drawing.Point(30, 190);
        this.checkBoxExample.Name = "checkBoxExample";
        this.checkBoxExample.Size = new System.Drawing.Size(130, 19);
        this.checkBoxExample.TabIndex = 3;
        this.checkBoxExample.Text = "I agree to the terms";
        this.checkBoxExample.UseVisualStyleBackColor = true;
        // 
        // btnShow
        // 
        this.btnShow.Location = new System.Drawing.Point(30, 230);
        this.btnShow.Name = "btnShow";
        this.btnShow.Size = new System.Drawing.Size(150, 30);
        this.btnShow.TabIndex = 4;
        this.btnShow.Text = "Show Selected";
        this.btnShow.UseVisualStyleBackColor = true;
        this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
        // 
        // lblResult
        // 
        this.lblResult.AutoSize = true;
        this.lblResult.Location = new System.Drawing.Point(30, 280);
        this.lblResult.Name = "lblResult";
        this.lblResult.Size = new System.Drawing.Size(39, 15);
        this.lblResult.TabIndex = 5;
        this.lblResult.Text = "Result";
        // 
        // FrmControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 380);
        this.Controls.Add(this.lblResult);
        this.Controls.Add(this.btnShow);
        this.Controls.Add(this.checkBoxExample);
        this.Controls.Add(this.groupBoxExample);
        this.Controls.Add(this.numericUpDownExample);
        this.Controls.Add(this.comboBoxExample);
        this.Name = "FrmControl";
        this.Text = "Demo Controls";
        this.Load += new System.EventHandler(this.FrmControl_Load);
        this.groupBoxExample.ResumeLayout(false);
        this.groupBoxExample.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExample)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
