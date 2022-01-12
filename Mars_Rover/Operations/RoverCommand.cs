using Mars_Rover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Operations
{
    public class RoverCommand
    {
        public Guid RoverId { get; }
        public int RoverOrder { get; }
        public IList<Movement> MovementList { get; }

        public RoverCommand(Guid roverId, int roverOrder, string roverMovementInput)
        {
            RoverId = roverId;
            RoverOrder = roverOrder;
            MovementList = new List<Movement>();

            if (!string.IsNullOrEmpty(roverMovementInput))
            {
                var inputArray = roverMovementInput.ToCharArray();
                MovementList = inputArray.Select(input =>
                {
                    Enum.TryParse(input.ToString(), out Movement movement);
                    return movement;
                }).ToList();
            }
        }
    }
}
