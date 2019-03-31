using System;
using System.Collections.Generic;

namespace ShadowQL.Models
{
    public partial class Player
    {
        public Player()
        {
            Characters = new HashSet<Character>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
