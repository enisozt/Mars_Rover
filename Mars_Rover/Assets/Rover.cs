using Mars_Rover.Enums;
using Mars_Rover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Assets
{
    public class Rover : IRover
    {
        public Guid Id { get; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public Direction Direction { get; set; }

        public Rover(string roverInput)
        {
            Id = Guid.NewGuid();

            if (!string.IsNullOrEmpty(roverInput))
            {
                var inputArray = roverInput.Split(" ");
                if (inputArray.Length == 3)
                {
                    int.TryParse(inputArray[0], out int xPosition);
                    int.TryParse(inputArray[1], out int yPosition);
                    Enum.TryParse(inputArray[2], out Direction direction);

                    XPos = xPosition;
                    YPos = yPosition;
                    Direction = direction;
                }
                else
                {
                    throw new ArgumentException("Invalid Rover Position");
                }
            }
            else
            {
                throw new ArgumentException("Empty Rover Position Size Input!");
            }
        }
    }
}
