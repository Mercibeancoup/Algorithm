using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.Models.DesignPattern.Creational.Singleton
{
    /// <summary>
    /// 单线程的单例模式
    /// </summary>
    public sealed class SingletonForSingleThread
    {

        //定义一个静态变量来保存类的实例
        private static SingletonForSingleThread _uniqueInstance;

        //定义私有构造函数，使外界不能创建该类实例
        private SingletonForSingleThread()
        {
            
        }

        /// <summary>
        /// 定义公有方法提供全局访问点，同时可以定义公有属性来提供全局访问点
        /// </summary>
        /// <returns></returns>
        public static SingletonForSingleThread GetInstance()
        {
            //如果类的实例不存在则创建，否则直接返回
            return _uniqueInstance ?? (_uniqueInstance = new SingletonForSingleThread());
        }

    }
}
