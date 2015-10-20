using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaFoo.Models
{
    public class ShoppingListViewModel
    {
        //Final List
        public IEnumerable<RestDataModel.GetSnacks> OnlineSnacksShoppingList { get; set; }

        //Helper Lists
        public IEnumerable<RestDataModel.GetSnacks> OnlineSnacksAlwaysPurchased { get; set; }
        public IEnumerable<RestDataModel.GetSnacks> OnlineSnacksSuggested { get; set; }
        public IEnumerable<Vote> votList { get; set; }
    }

    public class ShoppingListViewLogic
    {
        public static ShoppingListViewModel OrganizeShoppingList(ShoppingListViewModel shopListVM)
        {
            int cnt = shopListVM.OnlineSnacksAlwaysPurchased.Count();
            //Only Ten Snacks Can Be Chosen
            if (cnt >= 10)
            {
                shopListVM.OnlineSnacksShoppingList = shopListVM.OnlineSnacksAlwaysPurchased.Take(10);
            }
            else
            {
                int leftOver = 10 - cnt;
                if (leftOver > 1)
                {
                    // TODO: Join Voting Tables To Suggestions and Sort
                    //shopListVM.OnlineSnacksSuggested
                    shopListVM.OnlineSnacksShoppingList =
                                shopListVM.OnlineSnacksAlwaysPurchased.Take(cnt)
                                    .Concat(shopListVM.OnlineSnacksSuggested.Take(leftOver));
                }
                else
                {
                    //With only one record to add on, don't bother sorting
                    shopListVM.OnlineSnacksShoppingList =
                                shopListVM.OnlineSnacksAlwaysPurchased.Take(cnt)
                                    .Concat(shopListVM.OnlineSnacksSuggested.Take(leftOver));
                }
            }
            return shopListVM;
        }
    }
}
