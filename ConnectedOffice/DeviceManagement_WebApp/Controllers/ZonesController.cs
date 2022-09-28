using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Controllers
{
    public class ZonesController : Controller
    {
        private readonly ConnectedOfficeContext _context;
        private ZonesRepository _zonesRepository = new ZonesRepository();

        public ZonesController(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: Zones
        public async Task<IActionResult> Index()
        {
            var zone = _zonesRepository.GetAll();
            return View(zone);
        }

        // GET: Zones/Create
        public IActionResult Create()
        {
            return View();
        }


    }
}
