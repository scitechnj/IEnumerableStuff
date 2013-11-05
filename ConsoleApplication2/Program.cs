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
            //MyRandomGenerator rnd = new MyRandomGenerator(10, 1000, 10);
            //IEnumerable<int> randomEvenNumbers = EnumerableHelpers.FindAll(rnd, MyPredicateMethod);
            //foreach (int x in randomEvenNumbers)
            //{
            //    Console.WriteLine(x);
            //}

            List<Person> persons = new List<Person>();
            persons.Add(new Person
                {
                    FirstName = "Alex",
                    LastName = "Friedman",
                    Age = 31
                });
            persons.Add(new Person
            {
                FirstName = "John",
                LastName = "Doe",
                Age = 45
            });
            persons.Add(new Person
            {
                FirstName = "Mike",
                LastName = "Jones",
                Age = 65
            });

            IEnumerable<int> ages = EnumerableHelpers.Map<Person, int>(persons, MapMethod);
            foreach (int x in ages)
            {
                Console.WriteLine(x);
            }

            Console.ReadKey(true);
        }

        private static bool MyPredicateMethod(int x)
        {
            return x % 2 == 0;
        }

        private static int MapMethod(Person p)
        {
            return p.Age;
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

        public static T First<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            foreach (T item in items)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default(T);
        }

        public static IEnumerable<T1> Map<T, T1>(IEnumerable<T> items, Func<T, T1> func)
        {
            List<T1> result = new List<T1>();
            foreach (T item in items)
            {
                result.Add(func(item));
            }

            return result;
        }

    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
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
