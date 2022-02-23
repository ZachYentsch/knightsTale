using System;
using System.Collections.Generic;

namespace knightsTale.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }

    public class Profile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class KnightCastleViewModel : Profile
    {
        public int SirId { get; set; }
    }
}