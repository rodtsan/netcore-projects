using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PinoyCode.Domain.Ads.Repositories;
using PinoyCode.Data;
using PinoyCode.Data.Extensions;
using PinoyCode.Domain.Ads.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PinoyCode.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IAdsBusinessObject _businessObject;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(IAdsBusinessObject businessObject)
        {
            _businessObject = businessObject;
            _categoryRepository = _businessObject.GetCategoryRepository();
        }
        // GET: /<controller>/

        //[Route("classifieds/list")]
        public IActionResult Index()
        {
            return View(_categoryRepository.GetPaged(new PagedList<Category>()
            {
                PageIndex = 0,
                PageSize = 10,
                OrderByPropertyName = "ParentId"
            }));
        }

        //[Route("classifieds/list")]
        [HttpPost]
        public IActionResult Index(IPaged paged)
        {
            return View(_categoryRepository.GetPaged(paged));
        }

        public IActionResult Create(int? Id)
        {
            return View(new Category
            {
                ParentId = Id
            });
        }


        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Description,ParentId")] Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedOnUtc = DateTime.UtcNow;

                await _categoryRepository.AddAsync(model);

                await _businessObject.UnitOfWork.CommitAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            var model = await _categoryRepository.GetByIdAsync(Id);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Title,Description")] Category model)
        {
            if (ModelState.IsValid)
            {
                model.UpdatedOnUtc = DateTime.UtcNow;

                _categoryRepository.Update(model);

                await _businessObject.UnitOfWork.CommitAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int? Id)
        {
            var model = await _categoryRepository.GetByIdAsync(Id);
            if (model != null)
            {
                _categoryRepository.Delete(model);

                await _businessObject.UnitOfWork.CommitAsync();
            }

            return RedirectToAction("Index");
        }
    }

}
