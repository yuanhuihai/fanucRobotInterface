namespace fanucRobotInterface
{
    partial class addRobot
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.line = new System.Windows.Forms.TextBox();
            this.robotname = new System.Windows.Forms.TextBox();
            this.robotip = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "1线 or 2线";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(131, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "机器人名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "机器人Ip地址";
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(358, 129);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(290, 42);
            this.line.TabIndex = 3;
            // 
            // robotname
            // 
            this.robotname.Location = new System.Drawing.Point(358, 263);
            this.robotname.Name = "robotname";
            this.robotname.Size = new System.Drawing.Size(290, 42);
            this.robotname.TabIndex = 4;
            // 
            // robotip
            // 
            this.robotip.Location = new System.Drawing.Point(358, 418);
            this.robotip.Name = "robotip";
            this.robotip.Size = new System.Drawing.Size(290, 42);
            this.robotip.TabIndex = 5;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(791, 408);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(226, 56);
            this.add.TabIndex = 6;
            this.add.Text = "添加";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // addRobot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 927);
            this.Controls.Add(this.add);
            this.Controls.Add(this.robotip);
            this.Controls.Add(this.robotname);
            this.Controls.Add(this.line);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "addRobot";
            this.Text = "新增机器人信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox line;
        private System.Windows.Forms.TextBox robotname;
        private System.Windows.Forms.TextBox robotip;
        private System.Windows.Forms.Button add;
    }
}