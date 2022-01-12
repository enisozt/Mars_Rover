using Mars_Rover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Interfaces
{
    public interface IRover
    {
        public Guid Id { get; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Direction Direction { get; set; }
    }
}
