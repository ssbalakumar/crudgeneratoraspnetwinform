using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using u = CrudGenerator.Util.Utility;

namespace CrudGenerator
{
    /// <summary>
    /// What this class needs to do is look through a list of columns and 
    /// </summary>
    class CrudGenCSharp
    {

        /// <summary>This is the businessObject</summary>
        StringBuilder crudObject=new StringBuilder();
        /// <summary>This is the data object</summary>
        StringBuilder crudData=new StringBuilder();
        /// <summary>Data Access Layer</summary>
        StringBuilder crudDAL=new StringBuilder();

        /// <summary>synonymous with the tableName, except it chops off anything before _tbl as in Finance_tblAccount -- becomes account</summary>
        string _className;
        string _tableName; //the table name is used to extrapolate the name of the crud stored procedure
        public string ClassName{get { return _className; }}

        List<Column> _cols;
        public string CrudObject { get { return crudObject.ToString(); } }
        public string CrudData { get { return crudData.ToString(); } }

        public CrudGenCSharp() { }
        public CrudGenCSharp(string tableName, List<Column> cols)
        {
            
            _tableName = tableName;
            //if class name has _tbl in it, name the class using whatever is after the tbl part.
            if (tableName.Contains("_tbl"))
                tableName = tableName.Substring(tableName.IndexOf("_tbl") + 4);
            _className = tableName.Substring(0, 1).ToUpper() + tableName.Substring(1);
            _cols = cols;
            
            BuildCrudObject();
            BuildCrudData();
            
           
        
        }
        public void BuildCrudObject(){
            crudObject.AppendLine("using System;");
            crudObject.AppendLine("using System.Collections.Generic;");
            crudObject.AppendLine("using System.Web;");
            crudObject.AppendLine("using System.Data;");
            crudObject.AppendLine("using System.Data.SqlClient;");
            crudObject.AppendLine("using System.Web.UI.WebControls;");
            if (u.UserSettings.NamespaceBL != u.UserSettings.NamespaceDL)
                crudObject.AppendFormat("using {0};\r\n", u.UserSettings.NamespaceDL);
            crudObject.AppendLine();
            crudObject.AppendFormat("{1}//******************** {0} ****************************//{1}", _className, Environment.NewLine );
            crudObject.AppendFormat("\r\n namespace {0} {{\r\n", u.UserSettings.NamespaceBL);
            crudObject.AppendFormat("public partial class {0}{{\r\n", _className );
            crudObject.Append(BuildFields(_cols));
            crudObject.Append(BuildProps(_cols) );
            crudObject.Append(BuildConstructor(_cols, _className));
            crudObject.Append(BuildCRUD(_cols));
            crudObject.AppendFormat("}} //{0}\r\n", _className);
            crudObject.AppendFormat("\r\n}} //{0}", u.UserSettings.NamespaceBL);
        }
        private void BuildCrudData() {
            crudData.AppendLine("using System;");
            crudData.AppendLine("using System.Collections.Generic;");
            crudData.AppendLine("using System.Data.SqlClient;");
            crudData.AppendLine("using System.Data;");
            crudData.AppendLine("using System.Web;");
            crudData.AppendLine("using System.Web.UI.WebControls; //added so i can return a type listItem collection");
            crudData.AppendLine("using System.Web.Caching;");
            if(u.UserSettings.NamespaceBL != u.UserSettings.NamespaceDL)
                crudData.AppendFormat("using {0};\r\n", u.UserSettings.NamespaceBL);
            crudData.AppendLine();
            crudData.AppendFormat("namespace {0} {{\r\n", u.UserSettings.NamespaceDL );
            crudData.AppendFormat("\tpublic partial class {0}Data{{\r\n", _className);
            BuildCrud_CreateDL();
            BuildCrud_DL_ReadUpdateDelete();
            BuildCrud_DL_ReaderToObject();
            crudData.AppendFormat("\t}} //{0}\r\n", _className);
            crudData.AppendFormat("\r\n}} //{0}\r\n", u.UserSettings.NamespaceDL);
        }
        private void BuildCrudDAL(){}
        private string BuildFields(List<Column> cols) {
            System.ComponentModel.TypeConverter tc = new System.ComponentModel.TypeConverter();

            string result="#region Fields\r\n";
            foreach (Column c in cols) {
                //private int _field;
                result += string.Format( "\t private {0} {1};\r\n", 
                    c.GetASPNetDataType(),GetFieldName(c));
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
                    c.GetASPNetDataType(), GetFieldName(c), GetPropName(c));
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
                CTORdflt += string.Format("\t\t{0} = {1};\r\n",
                    GetFieldName(c), GetInitialValueByType(c));

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
           
            string create, retrieveByID,retrieveAll, update, delete;
            create = retrieveByID = retrieveAll = update = delete = "";

            Column identityCol = Column.GetIdentityColumn(_cols);
            if (identityCol == null){ 
                identityCol = new Column();
                identityCol.DataType = "Int";
                identityCol.Name = "NoIdentityColumnInTable_NeedManualSetup";
            }



            create = string.Format("\tpublic {0} Create(Guid userId){{\r\n", identityCol.GetASPNetDataType())
                + string.Format("\t\t return {0}Data.Create(this,userId);", _className   )
                + "\t}\r\n";

            retrieveAll = string.Format("\tpublic static List<{0}> RetrieveAll(Guid userId){{\r\n", _className)
                + string.Format("\t\t return {0}Data.RetrieveAll(userId);\r\n", _className)
                + "\t}\r\n";

            retrieveByID = string.Format("\tpublic static {0} RetrieveById(int {1}, Guid userId){{\r\n", _className, identityCol.Name)
                + string.Format("\t\t return {0}Data.RetrieveById({1}, userId);\r\n", _className, identityCol.Name)
                + "\t}\r\n";

            update = "\tpublic bool Update(Guid userId){\r\n"
                + string.Format("\t\t return {0}Data.Update(this, userId);\r\n", _className)
                + "\t}\r\n";

            delete = "\tpublic bool Delete(Guid userId){\r\n"
                + string.Format("\t\t return {0}Data.Delete(this, userId);\r\n", _className)
                + "\t}\r\n";


            delete = string.Format("\tpublic static bool Delete(int {0},Guid userId){{\r\n", identityCol.Name)
                + string.Format("\t\t return {0}Data.Delete({1}, userId);\r\n", _className, identityCol.Name)
                + "\t}\r\n";
            result.Append(create);
            result.Append(retrieveAll);
            result.Append(retrieveByID);
            result.Append(update);
            result.Append(delete);
            result.Append("#endregion //CRUD\r\n");
            return result.ToString();
        }

  

