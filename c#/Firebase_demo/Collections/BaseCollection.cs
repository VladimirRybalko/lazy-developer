using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStorage
{
    public interface ICollection<T> 
        where T : DataModel
    {
        Task<T> GetById(string id);

        Task<IReadOnlyCollection<T>> GetByProperty(string propertyName, string value);

        Task<IReadOnlyCollection<T>> GetByProperty(string propertyName, double value);
                
        Task<T> Add(T entity);

        Task Update(T entity);

        Task Remove(string id);
    }


    internal abstract class BaseCollection<T> : ICollection<T>
        where T : DataModel
    {
        protected readonly FirebaseClient _db;
        protected string Name { get; } = typeof(T).Name;

        protected ChildQuery Collection => _db.Child(Name);

        protected BaseCollection(IDataClient client)
        {            
            _db = client.Db;            
        }
               
        public async Task<IReadOnlyCollection<T>> GetAll()
        {
            var objs = await Collection.OnceAsync<T>();
            return objs.ToModals().AsReadonly();            
        }

        public async Task<T> GetById(string id)
        {
            var obj = (await Collection.OrderByKey().EqualTo(id).OnceAsync<T>()).SingleOrDefault();            
            return obj.ToModal();
        }

        public async Task<IReadOnlyCollection<T>> GetByProperty(string propertyName, string value)
        {
            var objs = await Collection.OrderBy(propertyName).EqualTo(value).OnceAsync<T>();
            return objs.ToModals().AsReadonly();
        }

        public Task<IReadOnlyCollection<T>> GetByProperty(string propertyName, double value)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Add(T entity)
        {
            var obj = await Collection.PostAsync(entity);
            return obj.ToModal();
        }

        public async Task Remove(string id)
        {
            await Collection.OrderByKey().EqualTo(id).DeleteAsync();
        }

        public async Task Update(T entity)
        {
            await Collection.Child(entity.Id).PutAsync(entity);
        }
    }
}
