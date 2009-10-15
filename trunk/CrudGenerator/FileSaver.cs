using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CrudGenerator
{
    class FileSaver
    {
        /// <summary>
        /// Saves the specified content into the specified file name.
        /// </summary>
        /// <param name="fileName">this is the fully qualified file name</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public bool SaveFile(string fileName, string content, bool overwriteExisting) {
            bool success=false;
            //if folder doesn't exist build the tree
            FileInfo fi = new FileInfo(fileName);
            if (!fi.Directory.Exists)
                fi.Directory.Create();
            if (!overwriteExisting)
                fileName=GetNonConflictingFileName(fileName);
            using (TextWriter tw = new StreamWriter(fileName) ) { 
                tw.Write(content);
                success = true;
            }
            return success;
        }

        /// <summary>Checks if the file exists, and if it does, appends a number to the end of the file name
        /// </summary>
        /// <param name="fileName">Fully qualified file path</param>
        /// <returns></returns>
        public string GetNonConflictingFileName(string fileName) {
            FileInfo finfo = new FileInfo(fileName);
            string justFileName = finfo.Name.Replace(finfo.Extension, "");
            int i=2;
            while (finfo.Exists){
                fileName = string.Format("{0}\\{1}_{2}{3}",
                    finfo.Directory, justFileName, i, finfo.Extension);
                finfo = new FileInfo(fileName);
                i++;
            }
            return fileName;

        }
    }
}