        /// <summary>Create should return the datatype of the current </summary>
        private void BuildCrud_CreateDL()
        {
            Column identityCol = Column.GetIdentityColumn(_cols);
            if (identityCol == null)
            {
                identityCol = new Column();
                identityCol.DataType = "Int"; //default return data type
                identityCol.Name = "NoIdentityColumnInTable_NeedManualSetup";
            }
            crudData.Append("\t///<summary>returns the id of the item which was just created</summary>\r\n"
                + string.Format("\tpublic static {0} Create({1} obj{2}){{\r\n"
                    , identityCol.GetASPNetDataType()
                    , _className
                    , (u.UserSettings.UserIdIsParamForCRUBusinessLayer) ? ",Guid userId" : "")
                + string.Format("\t using(SqlCommand cmd=new SqlCommand(\"{0}\")){{\r\n", CrudGenSPROC.GetSprocNameCreate(_tableName))
                + "\t\t cmd.CommandType = CommandType.StoredProcedure;\r\n");

            //for each column, add a parameter to the sproc
            //foreach (Column c in cols) {
            //    result += string.Format("\t\t cmd.Parameters.AddWithValue(\"@{0}\" , obj.{1});\r\n", c.Name, GetPropName(c));
            //    //todo: convert the value from theinput object to database friendly value... this means need to have a ToDBFriendly method
            //}

            crudData_AddSprocParams(crudData, true);
            crudData.AppendFormat("\t\t return DataAccess.RunCmdReturn_{0}(cmd);\r\n", identityCol.GetASPNetDataType());

            crudData.AppendLine("\t } //close using statement \r\n}");
        }
        /// <summary>
        /// Builds the readAll, readById, update, and delete procedures.
        /// Best practices: it uses as input only the identity column
        /// because we are guaranteed that there will only be one of those in a table.  
        /// As far as why not to use a primary key as input, that has to do with the fact that the number
        /// of primary keys can vary according to how the table is designed and I don't see
        /// a need to complicate this method.
        /// </summary>
        private void BuildCrud_DL_ReadUpdateDelete() {
            Column identity = Column.GetIdentityColumn(_cols);
            if (identity == null){
                identity = new Column();
                identity.Name = "NoIdentityColumn";
            }
            crudData.AppendFormat("	public static List<{0}> RetrieveAll(Guid userId) {{\r\n", _className);
            crudData.AppendFormat("            List<{0}> result = new List<{0}>();\r\n", _className);
            crudData.AppendFormat("            using (SqlCommand cmd = new SqlCommand(\"{0}\"))\r\n", CrudGenSPROC.GetSprocNameReadAll(_tableName) );
            crudData.AppendLine("            {");
            crudData.AppendLine("                cmd.CommandType = CommandType.StoredProcedure;");
            crudData.AppendLine("                cmd.Parameters.AddWithValue(\"@userId\", userId);");
            crudData.AppendLine("                try{");
            crudData.AppendLine("                   SqlDataReader r = DataAccess.RunCMDGetDataReader(cmd);");
            crudData.AppendLine("                   while (r.Read()) ");
            crudData.AppendLine("                        result.Add(convertReaderToObject(r));");
            crudData.AppendLine("                   r.Close();");
            crudData.AppendLine("                } catch (Exception ex) {throw ex; }");
            crudData.AppendLine("            } //close using statement ");
            crudData.AppendLine("            return result;");
            crudData.AppendLine("        }");
            //todo get key column type and its variable name
            crudData.AppendFormat("        public static {0} RetrieveById(int {1}, Guid userId){{\r\n", _className, identity.Name  );
            crudData.AppendFormat("            {0}  result=null;\r\n", _className);
            crudData.AppendFormat("            using (SqlCommand cmd = new SqlCommand(\"{0}\"))\r\n", CrudGenSPROC.GetSprocNameReadById(_tableName));
            crudData.AppendLine("            {");
            crudData.AppendLine("                cmd.CommandType = CommandType.StoredProcedure;");
            crudData.AppendFormat("                cmd.Parameters.AddWithValue(\"@{0}\", {0});\r\n", identity.Name);
            crudData.AppendLine("                cmd.Parameters.AddWithValue(\"@userId\", userId);");
            crudData.AppendLine("                SqlDataReader r = DataAccess.RunCMDGetDataReader(cmd);");
            crudData.AppendLine("                if (r.Read())");
            crudData.AppendLine("                    result = convertReaderToObject(r);");
            crudData.AppendLine("                r.Close();");
            crudData.AppendLine("            } //close using statement ");
            crudData.AppendLine("            return result;");
            crudData.AppendLine("        }");
            crudData.AppendLine("");
            crudData.AppendFormat("        public static Boolean Update({0} obj,Guid userId) {{\r\n", _className);
            crudData.AppendLine("            bool result = false;");
            crudData.AppendFormat("            using (SqlCommand cmd = new SqlCommand(\"{0}\"))\r\n", CrudGenSPROC.GetSprocNameUpdate(_tableName));
            crudData.AppendLine("            {");
            crudData.AppendLine("                cmd.CommandType = CommandType.StoredProcedure;");

            crudData_AddSprocParams(crudData, true);

            crudData.AppendLine("                cmd.Parameters.Add(\"@rowsAffected\", SqlDbType.Int);\r\n");
            crudData.AppendLine("                cmd.Parameters[\"@rowsAffected\"].Direction = ParameterDirection.ReturnValue;");
            crudData.AppendLine("                SqlDataReader r = DataAccess.RunCMDGetDataReader(cmd);");
            crudData.AppendLine("                if (cmd.Parameters[\"@rowsAffected\"].Value.ToString() == \"1\") result = true;");
            crudData.AppendLine("                r.Close();");
            crudData.AppendLine("            } //close using statement ");
            crudData.AppendLine("            return result;");
            crudData.AppendLine("        }\r\n");

            crudData.AppendFormat("        public static Boolean Delete(int {0}, Guid userId){{\r\n", identity.Name);
            crudData.AppendLine("            bool result = false;");
            crudData.AppendFormat("            using (SqlCommand cmd = new SqlCommand(\"{0}\")){{\r\n", CrudGenSPROC.GetSprocNameDelete(_tableName));
            crudData.AppendLine("                cmd.CommandType = CommandType.StoredProcedure;");
            crudData.AppendFormat("                cmd.Parameters.AddWithValue(\"@{0}\", {0});\r\n", identity.Name);
            crudData.AppendLine("                cmd.Parameters.AddWithValue(\"@userId\", userId);");
            crudData.AppendLine("                cmd.Parameters.Add(\"@rowsAffected\");");
            crudData.AppendLine("                cmd.Parameters[\"@rowsAffected\"].Direction = ParameterDirection.ReturnValue;");
            crudData.AppendLine("");
            crudData.AppendLine("                SqlDataReader r = DataAccess.RunCMDGetDataReader(cmd);");
            crudData.AppendLine("                if (cmd.Parameters[\"@rowsAffected\"].Value.ToString() == \"1\") result = true;");
            crudData.AppendLine("                //todo set the return value to true or false based on what the stored procedure returns as ");
            crudData.AppendLine("                r.Close();");
            crudData.AppendLine("                            } //close using statement ");
            crudData.AppendLine("            return result;");
            crudData.AppendLine("        }");
                    
        
        }


 

