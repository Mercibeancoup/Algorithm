using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm.Models.DesignPattern.Transition;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Algorithm.Controllers.DesignPattern.Transition
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            Food food1 = FoodSimpleFactory.CreateFood("西红柿炒鸡蛋");
            food1.Cook();

            Food food2 = FoodSimpleFactory.CreateFood("土豆丝");
            food2.Cook();


            return View();
        }
    }
}
