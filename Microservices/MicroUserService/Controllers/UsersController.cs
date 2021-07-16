using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroUserService.Data;
using MicroUserService.Entities;
using MicroUserService.Queues;
using Newtonsoft.Json;

namespace MicroUserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServiceContext _context;
        private readonly IQueueService _queueService;

        public UsersController(UserServiceContext context, IQueueService queueService)
        {
            _context = context;
            _queueService = queueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            await using var transaction = _context.Database.BeginTransaction();

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            _context.IntegrationEventOutbox.Add(new IntegrationEvent
            {
                Event = "user.update",
                Data = JsonConvert.SerializeObject(new
                {
                    id = user.ID,
                    newname = user.Name
                })
            });

            //_queueService.PublishToMessageQueue("user.update", JsonConvert.SerializeObject(new
            //{
            //    id = user.ID,
            //    newname = user.Name
            //}));

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await using var transaction = _context.Database.BeginTransaction();

            _context.User.Add(user);
            await _context.SaveChangesAsync();

            _context.IntegrationEventOutbox.Add(
                new IntegrationEvent
                {
                    Event = "user.add",
                    Data = JsonConvert.SerializeObject(new
                    {
                        id = user.ID,
                        name = user.Name
                    })
                });

            //_queueService.PublishToMessageQueue("user.add", JsonConvert.SerializeObject(new
            //{
            //    id = user.ID,
            //    name = user.Name
            //}));

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return CreatedAtAction("GetUser", new {id = user.ID}, user);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.ID == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            _queueService.PublishToMessageQueue("user.delete", JsonConvert.SerializeObject(new
            {
                id = user.ID,
                name = user.Name
            }));

            return NoContent();
        }
    }
}