        private void crudData_AddSprocParams(StringBuilder sb, bool excludeComputedColumns)
        {
            foreach (Column c in _cols)
            {
                string handledString;
                if (excludeComputedColumns == true && c.IsComputed){
                    //skipped computedColumns from the argument list
                }else
                {
                    if (c.SqlDbTypeOfColumn == SqlDbType.DateTime)
                        handledString = string.Format("DataAccess.StringToDB(obj.{0}.ToString(), SqlDbType.DateTime)", GetPropName(c));
                    else handledString = "obj." + GetPropName(c);
                    sb.AppendFormat("                cmd.Parameters.AddWithValue(\"@{0}\", {1});\r\n", c.Name, handledString);
                }
            }
        }
        private void BuildCrud_DL_ReaderToObject() { 

            crudData.AppendFormat("private static {0} convertReaderToObject(SqlDataReader r){{\r\n", _className );
            
            crudData.AppendFormat("    return new {0}({1});\r\n}}", _className, BuildCrud_DL_ReaderToObjectColumns()  );
        
        }
        private string BuildCrud_DL_ReaderToObjectColumns(){
            string result = "";
            foreach (Column c in _cols)
            {
                if (result != "") result += ",\r\n\t\t\t";
                string dataType = c.GetASPNetDataType();
                //make data type init capped because the r.ToString method is pascal cased.
                dataType = dataType.Substring(0, 1).ToUpper() + dataType.Substring(1);
                result += string.Format("r.To{0}(\"{1}\")", dataType, c.Name);
            }
            return result;

        
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
                c.GetASPNetDataType(), GetInputParamName(c));
            return result;
        
        }
        

