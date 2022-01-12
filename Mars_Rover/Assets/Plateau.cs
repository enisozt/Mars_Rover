using Mars_Rover.Enums;
using Mars_Rover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Assets
{
    public class Plateau
    {
        public int Width { get; }
        public int Height { get; }
        public IList<IRover> Rovers { get; private set; }

        public Plateau(string plateauInput)
        {
            Rovers = new List<IRover>();
            if (!string.IsNullOrEmpty(plateauInput))
            {
                var sizeArray = plateauInput.Split(" ");
                if (sizeArray.Length == 2)
                {
                    int.TryParse(sizeArray[0], out int width);
                    int.TryParse(sizeArray[1], out int height);

                    if (width == 0 || height == 0)
                    {
                        throw new ArgumentException("Invalid Plateau Size!");
                    }
                    Width = width;
                    Height = height;
                }
                else
                {
                    throw new ArgumentException("Invalid Plateau Size Count!");
                }
            }
            else
            {
                throw new ArgumentException("Empty Plateau Size Input!");
            }
        }

        public void AddRover(IRover rover)
        {
            if (rover.XPos > Width)
            {
                throw new ArgumentException("X position is out of the plateau size!");
            }

            if (rover.YPos > Height)
            {
                throw new ArgumentException("Y position is out of the plateau size!");
            }
            Rovers.Add(rover);
        }

        public void LocateRover(Guid roverId, int xPos, int yPos, Direction direction)
        {
            var currentRover = Rovers.FirstOrDefault(r => r.Id == roverId);

            if (currentRover != null)
            {
                currentRover.XPos = xPos;
                currentRover.YPos = yPos;
                currentRover.Direction = direction;
            }
        }
    }
}
