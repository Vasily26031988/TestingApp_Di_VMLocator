using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp_Di_VMLocator.Services
{
    public class Repository
    {
        private readonly LiteDatabase _database;
		private readonly EventBus _eventBus;

		public Repository(LiteDatabase database, EventBus eventBus)
        {
			
            _database = database;
			_eventBus = eventBus;
		}

        
        public Task Save<T>(T item)
        {
            GetCollection<T>().Upsert(item);
            _ = _eventBus.Publish(new OnSave<T>(item));
            return Task.CompletedTask;
        }
		public IEnumerable<T> FindAll<T>()
		{
            return GetCollection<T>().FindAll();
		}
        
		public Task Remove<T>(Guid id)
		{
			GetCollection<T>().Delete(id);
			_=_eventBus.Publish(new OnDelete<T>(id));
			return Task.CompletedTask;
		}
        
		private ILiteCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>();
        }

	}

    public class OnSave<T>: IEvent
	{
		public OnSave(T entity)
		{
			Entity = entity;
		}

		public T Entity { get; set; }
	}

	public class OnDelete<T> : IEvent
	{
		public OnDelete(Guid id)
		{
			Id = id;
		}

		public Guid Id { get; }
	}
}
