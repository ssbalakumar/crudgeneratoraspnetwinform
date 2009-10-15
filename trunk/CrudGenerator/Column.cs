using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CrudGenerator {
    public class Column
    {
        #region fieldsAndProps 
        string name = string.Empty;
        private SqlDbType _sqlDbTypeOfColumn = SqlDbType.Structured;
        public string Name {
            get { return name; }
            set { name = value; }
        }
        bool isIdentity = false;

        public bool IsIdentity {
            get { return isIdentity; }
            set { isIdentity = value; }
        }
        bool isPrimaryKey = false;

        public bool IsPrimaryKey {
            get { return isPrimaryKey; }
            set { isPrimaryKey = value; }
        }
        string dataType = string.Empty;

        public string DataType {
            get { return dataType; }
            set { dataType = value; }
        }

        public bool IsComputed { get;  set; }
        #endregion

        /// <summary>
        /// This is useful for determining if a table has a refernce to the userID, so i can create a crud to retrieve records by userId
        /// </summary>
        /// <param name="cols"></param>
        /// <returns></returns>
        public static List<Column> GetUserIdColumns(List<Column> cols) {

            List<Column> result=new List<Column>();
            foreach (Column c in cols) {
                if ((c.name.ToLower().Contains("entryby") || 
                     c.name.ToLower().Contains("user") || 
                     c.name.ToLower().Contains("owner")) && 
                     c.DataType.Contains("uniqueidentifier"))
                        result.Add(c);
            }
            return result;
        }
        public SqlDbType SqlDbTypeOfColumn {
            get {
                if (_sqlDbTypeOfColumn != SqlDbType.Structured ) return _sqlDbTypeOfColumn;
                string sqlDbTypeFriendlyStr = dataType;
                //make the sqlDbTypeFriendlyStr  be PascalCased (first character capitalized
                if (!string.IsNullOrEmpty(dataType))
                    sqlDbTypeFriendlyStr = dataType.Substring(0, 1).ToUpper() + dataType.Substring(1);
                sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("int", "Int").Replace("money", "Money").Replace("char", "Char");
                sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("Uniqueidentifier", "UniqueIdentifier");
                sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("binary", "Binary").Replace("varChar", "VarChar");
                sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("text", "Text").Replace("time", "Time");
                sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("Numeric", "Decimal");
                if (sqlDbTypeFriendlyStr.Contains("("))
                {
                    //get string before space
                    sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Substring(0, sqlDbTypeFriendlyStr.IndexOf('('));
                }
                if (sqlDbTypeFriendlyStr!="")
                    _sqlDbTypeOfColumn = (SqlDbType)Enum.Parse(typeof(SqlDbType), sqlDbTypeFriendlyStr);
                return _sqlDbTypeOfColumn;
            
            }
        }

        /// <summary>
        /// Attempts to get identity column if one is present, otherwise gets primary key column
        /// </summary>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static Column GetIdentityColumn(List<Column> columns)
        {
            foreach (Column c in columns)
            {
                if (c.IsIdentity)
                    return c;
            }

            //if there is no identity column... look for primary key column
            foreach (Column c in columns) {
                if (c.IsPrimaryKey)
                    return c;
            }
            return null;
        }
        /// <summary>Returns the ASPNET data type which correspond's to the column.  Example: varchar is string.</summary>
        public string GetASPNetDataType()
        {
            string result = "";
            switch (SqlDbTypeOfColumn)
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
