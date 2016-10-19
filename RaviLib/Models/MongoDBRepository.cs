using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RaviLib.Models
{
    /// <summary>
    /// A MongoDB repository. Maps to a collection with the same name
    /// as type TEntity.
    /// </summary>
    /// <typeparam name="T">Entity type for this repository</typeparam>
    public class MongoDbRepository<T> where T : MongoRepository.Entity

    {

        private MongoRepository<T> entityRep;
        
        public MongoDbRepository()
        {
            entityRep = new MongoRepository<T>();
            //GetDatabase();
            //GetCollection();
           
        }

        public bool InsertModel(T entity)
        {
            return entityRep.Add(entity).Id != null;
        }

        public bool UpdateModel(T entity, IMongoQuery query, UpdateBuilder update)
        {
            if (entity.Id == null)
                return InsertModel(entity);
            return entityRep.Collection.Update(query, update).Ok;
        }

        public bool UpsertModel(T entity, IMongoQuery query, UpdateBuilder update)
        {
            return entityRep.Collection.Update(query, update, UpdateFlags.Upsert).Ok;
        }



        public void Delete(T entity)
        {
            entityRep.Delete(entity.Id);
        }


       
        public List<T>
            SearchFor(Expression<Func<T, bool>> predicate)
        {
            return entityRep
                .AsQueryable<T>()
                    .Where(predicate.Compile())
                        .ToList();
        }

        public List<T> FindAll()
        {
            return entityRep.AsQueryable<T>().ToList();
        }

        public List<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return entityRep.AsQueryable<T>().Where(predicate.Compile()).ToList();
        }

        public T FindOne(Expression<Func<T, bool>> predicate)
        {
            return entityRep.AsQueryable<T>().Where(predicate.Compile()).FirstOrDefault();
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return entityRep.Exists(predicate);
        }




        #region Private Helper Methods

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString;
        }

        private string GetDatabaseName()
        {
            return Path.GetFileName(ConfigurationManager.ConnectionStrings["MongoServerSettings"].ConnectionString);
        }

        //private void GetCollection()
        //{
        //    collection = database
        //        .GetCollection<TEntity>(typeof(TEntity).Name);
        //}
        #endregion
    }
}
