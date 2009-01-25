using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
