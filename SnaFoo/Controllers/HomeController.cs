using Newtonsoft.Json;
using SnaFoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SnaFoo.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        //Move All Logic to Model
        private NerderyDBEntities db = new NerderyDBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            VotingViewModel votList = new VotingViewModel();

            //Make Web Service Request
            string serviceURL = "https://api-snacks.nerderylabs.com/v1/snacks/";
            var client = new RestClient(serviceURL, HttpVerb.GET);
            var json = client.MakeSnackRequest("");

            //Parse JSON Into PRoper Payload Structure
            List<RestDataModel.GetSnacks> payload = JsonConvert.DeserializeObject<List<RestDataModel.GetSnacks>>(json);

            //Separate Both Snack Lists
            votList.votOnlineList = payload.Where(x => x.optional == true);
            votList.alwaysPurchasedOnlineList = payload.Where(x => x.optional == false);

            //Legacy Internal DB Code
            //votList.sugList = (from a in db.Suggestions
            //                    select a).ToList();
            votList.votList = (from a in db.Votes
                               select a).ToList();

            //Get Cookie Info IF Applicable
            HttpCookie myCookie = HttpContext.Request.Cookies["votes"];
            votList = VotingViewLogic.GetCounterInfo(votList, myCookie);

            return View(votList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(VotingViewModel votes)
        {
            //Not Working To Capture Only Checked Box
            //if (votes.voteResults.Where(x => x.IsSelected == true) != null)
            //    votes.newCheckedBoxID = votes.voteResults.Where(x => x.IsSelected == true).Select(x => x.ID).First();
            //Build Internal DB Object
            Vote vote = new Vote();
            vote.SnackID = votes.newCheckedBoxID;
            vote.VotedOn = votes.VotedOn;

            //Save TO Internal DB On Success
            if (ModelState.IsValid)
            {
                db.Votes.Add(vote);
                db.SaveChanges();
            }
            //Get Cookie Info IF Applicable
            HttpCookie myCookie = HttpContext.Request.Cookies["votes"];
            votes.votedCnt = Convert.ToInt32(myCookie.Value) + 1;
            
            //Save Cookie - incremented votedCnt
            var voteCookie = new HttpCookie("votes", votes.votedCnt.ToString());
            DateTime begNextMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
            voteCookie.Expires = begNextMonth;
            HttpContext.Response.Cookies.Add(voteCookie);

            // Over-Voting Handled Without A Message
            return RedirectToAction("Index");
        }

        public ActionResult ShoppingList()
        {
            ShoppingListViewModel shopListVM = new ShoppingListViewModel();

            //Make Web Service Request
            string serviceURL = "https://api-snacks.nerderylabs.com/v1/snacks/";
            var client = new RestClient(serviceURL, HttpVerb.GET);
            var json = client.MakeSnackRequest("");

            //Parse JSON Into PRoper Payload Structure
            List<RestDataModel.GetSnacks> payload = JsonConvert.DeserializeObject<List<RestDataModel.GetSnacks>>(json);

            shopListVM.OnlineSnacksSuggested = payload.Where(x => x.optional == true);
            shopListVM.OnlineSnacksAlwaysPurchased = payload.Where(x => x.optional == false);

            shopListVM.votList = (from a in db.Votes
                                  select a).ToList();

            shopListVM = ShoppingListViewLogic.OrganizeShoppingList(shopListVM);

            return View(shopListVM);
        }

        [HttpGet]
        public ActionResult Suggestions()
        {
            SuggestionsViewModel sugVM = new SuggestionsViewModel();
            //LEgacy Internal DB Code
            //sugVM.sugList = (from a in db.Suggestions
            //                 select a).ToList();

            //Make Web Service Request
            string serviceURL = "https://api-snacks.nerderylabs.com/v1/snacks/";
            var client = new RestClient(serviceURL, HttpVerb.GET);
            var json = client.MakeSnackRequest("");

            //Parse JSON Into PRoper Payload Structure
            List<RestDataModel.GetSnacks> payload = JsonConvert.DeserializeObject<List<RestDataModel.GetSnacks>>(json);

            //Get Suggested Snack List
            sugVM.OnlineSuggestedSnackList = payload.Where(x => x.optional == true);

            // TODO: Error Handling - Show Error Messages For Items Already Purchased Or In The List
            return View(sugVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Suggestions(
            [Bind(Include = "Id,SnackName,SuggestedOn,SuggestionLocation")]
            SuggestionsViewModel suggestion)
        {
            //Legacy Internal DB Code
            //Build Internal DB Object
            //Suggestion sug = new Suggestion();
            //sug.SnackName = suggestion.SnackName;
            //sug.SuggestedOn = suggestion.SuggestedOn;
            //sug.SuggestionLocation = suggestion.SuggestionLocation;

            //Simple Struct For Data
            RestDataModel.AddSnack add = new RestDataModel.AddSnack();
            add.Name = suggestion.SnackName;
            add.Location = suggestion.SuggestionLocation;

            //Package Data For Transmission
            var dataToSend = JsonConvert.SerializeObject(add);

            //Add To Web Service
            string serviceURL = "https://api-snacks.nerderylabs.com/v1/snacks/";
            var client = new RestClient(serviceURL, HttpVerb.POST, dataToSend);
            var json = client.MakeSnackRequest("");

            //Legacy Internal DB Code
            //Save TO Internal DB On Success
            //if (ModelState.IsValid)
            //{
            //    db.Suggestions.Add(sug);
            //    db.SaveChanges();
            //    return RedirectToAction("Suggestions");
            //}
            //return View(suggestion);
            return RedirectToAction("Suggestions");
        }
    }
}
