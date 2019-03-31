using System;
using System.Collections.Generic;

namespace ShadowQL.Models
{
    public partial class Character
    {
        public long Id { get; set; }
        public long PlayerId { get; set; }
        public int? Metatype { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Handle { get; set; }
        public int? Age { get; set; }
        public int? Strength { get; set; }
        public int? Agility { get; set; }
        public int? Willpower { get; set; }
        public int? Logic { get; set; }
        public int? Charisma { get; set; }
        public int? Edge { get; set; }
        public bool? IsEmerged { get; set; }
        public bool? IsAwakened { get; set; }
        public decimal? Essence { get; set; }
        public int? Karma { get; set; }
        public int? KarmaBalance { get; set; }

        public virtual Metatype MetatypeNavigation { get; set; }
        public virtual Player Player { get; set; }
    }
}
