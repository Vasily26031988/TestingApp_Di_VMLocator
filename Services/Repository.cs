using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingApp_Di_VMLocator.Services
{
    public class Repository
    {
        private readonly LiteDatabase _database;

        public Repository(LiteDatabase database)
        {
            _database=database;
        }

        public void Save<T>(T item)
        {
            GetCollection<T>().Upsert(item);
        }
        
        private ILiteCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>();
        }
    }
}
