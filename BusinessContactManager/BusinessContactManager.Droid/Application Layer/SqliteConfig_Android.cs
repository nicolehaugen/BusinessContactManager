using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BusinessContactManager.Data_Access_Layer;

namespace BusinessContactManager.Droid.Application_Layer
{
    internal class SqliteConfig_Android : ISqliteConfig
    {
        public string Path
        {
            get
            {
                var sqliteFilename = "ContactsApp.db3";
                var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
                var path = System.IO.Path.Combine (documentsPath, sqliteFilename);

                return path;
            }
        }
    }
}