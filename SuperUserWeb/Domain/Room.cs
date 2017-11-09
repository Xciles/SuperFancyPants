using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SuperUserWeb.Domain.Enums;

namespace SuperUserWeb.Domain
{
    public class Room : BaseDomain<string>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ESize Size { get; set; }

        public IList<Booking> Bookings { get; set; }
    }
}