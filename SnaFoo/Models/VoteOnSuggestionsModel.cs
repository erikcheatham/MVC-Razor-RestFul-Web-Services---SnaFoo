using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaFoo.Models
{
    public class VoteOnSuggestionsModel
    {
        public int ID { get; set; }
        public string SnackName { get; set; }
        public DateTime SuggestedOn { get; set; }
        public string SuggestionLocation { get; set; }
        public bool IsSelected { get; set; }
    }
}
