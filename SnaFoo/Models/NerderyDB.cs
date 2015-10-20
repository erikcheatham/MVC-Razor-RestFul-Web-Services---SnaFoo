using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SnaFoo.Models
{
    public class NerderyDBEntities : DbContext
    {
        public NerderyDBEntities()
            : base("name=NerderyDBEntities")
        {
        }
        public virtual DbSet<Suggestion> Suggestions { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
    }
}
