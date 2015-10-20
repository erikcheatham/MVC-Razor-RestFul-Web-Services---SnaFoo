using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SnaFoo.Models
{
    public class VotingViewModel
    {
        public DateTime VotedOn { get { return DateTime.Now; } }
        public string voteCounter { get; set; }
        public string voteCounterCss { get; set; }
        public int newCheckedBoxID { get; set; }
        public int votedCnt { get; set; }

        //Internal DB Legacy Code
        public IEnumerable<Vote> votList { get; set; }
        public IEnumerable<Suggestion> sugList { get; set; }

        //Web Service Structures
        // TODO: Handle Blank Purchase Dates
        public IEnumerable<RestDataModel.GetSnacks> votOnlineList { get; set; }
        public IEnumerable<RestDataModel.GetSnacks> alwaysPurchasedOnlineList { get; set; }

        public IEnumerable<VoteOnSuggestionsModel> voteResults { get; set; }
        public VotingViewModel() { }
    }
    public class VotingViewLogic
    {
        public static VotingViewModel GetCounterInfo(VotingViewModel votList, HttpCookie myCookie)
        {
            if (myCookie == null)
            {
                votList.votedCnt = 0;
                votList.voteCounter = "3";
                votList.voteCounterCss = "counter counter_green";
            }
            else if (myCookie != null)
            {
                //Check number of votes in Cookie
                votList.votedCnt = Convert.ToInt32(myCookie.Value);
                if (votList.votedCnt == 1)
                {
                    votList.votedCnt = 1;
                    votList.voteCounter = "2";
                    votList.voteCounterCss = "counter counter_yellow";
                }
                else if (votList.votedCnt == 2)
                {
                    votList.votedCnt = 2;
                    votList.voteCounter = "1";
                    votList.voteCounterCss = "counter counter_red";
                }
                else if (votList.votedCnt == 3)
                {
                    votList.votedCnt = 3;
                    votList.voteCounter = "No Votes Remaining";
                    votList.voteCounterCss = "counter counter_red";
                }
            }
            //      //Replaced With Cookies
            //    //Calculate vote counter and css to return to view
            //    if (votList.votList.Count() == 1)
            //    {
            //        votList.voteCounter = "1";
            //        votList.voteCounterCss = "counter counter_green";
            //    }
            //    else if (votList.votList.Count() == 2)
            //    {
            //        votList.voteCounter = "2";
            //        votList.voteCounterCss = "counter counter_yellow";
            //    }
            //    else if (votList.votList.Count() == 3)
            //    {
            //        votList.voteCounter = "3";
            //        votList.voteCounterCss = "counter counter_red";
            //    }
            //    else
            //    {
            //        votList.voteCounter = "No Snacks Have Been Suggested!";
            //        votList.voteCounterCss = "counter counter_red";
            //    }
            return votList;
        }
    }
}
