using System;

namespace knightsTale.Models
{
    public class Castle
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImgUrl { get; set; }
        public String CreatorId { get; set; }
        public Profile Creator { get; set; }
    }

    public class CastleKnightsViewModel : Castle
    {
        public int LodgeId { get; set; }
    }
}