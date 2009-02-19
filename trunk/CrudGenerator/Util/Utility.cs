using System;
using System.Collections.Generic;
using System.Text;

namespace CrudGenerator.Util
{
    class Utility
    {
        private static string _connStr="";
        public static SettingsData UserSettings;

        
        public static string ConnectionString {
            get{
                if (UserSettings != null)
                    return UserSettings.ConnectionString;
                else return _connStr;
            }
            set {
                if (UserSettings != null)
                    UserSettings.ConnectionString = value;
                _connStr = value; 
            }
        }

        
       
        
    }
}
