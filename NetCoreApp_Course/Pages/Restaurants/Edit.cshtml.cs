using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetCoreApp_Course.Core;
using NetCoreApp_Course.Data;

namespace NetCoreApp_Course.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cusines { get; set; } 
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cusines = htmlHelper.GetEnumSelectList<CusineType>();


            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
    
            }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                //per impedire che vada persa l'info sulle cucine
                Cusines = htmlHelper.GetEnumSelectList<CusineType>();
                return Page();
            }

            if(Restaurant.Id > 0)
            {
                Restaurant = restaurantData.Update(Restaurant);

            }
            else
            {
                Restaurant = restaurantData.Add(Restaurant);

            }
            restaurantData.Commit();

            TempData["Message"] = "Restaurant saved";

            //get post redirect pattern
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id});
      

          
        }
    }
}
