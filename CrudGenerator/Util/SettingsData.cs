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
        public bool ResultsToFile;
        public string ConnectionString;
        /// <summary>
        /// more than one profile can be saved, the key is the settings name.
        /// </summary>
        private static Dictionary<string, SettingsData> SettingDataDict;

        public SettingsData() { }

        public SettingsData(string settingName, string codeNamespace,
            string sprocPrefix,string authorName,string serverName,
            string dbName, bool trustedConnection, string dbUsername,
            string dbPassword,string outputDirectory, string tableNameFilter,
            bool sprocDropIfExists, bool sprocCreate, bool sprocRetrieveByID,
            bool sprocRetrieveAll,bool sprocUpdate, bool sprocDelete, 
            bool sprocDeActivate,string deactivateColumnName,
            bool resultsToFile){

            //todo: initialize settingsData using input parameters.
             SettingName = settingName;
             CodeNamespace = codeNamespace;
                SprocPrefix = sprocPrefix;
                AuthorName = authorName;
                ServerName = serverName;
                DbName = dbName;
             TrustedConnection=trustedConnection  ;
             DbUsername = dbUsername;
             DbPassword = dbPassword;
             OutputDirectory = outputDirectory;
             TableNameFilter = tableNameFilter;
             SprocDropIfExists = sprocDropIfExists;
             SprocCreate = sprocCreate;
             SprocRetrieveByID= sprocRetrieveByID ;
             SprocRetrieveAll= sprocRetrieveAll ;
             SprocUpdate=sprocUpdate ;
             SprocDelete= sprocDelete ;
             SprocDeActivate= sprocDeActivate ;
             DeactivateColumnName=deactivateColumnName;
             ResultsToFile=resultsToFile;

             if (!trustedConnection && !string.IsNullOrEmpty(serverName) && !string.IsNullOrEmpty(dbName) && !string.IsNullOrEmpty(dbUsername) && !string.IsNullOrEmpty(dbPassword))
                 ConnectionString = "Server=" + serverName + ";Database=" + dbName + ";uid=" + dbUsername + ";pwd=" + dbPassword + ";";
             else if(!string.IsNullOrEmpty(serverName) && !string.IsNullOrEmpty(dbName) )
                 ConnectionString = "Server=" + serverName + ";Database=" + dbName + ";Trusted_Connection=True;";


        

        
        }

        public void SetSettings(SettingsData s) {

            

            
        }

        public static void SaveSettings(List<SettingsData> data){
            //todo the save settings should store a list of <userSettings>
                //and each settings should be loaded by name
            UserSettings.StoreObject(SettingsFileName, data);
        }


        public SettingsData LoadSetting() {
            return LoadSettings("CurrentSession");
        }
        public  SettingsData LoadSettings(string settingName) { 

            SettingsData settings = null;
                object settingsObj = UserSettings.RestoreObject(SettingsFileName);
                if (settingsObj is SettingsData)
                    settings = (SettingsData)settingsObj;
                else if (settingsObj is Dictionary<string, SettingsData>)
                {
                    SettingDataDict = (Dictionary<string, SettingsData>)settingsObj;
                    settings = SettingDataDict[settingName];
                }
            
    
            
            // if nothing loaded, initialise with default settings  
            if (settings==null) 
                settings = new SettingsData(); 
         
            return settings; 

            
        } 



        
        
    }
}

