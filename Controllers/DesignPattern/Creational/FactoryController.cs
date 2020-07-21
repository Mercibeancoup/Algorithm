using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Algorithm.Models.DesignPattern.Creational;
using Microsoft.AspNetCore.Mvc;

namespace Algorithm.Controllers.DesignPattern.Creational
{
    public class FactoryController:Controller
    {

        public IActionResult Index()
        {
            //创建汽车工厂的连两个工厂
            Factory hongQiFactory = new HongQiFactory();
            Factory aoDiFactory = new AoDiFactory();


            //生产一辆红旗汽车
            Car hongqiCar = hongQiFactory.CreateCar();

            hongqiCar.Go();
            Car aodiCar = aoDiFactory.CreateCar();

            aodiCar.Go();

            return View();

        }


    }
}
