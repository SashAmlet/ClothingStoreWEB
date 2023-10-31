using ClothingStoreWEB.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothingStoreWEB.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private readonly MainContext _context;
        public ChartController(MainContext context) 
        {
            _context = context;
        }

        [HttpGet("GetItemsByCategories")]
        public JsonResult GetItemsByCategories()
        {
            List<object> catItems = new List<object>();
            catItems.Add(new[] { "Category", "Num of items" });
            foreach (var category in _context.Categories.ToList())
            {
                catItems.Add(new object[] { category.Title, _context.Items.Where(a=>a.CategoryId == category.Id).Count()});
            }
            return new JsonResult(catItems);
        }
    }
}
