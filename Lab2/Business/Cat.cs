using Lab2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2.Business
{
    public class Cat : Animal, IMoveble
    {
        public Cat(string name, int age) : base(name, age)
        {
        }

        public void Move()
        {
            Console.WriteLine($"{Name} moves by Walking");
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Meow");
        }
    }
}
