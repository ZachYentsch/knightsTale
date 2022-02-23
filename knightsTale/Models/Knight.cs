using System;

namespace knightsTale.Models
{
    public class knights
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string WeaponType { get; set; }
        public string ImgUrl { get; set; }
        public string CreatorId { get; set; }

    }
}