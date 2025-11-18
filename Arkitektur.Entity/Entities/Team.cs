using Arkitektur.Entity.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkitektur.Entity.Entities
{
    public class Team: BaseEntity
    {
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public IList<TeamSocial> TeamSocials { get; set; }
    }
}
