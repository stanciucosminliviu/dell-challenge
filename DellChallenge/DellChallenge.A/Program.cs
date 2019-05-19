using System;

namespace DellChallenge.A
{
    class Program
    {
        static void Main(string[] args)
        {
            // State and explain console output order.
            //
            //Console output:
            //A.A()
            //B.B()
            //A .Age
            //
            //Explanation:
            //The Main method will create a new object from B class. 
            //The B class inherits from A class, so the program will execute A's constructor and it will write "A.A()".
            //After that, B's constructor will be executed, so the program will write "B.B()" and will set Age variable to 0. 
            //In Age's set method is another "Console.WriteLine" method, so the program will write "A .Age".
            //
            new B();
            Console.ReadKey();
        }
    }

    class A
    {
        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                Console.WriteLine("A .Age");
            }
        }


        public A()
        {
            Console.WriteLine("A.A()");
        }
    }

    class B : A
    {
        public B()
        {
            Console.WriteLine("B.B()");
            Age = 0;
        }
    }
}
