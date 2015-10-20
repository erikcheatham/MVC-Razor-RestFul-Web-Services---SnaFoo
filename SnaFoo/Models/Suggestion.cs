using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SnaFoo.Models
{
    public class Suggestion
    {
        public int ID { get; set; }
        public string SnackName { get; set; }
        public DateTime SuggestedOn { get; set; }
        public string SuggestionLocation { get; set; }
    }
}
