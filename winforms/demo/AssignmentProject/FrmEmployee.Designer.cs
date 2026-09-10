namespace AssignmentProject;

partial class FrmEmployee
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Label lblEmpId;
    private System.Windows.Forms.TextBox txtEmpId;
    private System.Windows.Forms.Label lblEmpName;
    private System.Windows.Forms.TextBox txtEmpName;
    private System.Windows.Forms.Label lblSalary;
    private System.Windows.Forms.TextBox txtSalary;
    private System.Windows.Forms.Label lblDeptNo;
    private System.Windows.Forms.TextBox txtDeptNo;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnViewAll;
    private System.Windows.Forms.DataGridView dgvEmployees;

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
        this.lblEmpId = new System.Windows.Forms.Label();
        this.txtEmpId = new System.Windows.Forms.TextBox();
        this.lblEmpName = new System.Windows.Forms.Label();
        this.txtEmpName = new System.Windows.Forms.TextBox();
        this.lblSalary = new System.Windows.Forms.Label();
        this.txtSalary = new System.Windows.Forms.TextBox();
        this.lblDeptNo = new System.Windows.Forms.Label();
        this.txtDeptNo = new System.Windows.Forms.TextBox();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        this.btnViewAll = new System.Windows.Forms.Button();
        this.dgvEmployees = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
        this.SuspendLayout();
        // 
        // lblEmpId
        // 
        this.lblEmpId.AutoSize = true;
        this.lblEmpId.Location = new System.Drawing.Point(20, 20);
        this.lblEmpId.Name = "lblEmpId";
        this.lblEmpId.Size = new System.Drawing.Size(46, 15);
        this.lblEmpId.TabIndex = 0;
        this.lblEmpId.Text = "Emp ID";
        // 
        // txtEmpId
        // 
        this.txtEmpId.Location = new System.Drawing.Point(90, 17);
        this.txtEmpId.Name = "txtEmpId";
        this.txtEmpId.Size = new System.Drawing.Size(100, 23);
        this.txtEmpId.TabIndex = 1;
        // 
        // lblEmpName
        // 
        this.lblEmpName.AutoSize = true;
        this.lblEmpName.Location = new System.Drawing.Point(20, 60);
        this.lblEmpName.Name = "lblEmpName";
        this.lblEmpName.Size = new System.Drawing.Size(66, 15);
        this.lblEmpName.TabIndex = 2;
        this.lblEmpName.Text = "Emp Name";
        // 
        // txtEmpName
        // 
        this.txtEmpName.Location = new System.Drawing.Point(90, 57);
        this.txtEmpName.Name = "txtEmpName";
        this.txtEmpName.Size = new System.Drawing.Size(100, 23);
        this.txtEmpName.TabIndex = 3;
        // 
        // lblSalary
        // 
        this.lblSalary.AutoSize = true;
        this.lblSalary.Location = new System.Drawing.Point(20, 100);
        this.lblSalary.Name = "lblSalary";
        this.lblSalary.Size = new System.Drawing.Size(38, 15);
        this.lblSalary.TabIndex = 4;
        this.lblSalary.Text = "Salary";
        // 
        // txtSalary
        // 
        this.txtSalary.Location = new System.Drawing.Point(90, 97);
        this.txtSalary.Name = "txtSalary";
        this.txtSalary.Size = new System.Drawing.Size(100, 23);
        this.txtSalary.TabIndex = 5;
        // 
        // lblDeptNo
        // 
        this.lblDeptNo.AutoSize = true;
        this.lblDeptNo.Location = new System.Drawing.Point(20, 140);
        this.lblDeptNo.Name = "lblDeptNo";
        this.lblDeptNo.Size = new System.Drawing.Size(49, 15);
        this.lblDeptNo.TabIndex = 6;
        this.lblDeptNo.Text = "Dept No";
        // 
        // txtDeptNo
        // 
        this.txtDeptNo.Location = new System.Drawing.Point(90, 137);
        this.txtDeptNo.Name = "txtDeptNo";
        this.txtDeptNo.Size = new System.Drawing.Size(100, 23);
        this.txtDeptNo.TabIndex = 7;
        // 
        // btnAdd
        // 
        this.btnAdd.Location = new System.Drawing.Point(220, 16);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(75, 23);
        this.btnAdd.TabIndex = 8;
        this.btnAdd.Text = "Add";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        // 
        // btnUpdate
        // 
        this.btnUpdate.Location = new System.Drawing.Point(220, 56);
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Size = new System.Drawing.Size(75, 23);
        this.btnUpdate.TabIndex = 9;
        this.btnUpdate.Text = "Update";
        this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(220, 96);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(75, 23);
        this.btnDelete.TabIndex = 10;
        this.btnDelete.Text = "Delete";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnViewAll
        // 
        this.btnViewAll.Location = new System.Drawing.Point(220, 136);
        this.btnViewAll.Name = "btnViewAll";
        this.btnViewAll.Size = new System.Drawing.Size(75, 23);
        this.btnViewAll.TabIndex = 11;
        this.btnViewAll.Text = "View All";
        this.btnViewAll.UseVisualStyleBackColor = true;
        this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
        // 
        // dgvEmployees
        // 
        this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvEmployees.Location = new System.Drawing.Point(20, 180);
        this.dgvEmployees.Name = "dgvEmployees";
        this.dgvEmployees.RowTemplate.Height = 25;
        this.dgvEmployees.Size = new System.Drawing.Size(500, 200);
        this.dgvEmployees.TabIndex = 12;
        // 
        // FrmEmployee
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(540, 400);
        this.Controls.Add(this.dgvEmployees);
        this.Controls.Add(this.btnViewAll);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.txtDeptNo);
        this.Controls.Add(this.lblDeptNo);
        this.Controls.Add(this.txtSalary);
        this.Controls.Add(this.lblSalary);
        this.Controls.Add(this.txtEmpName);
        this.Controls.Add(this.lblEmpName);
        this.Controls.Add(this.txtEmpId);
        this.Controls.Add(this.lblEmpId);
        this.Name = "FrmEmployee";
        this.Text = "Employee Management";
        ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
