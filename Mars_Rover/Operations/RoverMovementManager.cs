using Mars_Rover.Assets;
using Mars_Rover.Enums;
using Mars_Rover.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Operations
{
    public class RoverMovementManager
    {
        public Plateau Plateau { get; private set; }
        public IList<RoverCommand> RoverCommands { get; }

        public RoverMovementManager(Plateau plateau, IList<RoverCommand> roverCommands)
        {
            Plateau = plateau;
            RoverCommands = roverCommands;
        }

        public void StartMovements()
        {
            foreach (var roverCommand in RoverCommands.OrderBy(r => r.RoverOrder))
            {
                var rover = Plateau.Rovers.FirstOrDefault(r => r.Id == roverCommand.RoverId);

                if (rover != null)
                {
                    rover = StartRoverMovements(rover, roverCommand.MovementList);
                    Plateau.LocateRover(rover.Id, rover.XPos, rover.YPos, rover.Direction);
                }
            }
        }

        private IRover StartRoverMovements(IRover rover, IList<Movement> movements)
        {
            foreach (var movement in movements)
            {
                switch (movement)
                {
                    case Movement.L:
                        rover.Direction = TurnLeft(rover.Direction);
                        break;
                    case Movement.R:
                        rover.Direction = TurnRight(rover.Direction);
                        break;
                    case Movement.M:
                        rover = MoveRover(rover);
                        break;
                }
            }

            return rover;
        }

        private Direction TurnLeft(Direction currentDirection)
        {
            var newDirection = Direction.N;

            switch (currentDirection)
            {
                case Direction.N:
                    newDirection = Direction.W;
                    break;
                case Direction.E:
                    newDirection = Direction.N;
                    break;
                case Direction.S:
                    newDirection = Direction.E;
                    break;
                case Direction.W:
                    newDirection = Direction.S;
                    break;
            }

            return newDirection;
        }

        private Direction TurnRight(Direction currentDirection)
        {
            var newDirection = Direction.N;

            switch (currentDirection)
            {
                case Direction.N:
                    newDirection = Direction.E;
                    break;
                case Direction.E:
                    newDirection = Direction.S;
                    break;
                case Direction.S:
                    newDirection = Direction.W;
                    break;
                case Direction.W:
                    newDirection = Direction.N;
                    break;
            }

            return newDirection;
        }

        private IRover MoveRover(IRover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N:
                    if (rover.YPos < Plateau.Height)
                    {
                        rover.YPos++;
                    }
                    break;
                case Direction.E:
                    if (rover.XPos < Plateau.Width)
                    {
                        rover.XPos++;
                    }
                    break;
                case Direction.S:
                    if (rover.YPos > 0)
                    {
                        rover.YPos--;
                    }
                    break;
                case Direction.W:
                    if (rover.XPos > 0)
                    {
                        rover.XPos--;
                    }
                    break;
            }

            return rover;
        }
    }
}
