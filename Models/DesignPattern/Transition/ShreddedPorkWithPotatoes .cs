using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.Models.DesignPattern.Transition
{
    public class ShreddedPorkWithPotatoes :Food
    {
        public override void Cook( )
        {
            Console.Write("番茄炒鸡蛋");
        }
    }
}
