using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.Models.DesignPattern.Creational.Singleton
{
    /// <summary>
    /// 使用C#语言特性实现单例模式
    /// 使用内联初始化
    /// </summary>
    public sealed class SingletonNet
    {
        public static readonly SingletonNet Instance= new SingletonNet();

        static  SingletonNet()
        {
            
        }
    }
}
