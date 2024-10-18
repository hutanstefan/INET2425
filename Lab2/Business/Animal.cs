using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Business
{
    public abstract class Animal
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public abstract void MakeSound();
    }
}
