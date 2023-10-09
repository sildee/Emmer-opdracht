using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emmer_opdracht
{
    public class RainBarrel : Container
    {
        //set allowed values for rain barrel.
        public enum RainBarrelCapacity
        {
            Value80 = 80,
            Value100 = 100,
            Value120 = 120,
        }
        // constructor for rain barrels where one of the enum values has to be called.
        public RainBarrel(int content, RainBarrelCapacity c) : base((int)c)
        {
            Name = "Rain barrel";
            if (content < 0 || content > Convert.ToInt32(c))
            {
                ExceptionClass ex = new ExceptionClass(content, 0, Convert.ToInt32(c));
                ex.ThrowException("rain barrel");
            }
            Content = content;
            //subscribe to events at the bottom of child constructors to prevent events proceeding before exceptions can be handled
            ContainerFull += ContainerFullAction;
            ContainerOverflow += ContainerOverflowAction;
        }
    }
}
