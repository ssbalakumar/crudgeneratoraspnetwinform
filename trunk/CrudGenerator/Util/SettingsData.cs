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
        private string _outputDirectory;

        public string OutputDirectory
        {
            get { return _outputDirectory; }
            set { _outputDirectory = value; 
                //make sure output directory saved ends with a slash
            if (_outputDirectory.Length >0 &&  _outputDirectory.Substring(_outputDirectory.Length - 1) != "\\")
                _outputDirectory += "\\";
            }
        }
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
        public bool ResultFileOverwrite;
        public string ConnectionString;

    /// <summary>
    /// 
    /// </summary>
        public bool UserIdIsParamForCRUBusinessLayer;
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
            bool resultsToFile, bool resultFileOverwrite, bool userIdIsParamForCRUBusinessLayer)
        {

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
             ResultFileOverwrite=resultFileOverwrite;
             UserIdIsParamForCRUBusinessLayer = userIdIsParamForCRUBusinessLayer;

             if (!trustedConnection && !string.IsNullOrEmpty(serverName) && !string.IsNullOrEmpty(dbName) && !string.IsNullOrEmpty(dbUsername) && !string.IsNullOrEmpty(dbPassword))
                 ConnectionString = "Server=" + serverName + ";Database=" + dbName + ";uid=" + dbUsername + ";pwd=" + dbPassword + ";";
             else if(!string.IsNullOrEmpty(serverName) && !string.IsNullOrEmpty(dbName) )
                 ConnectionString = "Server=" + serverName + ";Database=" + dbName + ";Trusted_Connection=True;";


        

        
        }

        public static void SaveSettings(Dictionary<string,SettingsData> data){
            //todo the save settings should store a list of <userSettings>
                //and each settings should be loaded by name
            UserSettings.StoreObject(SettingsFileName, data);
        }

        /// <summary>Saves the settings after getting them from the saved location and replacing the current key with the updated version from the current session
        /// </summary>
        public static void SaveSettings(SettingsData sd){
            object SavedSettings = UserSettings.RestoreObject(SettingsFileName);
            if (SavedSettings is SettingsData){ //in case what's saved is 
                SettingsData settings = (SettingsData)SavedSettings;
                SettingDataDict[settings.SettingName] = settings;
            }
            else if (SavedSettings is Dictionary<string, SettingsData>){
                SettingDataDict = (Dictionary<string, SettingsData>)SavedSettings;
            }

            if (SettingDataDict == null) SettingDataDict = new Dictionary<string, SettingsData>();
            SettingDataDict[sd.SettingName] = sd;
            SaveSettings(SettingDataDict);
        }


        /// <summary>loads the CurrentSession</summary>
        public SettingsData LoadSettings() {
            return LoadSettings("CurrentSession");
        }
        public  SettingsData LoadSettings(string settingName) { 

            SettingsData settings = null;
                object settingsObj = UserSettings.RestoreObject(SettingsFileName);
                if (settingsObj is SettingsData)
                    settings = (SettingsData)settingsObj;
                else if (settingsObj is Dictionary<string, SettingsData>){
                    SettingDataDict = (Dictionary<string, SettingsData>)settingsObj;
                    try{
                        if (SettingDataDict.ContainsKey(settingName))
                            settings = SettingDataDict[settingName];
                        else //if the dictionary has only 1 key, get the first saved key. 
                        {
                            if (SettingDataDict.Values.Count== 1){
                                foreach (string keyName in SettingDataDict.Keys ) {
                                    settingName = keyName; //the setting name passed in was not found, so loading the only session which exists
                                    //todo optimize getting session by name.
                                    settings = SettingDataDict[settingName];
                                }
                            }
                            
                        }
                        
                    } 
                    catch(KeyNotFoundException ex){
                        
                    }
                }
            // if nothing loaded, initialise with default settings  
            if (settings==null) 
                settings = new SettingsData(); 
         
            return settings; 

            
        } 



        
        
    }
}

