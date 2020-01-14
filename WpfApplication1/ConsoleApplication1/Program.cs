using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // Singleton Design Pattern // 어떤 객체가 한 번만 생성되도록 제한하는 방법
    // "GoF Design Pattern"
    public class Human
    {
        // class = 속성 + 메소드
        // public 지정 안하면 private
        public int age;
        static Human me = new Human();
        //Human me2 = new Human();
        public static Human GetSingleton()
        {
            Console.WriteLine("나");
            return me;
        }
        public Human() // 생성을 막는 법
        {
            Console.WriteLine("생성자");
        }

        ~Human()
        {
            Console.WriteLine("나 죽어유");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human h = Human.GetSingleton();
            Human h2 = Human.GetSingleton();
            Human h3 = new Human();
            Human h4 = new Human();
            Console.WriteLine();

        }
    }
}
