using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ConnectedOfficeContext _context;
        private CategoriesRepository _categoriesRepository = new CategoriesRepository();


        public CategoriesController(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            var category = _categoriesRepository.GetAll();
            return View(category);
        }
        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }


    }
}
