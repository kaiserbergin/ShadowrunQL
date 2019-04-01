using System.Collections.Generic;

namespace ShadowQL.Models
{
    public partial class Metatype
    {
        public Metatype()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
