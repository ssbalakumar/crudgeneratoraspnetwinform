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
using u = CrudGenerator.Util.Utility;

namespace CrudGenerator {
    public partial class Form1 : Form {
        #region Member Variables
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

            if (Util.Utility.UserSettings.ResultsToFile){
                SuccessLog.Append(sql);
                return "";
            }

            try {
                using (CrudDAC dac = new CrudDAC(u.ConnectionString)) {
                    dac.Execute(sql);
                }
            } catch {
                ErrorLog.Append("----------------ERROR! Following procedure did not generate--\r\n");
                ErrorLog.Append(sql);
                return name + ", ";
            }
            SuccessLog.Append("--Following Procedure was created:");
            SuccessLog.Append(sql);
            return "";
        }
        private DataTable GetColumns() {
            DataTable tbl = new DataTable();
            try{
                using (CrudDAC dac = new CrudDAC(u.ConnectionString))
                {
                    tbl = dac.GetColumns(this.txtTableName.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tbl;
        }
        #endregion

        #region Make Stored Procedures BUTTON
        private void button1_Click(object sender, EventArgs e) {
            try { CheckIfAllRequiredFilledAreEntered(); }
            catch(Exception ex) {MessageBox.Show(ex.Message);return;}

            if (string.IsNullOrEmpty(u.ConnectionString))
            {
                MessageBox.Show("The connectionstring is empty");
                return;
            }
            string server = this.txtServer.Text, database = this.txtDatabase.Text, userName = this.txtUser.Text, passWord = this.txtPassword.Text;
            bool dropIfExists = u.UserSettings.SprocDropIfExists ;
            DataTable dt = GetColumns();
            List<CrudGenSPROC> sprocs = CrudGenSPROC.ParseDataTable(dt);
            string errors = "";
            SuccessLog = new StringBuilder();
            ErrorLog = new StringBuilder();

            foreach (CrudGenSPROC sp in sprocs) {
                sp.Author = this.txtAuthor.Text;
                sp.IsActive = this.txtIsActive.Text;

                string errorLine = "";
                
                if (u.UserSettings.SprocCreate)
                    errorLine = errorLine + Execute(sp.GenerateCreate(dropIfExists), "Create");
                if (u.UserSettings.SprocDelete)
                    errorLine = errorLine + Execute(sp.GenerateDelete(dropIfExists), "Delete");
                if (u.UserSettings.SprocUpdate)
                    errorLine = errorLine + Execute(sp.GenerateUpdate(dropIfExists), "Update");
                if (u.UserSettings.SprocRetrieveAll)
                    errorLine = errorLine + Execute(sp.GenerateSelectAll(dropIfExists), "ReadAll");
                if (u.UserSettings.SprocRetrieveByID)
                    errorLine = errorLine + Execute(sp.GenerateSelectById(dropIfExists), "ReadById");
                if (this.chkDeactivate.Checked)
                    errorLine = errorLine + Execute(sp.GenerateDeactiveate(dropIfExists), "Deactivate");

                if (errorLine.Length > 0) {
                    if (errors.Length > 0)
                        errors = errors + Environment.NewLine;
                    errors = errors + sp.TableName + "-" + errorLine.Remove(errorLine.Length-2);//remove ", "
                }
            }
           
            if (u.UserSettings.ResultsToFile) {
                this.txtSuccessLog.Text = "Files created in " + u.UserSettings.OutputDirectory + Environment.NewLine ;
                this.txtSuccessLog.Text += "  -  See file name: " + "InstallCRUD_SPROCs.sql" + Environment.NewLine;
                FileSaver fs = new FileSaver();
                fs.SaveFile(u.UserSettings.OutputDirectory + "InstallCRUD_SPROCs.sql", SuccessLog.ToString(), u.UserSettings.ResultFileOverwrite );
            }
            else
            {
                this.txtSuccessLog.Text = SuccessLog.ToString();
                this.txtErrorLog.Text = ErrorLog.ToString();
            }
            if (errors.Length > 0)
                MessageBox.Show("The following procedures were not able to be generated:" + Environment.NewLine + errors);
            else
            {
                MessageBox.Show("SUCCESS");
            }
            ErrorLog = null;
            SuccessLog = null;

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

        /// <summary>
        /// updates the value of the sesssion data in the UTILITY class so the settings can be used in other CRUD generators without having to maintain a pointer to this form.
        /// </summary>
        private void UpdateSessionInUtil() {
            Util.Utility.UserSettings = GetSettingsData("workingSession");
        
        }

        /// <summary>
        /// save the current session as the name passed in the querystring
        /// </summary>
        /// <param name="sessionName"></param>
        private  void SaveSession(string sessionName) {

            if (string.IsNullOrEmpty(sessionName))
            {
                MessageBox.Show("The save as name should not be blank");
                return;
            }
            UpdateSessionInUtil();
            u.UserSettings.SettingName = sessionName  ;
            Util.SettingsData.SaveSettings(u.UserSettings);
            
        }

        private Util.SettingsData GetSettingsData(string sessionName) {
            Util.SettingsData s = new CrudGenerator.Util.SettingsData(
                sessionName, txtNamespace.Text, txtSprocPrefix.Text,
                txtAuthor.Text, txtServer.Text, txtDatabase.Text,
                checkBox1TrustedConnection.Checked,
                txtUser.Text, txtPassword.Text, txtOutputDirectory.Text,
                txtTableName.Text, chBxDropIfExists.Checked,
                chkCreate.Checked, chkReadById.Checked, chkReadAll.Checked,
                chkUpdate.Checked, chkDelete.Checked, chkDeactivate.Checked,
                txtIsActive.Text, chkSendOutputToFiles.Checked, checkBox1OverWriteExisting.Checked,
                checkBox1GuidIsCrudParam.Checked);
            return s;
        }

        private void loadSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Util.SettingsData s = (new Util.SettingsData()).LoadSettings();
            Util.SettingsData s = u.UserSettings = (new Util.SettingsData()).LoadSettings();
            txtDatabase.Text = s.DbName;
            txtServer.Text = s.ServerName;
            checkBox1TrustedConnection.Checked = s.TrustedConnection;
            txtOutputDirectory.Text = s.OutputDirectory;
            chBxDropIfExists.Checked = s.TrustedConnection;
            txtTableName.Text = s.TableNameFilter;
            txtUser.Text = s.DbUsername;
            txtPassword.Text = s.DbPassword;
            txtAuthor.Text = s.AuthorName;
            txtNamespace.Text = s.CodeNamespace;
        }
        #region C# crud
        private void button3C_GenerateBL_Click(object sender, EventArgs e)
        {
            try { 
                CheckIfAllRequiredFilledAreEntered();
                if (txtNamespace.Text=="") throw new Exception("The namespace is required for c# classes.");
            } catch (Exception ex) { MessageBox.Show(ex.Message); return; }
            List<CrudGenCSharp> cSharpFiles = new List<CrudGenCSharp>();
            DataTable dt = GetColumns();
            List<CrudGenSPROC> tables = CrudGenSPROC.ParseDataTable(dt);
            foreach (CrudGenSPROC tbl in tables) {
              cSharpFiles.Add( new CrudGenCSharp(u.UserSettings.CodeNamespace, tbl.TableName , tbl.Columns ));    
            }

            GenerateFiles(cSharpFiles);
        }

        //throws an exception if any required field is left empty
        public string CheckIfAllRequiredFilledAreEntered(){
            string errMsg="";
            UpdateSessionInUtil();

            if (string.IsNullOrEmpty(u.ConnectionString))
                errMsg+=string.Format("The connectionstring is empty{0}", Environment.NewLine);
            if (u.UserSettings.ResultsToFile && string.IsNullOrEmpty(u.UserSettings.OutputDirectory))
                errMsg += string.Format("When the results to file is checked, the output directory must not be empty.{0}", Environment.NewLine);
            if(u.UserSettings.TrustedConnection == false && (u.UserSettings.DbUsername=="" || u.UserSettings.DbPassword==""))
                errMsg += string.Format("When the connection is not trusted, the username and password are required{0}", Environment.NewLine);
            //errMsg += string.Format("{0}", Environment.NewLine);

            if (errMsg != "") throw new Exception(errMsg);
            return errMsg;

        }

        private void GenerateFiles(List<CrudGenCSharp> cSharpFiles) {
            //output the files
            FileSaver fs = new FileSaver();
            foreach (CrudGenCSharp cs in cSharpFiles)
            {
                //todo output BL and DL 
                if (u.UserSettings.ResultsToFile)
                {
                    fs.SaveFile(u.UserSettings.OutputDirectory + cs.ClassName + ".cs", cs.CrudObject, u.UserSettings.ResultFileOverwrite);
                    fs.SaveFile(u.UserSettings.OutputDirectory + cs.ClassName + "Data.cs", cs.CrudData, u.UserSettings.ResultFileOverwrite);
                }
                else
                {
                    txtC_BL.Text += cs.CrudObject;
                    txtC_DL.Text += cs.CrudData;
                }
                
            }
            txtC_DAL.Text += "Under construction";
        
        }

        private void PushTextOfCSharpCodeToTextBox(List<CrudGenCSharp> cruds) {

            foreach (CrudGenCSharp crud in cruds) {
                txtC_BL.Text += crud.CrudObject.ToString() + "\n";
                txtC_BL.Text += crud.CrudData.ToString() + "\n";
            }
        }

        #endregion //C# crud

        private void btnGenerateDataLayer_Click(object sender, EventArgs e)
        {
            UpdateSessionInUtil();
            MessageBox.Show("Under construction.");
        }

        private void showSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage1Options.Hide();
            showSettingsToolStripMenuItem.Visible = false;
            hideOptionsTabToolStripMenuItem.Visible = true;
        }

        private void hideOptionsTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabPage1Options.Show();
            showSettingsToolStripMenuItem.Visible = true;
            hideOptionsTabToolStripMenuItem.Visible = false;
        }
    }
}