using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace CrudGenerator
{
    /// <summary>
    /// What this class needs to do is look through a list of columns and 
    /// </summary>
    class CrudGenCSharp
    {

        StringBuilder crudObject;
        StringBuilder crudData;
        string _namespace;
        string _className;
        public string ClassName{get { return _className; }}

        List<Column> _cols;
        public string CrudObject { get { return crudObject.ToString(); } }
        public string CrudData { get { return crudData.ToString(); } }

        public CrudGenCSharp() { }
        public CrudGenCSharp(string nameSpace, string className, List<Column> cols)
        {
            _namespace=nameSpace;
            _className = className.Substring(0, 1).ToUpper() + className.Substring(1);
            _cols = cols;
            
            BuildCrudObject();
            BuildCrudData();
            
           
        
        }

      
        public void BuildCrudObject(){
            crudObject = new StringBuilder();
            crudObject.AppendFormat("{1}//******************** {0} ****************************//{1}", _className, Environment.NewLine );
            crudObject.AppendFormat("\r\n namespace {0} {{\r\n", _namespace);
            crudObject.AppendFormat("public class {0}{{\r\n", _className );
            crudObject.Append(BuildFields(_cols));
            crudObject.Append(BuildProps(_cols) );
            crudObject.Append(BuildConstructor(_cols, _className));
            crudObject.Append(BuildCRUD(_cols));
            crudObject.AppendFormat("}} //{0}\r\n", _className);
            crudObject.AppendFormat("\r\n}} //{0}", _namespace);
        }

        private void BuildCrudData()
        {
            crudData = new StringBuilder();
            crudData.AppendFormat("namespace {0} {{\r\n", _namespace);
            crudData.AppendFormat("public class {0}Data{{\r\n", _className);
            crudData.Append("\\\\TODO under construction\r\n");
            crudData.AppendFormat("}} //{0}\r\n", _className);
            crudData.AppendFormat("\r\n}} //{0}\r\n", _namespace);
        }


        private string BuildFields(List<Column> cols) {
            System.ComponentModel.TypeConverter tc = new System.ComponentModel.TypeConverter();

            string result="#region Fields\r\n";
            foreach (Column c in cols) {
                //private int _field;
                result += string.Format( "\t private {0} {1};\r\n", 
                    GetASPNetDataType (c),GetFieldName(c));
            }
            result += "#endregion //Fields\r\n";

            return result;
        }

        private string BuildProps(List<Column> cols)
        {
            System.ComponentModel.TypeConverter tc = new System.ComponentModel.TypeConverter();

            string result = "#region Props\r\n";

            foreach (Column c in cols)
            {
                //public int Property {get{return _field;} set{_field=value;}}
                result += string.Format("\tpublic {0} {2} {{get{{return {1};}} set{{{1}=value;}}}}\r\n",
                    GetASPNetDataType(c), GetFieldName(c), GetPropName(c));
            }
            result += "#endregion //Props\r\n";

            return result;
        }

        private string BuildConstructor(List<Column> cols, string className)
        {
            System.ComponentModel.TypeConverter tc = new System.ComponentModel.TypeConverter();

            string result = "#region CTOR\r\n";
            string CTORdflt=string.Format("\tpublic {0}(){{\r\n", className);
            string CTOR = string.Format("\tpublic {0} ({1}){{\r\n", className, GetFieldsAsInputParams(cols));
            foreach (Column c in cols)
            {
                
                //_field=value;
                CTORdflt += string.Format("\t\tpublic {0} {2} {{get{{return {1};}} set{{{1}=value}}}};\r\n",
                    GetASPNetDataType(c), GetFieldName(c), GetPropName(c));

                //_field=inputParam;
                CTOR += string.Format ("\t\t{0}={1};\r\n",
                    GetFieldName(c), GetInputParamName(c));

            }
            

            CTORdflt += "\t}\r\n";
            CTOR += "\t}\r\n";
            result += CTORdflt + CTOR;
            result += "#endregion //CTOR\r\n";
            return result;
        }

        private string BuildCRUD(List<Column> cols) {
            StringBuilder result= new StringBuilder().Append("#region CRUD\r\n");
            string pattern = "public bool ACTION(PARAMS){\r\n//TODO setup ACTION\r\n}\r\n";
            string create, retrieveByID,retrieveAll, update, delete;
            create = retrieveByID = retrieveAll = update = delete = pattern;
            create = pattern.Replace("ACTION", "Create").Replace("PARAMS", "");
            retrieveByID = pattern.Replace("ACTION", "RetrieveByID").Replace("PARAMS", GetFieldsAsInputParams(cols, true));
            retrieveAll = pattern.Replace("ACTION", "RetrieveAll").Replace("PARAMS", "");
            update = pattern.Replace("ACTION", "Update").Replace("PARAMS", "");
            delete = pattern.Replace("ACTION", "Delete").Replace("PARAMS", "");
            result.Append(create);
            result.Append(retrieveAll);
            result.Append(retrieveByID);
            result.Append(update);
            result.Append(delete);
            result.Append("#endregion //CRUD\r\n");
            return result.ToString();
        }



        private string GetFieldsAsInputParams(List<Column> cols) {
            return GetFieldsAsInputParams(cols, false);
        }
        private string GetFieldsAsInputParams(List<Column> cols, bool onlyKeyCols){
            string result = "";
            foreach (Column c in cols) {
                if (result.Length > 0) result += ",";
                if(onlyKeyCols && c.IsIdentity)
                    result += GetFieldAsInputParameter(c);
                else
                    result += GetFieldAsInputParameter(c);

            }

            return result;
        
        }
        private string GetFieldAsInputParameter(Column c) {
            string result = "";
            result = string.Format ("{0} {1}",
                GetASPNetDataType(c), GetInputParamName(c));
            return result;
        
        }
        

        private string GetInputParamName(Column c) {
            return c.Name + "in";
        }
        private string GetFieldName(Column c) {
            string result = (c.Name.Length > 1)? 
                string.Format("_{0}{1}", c.Name.Substring(0,1).ToLower(), c.Name.Substring(1)):
                "_" + c.Name.ToLower();
            return result;

        }
        private string GetPropName(Column c) {
            string result = (c.Name.Length > 1) ?
                string.Format("{0}{1}", c.Name.Substring(0, 1).ToUpper(), c.Name.Substring(1)) :
                c.Name.ToUpper(); 
            return result;
        }

        /// <summary>
        /// The initial value fields are set to when the constructor is invoked
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetInitialValueByType(Column c) {
            SqlDbType type = (SqlDbType)Enum.Parse(typeof(SqlDbType), c.DataType);
            string result = "\"\"";
            switch (type) { 
                case SqlDbType.BigInt :
                case SqlDbType.Binary:
                case SqlDbType.Bit:               
                case SqlDbType.Decimal:
                case SqlDbType.Float:
                case SqlDbType.Int :
                case SqlDbType.Money:
                case SqlDbType.Real:
                case SqlDbType.SmallInt:
                case SqlDbType.SmallMoney:
                case SqlDbType.TinyInt:
                case SqlDbType.VarBinary:
                    result = "0";break;
                case SqlDbType.Char:
                case SqlDbType.NChar:
                    result = "''";break;
                case SqlDbType.VarChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                    result = "\"\"";break;
                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Time:
                    result = "null";break;
                case SqlDbType.UniqueIdentifier:
                    result = "new Guid()"; break;
            }
                
            return result;
        }
        /// <summary>
        /// The initial value fields are set to when the constructor is invoked
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string GetASPNetDataType(Column c)
        {
            //init cap and match dataType of Enum list's casing in order for parsing to be ok
            string sqlDbTypeFriendlyStr = c.DataType.Substring(0, 1).ToUpper() + c.DataType.Substring(1);
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("int", "Int").Replace("money", "Money").Replace("char", "Char");
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("Uniqueidentifier", "UniqueIdentifier");
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("binary", "Binary").Replace("varChar", "VarChar");
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("text", "Text").Replace("time", "Time");
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("Numeric", "Decimal");
            if (sqlDbTypeFriendlyStr.Contains(" ")) { 
                //get string before space
                sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Substring(0, sqlDbTypeFriendlyStr.IndexOf(' '));
            }


            SqlDbType type = (SqlDbType)Enum.Parse(typeof(SqlDbType), sqlDbTypeFriendlyStr);
            string result = "";
            switch (type)
            {
                case SqlDbType.Binary:
                case SqlDbType.Bit:
                case SqlDbType.VarBinary:
                    result = "bool"; break;
                case SqlDbType.BigInt:
                case SqlDbType.Int:
                case SqlDbType.TinyInt:
                case SqlDbType.SmallInt:
                    result = "int"; break;
                case SqlDbType.Money:
                case SqlDbType.Decimal:
                case SqlDbType.Float:
                case SqlDbType.Real:
                case SqlDbType.SmallMoney:
                    result = "decimal"; break;
                case SqlDbType.Char:
                case SqlDbType.NChar:
                    result = "char"; break;
                case SqlDbType.VarChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                    result = "string"; break;
                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.DateTime2:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Time:
                    result = "DateTime"; break;
                case SqlDbType.UniqueIdentifier:
                    result = "Guid"; break;
            }

            return result;
        }
    }
}
