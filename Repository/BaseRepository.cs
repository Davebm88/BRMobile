using BRMobile.Abstractions;
using SQLite;
using System.Linq.Expressions;

namespace BRMobile.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {
        private readonly SQLiteConnection _connection;

        public BaseRepository()
        {
            _connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            _connection.CreateTable<T>();
        }

        public string StatusMessage { get; set; }

        public void DeleteItem(T item)
        {
            try
            {
                _connection.Delete(item);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}.";
            }
        }

        public void Dispose()
        {
            _connection.Close();
        }

        public T GetItem(int id)
        {
            try
            {
                return _connection.Table<T>().FirstOrDefault(c => c.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}.";
                return null;
            }
        }

        public T GetItem(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _connection.Table<T>()
                    .Where(predicate)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}.";
                return null;
            }
        }

        public List<T> GetItems()
        {
            try
            {
                return _connection.Table<T>().ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}.";
                return null;
            }
        }

        public List<T> GetItems(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return _connection.Table<T>()
                    .Where(predicate)
                    .ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}.";
                return null;
            }
        }

        public void SaveItem(T item)
        {
            try
            {
                int result = 0;
                if (item.Id == 0)
                {
                    result = _connection.Insert(item);
                    StatusMessage = $"{result} row(s) added.";
                }
                else
                {
                    result = _connection.Update(item);
                    StatusMessage = $"{result} row(s) updated.";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error {ex.Message}.";
            }
        }
    }
}
