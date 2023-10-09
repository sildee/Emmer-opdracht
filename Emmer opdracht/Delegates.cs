using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emmer_opdracht
{
    public delegate void ContainerFullEvent(object sender, EventArgs e);
    public delegate void ContainerOverflowEvent(object sender, EventArgs e);
}
