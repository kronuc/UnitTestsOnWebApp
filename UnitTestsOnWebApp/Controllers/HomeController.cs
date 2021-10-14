using DataProject.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace UnitTestsOnWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, IUserRepository repository)
        {
            _logger = logger;
            _userRepository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_userRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Index(int start, int end)
        {
            
            return View(_userRepository.GetAll().Where(item => item.Id >= start && item.Id <= end).ToList());
        }
    }
}
