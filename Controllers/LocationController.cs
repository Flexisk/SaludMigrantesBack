using BackSaludMigrantes.Models.Context;
using BackSaludMigrantes.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BackSaludMigrantes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public LocationController(DataContext dbContext)
        {
            _dataContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Location> GetLocation()
        {
            var list = _dataContext.Location.ToList();
            return list;
        }
    }
}
