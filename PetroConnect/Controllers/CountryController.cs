using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetroConnect.API.Services;

namespace PetroConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _ICountryService;
        public CountryController(ICountryService countryService)
        {
            _ICountryService = countryService;
        }

    }
}