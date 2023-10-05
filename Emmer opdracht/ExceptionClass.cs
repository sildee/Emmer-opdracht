using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emmer_opdracht
{
    public class ExceptionClass
    {
        int InputValue { get; }
        int MinValue { get; }
        int MaxValue { get; }
        //class to throw expections as requested in requirements.
        //class is also used to throw exceptions when content of container exceed capacity due to it also being an outofrange exception.
        //chose for a method rather than including the error message in the class constructor as requested because it's more efficient to only write the error message once.
        public ExceptionClass(int input, int min, int max)
        {
            InputValue = input;
            MinValue = min;
            MaxValue = max;
        }
        public void ThrowException(string name)
        {
            Console.WriteLine($"Input of {InputValue} for {name} is invalid! Input must be at least {MinValue} and at most {MaxValue}");
            Exception ex = new ArgumentOutOfRangeException(nameof(InputValue), "Capacity not possible.");
            throw (ex);
        }
    }
}
