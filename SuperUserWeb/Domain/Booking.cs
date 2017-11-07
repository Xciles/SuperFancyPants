using System;

namespace SuperUserWeb.Domain
{
    public class Booking : BaseDomain<int>
    {
        public string Description { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Room Room { get; set; }
        public string RoomId { get; set; }
        public UserAccount UserAccount { get; set; }
        public string UserAccountId { get; set; }
    }
}
