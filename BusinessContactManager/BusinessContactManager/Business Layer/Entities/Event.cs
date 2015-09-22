using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContactManager.Business_Layer.Entities
{
    public class Event : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
