// See https://aka.ms/new-console-template for more information

using Lab2.Business;
using Lab2.Interface;

try
{
    Animal dog = new Dog("Rex", 5);
    Animal cat = new Cat("Tom", 2);
    Animal bird = new Bird("Tweety", 1);

    List<Animal> animals = new List<Animal> { dog, cat, bird };

    foreach (var animal in animals)
    {
        animal.MakeSound();
        if (animal is IMoveble moveble)
        {
            moveble.Move();
        }
    }
}
catch(Exception err)
{
    Console.WriteLine(err);
}



