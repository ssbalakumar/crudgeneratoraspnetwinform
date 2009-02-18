using System;
using System.Collections.Generic;
using System.Text;

namespace CrudGenerator.Util
{
    class Utility
    {
        private static string _connStr="";

        public static string ConnectionString {

            get{return _connStr;}
            set { _connStr = value; }
        }
    }
}
