using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperUserWeb.Business
{
    public interface IService<TEntity>
    {
        Task<IList<TEntity>> ToList();
    }

    public interface IRoom : IService<Domain.Room>
    {
        Task CreatePost(Domain.Room room);
    }

    public abstract class BaseService<TEntity> : IService<TEntity>
        where TEntity : class
    {
        private readonly DbContext _context;

        protected BaseService(DbContext content)
        {
            _context = content;
        }

        public async Task<IList<TEntity>> ToList()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }

    public class RoomExample : BaseService<Domain.Room>, IRoom
    {
        public RoomExample(DbContext content) : base(content)
        {
        }

        public Task CreatePost(Domain.Room T)
        {
            throw new NotImplementedException();
        }
    }
}
