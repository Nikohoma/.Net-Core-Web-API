using ECommerceAPI.Services;
using ECommerceAPI.Data;
using ECommerceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using EcommerceAPI.Services;

namespace ECommerceAPI.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult GetCatalogs()
        {
            var result = CatalogServices.GetAllCatalogs();
            return View(result);
        }
    }
}
