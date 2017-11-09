using System.ComponentModel.DataAnnotations;
using SuperUserWeb.Domain.Enums;

namespace SuperUserWeb.Models.RoomViewModels
{
    public class RoomViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Je mot iets invullen")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ESize Size { get; set; }
        public int SizeAsInt { get; set; }
    }
}
