using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CrudGenerator {
    public class Column {
        string name = string.Empty;

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


        /// <summary>Returns the ASPNET data type which correspond's to the column.  Example: varchar is string.</summary>
        public string GetASPNetDataType()
        {
            //init cap and match dataType of Enum list's casing in order for parsing to be ok
            string sqlDbTypeFriendlyStr = dataType.Substring(0, 1).ToUpper() + dataType.Substring(1);
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("int", "Int").Replace("money", "Money").Replace("char", "Char");
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("Uniqueidentifier", "UniqueIdentifier");
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("binary", "Binary").Replace("varChar", "VarChar");
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("text", "Text").Replace("time", "Time");
            sqlDbTypeFriendlyStr = sqlDbTypeFriendlyStr.Replace("Numeric", "Decimal");
            if (sqlDbTypeFriendlyStr.Contains(" "))
            {
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
