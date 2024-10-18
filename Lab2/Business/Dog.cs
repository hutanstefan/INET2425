using Lab2.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Business
{
    public class Dog : Animal , IMoveble
    {
        public Dog(string name, int age) : base(name,age) 
        {
        }

        public void Move()
        {
            Console.WriteLine($"{Name} moves by Running");
        }
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} says: Bark");
        }
    }
}
