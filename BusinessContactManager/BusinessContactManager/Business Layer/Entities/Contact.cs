using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContactManager.Business_Layer.Entities
{
    public class Contact : IBusinessEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Image { get; set; }

        public string JobTitle { get; set; }

        public string Notes { get; set; }

        public int CompanyId { get; set; }

        public int EventId { get; set; }

    }
}