        private string GetInputParamName(Column c) {
            //make it camel cased
           string result = (c.Name.Length > 1) ?
           string.Format("{0}{1}", c.Name.Substring(0, 1).ToLower(), c.Name.Substring(1)) :
             c.Name.ToLower();
            return result;
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
            SqlDbType type = c.SqlDbTypeOfColumn ;
            string result = "\"\"";
            switch (type) {
                case SqlDbType.Bit:
                    result = "false"; break;
                case SqlDbType.BigInt :
                case SqlDbType.Binary:             
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
                    result = "' '";break;
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
                    result = "new DateTime()"; break;
                case SqlDbType.UniqueIdentifier:
                    result = "new Guid()"; break;
            }
                
            return result;
        }

        public static string GetDataAccessLayer() {
            StringBuilder crudDAL = new StringBuilder();
            crudDAL.AppendLine("using System;");
            crudDAL.AppendLine("using System.Collections.Generic;");
            crudDAL.AppendLine("using System.Data;");
            crudDAL.AppendLine("using System.Data.SqlClient;");
            crudDAL.AppendLine("using System.Web;");
            crudDAL.AppendLine("using System.Configuration;");
            crudDAL.AppendFormat("namespace {0} \r\n", u.UserSettings.NamespaceDL);
            crudDAL.AppendLine("{");
            crudDAL.AppendLine("    public class DataAccess");
            crudDAL.AppendLine("    {");
            crudDAL.AppendLine("        private static string _connString;");
            crudDAL.AppendLine("        public static string ConnString {");
            crudDAL.AppendLine("            get {");
            crudDAL.AppendLine("                ");
            crudDAL.AppendLine("                if (string.IsNullOrEmpty(_connString) && ConfigurationManager.ConnectionStrings.Count >0)");
            crudDAL.AppendLine("                {");
            crudDAL.AppendLine("                    for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)");
            crudDAL.AppendLine("                    {");
            crudDAL.AppendLine("                        //todo: change the customDefaultConnectionstring name to what you would like your datalayer to use when you don't provide a Connectionstring in your sqlCommand");
            crudDAL.AppendLine("                        if (ConfigurationManager.ConnectionStrings[i].Name.Contains(\"CustomDefaultConnectionString\")) ");
            crudDAL.AppendLine("                        {");
            crudDAL.AppendLine("                            _connString = ConfigurationManager.ConnectionStrings[i].ConnectionString;");
            crudDAL.AppendLine("                        }");
            crudDAL.AppendLine("                    }    ");
            crudDAL.AppendLine("                }    ");
            crudDAL.AppendLine("                return _connString;");
            crudDAL.AppendLine("            }");
            crudDAL.AppendLine("            set { _connString = value; }");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        /// <summary>Returns true if your stored procedure runs and returns no errors.</summary>");
            crudDAL.AppendLine("        ///   <returns>The stored proc should return 1 to indicate success and 0 to indicate failure");
            crudDAL.AppendLine("        ///   </returns>");
            crudDAL.AppendLine("        /// ");
            crudDAL.AppendLine("        public static bool RunActionCmdReturnBool(SqlCommand cmd)");
            crudDAL.AppendLine("        {");
            crudDAL.AppendLine("            bool result = false;");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            SqlParameter returnParam = new SqlParameter(\"@RETURN_VALUE\", SqlDbType.Int);");
            crudDAL.AppendLine("            returnParam.Direction = ParameterDirection.ReturnValue ;");
            crudDAL.AppendLine("            cmd.Parameters.Add(returnParam);");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            ");
            crudDAL.AppendLine("            if (cmd.Connection == null) ");
            crudDAL.AppendLine("                cmd.Connection = new SqlConnection(ConnString);");
            crudDAL.AppendLine("            if (cmd.Connection.State == ConnectionState.Closed)");
            crudDAL.AppendLine("                cmd.Connection.Open();");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            using (SqlDataReader r = cmd.ExecuteReader(CommandBehavior.CloseConnection))");
            crudDAL.AppendLine("            {");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("                if (returnParam.Value == DBNull.Value)");
            crudDAL.AppendLine("                    result = false;");
            crudDAL.AppendLine("                else if (returnParam.Value.ToString() == \"1\")");
            crudDAL.AppendLine("                    result = true;");
            crudDAL.AppendLine("                else if (returnParam.Value != DBNull.Value)");
            crudDAL.AppendLine("                    bool.TryParse(returnParam.Value.ToString(), out result);");
            crudDAL.AppendLine("                r.Close();");
            crudDAL.AppendLine("            }");
            crudDAL.AppendLine("            cmd.Dispose();");
            crudDAL.AppendLine("            return result;");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        /// <summary>");
            crudDAL.AppendLine("        /// assumes that one of the parameterDirections is output or inputoutput.  If there are more than one, it returns the first one.  If none, it returns 0.");
            crudDAL.AppendLine("        /// </summary>");
            crudDAL.AppendLine("        /// <param name=\"cmd\"></param>");
            crudDAL.AppendLine("        public static int RunCmdReturn_int(SqlCommand cmd){");
            crudDAL.AppendLine("            int result = 0;");
            crudDAL.AppendLine("            SqlParameter returnParam = GetOutputParameter(cmd.Parameters);            ");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            if (cmd.Connection == null)");
            crudDAL.AppendLine("                cmd.Connection = new SqlConnection(ConnString);");
            crudDAL.AppendLine("            if (cmd.Connection.State == ConnectionState.Closed)");
            crudDAL.AppendLine("                cmd.Connection.Open();");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            int i = cmd.ExecuteNonQuery();");
            crudDAL.AppendLine("            if (returnParam!=null)");
            crudDAL.AppendLine("              result = (returnParam.Value == DBNull.Value) ? 0: (int)returnParam.Value;");
            crudDAL.AppendLine("          ");
            crudDAL.AppendLine("            cmd.Dispose();");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            return result;");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        private static SqlParameter GetOutputParameter(SqlParameterCollection sqlParameters) {");
            crudDAL.AppendLine("            SqlParameter returnParam = null;");
            crudDAL.AppendLine("            SqlParameter inoutParam = null;");
            crudDAL.AppendLine("            foreach (SqlParameter p in sqlParameters)");
            crudDAL.AppendLine("            {");
            crudDAL.AppendLine("                if (p.Direction == ParameterDirection.Output)");
            crudDAL.AppendLine("                    returnParam = p;");
            crudDAL.AppendLine("                if (p.Direction == ParameterDirection.InputOutput)");
            crudDAL.AppendLine("                    inoutParam = p;");
            crudDAL.AppendLine("            }");
            crudDAL.AppendLine("            //if the return parameter is not defined but there is an inputoutput parameter present, ");
            crudDAL.AppendLine("            if (returnParam == null && inoutParam !=null)");
            crudDAL.AppendLine("                returnParam = inoutParam;");
            crudDAL.AppendLine("            ");
            crudDAL.AppendLine("            return returnParam;");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("        /// <summary>");
            crudDAL.AppendLine("        /// assumes that the key column's parameterDirection has been set to output");
            crudDAL.AppendLine("        /// </summary>");
            crudDAL.AppendLine("        /// <param name=\"cmd\"></param>");
            crudDAL.AppendLine("        /// <returns></returns>");
            crudDAL.AppendLine("        public static Guid RunCmdReturn_Guid(SqlCommand cmd){");
            crudDAL.AppendLine("            Guid result = new Guid();");
            crudDAL.AppendLine("            SqlParameter returnParam = GetOutputParameter(cmd.Parameters);");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            if (cmd.Connection == null)");
            crudDAL.AppendLine("                cmd.Connection = new SqlConnection(ConnString);");
            crudDAL.AppendLine("            if (cmd.Connection.State == ConnectionState.Closed)");
            crudDAL.AppendLine("                cmd.Connection.Open();");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            using (SqlDataReader r = cmd.ExecuteReader(CommandBehavior.CloseConnection))");
            crudDAL.AppendLine("            {");
            crudDAL.AppendLine("                if (returnParam != null && returnParam.Value != DBNull.Value)");
            crudDAL.AppendLine("                    result = (Guid)returnParam.Value;");
            crudDAL.AppendLine("                r.Close();");
            crudDAL.AppendLine("            }");
            crudDAL.AppendLine("            cmd.Dispose();");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            return result;");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        public static void RunActionCmd(SqlCommand cmd)");
            crudDAL.AppendLine("        {");
            crudDAL.AppendLine("            if (cmd.Connection == null)");
            crudDAL.AppendLine("                cmd.Connection = new SqlConnection(ConnString);");
            crudDAL.AppendLine("            if (cmd.Connection.State == ConnectionState.Closed)");
            crudDAL.AppendLine("                cmd.Connection.Open();");
            crudDAL.AppendLine("            cmd.ExecuteNonQuery();");
            crudDAL.AppendLine("            cmd.Dispose();");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("        public static SqlDataReader RunCMDGetDataReader (SqlCommand cmd)");
            crudDAL.AppendLine("        {");
            crudDAL.AppendLine("            SqlDataReader result;");
            crudDAL.AppendLine("            if (cmd.Connection == null)");
            crudDAL.AppendLine("                cmd.Connection = new SqlConnection(ConnString);");
            crudDAL.AppendLine("            if (cmd.Connection.State == ConnectionState.Closed)");
            crudDAL.AppendLine("                cmd.Connection.Open();");
            crudDAL.AppendLine("            try");
            crudDAL.AppendLine("            {");
            crudDAL.AppendLine("                result = cmd.ExecuteReader(CommandBehavior.CloseConnection);");
            crudDAL.AppendLine("            }");
            crudDAL.AppendLine("            catch (Exception ex)");
            crudDAL.AppendLine("            {");
            crudDAL.AppendLine("                throw ex;");
            crudDAL.AppendLine("            }");
            crudDAL.AppendLine("            ");
            crudDAL.AppendLine("            return result;");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        public static DataSet RunCMDGetDataSet (SqlCommand cmd) {");
            crudDAL.AppendLine("            DataSet result = new DataSet();");
            crudDAL.AppendLine("            if (cmd.Connection == null)");
            crudDAL.AppendLine("                cmd.Connection = new SqlConnection(ConnString);");
            crudDAL.AppendLine("            if (cmd.Connection.State == ConnectionState.Closed)");
            crudDAL.AppendLine("                cmd.Connection.Open();");
            crudDAL.AppendLine("            SqlDataAdapter da = new SqlDataAdapter(cmd);");
            crudDAL.AppendLine("            da.Fill(result);");
            crudDAL.AppendLine("            cmd.Dispose();");
            crudDAL.AppendLine("            return result;");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        /// <summary>");
            crudDAL.AppendLine("        /// under construction");
            crudDAL.AppendLine("        /// </summary>");
            crudDAL.AppendLine("        /// <param name=\"cmd\"></param>");
            crudDAL.AppendLine("        /// <returns></returns>");
            crudDAL.AppendLine("        public static string DLookup(SqlCommand cmd)");
            crudDAL.AppendLine("        {");
            crudDAL.AppendLine("            if (cmd.Connection == null)");
            crudDAL.AppendLine("                cmd.Connection = new SqlConnection(ConnString);");
            crudDAL.AppendLine("            if (cmd.Connection.State == ConnectionState.Closed)");
            crudDAL.AppendLine("                cmd.Connection.Open();");
            crudDAL.AppendLine("            string result= cmd.ExecuteScalar().ToString();");
            crudDAL.AppendLine("            cmd.Dispose();");
            crudDAL.AppendLine("            return result;");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        /// <summary>gets a string ready for insertion into database by replacing ' with ''</summary>");
            crudDAL.AppendLine("        public static string StringToDB(string s) {");
            crudDAL.AppendLine("            return StringToDB(s, SqlDbType.VarChar);");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        public static string StringToDB(string s, SqlDbType typ) {");
            crudDAL.AppendLine("            string result = s;");
            crudDAL.AppendLine("            switch (typ)");
            crudDAL.AppendLine("            {");
            crudDAL.AppendLine("                case SqlDbType.Bit :");
            crudDAL.AppendLine("                    if (s.ToLower() ==\"true\" || s.ToLower()==\"yes\")");
            crudDAL.AppendLine("                        result = \"1\";");
            crudDAL.AppendLine("                    else ");
            crudDAL.AppendLine("                         result = \"0\";");
            crudDAL.AppendLine("                    break;");
            crudDAL.AppendLine("                case SqlDbType.DateTime:");
            crudDAL.AppendLine("                case SqlDbType.Date:");
            crudDAL.AppendLine("                    if (s == DateTime.MinValue.ToString())");
            crudDAL.AppendLine("                        s = \"Null\";");
            crudDAL.AppendLine("                    break;");
            crudDAL.AppendLine("                case SqlDbType.UniqueIdentifier:");
            crudDAL.AppendLine("                    if (s == new Guid().ToString())");
            crudDAL.AppendLine("                        s = \"Null\";");
            crudDAL.AppendLine("                    break;");
            crudDAL.AppendLine("                default: //SqlDbType.VarChar | SqlDbType.Text ");
            crudDAL.AppendLine("                    result = s.Replace(\"'\", \"''\");");
            crudDAL.AppendLine("                    break;");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("            return result;");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("     ");
            crudDAL.AppendLine("        ");
            crudDAL.AppendLine("        }");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("");
            crudDAL.AppendLine("        ");
            crudDAL.AppendLine("    }");
            crudDAL.AppendLine("}");
            return crudDAL.ToString();
        }
        /// <summary>
        /// Helps to reduce the amount of code it takes to extract data from a dataReader
        /// </summary>
        /// <returns></returns>
        public static string GetDataReaderExtensions() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Web;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Data.SqlClient;");
            sb.AppendFormat ("namespace {0} {{\r\n", u.UserSettings.NamespaceDL );
            sb.AppendLine("    public static class DataReaderExtensions {");
            sb.AppendLine("        public static string ToString(this IDataReader reader, string column) {");
            sb.AppendLine("            if (reader[column] != DBNull.Value)");
            sb.AppendLine("                return reader[column].ToString();");
            sb.AppendLine("            else");
            sb.AppendLine("                return \"\";");
            sb.AppendLine("        }");
            sb.AppendLine("        public static Boolean ToBool(this IDataReader reader, string column)");
            sb.AppendLine("        {");
            sb.AppendLine("            return ToBool(reader, column, false);");
            sb.AppendLine("        }");
            sb.AppendLine("        public static Boolean ToBool(this IDataReader reader, string column, bool defaultValue)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (reader[column] != DBNull.Value)");
            sb.AppendLine("                return bool.Parse(reader[column].ToString());");
            sb.AppendLine("            else");
            sb.AppendLine("                return defaultValue;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public static int ToInt(this IDataReader reader, string column)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (reader[column] != DBNull.Value)");
            sb.AppendLine("            {");
            sb.AppendLine("                return Convert.ToInt32(reader[column]);");
            sb.AppendLine("            }");
            sb.AppendLine("            else                ");
            sb.AppendLine("                return 0;");
            sb.AppendLine("        }");
            sb.AppendLine("");
            sb.AppendLine("        public static Decimal ToDecimal(this IDataReader reader, string column)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (reader[column] != DBNull.Value)");
            sb.AppendLine("            {");
            sb.AppendLine("                return Convert.ToDecimal(reader[column]);");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("                return 0;");
            sb.AppendLine("        }");
            sb.AppendLine("        public static Guid ToGuid(this IDataReader reader, string column)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (reader[column] != DBNull.Value)");
            sb.AppendLine("            {");
            sb.AppendLine("                return new Guid(reader[column].ToString());");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("                return Guid.Empty;");
            sb.AppendLine("        }");
            sb.AppendLine("        public static DateTime ToDateTime(this IDataReader reader, string column)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (reader[column] != DBNull.Value)");
            sb.AppendLine("            {");
            sb.AppendLine("                return Convert.ToDateTime(reader[column]);");
            sb.AppendLine("            }");
            sb.AppendLine("            else");
            sb.AppendLine("                return DateTime.MinValue;");
            sb.AppendLine("        }");
            sb.AppendLine("        public static Char ToChar(this IDataReader reader, string column) {");
            sb.AppendLine("            if (reader[column] != DBNull.Value)");
            sb.AppendLine("                 return Convert.ToChar(reader[column]);");
            sb.AppendLine("             else");
            sb.AppendLine("                 return ' ';");
            sb.AppendLine("        }");
            sb.AppendLine("        //This converts an integer column to the given enum (T)");
            sb.AppendLine("        public static T ToEnum<T>(this IDataReader reader, string column)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (!typeof(T).IsEnum)");
            sb.AppendLine("            {");
            sb.AppendLine("                throw new ArgumentException(typeof(T).ToString() + \" is not an Enum\");");
            sb.AppendLine("            }");
            sb.AppendLine("            return (T)Enum.ToObject(typeof(T), reader.ToInt(column));");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("} //end namespace");
            return sb.ToString();
        }
       
    }
}
