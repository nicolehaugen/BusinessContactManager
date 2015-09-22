using System;
using System.Linq;
using System.Collections.Generic;
using SQLite;
using BusinessContactManager.Business_Layer;

namespace BusinessContactManager.DataAccessLayer
{
    /// <summary>
    /// TaskDatabase builds on SQLite.Net and represents a specific database, in our case, the Task DB.
    /// It contains methods for retrieval and persistance as well as db creation, all based on the 
    /// underlying ORM.
    /// </summary>
    internal class LocalDatabase
    {
        static object locker = new object();

        SQLiteConnection database;

        /// <summary>
        /// Initializes a new instance of the local database. 
        /// </summary>
        /// <param name='path'>
        /// Path.
        /// </param>
        internal LocalDatabase(SQLiteConnection conn)
        {
            database = conn;
        }

        /// <summary>
        /// Creates the table if it doesn't already exist.
        /// </summary>
        public int CreateEntityTable<T>() where T: IBusinessEntity, new()
        {
            return database.CreateTable<T>();
        }

        public IEnumerable<T> GetEntities<T>() where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return (from i in database.Table<T>() select i).ToList();
            }
        }

        public T GetEntity<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return database.Table<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        //public int InsertContact(Business_Layer.Entities.Contact c)
        //{
        //    database.Insert(c)
        //}

        public int SaveEntity<T>(T entity) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                
                if (entity.Id != 0)
                {
                    database.Update(entity);
                    return entity.Id;
                }
                else
                {
                    return database.Insert(entity);
                }
            }
        }

        public int DeleteEntity<T>(int id) where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return database.Delete<T>(id);
            }
        }

        public int DeleteAll<T>() where T : IBusinessEntity, new()
        {
            lock (locker)
            {
                return database.DeleteAll<T>();
            }
        }
    }
}