using System;

namespace DellChallenge.B
{
    class Program
    {
        static void Main(string[] args)
        {
            Species species = new Species();
            species.GetSpecies();
            Console.Read();

            // Given the classes and interface below, please constructor the proper hierarchy.
            // Feel free to refactor and restructure the classes/interface below.
            // (Hint: Not all species and Fly and/or Swim)
            //
            //Explanation:
            //Human class implements ISpecies interface. I am considering Human as a species who can swim without any help, but can't fly.
            //Fish class inherits from Human class and doesn't need any method override.
            //Bird class inherits from Fish, but overrides Swim() and Fly() methods.
        }
    }

    public interface ISpecies
    {
        void Eat();
        void Drink();
        void Fly();
        void Swim();
    }

    public class Species
    {
        public virtual void GetSpecies()
        {
            Console.WriteLine("Who am I?");

            Console.WriteLine();

            Console.WriteLine("I am a human.");
            Human human = new Human();
            human.Eat();
            human.Drink();
            human.Fly();
            human.Swim();

            Console.WriteLine();

            Console.WriteLine("I am a fish.");
            Fish fish = new Fish();
            fish.Eat();
            fish.Drink();
            fish.Fly();
            fish.Swim();

            Console.WriteLine();

            Console.WriteLine("I am a bird.");
            Bird bird = new Bird();
            bird.Eat();
            bird.Drink();
            bird.Fly();
            bird.Swim();

        }
    }

    public class Human : ISpecies
    {
       
        public void Drink()
        {
            Console.WriteLine("I should drink to live.");
        }

        public void Eat()
        {
            Console.WriteLine("I should eat to live.");
        }

        public virtual void Fly()
        {
            
            Console.WriteLine("I can't fly.");
        }

        public virtual void Swim()
        {
            Console.WriteLine("I can swim.");
        }
    }

    public class Fish : Human { }

    public class Bird : Fish
    {
        public override void Fly()
        {
            Console.WriteLine("I can fly.");
        }

        public override void Swim()
        {
            Console.WriteLine("I can't swim.");
        }

    }

    
}

