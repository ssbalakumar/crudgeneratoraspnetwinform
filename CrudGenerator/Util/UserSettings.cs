using System;
using System.Diagnostics;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;

namespace CrudGenerator.Util
{
    /// <summary>
    /// Stores and restores user settings in the roaming user profile (via Isolated Storage).  This should be used for
    /// preferences and data that are not suitable for the config file.
    /// </summary>
    /// <remarks>Authored by Drew Noakes, February 2005.  Use freely, though keep this message intact and
    /// report any bugs to me.  I also appreciate seeing extensions, or simply hearing that you're using
    /// these classes.  You may not copyright this work, though may use it in commercial/copyrighted works.
    /// Happy coding.</remarks>
    /// <seealso cref="http://www.drewnoakes.com/code/util/UserSettings.html"/>
    public sealed class UserSettings
    {
        private const IsolatedStorageScope scope =
                IsolatedStorageScope.Roaming |
                IsolatedStorageScope.User |
                IsolatedStorageScope.Assembly |
                IsolatedStorageScope.Domain;

        private UserSettings()
        { }

        public static object RestoreObject(string filename)
        {
            // method should never throw an exception...
            Stream stream = null;
            try
            {
                stream = GetStreamForRead(filename);
                if (stream == null)
                    return null;
                return new BinaryFormatter().Deserialize(stream);
            }
            catch 
            {
                return null;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        public static void StoreObject(string filename, object obj)
        {
            if (obj == null)
            {
                DeleteFile(filename);
                return;
            }

            // method should never throw an exception...
            Stream stream = null;
            try
            {
                stream = GetStreamForWrite(filename);
                if (stream == null)
                    return;
                new BinaryFormatter().Serialize(stream, obj);
            }
            catch
            {
                return;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
        }

        private static IsolatedStorageFile GetIsolatedStore()
        {
            return IsolatedStorageFile.GetStore(scope, null, null);
        }

        public static Stream GetStreamForWrite(string filename)
        {
            IsolatedStorageFile storage = GetIsolatedStore();
            return new IsolatedStorageFileStream(filename, FileMode.Create, storage);
        }

        public static Stream GetStreamForRead(string filename)
        {
            IsolatedStorageFile storage = GetIsolatedStore();
            if (storage.GetFileNames(filename).Length == 0)
                return null;
            return new IsolatedStorageFileStream(filename, FileMode.OpenOrCreate, storage);
        }

        public static void DeleteFile(string fileName)
        {
            IsolatedStorageFile storage = GetIsolatedStore();
            if (storage.GetFileNames(fileName).Length != 0)
                storage.DeleteFile(fileName);
        }
    }
}