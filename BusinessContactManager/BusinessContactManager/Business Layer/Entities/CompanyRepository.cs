using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContactManager.Business_Layer.Entities
{
    /// <summary>
    /// Shared business logic can also be written here
    /// </summary>
    public class CompanyRepository
    {
        ConnectionManager connMgr;

        public CompanyRepository(ConnectionManager connectionManager)
        {
            connMgr = connectionManager;

            //Create the Company table if it doesn't exist
            connMgr.Database.CreateEntityTable<Company>();
        }

        public Company GetCompany(int id)
        {
            return connMgr.Database.GetEntity<Company>(id);
        }

        public IList<Company> GetCompanies()
        {
            return new List<Company>(connMgr.Database.GetEntities<Company>());
        }

        public int SaveCompany(Company company)
        {
            return connMgr.Database.SaveEntity<Company>(company);
        }

        public int DeleteCompany(int id)
        {
            return connMgr.Database.DeleteEntity<Company>(id);
        }

        public int DeleteAllCompanies()
        {
            return connMgr.Database.DeleteAll<Company>();
        }
    }
}
