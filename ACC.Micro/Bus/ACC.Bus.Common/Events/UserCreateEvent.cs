using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACC.Bus.Common.Events
{
    public class UserCreateEvent:BaseEvent
    {
        public string Name { get; set; }
        public string Familly { get; set; }
        public string Mob { get; set; }
    }
}
