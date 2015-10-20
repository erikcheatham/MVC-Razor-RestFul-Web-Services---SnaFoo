using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SnaFoo.Models
{
    public class Vote
    {
        public int ID { get; set; }
        public int SnackID { get; set; }
        public DateTime VotedOn { get; set; }
    }
}
