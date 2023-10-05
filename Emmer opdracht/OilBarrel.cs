using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emmer_opdracht
{
    public class OilBarrel : Container
    {
        //always set the capacity value in the parent constructor to be 159 so it cannot be changed.
        public OilBarrel(int content) : base(159)
        {
            Name = "Oil barrel";
            if (content >= 0 && content <= 159)
            {
                Content = content;
            }
            else
            {
                ExceptionClass ex = new ExceptionClass(content, 0, 159);
                ex.ThrowException("oil barrel");
            }
        }
    }
}
