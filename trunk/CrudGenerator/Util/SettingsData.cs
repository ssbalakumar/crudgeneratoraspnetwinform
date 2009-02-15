using System;
using System.Collections.Generic;
using System.Text;

namespace CrudGenerator.Util
{
    [Serializable] 
    class SettingsData
    {
        private const string SettingsFileName = "CRUDGeneratorSettings"; 
        /// <summary>The name of the session to be saved
        /// </summary>
        public string SettingName;
        public string CodeNamespace;
        public string SprocPrefix;
        public string AuthorName;
        public string ServerName;
        public string DbName;
        public bool TrustedConnection;
        public string DbUsername;
        public string DbPassword;
        public string OutputDirectory;
        public string TableNameFilter;
        public bool SprocDropIfExists;
        public bool SprocCreate;
        public bool SprocRetrieveByID;
        public bool SprocRetrieveAll;
        public bool SprocUpdate;
        public bool SprocDelete;
        public bool SprocDeActivate;
        public string DeactivateColumnName;

        public SettingsData() { }

        public SettingsData(string settingName, string codeNamespace,
            string sprocPrefix,string authorName,string serverName,
            string dbName, bool trustedConnection, string dbUsername,
            string dbPassword,string outputDirectory, string tableNameFilter,
            bool sprocDropIfExists, bool sprocCreate, bool sprocRetrieveByID,
            bool sprocRetrieveAll,bool sprocUpdate, bool sprocDelete, 
            bool sprocDeActivate,string deactivateColumnName){

            //todo: initialize settingsData using input parameters.


        

        
        }

        public void SetSettings(SettingsData s) {

            

            
        }

        public void SaveSettings(){
            //todo the save settings should store a list of <userSettings>
                //and each settings should be loaded by name
            UserSettings.StoreObject(SettingsFileName, this);
        }

                
        public  SettingsData LoadSettings() { 

            
            SettingsData settings = 
                (SettingsData)UserSettings.RestoreObject(SettingsFileName); 
            // if nothing loaded, initialise with default settings  
            if (settings==null) 
                settings = new SettingsData(); 
         
            return settings; 

            
        } 



        
        
    }
}

