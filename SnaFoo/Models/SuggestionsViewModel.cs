using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaFoo.Models
{
    public class SuggestionsViewModel
    {
        public int ID { get; set; }
        public string SnackName { get; set; }
        public DateTime SuggestedOn { get { return DateTime.Now; } }
        public string SuggestionLocation { get; set; }
        //public bool SuggestionVoted { get; set; }

        //Internal LEgacy DB Code
        public IEnumerable<Suggestion> sugList { get; set; }

        //Online Snack (Suggestion Data)
        public IEnumerable<RestDataModel.GetSnacks> OnlineSuggestedSnackList { get; set; } 
        public SuggestionsViewModel() { }
    }
}
