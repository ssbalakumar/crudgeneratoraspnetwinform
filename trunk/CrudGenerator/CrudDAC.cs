using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
//Microsoft.SqlServer.Smo.dll
//using Microsoft.SqlServer.Management.Smo;
////Microsoft.SqlServer.ConnectionInfo.dll
//using Microsoft.SqlServer.Management.Common;

namespace CrudGenerator {
    public class CrudDAC : IDisposable {
        SqlConnection connection;
        public CrudDAC(string strConnection) {
            connection = new SqlConnection();
            connection.ConnectionString = strConnection;
            try
            {
                connection.Open();
            }
            catch (Exception ex) { throw ex; }
        }

        #region IDisposable Members

        public void Dispose() {
            if (connection.State != ConnectionState.Closed) {
                connection.Close();
            }
        }

        #endregion

        public DataTable GetColumns(string tableLike) {
                string strSql = "select o.name as TableName,    c.name as ColumnName,   COLUMNPROPERTY(o.id,c.name,'IsIdentity' ) isIdentity, \n" +
                "case when p.Column_Name is not null then 1 else 0 end as IsPrimaryKey,   c.colorder as ColumnOrder, \n" +
                "CASE WHEN t.name IN ('char', 'varchar', 'nchar', 'nvarchar') THEN  ( CAST(t.name AS [varchar]) + '(' +  \n" +
                "case when c.length=-1 then 'max'  \n" +
                "when t.name in ('char','varchar')	then  CAST(c.length AS [varchar])  \n" +
                "when t.name in ('nchar','nvarchar') then CAST(c.length/2 AS [varchar])   \n" +
                "else '' \n" +
                "end \n" +
                "+ ')' ) \n" +
                "WHEN t.name IN ('numeric', 'decimal') THEN        ( CAST(t.name AS [varchar]) + ' (' + CAST(c.xprec AS [varchar]) + ',' + CAST(c.xscale AS [varchar]) + ')' )	 \n" +
                "ELSE t.name END AS DataType	, \n" +
                "isComputed \n" +
                "from  \n" +
                "syscolumns c    inner join sysobjects o on c.id=o.id  \n" +
                "INNER JOIN systypes t ON c.xtype = t.xtype   \n" +
                "left join ( \n" +
                "SELECT c.Table_Name, k.Column_Name \n" +
                "FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS c \n" +
                "inner JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE k ON k.table_name = c.table_name AND k.table_schema = c.table_schema AND k.table_catalog = c.table_catalog AND k.constraint_catalog = c.constraint_catalog AND k.constraint_name = c.constraint_name \n" +
                "where constraint_type = 'PRIMARY KEY' \n" +
                ") p on o.Name = p.Table_Name and c.Name = p.Column_Name \n" +
                "where o.xtype='U' and o.name <> 'dtproperties'  \n" +
                "and t.name not in ('sysname','timestamp')  \n" +
                "and  o.name like '" + tableLike + "'\n" +
                "order by o.name,c.colorder";

            SqlCommand command = new SqlCommand(strSql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds.Tables[0];
        }
        
        internal void Execute(string sql) {
            string[] strList = sql.Split(new string[] {" Go "}, StringSplitOptions.None);
            
            foreach (string s in strList)
                ExecuteBatch(s);

            //SqlCommand command = new SqlCommand(sql, connection);
            //command.ExecuteNonQuery();
        }

        private void ExecuteBatch(string sql) {

            if (sql.Substring(0, 3) == "Go ")
                sql = sql.Substring(3);

            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
