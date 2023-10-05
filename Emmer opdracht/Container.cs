using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emmer_opdracht
{
    public class Container
    {
        // create getter for capacity but not setter to make readonly after constructor
        public int Capacity { get; }
        public int Content { get; set; }
        public string Name;
        // parent constructor
        public Container(int capacity)
        {
            Capacity = capacity;
        }
        //method to change contents.
        public void ChangeContents(int value)
        {
            if (value > 0)
            {
                Console.WriteLine($"Adding {value} to contents of {Name}.");
                Content = Content + value;
            }
            else
            {
                Console.WriteLine($"Removing {value} from contents of {Name}.");
                Content = Content + value;
                if (Content < 0)
                {
                    ExceptionClass ex = new ExceptionClass(Content, 0, Capacity);
                    ex.ThrowException("container");

                }
            }
            Console.WriteLine($"Value is now {Content}");
        }
        // empty container.
        public void EmptyContents()
        {
            Content = 0;
            Console.WriteLine($"{Name} has been emptied. Value is now {Content}");
        }
        // print container details
        public void PrintContainer()
        {
            Console.WriteLine($"Container type is {Name}, Content is {Content} and the Capacity is {Capacity} ");
        }

    }
}
