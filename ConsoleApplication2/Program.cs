using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyRandomGenerator rnd = new MyRandomGenerator(10, 1000, 10);
            IEnumerable<int> randomEvenNumbers = EnumerableHelpers.FindAll(rnd, MyPredicateMethod);
            foreach (int x in randomEvenNumbers)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey(true);
        }

        private static bool MyPredicateMethod(int x)
        {
            return x % 2 == 0;
        }
    }

    public static class EnumerableHelpers
    {
        public static IEnumerable<T> FindAll<T>(IEnumerable<T> items,
            Predicate<T> predicate)
        {
            List<T> list = new List<T>();
            foreach (T item in items)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }

            return list;
        }
    }

    public class MyRandomGenerator : IEnumerable<int>
    {
        private readonly int _min;
        private readonly int _max;
        private readonly int _amount;
        private Random rnd = new Random();

        public MyRandomGenerator(int min, int max, int amount)
        {
            _min = min;
            _max = max;
            _amount = amount;
        }

        public IEnumerator<int> GetEnumerator()
        {
            List<int> l = new List<int>();
            for (int i = 0; i < _amount; i++)
            {
                l.Add(rnd.Next(_min, _max));
            }

            return l.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
