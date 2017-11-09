using System.Threading.Tasks;
using SuperUserWeb.Models.RoomViewModels;

namespace SuperUserWeb.Business.Interfaces
{
    public interface IRoom
    {
        Task CreatePost(RoomViewModel room);
    }
}