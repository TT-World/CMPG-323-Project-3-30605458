using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly ConnectedOfficeContext _context;
        private DevicesRepository _devicesRepository = new DevicesRepository();

        public DevicesController(ConnectedOfficeContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var zone = _devicesRepository.GetAll();
            return View(zone);
        }


    }
}
