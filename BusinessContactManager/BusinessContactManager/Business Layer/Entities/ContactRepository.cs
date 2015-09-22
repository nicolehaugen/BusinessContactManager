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
    public class ContactRepository
    {
        ConnectionManager connMgr;

        public ContactRepository(ConnectionManager connectionManager)
        {
            connMgr = connectionManager;

            //Create the Contact table if it doesn't exist
            connMgr.Database.CreateEntityTable<Contact>();
        }

        public Contact GetContact(int id)
        {
            return connMgr.Database.GetEntity<Contact>(id);
        }

        public IList<Contact> GetContacts()
        {
            return new List<Contact>(connMgr.Database.GetEntities<Contact>());
        }

        public int SaveContact(Contact contact)
        {
            return connMgr.Database.SaveEntity<Contact>(contact);
        }

        public int DeleteContact(int id)
        {
            return connMgr.Database.DeleteEntity<Contact>(id);
        }

        public int DeleteAllContacts()
        {
            return connMgr.Database.DeleteAll<Contact>();
        }


    }
}
