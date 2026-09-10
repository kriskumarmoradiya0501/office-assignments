namespace Practice
{
    public partial class Form3 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.gbSkills = new System.Windows.Forms.GroupBox();
            this.chkPython = new System.Windows.Forms.CheckBox();
            this.chkSql = new System.Windows.Forms.CheckBox();
            this.chkJava = new System.Windows.Forms.CheckBox();
            this.chkCSharp = new System.Windows.Forms.CheckBox();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.lblDays = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.lblDOB = new System.Windows.Forms.Label();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.btnShowDept = new System.Windows.Forms.Button();
            this.lstSkill = new System.Windows.Forms.ListBox();
            this.btnShowSkill = new System.Windows.Forms.Button();
            this.lblList = new System.Windows.Forms.Label();
            this.btnShoeSkills = new System.Windows.Forms.Button();
            this.lstSkills = new System.Windows.Forms.ListBox();
            this.lblSkills = new System.Windows.Forms.Label();
            this.grpTshirtSize = new System.Windows.Forms.GroupBox();
            this.rbXL = new System.Windows.Forms.RadioButton();
            this.rbM = new System.Windows.Forms.RadioButton();
            this.rbL = new System.Windows.Forms.RadioButton();
            this.rbS = new System.Windows.Forms.RadioButton();
            this.btnShowTshirtSize = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtLiveText = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblTextChengedEvent = new System.Windows.Forms.Label();
            this.lblLiveText = new System.Windows.Forms.Label();
            this.lblKeyPress = new System.Windows.Forms.Label();
            this.lblKeyPressEvet = new System.Windows.Forms.Label();
            this.lblKeyPressResult = new System.Windows.Forms.Label();
            this.txtKeyPress = new System.Windows.Forms.TextBox();
            this.lblKeyDownEvent = new System.Windows.Forms.Label();
            this.lblResulKeyDown = new System.Windows.Forms.Label();
            this.lblKeyDown = new System.Windows.Forms.Label();
            this.txtKeyDown = new System.Windows.Forms.TextBox();
            this.lblKeyUpEvent = new System.Windows.Forms.Label();
            this.lblKeyUpResult = new System.Windows.Forms.Label();
            this.lblKeyUp = new System.Windows.Forms.Label();
            this.txtKeyUpEvent = new System.Windows.Forms.TextBox();
            this.btnMouse = new System.Windows.Forms.Button();
            this.gbSkills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            this.grpTshirtSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(47, 44);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name : ";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(56, 82);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 16);
            this.lblAge.TabIndex = 1;
            this.lblAge.Text = "Age";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(121, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 22);
            this.txtName.TabIndex = 2;
            this.txtName.Enter += new System.EventHandler(this.TxtName_Enter);
            this.txtName.Leave += new System.EventHandler(this.TxtName_Leave);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(121, 76);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(100, 22);
            this.txtAge.TabIndex = 3;
            this.txtAge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAge_KeyPress);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(270, 453);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(187, 49);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
                        "Male",
                        "Female",
                        "Other"});
            this.cmbGender.Location = new System.Drawing.Point(121, 115);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 24);
            this.cmbGender.TabIndex = 5;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(56, 115);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(52, 16);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "Gender";
            // 
            // gbSkills
            // 
            this.gbSkills.Controls.Add(this.chkPython);
            this.gbSkills.Controls.Add(this.chkSql);
            this.gbSkills.Controls.Add(this.chkJava);
            this.gbSkills.Controls.Add(this.chkCSharp);
            this.gbSkills.Location = new System.Drawing.Point(66, 155);
            this.gbSkills.Name = "gbSkills";
            this.gbSkills.Size = new System.Drawing.Size(200, 134);
            this.gbSkills.TabIndex = 7;
            this.gbSkills.TabStop = false;
            this.gbSkills.Text = "Skills";
            // 
            // chkPython
            // 
            this.chkPython.AutoSize = true;
            this.chkPython.Location = new System.Drawing.Point(7, 74);
            this.chkPython.Name = "chkPython";
            this.chkPython.Size = new System.Drawing.Size(70, 20);
            this.chkPython.TabIndex = 3;
            this.chkPython.Text = "Python";
            this.chkPython.UseVisualStyleBackColor = true;
            // 
            // chkSql
            // 
            this.chkSql.AutoSize = true;
            this.chkSql.Location = new System.Drawing.Point(7, 100);
            this.chkSql.Name = "chkSql";
            this.chkSql.Size = new System.Drawing.Size(55, 20);
            this.chkSql.TabIndex = 2;
            this.chkSql.Text = "SQL";
            this.chkSql.UseVisualStyleBackColor = true;
            // 
            // chkJava
            // 
            this.chkJava.AutoSize = true;
            this.chkJava.Location = new System.Drawing.Point(7, 48);
            this.chkJava.Name = "chkJava";
            this.chkJava.Size = new System.Drawing.Size(59, 20);
            this.chkJava.TabIndex = 1;
            this.chkJava.Text = "Java";
            this.chkJava.UseVisualStyleBackColor = true;
            // 
            // chkCSharp
            // 
            this.chkCSharp.AutoSize = true;
            this.chkCSharp.Location = new System.Drawing.Point(7, 22);
            this.chkCSharp.Name = "chkCSharp";
            this.chkCSharp.Size = new System.Drawing.Size(45, 20);
            this.chkCSharp.TabIndex = 0;
            this.chkCSharp.Text = "C#";
            this.chkCSharp.UseVisualStyleBackColor = true;
            // 
            // nudDays
            // 
            this.nudDays.Location = new System.Drawing.Point(121, 295);
            this.nudDays.Minimum = new decimal(new int[] {
                        1,
                        0,
                        0,
                        0});
            this.nudDays.Name = "nudDays";
            this.nudDays.Size = new System.Drawing.Size(120, 22);
            this.nudDays.TabIndex = 8;
            this.nudDays.Value = new decimal(new int[] {
                        1,
                        0,
                        0,
                        0});
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(66, 296);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(39, 16);
            this.lblDays.TabIndex = 9;
            this.lblDays.Text = "Days";
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(121, 320);
            this.dtpDOB.MaxDate = new System.DateTime(2026, 9, 9, 0, 0, 0, 0);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(200, 22);
            this.dtpDOB.TabIndex = 10;
            this.dtpDOB.Value = new System.DateTime(2026, 9, 9, 0, 0, 0, 0);
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Location = new System.Drawing.Point(66, 320);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(36, 16);
            this.lblDOB.TabIndex = 11;
            this.lblDOB.Text = "DOB";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.AllowDrop = true;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Items.AddRange(new object[] {
                        "Computer Science",
                        "Information Technology",
                        "Artificial Intelligence",
                        "Data Science"});
            this.cmbDepartment.Location = new System.Drawing.Point(367, 64);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(121, 24);
            this.cmbDepartment.TabIndex = 12;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(284, 67);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(77, 16);
            this.lblDepartment.TabIndex = 13;
            this.lblDepartment.Text = "Department";
            // 
            // btnShowDept
            // 
            this.btnShowDept.Location = new System.Drawing.Point(337, 108);
            this.btnShowDept.Name = "btnShowDept";
            this.btnShowDept.Size = new System.Drawing.Size(169, 23);
            this.btnShowDept.TabIndex = 14;
            this.btnShowDept.Text = "Show Department Index";
            this.btnShowDept.UseVisualStyleBackColor = true;
            this.btnShowDept.Click += new System.EventHandler(this.BtnShowDept_Click);
            // 
            // lstSkill
            // 
            this.lstSkill.FormattingEnabled = true;
            this.lstSkill.ItemHeight = 16;
            this.lstSkill.Items.AddRange(new object[] {
                        "C#",
                        "Java",
                        "Python",
                        "SQL",
                        "JavaScript"});
            this.lstSkill.Location = new System.Drawing.Point(337, 155);
            this.lstSkill.Name = "lstSkill";
            this.lstSkill.Size = new System.Drawing.Size(120, 84);
            this.lstSkill.TabIndex = 15;
            // 
            // btnShowSkill
            // 
            this.btnShowSkill.Location = new System.Drawing.Point(337, 255);
            this.btnShowSkill.Name = "btnShowSkill";
            this.btnShowSkill.Size = new System.Drawing.Size(120, 23);
            this.btnShowSkill.TabIndex = 16;
            this.btnShowSkill.Text = "Show skill";
            this.btnShowSkill.UseVisualStyleBackColor = true;
            this.btnShowSkill.Click += new System.EventHandler(this.BtnShowSkill_Click);
            // 
            // lblList
            // 
            this.lblList.AutoSize = true;
            this.lblList.Location = new System.Drawing.Point(337, 138);
            this.lblList.Name = "lblList";
            this.lblList.Size = new System.Drawing.Size(92, 16);
            this.lblList.TabIndex = 17;
            this.lblList.Text = "Available Skill";
            // 
            // btnShoeSkills
            // 
            this.btnShoeSkills.Location = new System.Drawing.Point(491, 257);
            this.btnShoeSkills.Name = "btnShoeSkills";
            this.btnShoeSkills.Size = new System.Drawing.Size(127, 40);
            this.btnShoeSkills.TabIndex = 18;
            this.btnShoeSkills.Text = "Show Skills";
            this.btnShoeSkills.UseVisualStyleBackColor = true;
            this.btnShoeSkills.Click += new System.EventHandler(this.BtnShoeSkills_Click);
            // 
            // lstSkills
            // 
            this.lstSkills.FormattingEnabled = true;
            this.lstSkills.ItemHeight = 16;
            this.lstSkills.Items.AddRange(new object[] {
                        "C#",
                        "Java",
                        "Python",
                        "SQL",
                        "JavaScript"});
            this.lstSkills.Location = new System.Drawing.Point(498, 155);
            this.lstSkills.Name = "lstSkills";
            this.lstSkills.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSkills.Size = new System.Drawing.Size(120, 84);
            this.lstSkills.TabIndex = 19;
            // 
            // lblSkills
            // 
            this.lblSkills.AutoSize = true;
            this.lblSkills.Location = new System.Drawing.Point(498, 134);
            this.lblSkills.Name = "lblSkills";
            this.lblSkills.Size = new System.Drawing.Size(99, 16);
            this.lblSkills.TabIndex = 20;
            this.lblSkills.Text = "Available Skills";
            // 
            // grpTshirtSize
            // 
            this.grpTshirtSize.Controls.Add(this.rbXL);
            this.grpTshirtSize.Controls.Add(this.rbM);
            this.grpTshirtSize.Controls.Add(this.rbL);
            this.grpTshirtSize.Controls.Add(this.rbS);
            this.grpTshirtSize.Location = new System.Drawing.Point(355, 320);
            this.grpTshirtSize.Name = "grpTshirtSize";
            this.grpTshirtSize.Size = new System.Drawing.Size(200, 100);
            this.grpTshirtSize.TabIndex = 21;
            this.grpTshirtSize.TabStop = false;
            this.grpTshirtSize.Text = "Select Your Tshirt Size";
            // 
            // rbXL
            // 
            this.rbXL.Location = new System.Drawing.Point(96, 28);
            this.rbXL.Name = "rbXL";
            this.rbXL.Size = new System.Drawing.Size(104, 24);
            this.rbXL.TabIndex = 3;
            this.rbXL.TabStop = true;
            this.rbXL.Text = "XL";
            this.rbXL.UseVisualStyleBackColor = true;
            // 
            // rbM
            // 
            this.rbM.Location = new System.Drawing.Point(6, 73);
            this.rbM.Name = "rbM";
            this.rbM.Size = new System.Drawing.Size(104, 24);
            this.rbM.TabIndex = 2;
            this.rbM.TabStop = true;
            this.rbM.Text = "M";
            this.rbM.UseVisualStyleBackColor = true;
            // 
            // rbL
            // 
            this.rbL.Location = new System.Drawing.Point(7, 43);
            this.rbL.Name = "rbL";
            this.rbL.Size = new System.Drawing.Size(104, 24);
            this.rbL.TabIndex = 1;
            this.rbL.TabStop = true;
            this.rbL.Text = "L";
            this.rbL.UseVisualStyleBackColor = true;
            // 
            // rbS
            // 
            this.rbS.Location = new System.Drawing.Point(7, 13);
            this.rbS.Name = "rbS";
            this.rbS.Size = new System.Drawing.Size(104, 24);
            this.rbS.TabIndex = 0;
            this.rbS.TabStop = true;
            this.rbS.Text = "S";
            this.rbS.UseVisualStyleBackColor = true;
            // 
            // btnShowTshirtSize
            // 
            this.btnShowTshirtSize.Location = new System.Drawing.Point(388, 426);
            this.btnShowTshirtSize.Name = "btnShowTshirtSize";
            this.btnShowTshirtSize.Size = new System.Drawing.Size(138, 23);
            this.btnShowTshirtSize.TabIndex = 22;
            this.btnShowTshirtSize.Text = "Show Tshirt Size";
            this.btnShowTshirtSize.UseVisualStyleBackColor = true;
            this.btnShowTshirtSize.Click += new System.EventHandler(this.BtnShowTshirtSize_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(30, 453);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(166, 49);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // txtLiveText
            // 
            this.txtLiveText.Location = new System.Drawing.Point(152, 369);
            this.txtLiveText.Name = "txtLiveText";
            this.txtLiveText.Size = new System.Drawing.Size(169, 22);
            this.txtLiveText.TabIndex = 24;
            this.txtLiveText.TextChanged += new System.EventHandler(this.TxtLiveText_TextChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(92, 397);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(51, 16);
            this.lblResult.TabIndex = 25;
            this.lblResult.Text = "Result :";
            // 
            // lblTextChengedEvent
            // 
            this.lblTextChengedEvent.AutoSize = true;
            this.lblTextChengedEvent.Location = new System.Drawing.Point(12, 369);
            this.lblTextChengedEvent.Name = "lblTextChengedEvent";
            this.lblTextChengedEvent.Size = new System.Drawing.Size(134, 16);
            this.lblTextChengedEvent.TabIndex = 26;
            this.lblTextChengedEvent.Text = "Text Chenged Event :";
            // 
            // lblLiveText
            // 
            this.lblLiveText.AutoSize = true;
            this.lblLiveText.Location = new System.Drawing.Point(131, 398);
            this.lblLiveText.Name = "lblLiveText";
            this.lblLiveText.Size = new System.Drawing.Size(0, 16);
            this.lblLiveText.TabIndex = 27;
            // 
            // lblKeyPress
            // 
            this.lblKeyPress.AutoSize = true;
            this.lblKeyPress.Location = new System.Drawing.Point(682, 352);
            this.lblKeyPress.Name = "lblKeyPress";
            this.lblKeyPress.Size = new System.Drawing.Size(0, 16);
            this.lblKeyPress.TabIndex = 31;
            // 
            // lblKeyPressEvet
            // 
            this.lblKeyPressEvet.AutoSize = true;
            this.lblKeyPressEvet.Location = new System.Drawing.Point(561, 320);
            this.lblKeyPressEvet.Name = "lblKeyPressEvet";
            this.lblKeyPressEvet.Size = new System.Drawing.Size(111, 16);
            this.lblKeyPressEvet.TabIndex = 30;
            this.lblKeyPressEvet.Text = "Key Press Event :";
            // 
            // lblKeyPressResult
            // 
            this.lblKeyPressResult.AutoSize = true;
            this.lblKeyPressResult.Location = new System.Drawing.Point(561, 348);
            this.lblKeyPressResult.Name = "lblKeyPressResult";
            this.lblKeyPressResult.Size = new System.Drawing.Size(115, 16);
            this.lblKeyPressResult.TabIndex = 29;
            this.lblKeyPressResult.Text = "Result Key Press :";
            // 
            // txtKeyPress
            // 
            this.txtKeyPress.Location = new System.Drawing.Point(682, 314);
            this.txtKeyPress.Name = "txtKeyPress";
            this.txtKeyPress.Size = new System.Drawing.Size(116, 22);
            this.txtKeyPress.TabIndex = 28;
            this.txtKeyPress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtKeyPress_KeyPress);
            // 
            // lblKeyDownEvent
            // 
            this.lblKeyDownEvent.AutoSize = true;
            this.lblKeyDownEvent.Location = new System.Drawing.Point(562, 393);
            this.lblKeyDownEvent.Name = "lblKeyDownEvent";
            this.lblKeyDownEvent.Size = new System.Drawing.Size(110, 16);
            this.lblKeyDownEvent.TabIndex = 32;
            this.lblKeyDownEvent.Text = "Key Down Event :";
            // 
            // lblResulKeyDown
            // 
            this.lblResulKeyDown.AutoSize = true;
            this.lblResulKeyDown.Location = new System.Drawing.Point(561, 429);
            this.lblResulKeyDown.Name = "lblResulKeyDown";
            this.lblResulKeyDown.Size = new System.Drawing.Size(114, 16);
            this.lblResulKeyDown.TabIndex = 33;
            this.lblResulKeyDown.Text = "Result Key Down :";
            // 
            // lblKeyDown
            // 
            this.lblKeyDown.AutoSize = true;
            this.lblKeyDown.Location = new System.Drawing.Point(682, 429);
            this.lblKeyDown.Name = "lblKeyDown";
            this.lblKeyDown.Size = new System.Drawing.Size(0, 16);
            this.lblKeyDown.TabIndex = 34;
            // 
            // txtKeyDown
            // 
            this.txtKeyDown.Location = new System.Drawing.Point(682, 395);
            this.txtKeyDown.Name = "txtKeyDown";
            this.txtKeyDown.Size = new System.Drawing.Size(100, 22);
            this.txtKeyDown.TabIndex = 35;
            this.txtKeyDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtKeyDown_KeyDown);
            // 
            // lblKeyUpEvent
            // 
            this.lblKeyUpEvent.AutoSize = true;
            this.lblKeyUpEvent.Location = new System.Drawing.Point(562, 453);
            this.lblKeyUpEvent.Name = "lblKeyUpEvent";
            this.lblKeyUpEvent.Size = new System.Drawing.Size(88, 16);
            this.lblKeyUpEvent.TabIndex = 36;
            this.lblKeyUpEvent.Text = "Key Up Event";
            // 
            // lblKeyUpResult
            // 
            this.lblKeyUpResult.AutoSize = true;
            this.lblKeyUpResult.Location = new System.Drawing.Point(561, 486);
            this.lblKeyUpResult.Name = "lblKeyUpResult";
            this.lblKeyUpResult.Size = new System.Drawing.Size(92, 16);
            this.lblKeyUpResult.TabIndex = 37;
            this.lblKeyUpResult.Text = "Result Key Up";
            // 
            // lblKeyUp
            // 
            this.lblKeyUp.AutoSize = true;
            this.lblKeyUp.Location = new System.Drawing.Point(672, 486);
            this.lblKeyUp.Name = "lblKeyUp";
            this.lblKeyUp.Size = new System.Drawing.Size(0, 16);
            this.lblKeyUp.TabIndex = 38;
            // 
            // txtKeyUpEvent
            // 
            this.txtKeyUpEvent.Location = new System.Drawing.Point(656, 448);
            this.txtKeyUpEvent.Name = "txtKeyUpEvent";
            this.txtKeyUpEvent.Size = new System.Drawing.Size(100, 22);
            this.txtKeyUpEvent.TabIndex = 39;
            this.txtKeyUpEvent.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtKeyUpEvent_KeyUp);
            // 
            // btnMouse
            // 
            this.btnMouse.Location = new System.Drawing.Point(121, 12);
            this.btnMouse.Name = "btnMouse";
            this.btnMouse.Size = new System.Drawing.Size(270, 23);
            this.btnMouse.TabIndex = 40;
            this.btnMouse.Text = "Mouse Enter left demo";
            this.btnMouse.UseVisualStyleBackColor = true;
            this.btnMouse.MouseEnter += new System.EventHandler(this.BtnMouse_MouseEnter);
            this.btnMouse.MouseLeave += new System.EventHandler(this.BtnMouse_MouseLeave);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 514);
            this.Controls.Add(this.btnMouse);
            this.Controls.Add(this.txtKeyUpEvent);
            this.Controls.Add(this.lblKeyUp);
            this.Controls.Add(this.lblKeyUpResult);
            this.Controls.Add(this.lblKeyUpEvent);
            this.Controls.Add(this.txtKeyDown);
            this.Controls.Add(this.lblKeyDown);
            this.Controls.Add(this.lblResulKeyDown);
            this.Controls.Add(this.lblKeyDownEvent);
            this.Controls.Add(this.lblKeyPress);
            this.Controls.Add(this.lblKeyPressEvet);
            this.Controls.Add(this.lblKeyPressResult);
            this.Controls.Add(this.txtKeyPress);
            this.Controls.Add(this.lblLiveText);
            this.Controls.Add(this.lblTextChengedEvent);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtLiveText);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnShowTshirtSize);
            this.Controls.Add(this.grpTshirtSize);
            this.Controls.Add(this.lblSkills);
            this.Controls.Add(this.lstSkills);
            this.Controls.Add(this.btnShoeSkills);
            this.Controls.Add(this.lblList);
            this.Controls.Add(this.btnShowSkill);
            this.Controls.Add(this.lstSkill);
            this.Controls.Add(this.btnShowDept);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.nudDays);
            this.Controls.Add(this.gbSkills);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.cmbGender);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblName);
            this.Name = "Form3";
            this.Text = "Form3";
            this.gbSkills.ResumeLayout(false);
            this.gbSkills.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            this.grpTshirtSize.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.GroupBox gbSkills;
        private System.Windows.Forms.CheckBox chkPython;
        private System.Windows.Forms.CheckBox chkSql;
        private System.Windows.Forms.CheckBox chkJava;
        private System.Windows.Forms.CheckBox chkCSharp;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Button btnShowDept;
        private System.Windows.Forms.ListBox lstSkill;
        private System.Windows.Forms.Button btnShowSkill;
        private System.Windows.Forms.Label lblList;
        private System.Windows.Forms.Button btnShoeSkills;
        private System.Windows.Forms.ListBox lstSkills;
        private System.Windows.Forms.Label lblSkills;
        private System.Windows.Forms.GroupBox grpTshirtSize;
        private System.Windows.Forms.RadioButton rbXL;
        private System.Windows.Forms.RadioButton rbM;
        private System.Windows.Forms.RadioButton rbL;
        private System.Windows.Forms.RadioButton rbS;
        private System.Windows.Forms.Button btnShowTshirtSize;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtLiveText;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblTextChengedEvent;
        private System.Windows.Forms.Label lblLiveText;
        private System.Windows.Forms.Label lblKeyPress;
        private System.Windows.Forms.Label lblKeyPressEvet;
        private System.Windows.Forms.Label lblKeyPressResult;
        private System.Windows.Forms.TextBox txtKeyPress;
        private System.Windows.Forms.Label lblKeyDownEvent;
        private System.Windows.Forms.Label lblResulKeyDown;
        private System.Windows.Forms.Label lblKeyDown;
        private System.Windows.Forms.TextBox txtKeyDown;
        private System.Windows.Forms.Label lblKeyUpEvent;
        private System.Windows.Forms.Label lblKeyUpResult;
        private System.Windows.Forms.Label lblKeyUp;
        private System.Windows.Forms.TextBox txtKeyUpEvent;
        private System.Windows.Forms.Button btnMouse;
    }
}