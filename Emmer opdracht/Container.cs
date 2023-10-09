using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Emmer_opdracht
{
    public class Container
    {
        //create events
        public event ContainerFullEvent? ContainerFull;
        public event ContainerOverflowEvent? ContainerOverflow;
        //interface to simulate console input
        // create getter for capacity but not setter to make readonly after constructor
        public int Capacity { get; }
        // fully implement property so that we can check if the container is full or overflowing every time the value is set/updated.
        private int content;
        public int Content
        {
            get { return content; }
            set
            {
                content = value;
                WhenContainerFilled();
            }
        }
        public string Name { get; set; }
        // parent constructor
        public Container(int capacity)
        {
            Capacity = capacity;
            Name = "Container";

        }
        //method to change contents.
        public void ChangeContents(int value)
        {
            if (value > 0)
            {
                Console.WriteLine($"Adding {value} to contents of {Name}.");
                Content += value;
            }
            else
            {
                Console.WriteLine($"Removing {value} from contents of {Name}.");
                Content += value;
                if (Content < 0)
                {
                    var ex = new ExceptionClass(Content, 0, Capacity);
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
        protected virtual void WhenContainerFilled()
        {
            if(Content == Capacity)
            {
                ContainerFull?.Invoke(this, EventArgs.Empty);
            }

            if(Content > Capacity)
            {
                ContainerOverflow?.Invoke(this, EventArgs.Empty);
            }
        }

        public static void ContainerFullAction(object sender, EventArgs e)
        {
            // check if the sender object is a container, mostly so we can easily access the container properties for the console message.
            if (sender is Container container)
            {
                Console.WriteLine($"{container.Name} is full! {container.Content} out of {container.Capacity}.");
            }
        }

        public static void ContainerOverflowAction(object sender, EventArgs e)
        {
            if (sender is Container container)
            {
                int overflow = container.Content - container.Capacity;
                Console.WriteLine($"{container.Name} overflow! {container.Content} exceeds capacity {container.Capacity} by {overflow}");
                Console.WriteLine("Would you like to cancel the overflow? Y/N");
                string? input = Console.ReadLine();
                //various input scenarios. pressing y cancels overflowing process. n lets it proceed and asks for user input.
                //if user presses n but doesn't enter a number afterward, overflow gets cancelled.
                if (input == "Y" || input == "y")
                {
                    Console.WriteLine($"Overflow cancelled. Content is now {container.Content} and will exceed capacity.");
                }
                else if (input == "N" || input == "n")
                {
                    Console.WriteLine("Overflow will proceed. Enter the overflow amount:");
                    if (int.TryParse(Console.ReadLine(), out int value))
                    {
                        container.Content -= value;
                        Console.WriteLine($"Container has overflowed with the input amount and is now {container.Content} out of {container.Capacity}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Proceeding as if overflow was cancelled...");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Proceeding as if overflow was cancelled...");
                }
            }
        }
    }
}
