using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JacobPlateauMission
{
    public class Rover
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }

        private readonly Dictionary<Directions, Directions> RotateRight = new()
        { 
            { Directions.N, Directions.E },
            { Directions.S, Directions.W },
            { Directions.E, Directions.S },
            { Directions.W, Directions.N },
        };

        private readonly Dictionary<Directions, Directions> RotateLeft = new()
        {
            { Directions.N, Directions.W },
            { Directions.S, Directions.E },
            { Directions.E, Directions.N },
            { Directions.W, Directions.S },
        };

        public void ExploreJacobPlateau(JacobPlateau jacobPlateau, string missionRoute)
        {
            foreach (var item in missionRoute)
            {
                if (item == 'M') // same direction
                {
                    MoveDirection();
                }
                else if (item == 'L')
                {
                    Direction = RotateLeft[Direction];
                }
                else if (item == 'R')
                {
                    Direction = RotateRight[Direction];
                }
                else
                {
                    throw new Exception(message: "InvalidRoute");
                }

                if (X < 0 || Y < 0 || X > jacobPlateau.X || Y > jacobPlateau.Y)
                {
                    Console.WriteLine($"Warning!.. Rover Crossed Plateau Borders : {X},{Y}");
                }
            }
        }

        void MoveDirection()
        {
            switch (Direction)
            {
                case Directions.N:
                    Y += 1;
                    break;
                case Directions.S:
                    Y -= 1;
                    break;
                case Directions.E:
                    X += 1;
                    break;
                case Directions.W:
                    X -= 1;
                    break;
                default:
                    break;
            }
        }
    }

    public enum Directions
    {
        N, S, E, W
    }

    public class JacobPlateau
    {
        public int X { get; set; }
        public int Y { get; set; }

    }
}
