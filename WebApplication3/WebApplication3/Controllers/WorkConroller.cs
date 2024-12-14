using Itmytask.DAL.Interfaces;
using Itmytask.DAL.Repositories;
using Itmytask.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Itmytask.Controllers
{
    public class WorkController : Controller
    {
        private readonly IWorkRepository _workRepository;

        public WorkController(IWorkRepository workRepository)
        {
            _workRepository = workRepository;
        }


        [HttpGet] //атрибут на метод действия
        public async Task<IActionResult> GetWorks()
        {
        

            var work = new Work()
            {
                NameTask = "Восстановить ПК продавца",   //он зависит от work.cs в енампе (перечислении)
                TaskNumber = 3928,
                Description = "не запускается компьютер продавца",
                Customer = "Линии любви",
                AdressTask = "г. Орёл, ул. Революции, 38",
                Price = 1500,
                //StatusTask = "в работе",
                //DateCreate = DateTime.Now,
                TypeWork = 0
            };


            await _workRepository.Create(work);

            var work1 = new Work()
            {

                NameTask = "Подключить МФУ",   //он зависит от work.cs в енампе (перечислении)
                TaskNumber = 3029,
                Description = "Подключить новый МФУ на рабочее место заведующиго",
                Customer = "Линии любви",
                AdressTask = "г. Ульяновск, ул. Республики, 8",
                Price = 1900,
                //StatusTask = "в работе",
                //DateCreate = DateTime.Now,
                TypeWork = 0
            };


            await _workRepository.Create(work1);
       

            //var responseSelect = await _workRepository.GetAsyncSelect(); //убрал MY SQL
            var responseSelect = await _workRepository.Select();

            return View(responseSelect); //response будeт храниться писок объектов из нашей бд
            
        }
    }
}
