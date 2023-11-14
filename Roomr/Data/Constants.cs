using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roomr.Data
{
    public static class Constants
    {
        public const string DatabaseFilename = "SQLiteDB.db";

        public const SQLite.SQLiteOpenFlags Flags =
            //Open db in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            //Create if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            //Enable multi-threaded db access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
    }
}
