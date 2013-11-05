using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MyClass
    {
        public int MyInt { get; set; }
    }

    public class MyClassList : IEnumerable
    {
        private ArrayList _list = new ArrayList();
        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void Add(MyClass mc)
        {
            _list.Add(mc);
        }

        public MyClass this[int x]
        {
            get { return (MyClass)_list[x]; }
        }
    }

    public class MyList<T, T2, T3>
    {
        public void Add(T item)
        {
            
        }

        public T2 Remove()
        {
            
        }

        private T _myTField;

        public T MyTProp { get; set; }
    }

    public class Something
    {
        public void Add<T>(T item)
        {
            
        }

    }

    public interface IMyInterface<T>
    {
        T MyProp { get; set; }
    }

    public class MyImplementingClass<T> : IMyInterface<T>
    {
        public T MyProp { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //MyList<string, int, bool> s = new MyList<string, int, bool>();
           // s.Remove()
            
            Something s = new Something();
            s.Add(10);
            s.Add("hello");
            List<int> l = new List<int>();
            //PrintObject(10);
            //MyClass mc = new MyClass();
            //mc.MyInt = 100;
            //MyClassMethod(mc);
            //Console.WriteLine(mc.MyInt);
            //int x = 100;
            //MyIntMethod(x);
            //Console.WriteLine(x);

            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add("string");

            int x = (int)list[0];

            Console.ReadKey(true);
        }

        public static void PrintObject(object x)
        {
            Console.WriteLine(x);
        }

        public static void MyClassMethod(object mc)
        {
            MyClass mc2 = (MyClass)mc;
            mc2.MyInt++;
        }

        public static void MyIntMethod(object x)
        {
            int x2 = (int)x;
            x2++;
        }
    }
}
