using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> myList = new List<int>();
            //myList.Add(10);
            //myList.Add(12);
            //myList.Add(13);
            //myList.Add(14);

            //foreach (int x in myList)
            //{
            //    Console.WriteLine(x);
            //}

           
            //MyClass mc = new MyClass();
            //foreach (object x in mc)
            //{
            //    Console.WriteLine(x);
            //}

            MyRandomNumberGenerator gen = new MyRandomNumberGenerator(1, 100, 10);
            //foreach (int x in gen)
            //{
            //    Console.WriteLine(x);
            //}
            IEnumerator numerator = gen.GetEnumerator();
            while (numerator.MoveNext())
            {
                Console.WriteLine(numerator.Current);
            }

            Console.ReadKey(true);
        }
    }

    public class MyList : IEnumerable
    {

        private int[] array;

        public void Add(int x)
        {
            
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }
    }

    public class MyRandomNumberGenerator : IEnumerable, IEnumerator
    {
        private readonly int _min;
        private readonly int _max;
        private readonly int _amount;
        private int _currentIndex = 0;
        private Random rnd = new Random();

        public MyRandomNumberGenerator(int min, int max, int amount)
        {
            _min = min;
            _max = max;
            _amount = amount;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (_currentIndex == _amount)
            {
                return false;
            }

            this.Current = rnd.Next(_min, _max);
            _currentIndex++;
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public object Current { get; private set; }
    }

    public class MyClass : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            int[] myArray = new[] {1};
            return new MyClassEnumerator(myArray);
        }
    }

    public class MyClassEnumerator : IEnumerator
    {
        private readonly int[] _array;
        private int _currentIndex = 0;
        private object _current;

        public MyClassEnumerator(int[] array)
        {
            _array = array;
        }
        
        public bool MoveNext()
        {
            if (_currentIndex == _array.Length)
            {
                return false;
            }

            this._current = _array[_currentIndex++];
            return true;
        }

        public void Reset()
        {
            //throw new NotImplementedException();
        }

        public object Current
        {
            get
            {
                return _current;
            }
            
        }
    }
}
