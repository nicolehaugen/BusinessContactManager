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
    public class EventRepository
    {
        ConnectionManager connMgr;

        public EventRepository(ConnectionManager connectionManager)
        {
            connMgr = connectionManager;

            //Create the Event table if it doesn't exist
            connMgr.Database.CreateEntityTable<Event>();
        }

        public Event GetEvent(int id)
        {
            return connMgr.Database.GetEntity<Event>(id);
        }

        public IList<Event> GetEvents()
        {
            return new List<Event>(connMgr.Database.GetEntities<Event>());
        }

        public int SaveEvent(Event evnt)
        {
            return connMgr.Database.SaveEntity<Event>(evnt);
        }

        public int DeleteEvent(int id)
        {
            return connMgr.Database.DeleteEntity<Event>(id);
        }

        public int DeleteAllEvents()
        {
            return connMgr.Database.DeleteAll<Event>();
        }
    }
}
