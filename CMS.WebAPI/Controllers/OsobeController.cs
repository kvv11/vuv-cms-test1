using Microsoft.AspNetCore.Mvc;
using CMS.Service.Common;
using CMS.Model;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using CMS.Service;
using Microsoft.Extensions.Logging;

namespace CMS.WebApi.Controllers
{
    [Route("/[controller]")]
    [ApiController]

    public class OsobeController : ControllerBase
    {
        private readonly IService _service;
        private readonly ILogger<OsobeController> _logger;

        public OsobeController(IService service, ILogger<OsobeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OsobaDomain>> GetAll()
        {
            _logger.LogInformation("Fetching all osobe");
            var osobe = _service.PrikaziSveOsobe();
            return Ok(osobe);
        }

        [HttpGet("{id}")]
        public ActionResult<OsobaDomain> GetById(string id)
        {
            _logger.LogInformation($"Fetching osoba with id {id}");
            var osoba = _service.PrikaziOsobuPoId(id);
            if (osoba == null)
            {
                return NotFound();
            }
            return Ok(osoba);
        }
    }
}
