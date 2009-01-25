namespace CrudGenerator {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtSuccessLog = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkCreate = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkReadById = new System.Windows.Forms.CheckBox();
            this.chkReadAll = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkDeactivate = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.txtErrorLog = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1Authentication = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.groupBox1Authentication.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Table Like";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(75, 6);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 14;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(75, 33);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(100, 20);
            this.txtDatabase.TabIndex = 1;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(75, 195);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(100, 20);
            this.txtTableName.TabIndex = 2;
            this.txtTableName.Text = "%";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 41);
            this.button1.TabIndex = 11;
            this.button1.Text = "Make Stored Procedures";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Author";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(75, 221);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(100, 20);
            this.txtAuthor.TabIndex = 3;
            // 
            // txtSuccessLog
            // 
            this.txtSuccessLog.Location = new System.Drawing.Point(182, 22);
            this.txtSuccessLog.Multiline = true;
            this.txtSuccessLog.Name = "txtSuccessLog";
            this.txtSuccessLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSuccessLog.Size = new System.Drawing.Size(740, 376);
            this.txtSuccessLog.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Success Log:";
            // 
            // chkCreate
            // 
            this.chkCreate.AutoSize = true;
            this.chkCreate.Checked = true;
            this.chkCreate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreate.Location = new System.Drawing.Point(15, 247);
            this.chkCreate.Name = "chkCreate";
            this.chkCreate.Size = new System.Drawing.Size(57, 17);
            this.chkCreate.TabIndex = 4;
            this.chkCreate.Text = "Create";
            this.chkCreate.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(97, 247);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(61, 17);
            this.chkUpdate.TabIndex = 5;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkReadById
            // 
            this.chkReadById.AutoSize = true;
            this.chkReadById.Checked = true;
            this.chkReadById.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadById.Location = new System.Drawing.Point(15, 270);
            this.chkReadById.Name = "chkReadById";
            this.chkReadById.Size = new System.Drawing.Size(73, 17);
            this.chkReadById.TabIndex = 6;
            this.chkReadById.Text = "ReadById";
            this.chkReadById.UseVisualStyleBackColor = true;
            // 
            // chkReadAll
            // 
            this.chkReadAll.AutoSize = true;
            this.chkReadAll.Checked = true;
            this.chkReadAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadAll.Location = new System.Drawing.Point(97, 270);
            this.chkReadAll.Name = "chkReadAll";
            this.chkReadAll.Size = new System.Drawing.Size(63, 17);
            this.chkReadAll.TabIndex = 7;
            this.chkReadAll.Text = "ReadAll";
            this.chkReadAll.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(15, 293);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(57, 17);
            this.chkDelete.TabIndex = 8;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkDeactivate
            // 
            this.chkDeactivate.AutoSize = true;
            this.chkDeactivate.Location = new System.Drawing.Point(97, 293);
            this.chkDeactivate.Name = "chkDeactivate";
            this.chkDeactivate.Size = new System.Drawing.Size(78, 17);
            this.chkDeactivate.TabIndex = 9;
            this.chkDeactivate.Text = "Deactivate";
            this.chkDeactivate.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "IsActive Field:";
            // 
            // txtIsActive
            // 
            this.txtIsActive.Location = new System.Drawing.Point(92, 322);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Size = new System.Drawing.Size(83, 20);
            this.txtIsActive.TabIndex = 10;
            this.txtIsActive.Text = "IsActive";
            // 
            // txtErrorLog
            // 
            this.txtErrorLog.Location = new System.Drawing.Point(184, 417);
            this.txtErrorLog.Multiline = true;
            this.txtErrorLog.Name = "txtErrorLog";
            this.txtErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorLog.Size = new System.Drawing.Size(740, 387);
            this.txtErrorLog.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 401);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Error Log:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(16, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Trusted Connection";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1Authentication
            // 
            this.groupBox1Authentication.Controls.Add(this.lblUserName);
            this.groupBox1Authentication.Controls.Add(this.txtUser);
            this.groupBox1Authentication.Controls.Add(this.lblPassword);
            this.groupBox1Authentication.Controls.Add(this.txtPassword);
            this.groupBox1Authentication.Location = new System.Drawing.Point(4, 91);
            this.groupBox1Authentication.Name = "groupBox1Authentication";
            this.groupBox1Authentication.Size = new System.Drawing.Size(170, 97);
            this.groupBox1Authentication.TabIndex = 21;
            this.groupBox1Authentication.TabStop = false;
            this.groupBox1Authentication.Text = "Authentication";
            this.groupBox1Authentication.Visible = false;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(8, 26);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(55, 13);
            this.lblUserName.TabIndex = 24;
            this.lblUserName.Text = "Username";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(66, 19);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 23;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(3, 49);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 21;
            this.lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(67, 46);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 812);
            this.Controls.Add(this.groupBox1Authentication);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkDeactivate);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.chkReadAll);
            this.Controls.Add(this.chkReadById);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.chkCreate);
            this.Controls.Add(this.txtErrorLog);
            this.Controls.Add(this.txtSuccessLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIsActive);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1Authentication.ResumeLayout(false);
            this.groupBox1Authentication.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtSuccessLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkCreate;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkReadById;
        private System.Windows.Forms.CheckBox chkReadAll;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkDeactivate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIsActive;
        private System.Windows.Forms.TextBox txtErrorLog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1Authentication;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
    }
}

