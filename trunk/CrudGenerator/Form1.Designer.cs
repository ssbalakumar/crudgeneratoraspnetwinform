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
            this.components = new System.ComponentModel.Container();
            this.label1ServerName = new System.Windows.Forms.Label();
            this.label2DBName = new System.Windows.Forms.Label();
            this.label3TableLike = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4AuthorName = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.chkCreate = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkReadById = new System.Windows.Forms.CheckBox();
            this.chkReadAll = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkDeactivate = new System.Windows.Forms.CheckBox();
            this.label6IsActiveField = new System.Windows.Forms.Label();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.checkBox1TrustedConnection = new System.Windows.Forms.CheckBox();
            this.groupBox1Authentication = new System.Windows.Forms.GroupBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chBxDropIfExists = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1OutputDir = new System.Windows.Forms.Label();
            this.label1CodeNamespace = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSprocPrefix = new System.Windows.Forms.TextBox();
            this.label2SprocPrefix = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1SPROCs = new System.Windows.Forms.TabPage();
            this.chbxAddReadByUserId = new System.Windows.Forms.CheckBox();
            this.txtErrorLog = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSuccessLog = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2CSharp = new System.Windows.Forms.TabPage();
            this.txtNamespaceDL = new System.Windows.Forms.TextBox();
            this.txtC_DAL = new System.Windows.Forms.TextBox();
            this.txtNamespaceBL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtC_DL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtC_BL = new System.Windows.Forms.TextBox();
            this.lblC_Result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3C_GenerateBL = new System.Windows.Forms.Button();
            this.tabPage3VBCode = new System.Windows.Forms.TabPage();
            this.webBrowser1VBCode = new System.Windows.Forms.WebBrowser();
            this.tabPage1Options = new System.Windows.Forms.TabPage();
            this.checkBox1GuidIsCrudParam = new System.Windows.Forms.CheckBox();
            this.checkBox1OverWriteExisting = new System.Windows.Forms.CheckBox();
            this.label1AppTitle = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSessionAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1SessionName = new System.Windows.Forms.ToolStripTextBox();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideOptionsTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtOutputDirectory = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button2SelectFolder = new System.Windows.Forms.Button();
            this.chkSendOutputToFiles = new System.Windows.Forms.CheckBox();
            this.groupBox1Authentication.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1SPROCs.SuspendLayout();
            this.tabPage2CSharp.SuspendLayout();
            this.tabPage3VBCode.SuspendLayout();
            this.tabPage1Options.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1ServerName
            // 
            this.label1ServerName.AutoSize = true;
            this.label1ServerName.Location = new System.Drawing.Point(15, 84);
            this.label1ServerName.Name = "label1ServerName";
            this.label1ServerName.Size = new System.Drawing.Size(38, 13);
            this.label1ServerName.TabIndex = 0;
            this.label1ServerName.Text = "Server";
            // 
            // label2DBName
            // 
            this.label2DBName.AutoSize = true;
            this.label2DBName.Location = new System.Drawing.Point(15, 111);
            this.label2DBName.Name = "label2DBName";
            this.label2DBName.Size = new System.Drawing.Size(53, 13);
            this.label2DBName.TabIndex = 1;
            this.label2DBName.Text = "Database";
            // 
            // label3TableLike
            // 
            this.label3TableLike.AutoSize = true;
            this.label3TableLike.Location = new System.Drawing.Point(15, 273);
            this.label3TableLike.Name = "label3TableLike";
            this.label3TableLike.Size = new System.Drawing.Size(57, 13);
            this.label3TableLike.TabIndex = 2;
            this.label3TableLike.Text = "Table Like";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(78, 81);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(100, 20);
            this.txtServer.TabIndex = 1;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(78, 108);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(100, 20);
            this.txtDatabase.TabIndex = 2;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(78, 270);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(100, 20);
            this.txtTableName.TabIndex = 5;
            this.txtTableName.Text = "%";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 41);
            this.button1.TabIndex = 14;
            this.button1.Text = "Make Stored Procedures";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4AuthorName
            // 
            this.label4AuthorName.AutoSize = true;
            this.label4AuthorName.Location = new System.Drawing.Point(15, 299);
            this.label4AuthorName.Name = "label4AuthorName";
            this.label4AuthorName.Size = new System.Drawing.Size(38, 13);
            this.label4AuthorName.TabIndex = 2;
            this.label4AuthorName.Text = "Author";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(78, 296);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(100, 20);
            this.txtAuthor.TabIndex = 6;
            this.toolTip1.SetToolTip(this.txtAuthor, "Shows up in the comment above a stored procedure ");
            // 
            // chkCreate
            // 
            this.chkCreate.AutoSize = true;
            this.chkCreate.Checked = true;
            this.chkCreate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCreate.Location = new System.Drawing.Point(18, 322);
            this.chkCreate.Name = "chkCreate";
            this.chkCreate.Size = new System.Drawing.Size(57, 17);
            this.chkCreate.TabIndex = 7;
            this.chkCreate.Text = "Create";
            this.chkCreate.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Location = new System.Drawing.Point(100, 322);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(61, 17);
            this.chkUpdate.TabIndex = 8;
            this.chkUpdate.Text = "Update";
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkReadById
            // 
            this.chkReadById.AutoSize = true;
            this.chkReadById.Checked = true;
            this.chkReadById.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadById.Location = new System.Drawing.Point(18, 345);
            this.chkReadById.Name = "chkReadById";
            this.chkReadById.Size = new System.Drawing.Size(73, 17);
            this.chkReadById.TabIndex = 9;
            this.chkReadById.Text = "ReadById";
            this.chkReadById.UseVisualStyleBackColor = true;
            // 
            // chkReadAll
            // 
            this.chkReadAll.AutoSize = true;
            this.chkReadAll.Checked = true;
            this.chkReadAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReadAll.Location = new System.Drawing.Point(100, 345);
            this.chkReadAll.Name = "chkReadAll";
            this.chkReadAll.Size = new System.Drawing.Size(63, 17);
            this.chkReadAll.TabIndex = 10;
            this.chkReadAll.Text = "ReadAll";
            this.chkReadAll.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Checked = true;
            this.chkDelete.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDelete.Location = new System.Drawing.Point(18, 368);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(57, 17);
            this.chkDelete.TabIndex = 11;
            this.chkDelete.Text = "Delete";
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkDeactivate
            // 
            this.chkDeactivate.AutoSize = true;
            this.chkDeactivate.Location = new System.Drawing.Point(100, 368);
            this.chkDeactivate.Name = "chkDeactivate";
            this.chkDeactivate.Size = new System.Drawing.Size(78, 17);
            this.chkDeactivate.TabIndex = 12;
            this.chkDeactivate.Text = "Deactivate";
            this.toolTip1.SetToolTip(this.chkDeactivate, "This should be deprecated since the active flag should be part of the update proc" +
                    "edure.  it is just a column in the table - after all");
            this.chkDeactivate.UseVisualStyleBackColor = true;
            // 
            // label6IsActiveField
            // 
            this.label6IsActiveField.AutoSize = true;
            this.label6IsActiveField.Location = new System.Drawing.Point(16, 400);
            this.label6IsActiveField.Name = "label6IsActiveField";
            this.label6IsActiveField.Size = new System.Drawing.Size(73, 13);
            this.label6IsActiveField.TabIndex = 13;
            this.label6IsActiveField.Text = "IsActive Field:";
            // 
            // txtIsActive
            // 
            this.txtIsActive.Location = new System.Drawing.Point(95, 397);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Size = new System.Drawing.Size(83, 20);
            this.txtIsActive.TabIndex = 13;
            this.txtIsActive.Text = "IsActive";
            this.toolTip1.SetToolTip(this.txtIsActive, "This should be deprecated since the active flag should be part of the update proc" +
                    "edure.  it is just a column in the table - after all");
            // 
            // checkBox1TrustedConnection
            // 
            this.checkBox1TrustedConnection.AutoSize = true;
            this.checkBox1TrustedConnection.Checked = true;
            this.checkBox1TrustedConnection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1TrustedConnection.Location = new System.Drawing.Point(18, 143);
            this.checkBox1TrustedConnection.Name = "checkBox1TrustedConnection";
            this.checkBox1TrustedConnection.Size = new System.Drawing.Size(119, 17);
            this.checkBox1TrustedConnection.TabIndex = 3;
            this.checkBox1TrustedConnection.Text = "Trusted Connection";
            this.checkBox1TrustedConnection.UseVisualStyleBackColor = true;
            this.checkBox1TrustedConnection.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox1Authentication
            // 
            this.groupBox1Authentication.Controls.Add(this.lblUserName);
            this.groupBox1Authentication.Controls.Add(this.txtUser);
            this.groupBox1Authentication.Controls.Add(this.lblPassword);
            this.groupBox1Authentication.Controls.Add(this.txtPassword);
            this.groupBox1Authentication.Location = new System.Drawing.Point(7, 166);
            this.groupBox1Authentication.Name = "groupBox1Authentication";
            this.groupBox1Authentication.Size = new System.Drawing.Size(170, 97);
            this.groupBox1Authentication.TabIndex = 4;
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
            this.txtUser.TabIndex = 2;
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
            this.txtPassword.TabIndex = 3;
            // 
            // chBxDropIfExists
            // 
            this.chBxDropIfExists.AutoSize = true;
            this.chBxDropIfExists.Location = new System.Drawing.Point(208, 18);
            this.chBxDropIfExists.Name = "chBxDropIfExists";
            this.chBxDropIfExists.Size = new System.Drawing.Size(160, 17);
            this.chBxDropIfExists.TabIndex = 15;
            this.chBxDropIfExists.Text = "Add drop if exists statements";
            this.toolTip1.SetToolTip(this.chBxDropIfExists, "Adds drop if exists statements if.  Turn this on only if you are sure you will no" +
                    "t over-write your own customizations.");
            this.chBxDropIfExists.UseVisualStyleBackColor = true;
            this.chBxDropIfExists.CheckedChanged += new System.EventHandler(this.chBxDropIfExists_CheckedChanged);
            // 
            // label1OutputDir
            // 
            this.label1OutputDir.AutoSize = true;
            this.label1OutputDir.Location = new System.Drawing.Point(192, 642);
            this.label1OutputDir.Name = "label1OutputDir";
            this.label1OutputDir.Size = new System.Drawing.Size(84, 13);
            this.label1OutputDir.TabIndex = 3;
            this.label1OutputDir.Text = "Output Directory";
            this.toolTip1.SetToolTip(this.label1OutputDir, "This is the direcotry to which the c# code would be written to");
            // 
            // label1CodeNamespace
            // 
            this.label1CodeNamespace.AutoSize = true;
            this.label1CodeNamespace.Location = new System.Drawing.Point(46, 48);
            this.label1CodeNamespace.Name = "label1CodeNamespace";
            this.label1CodeNamespace.Size = new System.Drawing.Size(138, 13);
            this.label1CodeNamespace.TabIndex = 23;
            this.label1CodeNamespace.Text = "Business Layer Namespace";
            this.toolTip1.SetToolTip(this.label1CodeNamespace, "Namespace is used for C# and VB Code");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Data Layer Namespace";
            this.toolTip1.SetToolTip(this.label4, "Namespace is used for C# and VB Code");
            // 
            // txtSprocPrefix
            // 
            this.txtSprocPrefix.Enabled = false;
            this.txtSprocPrefix.Location = new System.Drawing.Point(482, 16);
            this.txtSprocPrefix.Name = "txtSprocPrefix";
            this.txtSprocPrefix.Size = new System.Drawing.Size(78, 20);
            this.txtSprocPrefix.TabIndex = 24;
            this.toolTip1.SetToolTip(this.txtSprocPrefix, "This is not implimented yet");
            // 
            // label2SprocPrefix
            // 
            this.label2SprocPrefix.AutoSize = true;
            this.label2SprocPrefix.Location = new System.Drawing.Point(404, 19);
            this.label2SprocPrefix.Name = "label2SprocPrefix";
            this.label2SprocPrefix.Size = new System.Drawing.Size(73, 13);
            this.label2SprocPrefix.TabIndex = 22;
            this.label2SprocPrefix.Text = "SPROC Prefix";
            this.toolTip1.SetToolTip(this.label2SprocPrefix, "This is not implimented yet");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1SPROCs);
            this.tabControl1.Controls.Add(this.tabPage2CSharp);
            this.tabControl1.Controls.Add(this.tabPage3VBCode);
            this.tabControl1.Controls.Add(this.tabPage1Options);
            this.tabControl1.Location = new System.Drawing.Point(184, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 556);
            this.tabControl1.TabIndex = 18;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1SPROCs
            // 
            this.tabPage1SPROCs.Controls.Add(this.chbxAddReadByUserId);
            this.tabPage1SPROCs.Controls.Add(this.txtErrorLog);
            this.tabPage1SPROCs.Controls.Add(this.txtSprocPrefix);
            this.tabPage1SPROCs.Controls.Add(this.label2SprocPrefix);
            this.tabPage1SPROCs.Controls.Add(this.chBxDropIfExists);
            this.tabPage1SPROCs.Controls.Add(this.label8);
            this.tabPage1SPROCs.Controls.Add(this.txtSuccessLog);
            this.tabPage1SPROCs.Controls.Add(this.label5);
            this.tabPage1SPROCs.Controls.Add(this.button1);
            this.tabPage1SPROCs.Location = new System.Drawing.Point(4, 22);
            this.tabPage1SPROCs.Name = "tabPage1SPROCs";
            this.tabPage1SPROCs.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1SPROCs.Size = new System.Drawing.Size(729, 530);
            this.tabPage1SPROCs.TabIndex = 0;
            this.tabPage1SPROCs.Text = "Stored Procedures";
            this.tabPage1SPROCs.UseVisualStyleBackColor = true;
            // 
            // chbxAddReadByUserId
            // 
            this.chbxAddReadByUserId.AutoSize = true;
            this.chbxAddReadByUserId.Checked = true;
            this.chbxAddReadByUserId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbxAddReadByUserId.Location = new System.Drawing.Point(208, 41);
            this.chbxAddReadByUserId.Name = "chbxAddReadByUserId";
            this.chbxAddReadByUserId.Size = new System.Drawing.Size(274, 17);
            this.chbxAddReadByUserId.TabIndex = 25;
            this.chbxAddReadByUserId.Text = "Add Read by UserId if the table has a userID column";
            this.chbxAddReadByUserId.UseVisualStyleBackColor = true;
            // 
            // txtErrorLog
            // 
            this.txtErrorLog.Location = new System.Drawing.Point(30, 311);
            this.txtErrorLog.Multiline = true;
            this.txtErrorLog.Name = "txtErrorLog";
            this.txtErrorLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorLog.Size = new System.Drawing.Size(658, 213);
            this.txtErrorLog.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Error Log:";
            // 
            // txtSuccessLog
            // 
            this.txtSuccessLog.Location = new System.Drawing.Point(30, 77);
            this.txtSuccessLog.Multiline = true;
            this.txtSuccessLog.Name = "txtSuccessLog";
            this.txtSuccessLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSuccessLog.Size = new System.Drawing.Size(658, 212);
            this.txtSuccessLog.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Success Log:";
            // 
            // tabPage2CSharp
            // 
            this.tabPage2CSharp.Controls.Add(this.txtNamespaceDL);
            this.tabPage2CSharp.Controls.Add(this.label4);
            this.tabPage2CSharp.Controls.Add(this.txtC_DAL);
            this.tabPage2CSharp.Controls.Add(this.txtNamespaceBL);
            this.tabPage2CSharp.Controls.Add(this.label3);
            this.tabPage2CSharp.Controls.Add(this.label1CodeNamespace);
            this.tabPage2CSharp.Controls.Add(this.txtC_DL);
            this.tabPage2CSharp.Controls.Add(this.label2);
            this.tabPage2CSharp.Controls.Add(this.txtC_BL);
            this.tabPage2CSharp.Controls.Add(this.lblC_Result);
            this.tabPage2CSharp.Controls.Add(this.label1);
            this.tabPage2CSharp.Controls.Add(this.button3C_GenerateBL);
            this.tabPage2CSharp.Location = new System.Drawing.Point(4, 22);
            this.tabPage2CSharp.Name = "tabPage2CSharp";
            this.tabPage2CSharp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2CSharp.Size = new System.Drawing.Size(729, 530);
            this.tabPage2CSharp.TabIndex = 1;
            this.tabPage2CSharp.Text = "C # Code";
            this.tabPage2CSharp.UseVisualStyleBackColor = true;
            // 
            // txtNamespaceDL
            // 
            this.txtNamespaceDL.Location = new System.Drawing.Point(190, 71);
            this.txtNamespaceDL.Name = "txtNamespaceDL";
            this.txtNamespaceDL.Size = new System.Drawing.Size(199, 20);
            this.txtNamespaceDL.TabIndex = 28;
            this.txtNamespaceDL.Text = "MyCompany.MyProduct.DL";
            // 
            // txtC_DAL
            // 
            this.txtC_DAL.Location = new System.Drawing.Point(32, 390);
            this.txtC_DAL.Multiline = true;
            this.txtC_DAL.Name = "txtC_DAL";
            this.txtC_DAL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtC_DAL.Size = new System.Drawing.Size(658, 122);
            this.txtC_DAL.TabIndex = 26;
            // 
            // txtNamespaceBL
            // 
            this.txtNamespaceBL.Location = new System.Drawing.Point(190, 45);
            this.txtNamespaceBL.Name = "txtNamespaceBL";
            this.txtNamespaceBL.Size = new System.Drawing.Size(199, 20);
            this.txtNamespaceBL.TabIndex = 25;
            this.txtNamespaceBL.Text = "MyCompany.MyProduct";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Data Access Layer";
            // 
            // txtC_DL
            // 
            this.txtC_DL.Location = new System.Drawing.Point(32, 240);
            this.txtC_DL.Multiline = true;
            this.txtC_DL.Name = "txtC_DL";
            this.txtC_DL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtC_DL.Size = new System.Drawing.Size(658, 122);
            this.txtC_DL.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Data Layer";
            // 
            // txtC_BL
            // 
            this.txtC_BL.Location = new System.Drawing.Point(37, 113);
            this.txtC_BL.Multiline = true;
            this.txtC_BL.Name = "txtC_BL";
            this.txtC_BL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtC_BL.Size = new System.Drawing.Size(658, 101);
            this.txtC_BL.TabIndex = 22;
            // 
            // lblC_Result
            // 
            this.lblC_Result.AutoSize = true;
            this.lblC_Result.Location = new System.Drawing.Point(34, 97);
            this.lblC_Result.Name = "lblC_Result";
            this.lblC_Result.Size = new System.Drawing.Size(78, 13);
            this.lblC_Result.TabIndex = 21;
            this.lblC_Result.Text = "Business Layer";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "C # Code Generator";
            // 
            // button3C_GenerateBL
            // 
            this.button3C_GenerateBL.Location = new System.Drawing.Point(412, 45);
            this.button3C_GenerateBL.Name = "button3C_GenerateBL";
            this.button3C_GenerateBL.Size = new System.Drawing.Size(199, 46);
            this.button3C_GenerateBL.TabIndex = 1;
            this.button3C_GenerateBL.Text = "Generate C# Code";
            this.button3C_GenerateBL.UseVisualStyleBackColor = true;
            this.button3C_GenerateBL.Click += new System.EventHandler(this.button3C_GenerateBL_Click);
            // 
            // tabPage3VBCode
            // 
            this.tabPage3VBCode.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage3VBCode.Controls.Add(this.webBrowser1VBCode);
            this.tabPage3VBCode.Location = new System.Drawing.Point(4, 22);
            this.tabPage3VBCode.Name = "tabPage3VBCode";
            this.tabPage3VBCode.Size = new System.Drawing.Size(729, 530);
            this.tabPage3VBCode.TabIndex = 2;
            this.tabPage3VBCode.Text = "VB Code";
            // 
            // webBrowser1VBCode
            // 
            this.webBrowser1VBCode.Location = new System.Drawing.Point(5, 13);
            this.webBrowser1VBCode.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1VBCode.Name = "webBrowser1VBCode";
            this.webBrowser1VBCode.Size = new System.Drawing.Size(711, 516);
            this.webBrowser1VBCode.TabIndex = 1;
            this.webBrowser1VBCode.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // tabPage1Options
            // 
            this.tabPage1Options.Controls.Add(this.checkBox1GuidIsCrudParam);
            this.tabPage1Options.Controls.Add(this.checkBox1OverWriteExisting);
            this.tabPage1Options.Location = new System.Drawing.Point(4, 22);
            this.tabPage1Options.Name = "tabPage1Options";
            this.tabPage1Options.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1Options.Size = new System.Drawing.Size(729, 530);
            this.tabPage1Options.TabIndex = 3;
            this.tabPage1Options.Text = "Options";
            this.tabPage1Options.UseVisualStyleBackColor = true;
            // 
            // checkBox1GuidIsCrudParam
            // 
            this.checkBox1GuidIsCrudParam.AutoSize = true;
            this.checkBox1GuidIsCrudParam.Location = new System.Drawing.Point(59, 94);
            this.checkBox1GuidIsCrudParam.Name = "checkBox1GuidIsCrudParam";
            this.checkBox1GuidIsCrudParam.Size = new System.Drawing.Size(253, 17);
            this.checkBox1GuidIsCrudParam.TabIndex = 1;
            this.checkBox1GuidIsCrudParam.Text = "userId Guid is a parameter for all crud operations";
            this.toolTip1.SetToolTip(this.checkBox1GuidIsCrudParam, "this is for to be used when you plan on filtering data from your stored procedure" +
                    "s based on the userId requesting the data");
            this.checkBox1GuidIsCrudParam.UseVisualStyleBackColor = true;
            // 
            // checkBox1OverWriteExisting
            // 
            this.checkBox1OverWriteExisting.AutoSize = true;
            this.checkBox1OverWriteExisting.Checked = true;
            this.checkBox1OverWriteExisting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1OverWriteExisting.Location = new System.Drawing.Point(59, 70);
            this.checkBox1OverWriteExisting.Name = "checkBox1OverWriteExisting";
            this.checkBox1OverWriteExisting.Size = new System.Drawing.Size(234, 17);
            this.checkBox1OverWriteExisting.TabIndex = 0;
            this.checkBox1OverWriteExisting.Text = "When outputting files, overwrite existing files";
            this.checkBox1OverWriteExisting.UseVisualStyleBackColor = true;
            // 
            // label1AppTitle
            // 
            this.label1AppTitle.AutoSize = true;
            this.label1AppTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1AppTitle.Location = new System.Drawing.Point(15, 40);
            this.label1AppTitle.Name = "label1AppTitle";
            this.label1AppTitle.Size = new System.Drawing.Size(165, 24);
            this.label1AppTitle.TabIndex = 19;
            this.label1AppTitle.Text = "CRUD Generator";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.loadSessionToolStripMenuItem,
            this.saveSessionAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // loadSessionToolStripMenuItem
            // 
            this.loadSessionToolStripMenuItem.Name = "loadSessionToolStripMenuItem";
            this.loadSessionToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.loadSessionToolStripMenuItem.Text = "Load Session";
            this.loadSessionToolStripMenuItem.Click += new System.EventHandler(this.loadSessionToolStripMenuItem_Click);
            // 
            // saveSessionAsToolStripMenuItem
            // 
            this.saveSessionAsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1SessionName});
            this.saveSessionAsToolStripMenuItem.Name = "saveSessionAsToolStripMenuItem";
            this.saveSessionAsToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.saveSessionAsToolStripMenuItem.Text = "Save Session As";
            // 
            // toolStripTextBox1SessionName
            // 
            this.toolStripTextBox1SessionName.Name = "toolStripTextBox1SessionName";
            this.toolStripTextBox1SessionName.Size = new System.Drawing.Size(100, 21);
            this.toolStripTextBox1SessionName.Text = "CurrentSession";
            this.toolStripTextBox1SessionName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolStripTextBox1SessionName_KeyDown);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSettingsToolStripMenuItem,
            this.hideOptionsTabToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.settingsToolStripMenuItem.Text = "Tools";
            // 
            // showSettingsToolStripMenuItem
            // 
            this.showSettingsToolStripMenuItem.Name = "showSettingsToolStripMenuItem";
            this.showSettingsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.showSettingsToolStripMenuItem.Text = "Show Options Tab";
            this.showSettingsToolStripMenuItem.Click += new System.EventHandler(this.showSettingsToolStripMenuItem_Click);
            // 
            // hideOptionsTabToolStripMenuItem
            // 
            this.hideOptionsTabToolStripMenuItem.Name = "hideOptionsTabToolStripMenuItem";
            this.hideOptionsTabToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.hideOptionsTabToolStripMenuItem.Text = "Hide Options Tab";
            this.hideOptionsTabToolStripMenuItem.Visible = false;
            this.hideOptionsTabToolStripMenuItem.Click += new System.EventHandler(this.hideOptionsTabToolStripMenuItem_Click);
            // 
            // txtOutputDirectory
            // 
            this.txtOutputDirectory.Location = new System.Drawing.Point(282, 639);
            this.txtOutputDirectory.Name = "txtOutputDirectory";
            this.txtOutputDirectory.Size = new System.Drawing.Size(548, 20);
            this.txtOutputDirectory.TabIndex = 4;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // button2SelectFolder
            // 
            this.button2SelectFolder.Location = new System.Drawing.Point(836, 636);
            this.button2SelectFolder.Name = "button2SelectFolder";
            this.button2SelectFolder.Size = new System.Drawing.Size(75, 23);
            this.button2SelectFolder.TabIndex = 21;
            this.button2SelectFolder.Text = "Select";
            this.button2SelectFolder.UseVisualStyleBackColor = true;
            this.button2SelectFolder.Click += new System.EventHandler(this.button2SelectFolder_Click);
            // 
            // chkSendOutputToFiles
            // 
            this.chkSendOutputToFiles.AutoSize = true;
            this.chkSendOutputToFiles.Checked = true;
            this.chkSendOutputToFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendOutputToFiles.Location = new System.Drawing.Point(58, 641);
            this.chkSendOutputToFiles.Name = "chkSendOutputToFiles";
            this.chkSendOutputToFiles.Size = new System.Drawing.Size(122, 17);
            this.chkSendOutputToFiles.TabIndex = 26;
            this.chkSendOutputToFiles.Text = "Send Output to Files";
            this.chkSendOutputToFiles.UseVisualStyleBackColor = true;
            this.chkSendOutputToFiles.CheckedChanged += new System.EventHandler(this.chkSendOutputToFiles_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 671);
            this.Controls.Add(this.chkSendOutputToFiles);
            this.Controls.Add(this.button2SelectFolder);
            this.Controls.Add(this.txtOutputDirectory);
            this.Controls.Add(this.label1OutputDir);
            this.Controls.Add(this.label1AppTitle);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1Authentication);
            this.Controls.Add(this.checkBox1TrustedConnection);
            this.Controls.Add(this.label6IsActiveField);
            this.Controls.Add(this.chkDeactivate);
            this.Controls.Add(this.chkDelete);
            this.Controls.Add(this.chkReadAll);
            this.Controls.Add(this.chkReadById);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.chkCreate);
            this.Controls.Add(this.txtIsActive);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label4AuthorName);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label3TableLike);
            this.Controls.Add(this.label2DBName);
            this.Controls.Add(this.label1ServerName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "CRUD Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1Authentication.ResumeLayout(false);
            this.groupBox1Authentication.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1SPROCs.ResumeLayout(false);
            this.tabPage1SPROCs.PerformLayout();
            this.tabPage2CSharp.ResumeLayout(false);
            this.tabPage2CSharp.PerformLayout();
            this.tabPage3VBCode.ResumeLayout(false);
            this.tabPage1Options.ResumeLayout(false);
            this.tabPage1Options.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1ServerName;
        private System.Windows.Forms.Label label2DBName;
        private System.Windows.Forms.Label label3TableLike;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4AuthorName;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.CheckBox chkCreate;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkReadById;
        private System.Windows.Forms.CheckBox chkReadAll;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkDeactivate;
        private System.Windows.Forms.Label label6IsActiveField;
        private System.Windows.Forms.TextBox txtIsActive;
        private System.Windows.Forms.CheckBox checkBox1TrustedConnection;
        private System.Windows.Forms.GroupBox groupBox1Authentication;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chBxDropIfExists;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1SPROCs;
        private System.Windows.Forms.TextBox txtSuccessLog;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPage2CSharp;
        private System.Windows.Forms.TextBox txtErrorLog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3VBCode;
        private System.Windows.Forms.WebBrowser webBrowser1VBCode;
        private System.Windows.Forms.Label label1AppTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSessionAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1SessionName;
        private System.Windows.Forms.ToolStripMenuItem loadSessionToolStripMenuItem;
        private System.Windows.Forms.TextBox txtOutputDirectory;
        private System.Windows.Forms.Label label1OutputDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button2SelectFolder;
        private System.Windows.Forms.TextBox txtNamespaceBL;
        private System.Windows.Forms.TextBox txtSprocPrefix;
        private System.Windows.Forms.Label label1CodeNamespace;
        private System.Windows.Forms.Label label2SprocPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3C_GenerateBL;
        private System.Windows.Forms.CheckBox chkSendOutputToFiles;
        private System.Windows.Forms.TextBox txtC_BL;
        private System.Windows.Forms.Label lblC_Result;
        private System.Windows.Forms.TextBox txtC_DL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtC_DAL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage1Options;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideOptionsTabToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1OverWriteExisting;
        private System.Windows.Forms.CheckBox checkBox1GuidIsCrudParam;
        private System.Windows.Forms.CheckBox chbxAddReadByUserId;
        private System.Windows.Forms.TextBox txtNamespaceDL;
        private System.Windows.Forms.Label label4;
    }
}

