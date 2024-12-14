using Itmytask.DAL.Interfaces;
using Itmytask.DAL.Repositories;
using Itmytask.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Itmytask.DAL;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using WebApplication3.Models;
using System.Diagnostics;
using WebApplication3.Models;

namespace Itmytask.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> UserHtml(int id)
        {
            //var responseSelect = await _userRepository.Select();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UserHtml()
        {

            var user1 = new Users()
            {
                Name = "Восстановить ПК продавца",   //он зависит от work.cs в енампе (перечислении)

                email = "не запускается компьютер продавца",
                password = "Линиилюбви",
                phone = "5465454",
                //Price = 1500,
                city = "ujhljаботе",
                //DateCreate = DateTime.Now,
                //TypeWork = TypeWork.Free
            };
            await _userRepository.Create(user1);
            var responseSelect = await _userRepository.Select();
            return View(responseSelect);
        }
    }
}
