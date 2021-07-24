using System.Collections.Generic;
using System.Threading.Tasks;
using MicroPostService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MicroPostService.Data.Interfaces
{
    public interface IDataAccess
    {
        Task<ActionResult<IEnumerable<Post>>> ReadLatestPosts(string category, int count);
        Task<int> CreatePost(Post post);
        void InitDatabase(int countUsers, int countCategories);
        Task<int> AddUser(User user);
        Task<int> UpdateUser(User newUser);
        Task<int> DeleteUser(User user);
    }
}