using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContactManager.Data_Access_Layer
{
    public interface ISqliteConfig
    {
        //Location of where Sqlite database is created is platform specific, so each platform needs to override it with the proper 
        //implementation
        string Path { get; }
    }
}
