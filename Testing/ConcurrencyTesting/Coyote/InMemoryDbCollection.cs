using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace MyCoyote
{
    public class InMemoryDbCollection : IDbCollection
    {
        private readonly ConcurrentDictionary<string, string> Collection;

        public InMemoryDbCollection()
        {
            Collection = new ConcurrentDictionary<string, string>();
        }

        public Task<bool> CreateRow(string key, string value)
        {
            return Task.Run(() =>
            {
                var success = Collection.TryAdd(key, value);

                if (!success)
                {
                    throw new RowAlreadyExistsException();
                }

                return true;
            });
        }

        public Task<bool> DoesRowExist(string key)
        {
            return Task.Run(() => Collection.ContainsKey(key));
        }

        public Task<string> GetRow(string key)
        {
            return Task.Run(() =>
            {
                var success = Collection.TryGetValue(key, out var value);

                if (!success)
                {
                    throw new RowNotFoundException();
                }

                return value;
            });
        }

        public Task<bool> DeleteRow(string key)
        {
            return Task.Run(() =>
            {
                var success = Collection.TryRemove(key, out _);
                if (!success)
                {
                    throw new RowNotFoundException();
                }

                return true;
            });
        }
    }

    public class RowNotFoundException : Exception
    {
    }

    public class RowAlreadyExistsException : Exception
    {
    }
}