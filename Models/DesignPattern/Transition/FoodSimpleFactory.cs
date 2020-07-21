using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.Models.DesignPattern.Transition
{
    /// <summary>
    /// 简单工厂，负责炒菜
    /// </summary>
    public  class FoodSimpleFactory
    {
        public static Food CreateFood(string type)
        {
            Food food = null;
            if (type.Equals("土豆丝"))
            {
                food= new ShreddedPorkWithPotatoes();
            }
            else if (type.Equals(" 西红柿炒鸡蛋"))
            {
                food =  new TomatoScrambleEggs();
            }

            return food;
        }
    }
}
