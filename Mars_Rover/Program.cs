
using Mars_Rover.Assets;
using Mars_Rover.Operations;

namespace Mars_Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            var roverMovements = new List<RoverCommand>();
            Plateau plateau = default;

            while (true)
            {
                try
                {
                    Console.Write("Plateau (5 5): ");
                    var plateauInput = Console.ReadLine();
                    plateau = new Plateau(plateauInput.ToUpper());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("------------------------------------");
                }
            }

            int order = 1;
            while (order <= 2)
            {
                Console.Write("Rover Position (0 0 N): ");
                var roverInput = Console.ReadLine();
                var rover = new Rover(roverInput.ToUpper());
                plateau.AddRover(rover);

                Console.Write("Rover Commands (NLM): ");
                var roverCommandInput = Console.ReadLine();
                var roverCommand = new RoverCommand(rover.Id, order, roverCommandInput.ToUpper());
                roverMovements.Add(roverCommand);
                order++;
            }

            var movementManager = new RoverMovementManager(plateau, roverMovements);
            movementManager.StartMovements();

            var writeOrder = 1;

            foreach (var rover in movementManager.Plateau.Rovers)
            {
                Console.WriteLine($"{rover.XPos} {rover.YPos} {rover.Direction}");
                writeOrder++;
            }            
            Console.ReadLine();
        }
    }
}