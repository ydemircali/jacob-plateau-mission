using System;
using System.Linq;

namespace JacobPlateauMission
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter plateau boundary (example:5 5) /n");
            var points = Console.ReadLine().Trim().Split(' ');
            JacobPlateau jacobPlateau = new() { X = Convert.ToInt32(points[0]), Y = Convert.ToInt32(points[1]) };

            while (true)
            {
               
                try
                {
                    Console.WriteLine("Enter rover position (example:1 2 N) /n");
                    var roverPositions = Console.ReadLine().Trim().Split(' ');
                    Rover rover = new()
                    {
                        X = Convert.ToInt32(roverPositions[0]),
                        Y = Convert.ToInt32(roverPositions[1]),
                        Direction = (Directions)Enum.Parse(typeof(Directions), roverPositions[2].ToUpper())
                    };

                    Console.WriteLine("Enter rover route (example:LMLMLMLMM) /n");
                    var missionRoute = Console.ReadLine().ToUpper();
                    rover.ExploreJacobPlateau(jacobPlateau, missionRoute);
                    Console.WriteLine($"Rover final position : {rover.X} {rover.Y} {rover.Direction}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Is the exploration mission over?(yes/no) /n");
                if (Console.ReadLine() == "yes")
                {
                    break;
                }
            }
        }
    }
}
