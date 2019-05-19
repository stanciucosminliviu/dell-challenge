using System;

namespace DellChallenge.C
{
    class Program
    {
        static void Main(string[] args)
        {
            // Please refactor the code below whilst taking into consideration the following aspects:
            //      1. clean coding
            //      2. naming standards
            //      3. code reusability, hence maintainability
            //
            //Explanation:
            //Renamed "myObject" class into "MyObject" based on naming standards.
            //Renamed "Do" into "DoSum" to be more clear.
            //Renamed "DoExtended" into "DoSum" as an overload of "DoSum".
            //Formated the second "DoSum" method.
            //
            //Renamed "_MyNewObject" into "myObject" based on naming conventions.
            //Renamed "obj1" into "sumOfTwo" to be more clear.
            //Renamed "num2" into "sumOfThree" to be more clear.
            //Put some spaces between declarations and actions.
           
            StartHere();
            Console.ReadKey();
        }

        private static void StartHere()
        {
            MyObject myObject = new MyObject();

            int sumOfTwo = myObject.DoSum(1, 3);
            int sumOfThree = myObject.DoSum(1, 3, 5);

            Console.WriteLine(sumOfTwo);
            Console.WriteLine(sumOfThree);
        }
    }

    class MyObject
    {
        public int DoSum(int a, int b)
        {
            return a + b;
        }

        public int DoSum(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
