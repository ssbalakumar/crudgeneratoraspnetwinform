using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices; // DllImport
using System.Security.Principal; // WindowsImpersonationContext
using System.Security.Permissions; // PermissionSetAttribute

namespace CrudGenerator {
    public partial class Form1 : Form {
        #region Member Variables
        string ConnectionString;
        StringBuilder ErrorLog, SuccessLog;
        bool VBCodeWebSiteLoaded ;
        #endregion

        #region Form Load / Constructor
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            string name = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(".", " ");
            name = name.Substring(name.IndexOf('\\') + 1);
            this.txtAuthor.Text = ToTitleCase(name);
        }
        #endregion

        #region helper method - to-title-case
        /// <summary>
        /// Applies title case format to the input string
        /// </summary>
        /// <param name="strIn">Input string tobe formatted</param>
        /// <returns>Title case formatted string</returns>
        public string ToTitleCase(string strIn) {
            //check if is null
            if (strIn == null)
                return string.Empty;

            //split the input string using space char as delimiter
            string[] words = strIn.Split(' ');
            string retValue = string.Empty;

            //apply upper case format to each string and append it to the output string
            foreach (string word in words) {
                retValue += String.Format("{0}{1} ", word[0].ToString().ToUpper(), word.Substring(1));
            }

            //return the formatted string
            return retValue;
        }
        #endregion

        #region Methods that call to the dac. also append to logs
        private string Execute(string sql, string name) {
            try {
                using (CrudDAC dac = new CrudDAC(ConnectionString)) {
                    dac.Execute(sql);
                }
            } catch {
                ErrorLog.Append("----------------ERROR! Following procedure did not generate--\r\n");
                ErrorLog.Append(sql);
                return name + ", ";
            }
            SuccessLog.Append("--Following Procedure was created.");
            SuccessLog.Append(sql);
            return "";
        }
        private DataTable GetColumns() {
            using (CrudDAC dac = new CrudDAC(ConnectionString)) {
                return dac.GetColumns(this.txtTableName.Text);
            }
        }
        #endregion

        #region Make Stored Procedures BUTTON
        private void button1_Click(object sender, EventArgs e) {
            string server = this.txtServer.Text, database = this.txtDatabase.Text, userName = this.txtUser.Text, passWord = this.txtPassword.Text;
            bool dropIfExists = this.chBxDropIfExists.Checked;
            if (server.Length > 0 && database.Length > 0) {
                if (!checkBox1TrustedConnection.Checked)
                    ConnectionString = "Server=" + server + ";Database=" + database + ";uid=" + txtUser.Text + ";pwd=" + txtPassword.Text + ";";
                else
                    ConnectionString = "Server=" + server + ";Database=" + database + ";Trusted_Connection=True;";

                DataTable dt = GetColumns();
                List<Table> tables = Table.ParseDataTable(dt);
                string errors = "";
                SuccessLog = new StringBuilder();
                ErrorLog = new StringBuilder();

                foreach (Table table in tables) {
                    table.Author = this.txtAuthor.Text;
                    table.IsActive = this.txtIsActive.Text;

                    string errorLine = "";
                    
                    if (this.chkCreate.Checked)
                        errorLine = errorLine + Execute(table.GenerateCreate(dropIfExists), "Create");
                    if (this.chkDelete.Checked)
                        errorLine = errorLine + Execute(table.GenerateDelete(dropIfExists), "Delete");
                    if (this.chkUpdate.Checked)
                        errorLine = errorLine + Execute(table.GenerateUpdate(dropIfExists), "Update");
                    if (this.chkReadAll.Checked)
                        errorLine = errorLine + Execute(table.GenerateSelectAll(dropIfExists), "ReadAll");
                    if (this.chkReadById.Checked)
                        errorLine = errorLine + Execute(table.GenerateSelectById(dropIfExists), "ReadById");
                    if (this.chkDeactivate.Checked)
                        errorLine = errorLine + Execute(table.GenerateDeactiveate(dropIfExists), "Deactivate");

                    if (errorLine.Length > 0) {
                        if (errors.Length > 0)
                            errors = errors + Environment.NewLine;
                        errors = errors + table.TableName + "-" + errorLine.Remove(errorLine.Length-2);//remove ", "
                    }
                }
                if (errors.Length > 0)
                    MessageBox.Show("The following procedures were not able to be generated:" + Environment.NewLine + errors);
                else {
                    MessageBox.Show("SUCCESS");
                }
                this.txtSuccessLog.Text = SuccessLog.ToString();
                this.txtErrorLog.Text = ErrorLog.ToString();
                ErrorLog = null;
                SuccessLog = null;
            } else {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Must enter both server and database;");
            }
        }
        #endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1TrustedConnection.Checked == true)
                groupBox1Authentication.Visible = false;
            else
                groupBox1Authentication.Visible = true;

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage3VBCode" && !VBCodeWebSiteLoaded)
            {
                webBrowser1VBCode.Url = new Uri("http://code.google.com/p/crudgeneratoraspnetwinform/wiki/VBCodeGenerator");
                VBCodeWebSiteLoaded = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?  Budy old pal?","Quit?", MessageBoxButtons.YesNo) == DialogResult.Yes )
                Application.Exit();
        }

   

        private void button2SelectFolder_Click(object sender, EventArgs e)
        {
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK )
            {
                txtOutputDirectory.Text = folderBrowserDialog1.SelectedPath;

            }
            
        }

        

        private void toolStripTextBox1SessionName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveSession(toolStripTextBox1SessionName.Text);
                fileToolStripMenuItem.DropDown.Close();
            }

        }

        private  void SaveSession(string sessionName) {

            if (string.IsNullOrEmpty(sessionName))
            {
                MessageBox.Show("The save as name should not be blank");
                return;
            }
            Util.SettingsData s = new CrudGenerator.Util.SettingsData(
                sessionName,  txtNamespace.Text, txtSprocPrefix.Text,
                txtAuthor.Text,txtServer.Text,txtDatabase.Text,
                checkBox1TrustedConnection.Checked, 
                txtUser.Text, txtPassword.Text, txtOutputDirectory.Text,
                txtTableName.Text, chBxDropIfExists.Checked, 
                chkCreate.Checked, chkReadById.Checked, chkReadAll.Checked,
                chkUpdate.Checked, chkDelete.Checked, chkDeactivate.Checked,
                txtIsActive.Text);
            
            s.SaveSettings();
            
        }

        private void loadSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Util.SettingsData s = (new Util.SettingsData()).LoadSettings();
            

            txtDatabase.Text = s.DbName;
            txtServer.Text = s.ServerName;
            txtOutputDirectory.Text = s.OutputDirectory;
            chBxDropIfExists.Checked = s.TrustedConnection;
            txtTableName.Text=s.TableNameFilter ;
            txtUser.Text = s.DbUsername;
            txtPassword.Text = s.DbPassword;
            txtAuthor.Text = s.AuthorName;

        }

     

  
    }
}