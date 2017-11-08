using System.Threading.Tasks;

namespace SuperUserWeb.Business.Interfaces
{
    public interface IRoom
    {
        Task CreatePost(Domain.Room room);
    }
}