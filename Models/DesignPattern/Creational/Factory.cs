using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.Models.DesignPattern.Creational
{

    #region 汽车抽象类
    /// <summary>
    /// 汽车抽象类
    /// </summary>
    public abstract class Car
    {
        public abstract void Go();
    }
    #endregion

    #region 汽车实体类
    /// <summary>
    /// 奥迪汽车
    /// </summary>
    public class AoDiCar : Car
    {
        public override void Go()
        {
            Console.WriteLine("奥迪汽车开始行驶了");
        }
    }
    /// <summary>
    /// 红旗汽车
    /// </summary>
    public class HongQiCar : Car
    {
        public override void Go()
        {
            Console.WriteLine("红旗汽车开始行驶了！");
        }
    }
    #endregion

    #region 抽象工厂类
    /// <summary>
    /// 抽象工厂类
    /// </summary>
    public abstract class Factory
    {
        public abstract Car CreateCar();
    }
    #endregion

    #region 实体工厂类
    /// <summary>
    /// 红旗汽车工厂类
    /// </summary>
    public class HongQiFactory : Factory
    {
        public override Car CreateCar()
        {
            return new HongQiCar();
        }
    }

    /// <summary>
    /// 奥迪汽车工厂类
    /// </summary>
    public class AoDiFactory : Factory
    {
        public override Car CreateCar()
        {
            return new AoDiCar();
        }
    }
    #endregion


}
