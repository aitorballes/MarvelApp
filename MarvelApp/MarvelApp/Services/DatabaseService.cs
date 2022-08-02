using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using MarvelApp.Services.Interfaces;

namespace MarvelApp.Services
{
    public class DatabaseService : IDatabaseService
    {
        private string _dbPath;

        public void SetDatabasePath(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void UpsertElement<T>(T run)
        {
            using var db = new LiteDatabase(_dbPath);
            db.GetCollection<T>(typeof(T).Name.ToLower()).Upsert(run);
        }

        public IEnumerable<T> GetAllElements<T>()
        {
            using var db = new LiteDatabase(_dbPath);
            var allElements = db.GetCollection<T>(typeof(T).Name.ToLower())
                .FindAll().ToList();
            return allElements;
        }
        public T FindElement<T>(Func<T, bool> query)
        {
            using var db = new LiteDatabase(_dbPath);
            var element = db.GetCollection<T>(typeof(T).Name.ToLower())
                .FindOne(arg => query.Invoke(arg));

            return element;
        }

        public T FindById<T>(int? id)
        {
            using var db = new LiteDatabase(_dbPath);
            var element = db.GetCollection<T>(typeof(T).Name.ToLower())
                .FindById(id);

            return element;
        }
        
        public bool CheckIfExist<T>(int? id)
        {
            var element = FindById<T>(id);
            return element != null;
        }

        public bool DeleteById<T>(int? id)
        {
            using var db = new LiteDatabase(_dbPath);
            return db.GetCollection<T>(typeof(T).Name.ToLower()).Delete(id);
        }

        public void ClearAllElements<T>()
        {
            using var db = new LiteDatabase(_dbPath);
            db.DropCollection(typeof(T).Name.ToLower());
        }
    }
}