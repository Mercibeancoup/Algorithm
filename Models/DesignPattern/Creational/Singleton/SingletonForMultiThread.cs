using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.Models.DesignPattern.Creational.Singleton
{
    /// <summary>
    /// 多线程下的单例模式
    /// </summary>
    public class SingletonForMultiThread
    {

        /// <summary>
        /// 定义静态变量来保存类的实例
        /// volatile:编译器在编译代码的时候会对代码的顺序进行微调，用volatile修饰保证了严格意义的顺序。一个定义为volatile的变量是说这变量可能会被意想不到地改变，这样，编译器就不会去假设这个变量的值了。精确地说就是，优化器在用到这个变量时必须每次都小心地重新读取这个变量的值，而不是使用保存在寄存器里的备份。
        /// </summary>
        private static volatile SingletonForMultiThread _uniqueInstance;

        //定义一个标识确保线程同步与
        private static readonly object locker = new object();

        //定义私有构造函数，使外界不能创建该实例
        private SingletonForMultiThread()
        {

        }

        ///// <summary>
        ///// 定义公有方法提供全局访问点，同时可以定义公有属性来提供全局访问点
        ///// 此方法在多线程时，每次都会lock，性能偏低。
        ///// 而当一个线程创建该实例之后，后面的线程此时只要判断_uniqueInstance==null为假即可
        ///// </summary>
        ///// <returns></returns>
        //public static SingletonForMultiThread GetInstance()
        //{
        //    // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
        //    // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
        //    // lock语句运行完之后（即线程运行完之后）会对该对象"解锁
        //    lock (locker)
        //    {
        //        _uniqueInstance = _uniqueInstance ?? (_uniqueInstance = new SingletonForMultiThread());

        //    }

        //    return _uniqueInstance;
        //}


        /// <summary>
        /// 优化方法，使用
        /// </summary>
        /// <returns></returns>
        public static SingletonForMultiThread GetInstance()
        {
            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁
            //双重锁定只需要一句判断
            if (_uniqueInstance == null)
            {
                lock (locker)
                {
                    _uniqueInstance = _uniqueInstance ?? (_uniqueInstance = new SingletonForMultiThread());
                }
            }

            return _uniqueInstance;
        }
    }
}
