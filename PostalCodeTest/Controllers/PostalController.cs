using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostalCodeTest.Models;
using PostalCodeTest.Services;
using PostalCodeTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostalCodeTest.Controllers
{
    public class PostalController : Controller
    {
        protected IHttpContextAccessor contextAccessor;
        protected ApplicationDbContext context;
        private VillageService villageService;
        public PostalController(IHttpContextAccessor _contextAccessor,
            ApplicationDbContext _context, 
            VillageService _villageService)
        {
            contextAccessor = _contextAccessor;
            context = _context;
            villageService = _villageService;
        }

        public IActionResult Index()
        {
            List<VillageViewModel> viewModel = villageService.GetAll();
            return View(viewModel);
        }
    }
}
