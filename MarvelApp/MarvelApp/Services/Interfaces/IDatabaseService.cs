using System;
using System.Collections.Generic;

namespace MarvelApp.Services.Interfaces
{
    public interface IDatabaseService
    {
        void SetDatabasePath(string dbPath);
        void UpsertElement<T>(T obj);
        IEnumerable<T> GetAllElements<T>();
        T FindElement<T>(Func<T, bool> query);
        T FindById<T>(int? id);  
        bool DeleteById<T>(int? id);
        bool CheckIfExist<T>(int? id);
        void ClearAllElements<T>();
    }
}