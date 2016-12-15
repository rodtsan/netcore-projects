using Microsoft.AspNetCore.Mvc;
using PinoyCode.Data;
using PinoyCode.Data.Extensions;
using PinoyCode.Domain.Ads.Models;
using PinoyCode.Domain.Ads.Repositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PinoyCode.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IAdsBusinessObject _businessObject;
        private readonly IAdPostRepository _adPostRepository;
        public PostController(IAdsBusinessObject businessObject)
        {
            _businessObject = businessObject;
            _adPostRepository = _businessObject.GetAdPostRepository();
        }

        //[Route("classifieds/ads/list")]
        public IActionResult Index()
        {
            return View(_adPostRepository.GetPaged(new PagedList<AdPost>()
            {
                PageIndex = 0,
                PageSize = 10,
                OrderByPropertyName = "CreatedOnUtc"
            }));
        }

        //[Route("classifieds/ads/list")]
        [HttpPost]
        public IActionResult Index(IPaged paged)
        {
            return View(_adPostRepository.GetPaged(paged));
        }
    }
}
