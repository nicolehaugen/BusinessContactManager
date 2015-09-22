using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContactManager.Business_Layer
{
    public interface IBusinessEntity
    {
        //Empty interface simply used as a constraint the type for use with generics
        //Each entity stored in sqlite must derive from this interface

        [PrimaryKey, AutoIncrement]
        int Id { get; set; }
    }
}
