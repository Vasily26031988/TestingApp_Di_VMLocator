using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingApp_Di_VMLocator.Services
{
    public class Repository
    {
        private readonly LiteDatabase database;

        public Repository(LiteDatabase database)
        {
			this.database = database;
        }

        public void Save<T>(T item)
        {
            GetCollection<T>().Upsert(item);
        }
		public IEnumerable<T> FindAll<T>()
		{
            return GetCollection<T>().FindAll();
		}
        
        private ILiteCollection<T> GetCollection<T>()
        {
            return database.GetCollection<T>();
        }

	}
}
