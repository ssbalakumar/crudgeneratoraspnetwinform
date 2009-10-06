using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CrudGenerator {
    public class CrudGenSPROC {
        #region Member variables
        string tableName = string.Empty;
        string author = string.Empty;
        string isActive = string.Empty;
        List<Column> columns = new List<Column>();
        #endregion

        #region Properties
        public string Author {
            get { return author; }
            set { author = value; }
        }
        public string IsActive {
            get { return isActive; }
            set { isActive = value; }
        }
        public string TableName {
            get { return tableName; }
            set { tableName = value; }
        }
        public List<Column> Columns {
            get { return columns; }
            set { columns = value; }
        } 
        #endregion

        #region Column Selector Methods

        public List<Column> GetPrimaryKeys() {
            List<Column> list = new List<Column>();
            foreach (Column column in columns) {
                if (column.IsPrimaryKey)
                    list.Add(column);
            }
            return list;
        }
        public List<Column> GetNotPrimaryKeysAndNotIdentity() {
            List<Column> list = new List<Column>();
            foreach (Column column in columns) {
                if (!column.IsPrimaryKey && !column.IsIdentity && !column.IsComputed)
                    list.Add(column);
            }
            return list;
        }
        public List<Column> GetAllColumns() {
            return columns;
        }
      
        public List<Column> GetNotIdentity() {
            List<Column> list = new List<Column>();
            foreach (Column column in columns) {
                if (!column.IsIdentity)
                    list.Add(column);
            }
            return list;
        }

        public List<Column> GetNotIdentityAndNonComputed()
        {
            List<Column> list = new List<Column>();
            foreach (Column column in columns)
            {
                if (!column.IsIdentity && !column.IsComputed) 
                    list.Add(column);
            }
            return list;
        } 
        #endregion

        #region STATIC - Parse Table method
        public static List<CrudGenSPROC> ParseDataTable(DataTable dt) {
            List<CrudGenSPROC> tables = new List<CrudGenSPROC>();
            foreach (DataRow dr in dt.Rows) {
                CrudGenSPROC table;
                if (tables.Count == 0 || tables[tables.Count - 1].TableName != dr["TableName"].ToString()) {
                    table = new CrudGenSPROC();
                    table.TableName = dr["TableName"].ToString();
                    tables.Add(table);
                } else {
                    table = tables[tables.Count - 1];
                }
                Column column = new Column();
                column.Name = dr["ColumnName"].ToString();
                column.IsIdentity = ((int)dr["IsIdentity"] == 1);
                column.IsPrimaryKey = ((int)dr["IsPrimaryKey"] == 1);
                column.DataType = dr["DataType"].ToString();
                if (dr["isComputed"].ToString() == "1") 
                    column.IsComputed = true;
                table.Columns.Add(column);
            }
            return tables;
        }
        #endregion

        #region CRUD Methods
        internal string GenerateSelectById(bool dropIfExists)
        {
            StringBuilder sb = new StringBuilder(2000);
            WriteDropIfExists(dropIfExists, sb, "_ReadById", "");
            
            WriteComments(sb);
            sb.Append("Create Procedure ");
            sb.Append(this.tableName);
            sb.Append("_ReadById\r\n");

            DeclareColumnList(sb, GetPrimaryKeys(), true);

            sb.Append("\r\nAS\r\nBegin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tselect\r\n\t");

            SelectColumns(sb, true, this.Columns);

            sb.Append("\r\n\tfrom ");
            sb.Append(this.tableName);

            PK_WhereClause(sb);

            sb.Append("\r\nEnd\r\nGo\r\n");

            return sb.ToString();
        }

        internal string GenerateSelectAll(bool dropIfExists)
        {
            StringBuilder sb = new StringBuilder(2000);
            WriteDropIfExists(dropIfExists,sb, "_ReadAll", "");
            WriteComments(sb);
            sb.Append("Create Procedure ");
            sb.Append(this.tableName);
            sb.Append("_ReadAll\r\n");
            
            sb.Append("\r\nAS\r\nBegin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tselect\r\n\t");

            SelectColumns(sb, true, this.Columns);

            sb.Append("\r\n\tfrom ");
            sb.Append(this.tableName);
            sb.Append("\r\nEnd\r\nGo\r\n");

            return sb.ToString();
        }
        internal string GenerateSelectByUserId(bool dropIfExists) {

            List<Column> userIdCols = Column.GetUserIdColumns(columns);
            if (userIdCols.Count == 0) return "";
            StringBuilder sb = new StringBuilder(2000);
            string postfix = "_ReadByUserId";
            WriteDropIfExists(dropIfExists, sb, postfix, "");
            WriteComments(sb);
            sb.AppendFormat("Create Procedure {0} (@userId uniqueIdentifier)\r\n", tableName+postfix );
            sb.Append("AS Begin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tselect\r\n\t");

            SelectColumns(sb, true, this.Columns);

            sb.Append("\r\n\tfrom ");
            sb.Append(this.tableName);
            WriteWhereConditionForUserIDCols(sb, userIdCols);
            sb.Append("\r\nEnd\r\nGo\r\n");

            return sb.ToString();
        }

        internal void WriteWhereConditionForUserIDCols(StringBuilder sb, List<Column> userIdCols) {
            bool isFirst = true;
            foreach (Column c in userIdCols) { 
                if (isFirst)
                    sb.Append("\r\nWhere @userId=" + c.Name );
                else
                    sb.Append("\r\n OR @userId=" + c.Name);
            }

        }
        internal string GenerateUpdate(bool dropIfExists)
        {
            StringBuilder sb = new StringBuilder(2000);
            WriteDropIfExists(dropIfExists, sb, "_Update", "");
            WriteComments(sb);
            sb.Append("Create Procedure ");
            sb.Append(this.tableName);
            sb.Append("_Update\r\n");
            bool first;
            List<Column> notPrimaryOrIdentity = GetNotPrimaryKeysAndNotIdentity();

            first = DeclareColumnList(sb, GetPrimaryKeys(), true);
            DeclareColumnList(sb, notPrimaryOrIdentity, first);

            sb.Append("\r\nAS\r\nBegin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tupdate ");
            sb.Append(this.tableName);
            sb.Append("\r\n\tset\r\n");
            first = true;
            foreach (Column c in notPrimaryOrIdentity) {
                if (!first) {
                    sb.Append(",\r\n\t\t");
                } else {
                    first = !first;
                    sb.Append("\t\t");
                }
                sb.Append(c.Name);
                sb.Append(" = @");
                sb.Append(c.Name);
            }

            PK_WhereClause(sb);

            sb.Append("\r\nEnd\r\nGo\r\n");

            return sb.ToString();
        }

        internal string GenerateDelete(bool dropIfExists)
        {
            StringBuilder sb = new StringBuilder(2000);
            WriteDropIfExists(dropIfExists,sb, "_Delete", "");
            WriteComments(sb);
            sb.Append("Create Procedure ");
            sb.Append(this.tableName);
            sb.Append("_Delete\r\n");

            DeclareColumnList(sb, GetPrimaryKeys(), true);

            sb.Append("\r\nAS\r\nBegin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tdelete from ");
            sb.Append(this.tableName);

            PK_WhereClause(sb);

            sb.Append("\r\nEnd\r\nGo\r\n");

            return sb.ToString();
        }

        internal string GenerateCreate(bool dropIfExists) {
            StringBuilder sb = new StringBuilder(2000);
            WriteDropIfExists(dropIfExists,sb, "_Create", "");
            WriteComments(sb);
            sb.Append("Create Procedure ");
            sb.Append(this.tableName);
            sb.Append("_Create\r\n");
            bool first;
            List<Column> nonIdentity = GetNotIdentityAndNonComputed();

            first = DeclareColumnList(sb, nonIdentity, true);

            Column identity = Column.GetIdentityColumn(columns);

            if (identity != null) {
                DeclareColumn(sb, identity, first, true);
            }

            sb.Append("\r\nAS\r\nBegin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tinsert into ");
            sb.Append(this.tableName);
            sb.Append("\r\n\t\t(");

            SelectColumns(sb, true, nonIdentity);

            sb.Append(")\r\n\tvalues\r\n\t\t(");
            first = true;
            foreach (Column c in nonIdentity) {
                if (!first) {
                    sb.Append(",@");
                } else {
                    first = !first;
                    sb.Append("@");
                }
                sb.Append(c.Name);
            }
            sb.Append(")\r\n");
            if (identity != null) {
                sb.Append("\r\n\tselect @");
                sb.Append(identity.Name);
                sb.Append(" = SCOPE_IDENTITY()\r\n");
            }
            sb.Append("End\r\nGo\r\n");

            return sb.ToString();
        }
        internal string GenerateDeactiveate(bool dropIfExists)
        {
            StringBuilder sb = new StringBuilder(2000);
            WriteDropIfExists(dropIfExists,sb, "_Deactivate", "");
            WriteComments(sb);
            sb.Append("Create Procedure ");
            sb.Append(this.tableName);
            sb.Append("_Deactivate\r\n");

            DeclareColumnList(sb, GetPrimaryKeys(), true);

            sb.Append("\r\nAS\r\nBegin\r\n\tSET NOCOUNT ON\r\n");
            sb.Append("\tupdate ");
            sb.Append(this.tableName);
            sb.Append("\r\n\tset\r\n\t\t");

            sb.Append(this.IsActive);

            sb.Append(" = 0");

            PK_WhereClause(sb);

            sb.Append("\r\nEnd\r\nGo\r\n");

            return sb.ToString();
        }
        #endregion

        #region CRUD - Common Code Methods

        public static string GetSprocNameCreate(string tableName) {
            return string.Format("{0}{1}_Create", Util.Utility.UserSettings.SprocPrefix, tableName );
        }
        public static string GetSprocNameReadById(string tableName)
        {
            return string.Format("{0}{1}_ReadById", Util.Utility.UserSettings.SprocPrefix, tableName);
        }
        public static string GetSprocNameReadAll(string tableName)
        {
            return string.Format("{0}{1}_ReadAll", Util.Utility.UserSettings.SprocPrefix, tableName);
        }
        public static string GetSprocNameUpdate(string tableName)
        {
            return string.Format("{0}{1}_Update", Util.Utility.UserSettings.SprocPrefix, tableName);
        }

        public static string GetSprocNameDelete(string tableName)
        {
            return string.Format("{0}{1}_Delete", Util.Utility.UserSettings.SprocPrefix, tableName);
        }
 
        /// <summary>generates a drop if exists statment with a Go statement.  of the format [preFix][tableName][postFix]</summary>
        private string WriteDropIfExists(bool dropIfExists, StringBuilder sb,
            string postFix, string preFix)
        {

            if (!dropIfExists)
            {
                return "";// WriteIfNotExists(sb, postFix, preFix); //doing this would not work since the create statement needs to be the first statement in a batch
            }

            string result = "Go \r\n if object_id('" + preFix + tableName + postFix + "', 'P') is not null \r\n";
            result += "\t drop proc " + preFix + tableName + postFix + " \r\n Go \r\n";

            sb.Append(result);
            return sb.ToString();
        }

        /// <summary>generates a drop if exists statment with a Go statement.  of the format [preFix][tableName][postFix]</summary>
        private string WriteIfNotExists(StringBuilder sb,
            string postFix, string preFix)
        {
            //drop you should get here if drop if exists is set to false.
            string result = "Go \r\n if object_id('" + preFix + tableName + postFix + "', 'P') is null \r\n";
            sb.Append(result);
            return sb.ToString();
        }

        private void WriteComments(StringBuilder sb) {
            sb.Append("-- =============================================");
            sb.Append("\r\n-- Author:\t\t");
            sb.Append(author);
            sb.Append("\r\n-- Create date:\t");
            sb.Append(DateTime.Now.ToShortDateString());
            sb.Append("\r\n-- Description:\t");
            sb.Append("\r\n-- Revisions:\t");
            sb.Append("\r\n-- =============================================\r\n");
        }
        private void PK_WhereClause(StringBuilder sb) {
            sb.Append("\r\n\twhere\r\n");
            bool first = true;
            foreach (Column c in GetPrimaryKeys()) {
                if (!first) {
                    sb.Append("\r\n\t\tand ");
                } else {
                    first = !first;
                    sb.Append("\t\t");
                }
                sb.Append(c.Name);
                sb.Append(" = @");
                sb.Append(c.Name);
            }
        }
        private bool DeclareColumnList(StringBuilder sb, List<Column> columns, bool first) {
            foreach (Column c in columns) {
                first = DeclareColumn(sb, c, first, false);
            }
            return first;
        }

        private static bool DeclareColumn(StringBuilder sb, Column c, bool first, bool output) {
            if (!first) {
                sb.Append(",\r\n");
            } else {
                first = !first;
            }
            sb.Append("\t@");
            sb.Append(c.Name + " ");
            sb.Append(c.DataType);
            if (output) {
                sb.Append(" OUTPUT");
            }
            return first;
        }
        private static bool SelectColumns(StringBuilder sb, bool first, List<Column> nonIdentity) {
            foreach (Column c in nonIdentity) {
                if (!first) {
                    sb.Append(", ");
                } else {
                    first = !first;
                    sb.Append(" ");
                }
                sb.Append(c.Name);
            }
            return first;
        }
        #endregion
    }
}
