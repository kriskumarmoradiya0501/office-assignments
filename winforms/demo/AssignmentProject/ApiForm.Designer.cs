namespace AssignmentProject;

partial class ApiForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.DataGridView dgview;
    private System.Windows.Forms.Label lblId;
    private System.Windows.Forms.TextBox txtid;
    private System.Windows.Forms.Label lblUserId;
    private System.Windows.Forms.TextBox txtuserid;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TextBox txttitle;
    private System.Windows.Forms.Label lblBody;
    private System.Windows.Forms.TextBox txtbody;
    private System.Windows.Forms.Button btnRead;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnDelete;

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
        this.dgview = new System.Windows.Forms.DataGridView();
        this.lblId = new System.Windows.Forms.Label();
        this.txtid = new System.Windows.Forms.TextBox();
        this.lblUserId = new System.Windows.Forms.Label();
        this.txtuserid = new System.Windows.Forms.TextBox();
        this.lblTitle = new System.Windows.Forms.Label();
        this.txttitle = new System.Windows.Forms.TextBox();
        this.lblBody = new System.Windows.Forms.Label();
        this.txtbody = new System.Windows.Forms.TextBox();
        this.btnRead = new System.Windows.Forms.Button();
        this.btnAdd = new System.Windows.Forms.Button();
        this.btnUpdate = new System.Windows.Forms.Button();
        this.btnDelete = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
        this.SuspendLayout();
        // 
        // dgview
        // 
        this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgview.Location = new System.Drawing.Point(20, 20);
        this.dgview.Name = "dgview";
        this.dgview.RowTemplate.Height = 25;
        this.dgview.Size = new System.Drawing.Size(650, 200);
        this.dgview.TabIndex = 0;
        // 
        // lblId
        // 
        this.lblId.AutoSize = true;
        this.lblId.Location = new System.Drawing.Point(20, 280);
        this.lblId.Name = "lblId";
        this.lblId.Size = new System.Drawing.Size(17, 15);
        this.lblId.TabIndex = 5;
        this.lblId.Text = "Id";
        // 
        // txtid
        // 
        this.txtid.Location = new System.Drawing.Point(70, 277);
        this.txtid.Name = "txtid";
        this.txtid.Size = new System.Drawing.Size(100, 23);
        this.txtid.TabIndex = 6;
        // 
        // lblUserId
        // 
        this.lblUserId.AutoSize = true;
        this.lblUserId.Location = new System.Drawing.Point(200, 280);
        this.lblUserId.Name = "lblUserId";
        this.lblUserId.Size = new System.Drawing.Size(43, 15);
        this.lblUserId.TabIndex = 7;
        this.lblUserId.Text = "UserId";
        // 
        // txtuserid
        // 
        this.txtuserid.Location = new System.Drawing.Point(250, 277);
        this.txtuserid.Name = "txtuserid";
        this.txtuserid.Size = new System.Drawing.Size(100, 23);
        this.txtuserid.TabIndex = 8;
        // 
        // lblTitle
        // 
        this.lblTitle.AutoSize = true;
        this.lblTitle.Location = new System.Drawing.Point(380, 280);
        this.lblTitle.Name = "lblTitle";
        this.lblTitle.Size = new System.Drawing.Size(29, 15);
        this.lblTitle.TabIndex = 9;
        this.lblTitle.Text = "Title";
        // 
        // txttitle
        // 
        this.txttitle.Location = new System.Drawing.Point(420, 277);
        this.txttitle.Name = "txttitle";
        this.txttitle.Size = new System.Drawing.Size(250, 23);
        this.txttitle.TabIndex = 10;
        // 
        // lblBody
        // 
        this.lblBody.AutoSize = true;
        this.lblBody.Location = new System.Drawing.Point(20, 320);
        this.lblBody.Name = "lblBody";
        this.lblBody.Size = new System.Drawing.Size(34, 15);
        this.lblBody.TabIndex = 11;
        this.lblBody.Text = "Body";
        // 
        // txtbody
        // 
        this.txtbody.Location = new System.Drawing.Point(70, 317);
        this.txtbody.Multiline = true;
        this.txtbody.Name = "txtbody";
        this.txtbody.Size = new System.Drawing.Size(600, 80);
        this.txtbody.TabIndex = 12;
        // 
        // btnAdd
        // 
        this.btnAdd.Location = new System.Drawing.Point(20, 240);
        this.btnAdd.Name = "btnAdd";
        this.btnAdd.Size = new System.Drawing.Size(75, 23);
        this.btnAdd.TabIndex = 1;
        this.btnAdd.Text = "Add";
        this.btnAdd.UseVisualStyleBackColor = true;
        this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        // 
        // btnUpdate
        // 
        this.btnUpdate.Location = new System.Drawing.Point(110, 240);
        this.btnUpdate.Name = "btnUpdate";
        this.btnUpdate.Size = new System.Drawing.Size(75, 23);
        this.btnUpdate.TabIndex = 2;
        this.btnUpdate.Text = "Update";
        this.btnUpdate.UseVisualStyleBackColor = true;
        this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
        // 
        // btnDelete
        // 
        this.btnDelete.Location = new System.Drawing.Point(200, 240);
        this.btnDelete.Name = "btnDelete";
        this.btnDelete.Size = new System.Drawing.Size(75, 23);
        this.btnDelete.TabIndex = 3;
        this.btnDelete.Text = "Delete";
        this.btnDelete.UseVisualStyleBackColor = true;
        this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        // 
        // btnRead
        // 
        this.btnRead.Location = new System.Drawing.Point(290, 240);
        this.btnRead.Name = "btnRead";
        this.btnRead.Size = new System.Drawing.Size(75, 23);
        this.btnRead.TabIndex = 4;
        this.btnRead.Text = "Read";
        this.btnRead.UseVisualStyleBackColor = true;
        this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
        // 
        // ApiForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(700, 420);
        this.Controls.Add(this.txtbody);
        this.Controls.Add(this.lblBody);
        this.Controls.Add(this.txttitle);
        this.Controls.Add(this.lblTitle);
        this.Controls.Add(this.txtuserid);
        this.Controls.Add(this.lblUserId);
        this.Controls.Add(this.txtid);
        this.Controls.Add(this.lblId);
        this.Controls.Add(this.btnRead);
        this.Controls.Add(this.btnDelete);
        this.Controls.Add(this.btnUpdate);
        this.Controls.Add(this.btnAdd);
        this.Controls.Add(this.dgview);
        this.Name = "ApiForm";
        this.Text = "Api";
        ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
