using System.Threading.Tasks;

namespace MyCoyote
{
    public interface IDbCollection
    {
        Task<bool> CreateRow(string key, string value);

        Task<bool> DoesRowExist(string key);

        Task<string> GetRow(string key);

        Task<bool> DeleteRow(string key);
    }
}