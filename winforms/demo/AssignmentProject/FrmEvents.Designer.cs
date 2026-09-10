namespace AssignmentProject;

partial class FrmEvents
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.TextBox t1;
    private System.Windows.Forms.TextBox t2;
    private System.Windows.Forms.TextBox t3;
    private System.Windows.Forms.TextBox t4;
    private System.Windows.Forms.PictureBox p1;
    private System.Windows.Forms.Button b1;

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
        this.t1 = new System.Windows.Forms.TextBox();
        this.t2 = new System.Windows.Forms.TextBox();
        this.t3 = new System.Windows.Forms.TextBox();
        this.t4 = new System.Windows.Forms.TextBox();
        this.p1 = new System.Windows.Forms.PictureBox();
        this.b1 = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.p1)).BeginInit();
        this.SuspendLayout();
        // 
        // t1
        // 
        this.t1.Location = new System.Drawing.Point(100, 100);
        this.t1.Name = "t1";
        this.t1.Size = new System.Drawing.Size(200, 23);
        this.t1.TabIndex = 2;
        this.t1.TextChanged += new System.EventHandler(this.t1_textchanged);
        this.t1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t1_keypress);
        // 
        // t2
        // 
        this.t2.Enabled = false;
        this.t2.Location = new System.Drawing.Point(100, 150);
        this.t2.Name = "t2";
        this.t2.Size = new System.Drawing.Size(200, 23);
        this.t2.TabIndex = 3;
        // 
        // t3
        // 
        this.t3.Location = new System.Drawing.Point(100, 200);
        this.t3.Name = "t3";
        this.t3.Size = new System.Drawing.Size(200, 23);
        this.t3.TabIndex = 0;
        this.t3.GotFocus += new System.EventHandler(this.t3_onfocus);
        this.t3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.t3_keydown);
        this.t3.Leave += new System.EventHandler(this.t3_onleave);
        // 
        // t4
        // 
        this.t4.Location = new System.Drawing.Point(100, 250);
        this.t4.Name = "t4";
        this.t4.Size = new System.Drawing.Size(200, 23);
        this.t4.TabIndex = 4;
        this.t4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.t4_keyup);
        this.t4.MouseEnter += new System.EventHandler(this.t4_mouseenter);
        this.t4.MouseLeave += new System.EventHandler(this.t4_mouseleave);
        // 
        // b1
        // 
        this.b1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.b1.Location = new System.Drawing.Point(100, 300);
        this.b1.Name = "b1";
        this.b1.Size = new System.Drawing.Size(200, 40);
        this.b1.TabIndex = 5;
        this.b1.Text = "Button";
        this.b1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.b1_mouseclick);
        // 
        // p1
        // 
        this.p1.BackColor = System.Drawing.Color.White;
        this.p1.Location = new System.Drawing.Point(100, 350);
        this.p1.Name = "p1";
        this.p1.Size = new System.Drawing.Size(400, 400);
        this.p1.TabIndex = 6;
        this.p1.TabStop = false;
        this.p1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.p1_mousedown);
        this.p1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.p1_mouseup);
        // 
        // FrmEvents
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 800);
        this.Controls.Add(this.b1);
        this.Controls.Add(this.p1);
        this.Controls.Add(this.t4);
        this.Controls.Add(this.t3);
        this.Controls.Add(this.t2);
        this.Controls.Add(this.t1);
        this.Name = "FrmEvents";
        this.Text = "Form Events & Drawing Demo";
        ((System.ComponentModel.ISupportInitialize)(this.p1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
