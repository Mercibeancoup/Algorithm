using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Algorithm.Models.DesignPattern.Creational
{

    #region 抽象工厂类
    /// <summary>
    /// 抽象工厂类，提供不同类型房子的接口
    /// </summary>
    public abstract class AbstractFactory
    {

        public abstract Roof CreateRoof();
        public abstract Floor CreateFloor();

        public abstract Window CreateWindow();

        public abstract Door CreateDoor();

    }

    #endregion


    #region 工厂实体类
    /// <summary>
    /// 欧式房子工厂，负责创建欧州风格房子
    /// </summary>
    public class EuropeanFactory : AbstractFactory
    {
        public override Roof CreateRoof()
        {
            return new EuropeanRoof();
        }

        public override Floor CreateFloor()
        {
            return new EuropeanFloor();
        }

        public override Window CreateWindow()
        {
            return new EuropeanWindow();

        }

        public override Door CreateDoor()
        {
            return new EuropeanDoor();
        }
    }

    /// <summary>
    /// 现代房子工厂，负责创建现代风格房子
    /// </summary>
    public class ModernFactory : AbstractFactory
    {
        public override Roof CreateRoof()
        {
            return new ModernRoof();
        }

        public override Floor CreateFloor()
        {
            return new ModernFloor();

        }

        public override Window CreateWindow()
        {
            return new ModernWindow();
        }

        public override Door CreateDoor()
        {
            return new ModernnDoor();
        }
    }


    #endregion


    #region 组成元素抽象类
    /// <summary>
    /// 房顶抽象类，子类的房顶必须继承该类
    /// </summary>
    public abstract class Roof
    {
        public abstract void Create();
    }



    /// <summary>
    /// 窗户抽象类，子类的窗户必须继承该类
    /// </summary>
    public abstract class Window
    {
        public abstract void Create();
    }

    /// <summary>
    /// 地板抽象类，子类的地板必须继承该类 
    /// </summary>
    public abstract class Floor
    {
        public abstract void Create();
    }

    /// <summary>
    ///  房门抽象类，子类的房门必须继承该类
    /// </summary>
    public abstract class Door
    {
        public abstract void Create();
    }
    #endregion

    #region 组成元素欧洲风格实体类

    public class EuropeanRoof : Roof
    {
        public override void Create()
        {
            Console.Write("创建欧式天花板");
        }
    }

    public class EuropeanWindow : Window
    {
        public override void Create()
        {
            Console.Write("创建欧式窗户");
        }
    }

    public class EuropeanDoor : Door
    {
        public override void Create()
        {
            Console.Write("创建欧式门");
        }
    }

    public class EuropeanFloor : Floor
    {
        public override void Create()
        {
            Console.Write("创建欧式地板");
        }
    }
    #endregion

    #region 组成元素现代风格实体类

    public class ModernRoof : Roof
    {
        public override void Create()
        {
            Console.Write("创建现代天花板");
        }
    }

    public class ModernWindow : Window
    {
        public override void Create()
        {
            Console.Write("创建现代窗户");
        }
    }

    public class ModernnDoor : Door
    {
        public override void Create()
        {
            Console.Write("创建现代门");
        }
    }

    public class ModernFloor : Floor
    {
        public override void Create()
        {
            Console.Write("创建现代地板");
        }
    }
    #endregion
}
